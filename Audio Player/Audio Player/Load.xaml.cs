using System.Windows;

namespace Audio_Player
{
    public partial class Load : Window
    {
        public Load()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         
              DB myQuery = new DB(string.Format("Select NamePlayList from PL where PL.UserLogin = '{0}'", DB.login));
            myQuery.getDbPlayList();
            listBox.Items.Clear();
            foreach (string i in Files.allNamePl)
            {
                listBox.Items.Add(i);
            }
            Files.allNamePl.Clear();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB(string.Format("Select SongName, Singer,Album, mark, PPath  from Songs where Songs.NamePlayList = '{0}' and Songs.UserLogin  = '{1}' ", listBox.SelectedItem.ToString(), DB.login));
                db.loadPlayList();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Выберите плейлист для загрузки");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
           try
            {
                DB db = new DB(string.Format("DELETE FROM PL WHERE NamePlayList = '{0}' and PL.UserLogin = '{1}'", listBox.SelectedItem.ToString(),DB.login));
                db.deletePl();

                DB db2 = new DB(string.Format("DELETE FROM Songs WHERE NamePlayList = '{0}' and Songs.UserLogin = '{1}' ", listBox.SelectedItem.ToString(), DB.login));
                db.deleteSongsPl();

                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
            catch
            {
              System.Windows.Forms.MessageBox.Show("Выберите плейлист для удаления");
            }

        }
    }
}
