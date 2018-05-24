using System;
using System.Collections.Generic;
using Un4seen.Bass;
using System.Windows.Forms;

namespace Audio_Player
{
   public static class PlayMusic // класс плеер
    {
        public static int frequency = 44100; // частота дискретизацции
        private static bool initializationState; // состояние инициализации
        public static int musicStream; // канал
        public static int volume = 100; // громкость
        private static readonly List<int> plugins = new List<int>();

        // проверка инициализации
        public static bool CheckInitializationState(int freq)
        {
            if (!initializationState)
            {
                initializationState = Bass.BASS_Init(-1, frequency,BASSInit.BASS_DEVICE_DEFAULT,IntPtr.Zero);
                 if (initializationState)
                {
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bass_aac.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bass_ac3.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bass_ape.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bass_mpc.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bass_tta.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bassalac.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bassflac.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\bassopus.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\basswma.dll"));
                    plugins.Add(Bass.BASS_PluginLoad(Files.AppPath + @"plugins\basswv.dll"));
                }

                int errors = 0;
                for(int i = 0; i < plugins.Count; i ++)
                {
                    if (plugins[i] == 0)
                    {
                        errors++;
                    }
                }
                if (errors !=0)
                {
                    MessageBox.Show(errors + " плагина(ов) не было загружено");
                    errors = 0;
                }
            }
            return initializationState;
        }

        // остановка воспроизведения
        public static void Stop()
        {
            Bass.BASS_ChannelStop(musicStream);
            Bass.BASS_StreamFree(musicStream);
        }

        public static void Pause()
        {
            if(Bass.BASS_ChannelIsActive(musicStream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(musicStream);
            }

        }

        // получить длительность аудиофайла
        public static int getSongTime(int musicStream)
        {
            long timeBytes = Bass.BASS_ChannelGetLength(musicStream);
            double songTime = Bass.BASS_ChannelBytes2Seconds(musicStream, timeBytes);
            return (int)songTime;
        }

        //получить текущее время воспроизведения
        public static int getNowTimePosition(int stream)
        {
            long position = Bass.BASS_ChannelGetPosition(stream);
            double nowSongTime = Bass.BASS_ChannelBytes2Seconds(musicStream, position);
            return (int) nowSongTime;
        }

        // перемотка воспроизведения
        public static void scroolPosition(int stream, int position)
        {
            Bass.BASS_ChannelSetPosition(stream, (double)position);
        }

        // установка громкости
        public static void SetVolume(int stream, double vol)
        {
            volume = (int)vol;       
            Bass.BASS_ChannelSetAttribute(musicStream,BASSAttribute.BASS_ATTRIB_VOL,volume/100F);
        }

        // воспроизвести
        public static void Play(string fileName, int vol)
        {

            if (Bass.BASS_ChannelIsActive(musicStream) != BASSActive.BASS_ACTIVE_PAUSED)
            {
                Stop();
                if (CheckInitializationState(frequency))
                {
                    musicStream = Bass.BASS_StreamCreateFile(fileName, 0, 0, BASSFlag.BASS_DEFAULT);
                    if (musicStream != 0)
                    {
                        volume = 100;
                        Bass.BASS_ChannelSetAttribute(musicStream, BASSAttribute.BASS_ATTRIB_VOL, (float)volume / 100);
                        Bass.BASS_ChannelPlay(musicStream, false);
                    }
                }
            }
            else
            {
                Bass.BASS_ChannelPlay(musicStream, false);
            }

        }
    }
}
