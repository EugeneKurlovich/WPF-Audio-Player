using System.Windows;

namespace Audio_Player
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            DB db = new DB();
            db.checkReg(textBox.Text, passwordBox.Password);
            if (db.getErrors() == true)
            {
                db = new DB (string.Format("Insert Into 'Users' " + "(UserLogin, UserPassword) Values(@log, @pass)"));
                db.reg(textBox.Text, passwordBox.Password);
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
          Autorisation newWindowAuth = new Autorisation();
            newWindowAuth.Show();
            Reg.Close();
        }
    }
}
