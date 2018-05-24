using Un4seen.Bass.AddOn.Tags;   

namespace Audio_Player
{
    public class SongElements
    {
        public string Singer { get; set; } // исполнитель
        public string album { get; set; }  // альбом
        public string mark { get; set; }  // оценка
        public string song { get; set; }
        public string path;

        public SongElements(string sing, string al, string mar, string son)
        {
            Singer = sing;
            album = al;
            mark = mar;
            song = son;
        }

        public SongElements(string file, string m)
        {
            TAG_INFO infoAboutSong = new TAG_INFO();
            infoAboutSong = BassTags.BASS_TAG_GetFromFile(file);
            Singer = infoAboutSong.artist;
            album = infoAboutSong.album;
            song = infoAboutSong.title;
            mark = m;
            path = file;
        }

        public SongElements(string file)
        {
            TAG_INFO infoAboutSong = new TAG_INFO();
            infoAboutSong = BassTags.BASS_TAG_GetFromFile(file);
            Singer = infoAboutSong.artist;
            album = infoAboutSong.album;
            song = infoAboutSong.title;
            mark = "";
            path = file;
        }
    }
}
