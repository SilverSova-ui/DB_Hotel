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
    /// <summary>
    /// Логика взаимодействия для Delete_Users.xaml
    /// </summary>
    public partial class Delete_Users : Window
    {
        Config_connection DB_Config = new Config_connection();
        public Delete_Users()
        {
            InitializeComponent();
            login_object.Text = "Логин: " + buffer.login;
            login_role.Text = buffer.Role;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "EXEC sp_helprotect Null,Null;";
            bool check = false;
            Connect conn = new Connect();
            conn.connection();

            SqlCommand command = new SqlCommand(sql, Connect.cnn); ;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetValue(2).ToString() == login.Text)
                {
                    check = true;
                    break;
                }

            }
            conn.disconnection();
            if (check == true)
            {
                if (MessageBox.Show("Вы хотите удалить профиль: " + login.Text + "?", "Внимание", MessageBoxButton.YesNo).ToString() == "Yes")
                {

                    sql = "ALTER LOGIN " + login.Text + " DISABLE;";
                    conn = new Connect();
                    conn.connection();
                    command = new SqlCommand(sql, Connect.cnn);
                    command.ExecuteNonQuery();
                    conn.disconnection();
                    conn.connection();
                    sql = "DROP USER " + login.Text + ";";
                    command = new SqlCommand(sql, Connect.cnn);
                    command.ExecuteNonQuery();
                    conn.disconnection();
                    conn.connection();
                    sql = "ALTER DATABASE " + DB_Config.DataBase  + " SET OFFLINE WITH ROLLBACK IMMEDIATE; ALTER DATABASE " + DB_Config.DataBase + " SET ONLINE";
                    command = new SqlCommand(sql, Connect.cnn);
                    command.ExecuteNonQuery();
                    conn.disconnection();
                    conn.connection();
                    sql = "DROP LOGIN " + login.Text + ";";
                    command = new SqlCommand(sql, Connect.cnn);
                    command.ExecuteNonQuery();
                    conn.disconnection();
                    login.Clear();
                    MessageBox.Show("Профиль удален", "Уведомление");
                }
                else
                {
                    MessageBox.Show("Профиль не удален", "Уведомление");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Уведомление");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string db = "staff";
            string sql = "EXEC sp_helprotect Null,Null;";
            Query_output Query = new Query_output();
            Query.Output(sql, db, table);
        }

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
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
