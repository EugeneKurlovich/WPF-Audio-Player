using System.Windows;

namespace Audio_Player
{

    public partial class Save : Window
    {
        public Save()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB(string.Format("Select NamePlayList from PL where UserLogin = '{0}'", DB.login));

            if (db.checkUserPL(textBox.Text) == true)
            {
                System.Windows.Forms.MessageBox.Show("У вас уже есть плейлист с таким именем!");
            }
            else
            {

                if (textBox.Text.Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Введите название плейлиста!!!");
                }
                else
                {
                    DB db2 = new DB("Insert Into 'PL'" + "(NamePlaylist,UserLogin) Values(@name, @log)");
                    db2.savePl(textBox.Text);
                    foreach (SongElements i in Files.PlayList)
                    {
                        DB db3 = new DB(string.Format("Insert Into 'Songs'" + "(SongName,Singer,Album,mark, NamePlayList,PPath, UserLogin) Values(@sn, @s, @al,@am,@np,@p,@ul)"));
                        db3.saveSongPl(textBox.Text, i);
                    }
                    textBox.Text = "";
                }
            }
        }
    }
}
