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
    /// Логика взаимодействия для Customer_account.xaml
    /// </summary>
    public partial class Customer_account : Window
    {
        string sql_query = "SELECT Clients.ID_Client as [Код клиента],Clients.Surname as [Фамилия],Clients.Name as [Имя],Clients.Patronymic as [Отчество] ,sum(Services.The_cost + Rooms.The_cost) as [Полный счет] FROM Clients INNER JOIN Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN" +
            " [Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN Staff ON Clients.ID_Employee = Staff.ID_Employee" +
            " group by Clients.ID_Client,Clients.Surname,Clients.Name,Clients.Patronymic order by sum(Services.The_cost + Rooms.The_cost)";
        string db = "Staff";
        string sql_explore = "SELECT Clients.ID_Client as [Код клиента],Clients.Surname  as [Фамилия],Clients.Name  as [Имя],Clients.Patronymic  as [Отчество],sum(Services.The_cost + Rooms.The_cost) as [Полный счет] FROM Clients INNER JOIN Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN [Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN Staff ON Clients.ID_Employee = Staff.ID_Employee";
        string[] query_output_name = new string[] { "Clients.ID_Client", "Clients.Surname", "Clients.Name", "Clients.Patronymic" };

        public Customer_account()
        {
            InitializeComponent();
            Query_output Query = new Query_output();
            Query.Output(sql_query, db, table);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sql_explore = "SELECT Clients.ID_Client as [Код клиента],Clients.Surname  as [Фамилия],Clients.Name  as [Имя],Clients.Patronymic  as [Отчество],sum(Services.The_cost + Rooms.The_cost) as [Полный счет] FROM Clients INNER JOIN Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN [Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN Staff ON Clients.ID_Employee = Staff.ID_Employee";
            string[] explore = new string[] { "Код клиента", "Фамилия", "Имя", "Отчество" };
            if (explorer_textBox.Text == string.Empty)
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else if (explorer_box.ItemsSource == new TextBlock())
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else
            {

                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        sql_explore += " WHERE " + query_output_name[i] + " LIKE ";
                    }
                }
                if (explorer_textBox.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    sql_explore += string.Format("\'{0}\'", explorer_textBox.Text);
                }
                sql_explore += " group by Clients.ID_Client,Clients.Surname,Clients.Name,Clients.Patronymic order by sum(Services.The_cost + Rooms.The_cost)";
                Query_output Query = new Query_output();
                Query.Output(sql_explore, db, table);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string pathToFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.chm");

                Process.Start("\"" + pathToFile + "\"");
            }
        }

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Service_to_customers transition = new Service_to_customers();
            transition.Show();
            this.Close();
        }
    }
}
