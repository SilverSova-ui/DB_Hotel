using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DB_Hotel_prototip_
{
 
    public static class buffer
    {
        public static string login;
        public static string password;
        public static string Role;
    }
    public partial class Authoriazation : Window
    {
        public Authoriazation()
        {
            InitializeComponent();


        }


        

    private void button_Click_1(object sender, RoutedEventArgs e)
        {
            String login = textBox1.Text;
            String password = passwordBox.Password;
            buffer.login = login;
            buffer.password = password;
            Connect conn = new Connect();
            conn.connection();
            if (Connect.cnn != null)
            {
                MessageBox.Show("Данные пользователя корректны", "Уведомление");
                MainWindow transition = new MainWindow();
                transition.Show();
                this.Close();
                conn.disconnection();
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string login = "Client";
            string password = "1234";
            buffer.login = login;
            buffer.password = password;
            Connect conn = new Connect();
            conn.connection();
            Main_Client transition = new Main_Client();
            transition.Show();
            conn.disconnection();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conection transition = new Conection();
            transition.Show();
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string pathToFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.chm");

                Process.Start("\""+ pathToFile + "\"");
            }
        }
    }
}
