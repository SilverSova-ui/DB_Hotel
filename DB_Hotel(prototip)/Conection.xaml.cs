using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для Conection.xaml
    /// </summary>
    public partial class Conection : Window
    {
        Config_connection DB_Config = new Config_connection();
        public Conection()
        {
            InitializeComponent();
            Server.Text = DB_Config.Server;
            BD.Text = DB_Config.DataBase;
        }

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB_Config.Server = Server.Text;
            DB_Config.DataBase = BD.Text;
            DB_Config.Save();
            MessageBox.Show("Данные настройки сохранены", "Уведомление");
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string pathToFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.chm");

                Process.Start("\"" + pathToFile + "\"");
            }
        }
    }
}
