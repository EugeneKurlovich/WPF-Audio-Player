using System.Windows;


namespace Audio_Player
{
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            DB db = new DB("SELECT UserLogin,UserPassword FROM Users");
            db.Authorization(textBox.Text, passwordBox.Password);

            if (db.getErrors() == true)
            {
                MainPlayer newWindowPlayer = new MainPlayer();
                DB.login = textBox.Text;
                newWindowPlayer.Show();
                auto.Close();
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Close();
        }
    }
}
