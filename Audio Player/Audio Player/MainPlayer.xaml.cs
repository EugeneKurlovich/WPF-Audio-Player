using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;


namespace Audio_Player
{
    public partial class MainPlayer : Window
    {
        public static RoutedCommand com1 = new RoutedCommand();
        public static RoutedCommand com = new RoutedCommand();
        public static RoutedCommand com2 = new RoutedCommand();
        public static RoutedCommand com3 = new RoutedCommand();
        public static RoutedCommand com4 = new RoutedCommand();

        int i = 0;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        Thread th;
        bool threadWorking = false;
        int ammount = 0;

        public void checkThreadWork()
        {
            if (threadWorking)
            {
                th.Abort();
                threadWorking = false;
            }
        }
        public void checkAmmount()
        {
            if (ammount == 1)
            {

                DrawingFractals counter = new DrawingFractals();
                th = new Thread(new ParameterizedThreadStart(Star));
                th.Start(counter);
                threadWorking = true;
            }
            else
            {
                th.Abort();
                DrawingFractals counter = new DrawingFractals();
                th = new Thread(new ParameterizedThreadStart(Star));
                th.Start(counter);
                threadWorking = true;
                ammount = 0;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            checkThreadWork();

            PlayMusic.Pause();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            ammount++;

            checkThreadWork();

            if (DataGridd.SelectedIndex != -1)
            {
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(1);

                int i = DataGridd.SelectedIndex;
                string current = Files.forPlay[i].ToString();
                Files.trackNumber = i;
                PlayMusic.Play(current, PlayMusic.volume);
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);

                timer.IsEnabled = true;
                timer.Start();

                checkAmmount();

            }
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            ammount++;
            checkThreadWork();

            checkAmmount();


            if (DataGridd.SelectedIndex != 0 && DataGridd.SelectedIndex != -1)
            {
                DataGridd.SelectedIndex--;
                PlayMusic.Play(Files.forPlay[DataGridd.SelectedIndex].ToString(), PlayMusic.volume);
                SongElements path = DataGridd.SelectedItem as SongElements;
                label3.Content = path.Singer;
                label7.Content = path.song;
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);
                timer.IsEnabled = true;
                timer.Start();

            }
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            ammount++;
            checkThreadWork();

            checkAmmount();

            int i = DataGridd.SelectedIndex;
            string current;
            if (i < Files.PlayList.Count - 1 && i != -1 && DataGridd.SelectedIndex != -1)
            {
                DataGridd.SelectedIndex++;
                current = Files.forPlay[++i].ToString();
                PlayMusic.Play(current, PlayMusic.volume);
                SongElements path = DataGridd.SelectedItem as SongElements;
                label3.Content = path.Singer;
                label7.Content = path.song;
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);
                timer.IsEnabled = true;
                timer.Start();

            }
        }

        private void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            checkThreadWork();
            PlayMusic.Stop();
            timer.Stop();
            slider.Value = 0;
            label.Content = "00:00:00";
            label1.Content = "00:00:00";
        }

        public MainPlayer()
        {
            InitializeComponent();
            PlayMusic.CheckInitializationState(PlayMusic.frequency);
        }

        public void Star(object obj)
        {
            DrawingFractals o = (DrawingFractals)obj;
            o.xc = 260;
            o.yc = 255;
            o.rad = 250;
   
            while  (PlayMusic.getNowTimePosition(PlayMusic.musicStream) != PlayMusic.getSongTime(PlayMusic.musicStream))
            {

                if (PlayMusic.getNowTimePosition(PlayMusic.musicStream) == PlayMusic.getSongTime(PlayMusic.musicStream))
                    Thread.Sleep(1000000000);
               

                Dispatcher.Invoke(() => {
                 
                    o.g = pb.CreateGraphics();
                    o.SetColor();
                });
                
               o.Draw(o.xc, o.yc, o.rad, o.g, o.p);               
            }

        }
 
        private void DataGridd_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as System.Windows.Forms.DataGrid;
            DataGridd.ItemsSource = Files.PlayList;
        }

        private void DataGridd_MouseRightButtonUp(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataGridd_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            string current = "";


            ammount++;
            checkThreadWork();

            try
            {
                SongElements path = DataGridd.SelectedItem as SongElements;
                label3.Content = path.Singer;
                label7.Content = path.song;
                int i = DataGridd.SelectedIndex;
                current = Files.forPlay[i].ToString();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(1);



                PlayMusic.Play(current, PlayMusic.volume);
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);

              

                timer.IsEnabled = true;
                timer.Start();
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Плейлист пуст!");
           
            }
            checkAmmount();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            ammount++;
            checkThreadWork();



            checkAmmount();


            if (DataGridd.SelectedIndex != 0 && DataGridd.SelectedIndex != -1)
            {
                DataGridd.SelectedIndex--;
                PlayMusic.Play(Files.forPlay[DataGridd.SelectedIndex].ToString(), PlayMusic.volume);
                SongElements path = DataGridd.SelectedItem as SongElements;
                label3.Content = path.Singer;
                label7.Content = path.song;
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);
                timer.IsEnabled = true;
                timer.Start();

            }

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            DataGridd.ItemsSource = null;
            DataGridd.ItemsSource = Files.PlayList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog song = new OpenFileDialog();
             song.Filter = song.Filter = "All Formats | *.mp3; *mp4; *.tta; *.alac; *.ogg; *.opus; *.ac3; *.ape; *.mpc; *.flac; *.wma; *.wv ";

            song.ShowDialog();

            string[] manySongs = song.FileNames;
               

            for (int i = 0; i < manySongs.Length; i++)
            {
                SongElements SE = new SongElements(manySongs[i]);
                 Files.PlayList.Add(SE);
                Files.forPlay.Add(manySongs[i]);
                DataGridd.ItemsSource = null;
                DataGridd.ItemsSource = Files.PlayList;
                
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Multiselect = true;
             a.Filter = "All Formats | *.mp3; *mp4; *.tta; *.alac; *.ogg; *.opus; *.ac3; *.ape; *.mpc; *.flac; *.wma; *.wv ";
            a.ShowDialog();
            string[] manySongs = a.FileNames;


            for (int i = 0; i < manySongs.Length; i++)
            {
                SongElements SE = new SongElements(manySongs[i]);
                Files.PlayList.Add(SE);
                Files.forPlay.Add(manySongs[i]);
                DataGridd.ItemsSource = null;
                DataGridd.ItemsSource = Files.PlayList; 
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
         Autorisation log = new Autorisation();
            PlayMusic.Stop();
            timer.Stop();
            slider.Value = 0;
            label.Content = "00:00:00";
            label1.Content = "00:00:00";
            DataGridd.ItemsSource = null;
            log.Show();
            Form1.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Load newWinsowLoad = new Load();
            newWinsowLoad.Show();
         

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
         
           System.Windows.Forms.MessageBox.Show("Audio Player " + "Version 1.0  Developer: Nikita Yaskovets");
        }
     
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ammount++;

            checkThreadWork();



            if (DataGridd.SelectedIndex !=-1)
            {
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(1);

                int i = DataGridd.SelectedIndex;
                string current = Files.forPlay[i].ToString();
                Files.trackNumber = i;
                PlayMusic.Play(current, PlayMusic.volume);
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);

                timer.IsEnabled = true;
                timer.Start();

                checkAmmount();

            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {         
            label.Content = TimeSpan.FromSeconds(PlayMusic.getNowTimePosition(PlayMusic.musicStream)).ToString();
            label4.Content = PlayMusic.volume.ToString();       
            label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
            slider.Value = PlayMusic.getNowTimePosition(PlayMusic.musicStream);
            slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);

            int nimb;


            try
            {

                if (TimeSpan.FromSeconds(PlayMusic.getNowTimePosition(PlayMusic.musicStream)) == TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)))
                {
                    nimb = DataGridd.SelectedIndex;
                    if (nimb == DataGridd.Items.Count - 1)
                    {
                        DataGridd.SelectedIndex = -1;

                        PlayMusic.Play(Files.forPlay[++DataGridd.SelectedIndex].ToString(), PlayMusic.volume);
                    }
                    else
                    {
                        PlayMusic.Play(Files.forPlay[++DataGridd.SelectedIndex].ToString(), PlayMusic.volume);

                    }

                    SongElements path = DataGridd.SelectedItem as SongElements;

                    label3.Content = path.Singer;
                    label7.Content = path.song;

                }
            }
            catch
            {
                PlayMusic.Stop();


            }
                

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            checkThreadWork();
            PlayMusic.Stop();
            timer.Stop();
            slider.Value = 0;
            label.Content = "00:00:00";
            label1.Content = "00:00:00";
  
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            checkThreadWork();

            PlayMusic.Pause();

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ammount++;
            checkThreadWork();

            checkAmmount();

            int i = DataGridd.SelectedIndex;
            string current ;
            if (i < Files.PlayList.Count-1 && i != -1 && DataGridd.SelectedIndex !=-1 )
            {
                DataGridd.SelectedIndex++;
                   current = Files.forPlay[++i].ToString();
                PlayMusic.Play(current, PlayMusic.volume);
                SongElements path = DataGridd.SelectedItem as SongElements;
                label3.Content = path.Singer;
                label7.Content = path.song;
                label1.Content = TimeSpan.FromSeconds(PlayMusic.getSongTime(PlayMusic.musicStream)).ToString();
                slider.Maximum = PlayMusic.getSongTime(PlayMusic.musicStream);
                timer.IsEnabled = true;
                timer.Start();

            }
        }

        private void slider1_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayMusic.SetVolume(PlayMusic.musicStream, slider1.Value);
        }

        private void slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayMusic.scroolPosition(PlayMusic.musicStream, (int)slider.Value);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {

            i++;
            if (i < 2)
            {
          
                PlayMusic.SetVolume(PlayMusic.musicStream, 0);
                slider1.Value = 0;
            }
            else
            {
                PlayMusic.SetVolume(PlayMusic.musicStream, 100);
                slider1.Value = 100;
                i = 0;
            }
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Files.PlayList[DataGridd.SelectedIndex].mark = stars.Value.ToString();
                DataGridd.ItemsSource = null;
                DataGridd.ItemsSource = Files.PlayList;
                

            }
              catch
            {
                System.Windows.Forms.MessageBox.Show("Выберите песню для оценивания");
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Files.PlayList.Clear();
            Files.forPlay.Clear();
            DataGridd.ItemsSource = Files.PlayList;
            DataGridd.ItemsSource = null;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataGridd.ItemsSource = null;
            DataGridd.ItemsSource = Files.PlayList;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Save obj = new Save();
            obj.Show();
        }

        private void button6_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Files.PlayList.RemoveAt(DataGridd.SelectedIndex);
                Files.forPlay.RemoveAt(DataGridd.SelectedIndex);
                DataGridd.SelectedItems.Clear();
                DataGridd.ItemsSource = null;
                DataGridd.ItemsSource = Files.PlayList;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Выберите трек для удаления !!!");
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
    }





