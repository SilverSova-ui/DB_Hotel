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
    /// Логика взаимодействия для Main_Client.xaml
    /// </summary>
    public partial class Main_Client : Window
    {
        string sql_query_services = "Select Name as [Наименование сервиса], Description as [Описание сервиса], The_cost as [Стоимость сервиса] from dbo.Services";
        string db_services = "Services";
        string sql_query_rooms = "select Name as [Наименование номера],Capacity as [Вместимость номера],Description as [Описание номера],The_cost as [Стоимость номера] from dbo.Rooms";
        string db_rooms = "Rooms";
        string[] query_output_services_name = new string[] {"Name", "Description", "The_cost" };
        string[] query_output_rooms_name = new string[] { "Name", "Capacity", "Description", "The_cost" };
        public Main_Client()
        {
            InitializeComponent();
            login_object.Text = "Логин:" + buffer.login;
            Query_output Query = new Query_output();
            Query.Output(sql_query_rooms, db_rooms, table_rooms);
            Query.Output(sql_query_services, db_services, table_services);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql_services = "Select Name as [Наименование], Description as [Описание], The_cost as [Стоимость] from dbo." + db_services;
            string sql_rooms = "select Name as [Наименование номера],Capacity as [Вместимость номера],Description as [Описание номера],The_cost as [Стоимость номера] from dbo." + db_rooms;
            string[] explore_services = new string[] {"Наименование сервиса", "Описание сервиса", "Стоимость сервиса","" };
            string[] explore_rooms = new string[] { "Наименование номера", "Вместимость номера", "Описание номера", "Стоимость номера" };
            if (explorer_textBox.Text == string.Empty)
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else
            {
                for (int i = 0; i < explore_rooms.Length; i++)
                {
                    if (explorer_box.Text == explore_services[i])
                    {
                        sql_services += " WHERE " + query_output_services_name[i] + " LIKE ";
                    }
                    if (explorer_box.Text == explore_rooms[i])
                    {
                        sql_rooms += " WHERE " + query_output_rooms_name[i] + " LIKE ";
                    }
                }
                sql_services += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                sql_rooms += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                for (int i = 0; i < explore_rooms.Length; i++)
                {
                    if (explorer_box.Text == explore_services[i])
                    {
                        explorer_textBox.Clear();
                        Query_output Query = new Query_output();
                        Query.Output(sql_services, db_services, table_services);
                    }
                    if (explorer_box.Text == explore_rooms[i])
                    {
                        explorer_textBox.Clear();
                        Query_output Query = new Query_output();
                        Query.Output(sql_rooms, db_rooms, table_rooms);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Query_output Query = new Query_output();
            Query.Output(sql_query_rooms, db_rooms, table_rooms);
            Query.Output(sql_query_services, db_services, table_services);
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
