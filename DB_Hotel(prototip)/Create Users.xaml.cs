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
    /// Логика взаимодействия для Create_Users.xaml
    /// </summary>
    public partial class Create_Users : Window
    {
        public Create_Users()
        {
            InitializeComponent();
            login_object.Text = "Логин: " + buffer.login;
            login_role.Text = buffer.Role;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text) || string.IsNullOrEmpty(Pass.Password) || Role.SelectedIndex < 0)
            {
                MessageBox.Show("Пустые поля", "Уведомление");
            }
            else {
            string sql = "EXEC sp_helprotect Null,Null;";
            bool check = false;
            Connect conn = new Connect();
            conn.connection();

            SqlCommand command = new SqlCommand(sql, Connect.cnn); ;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               if(reader.GetValue(2).ToString() == login.Text)
               {
                    check = true;
                    break;
               }
               
            }
            conn.disconnection();

                if (check == true)
                {
                    MessageBox.Show("Пользователь существует", "Уведомление");
                }
                else
                {
                    sql = "CREATE LOGIN " + login.Text + " WITH PASSWORD = '" + Pass.Password + "'; " +
                        "CREATE USER " + login.Text + " FOR LOGIN " + login.Text + "; " +
                        "ALTER LOGIN " + login.Text + " WITH PASSWORD = '" + Pass.Password + "'; " +
                        "EXECUTE sp_addrolemember '" + Role.Text + "','" + login.Text + "'";
                    conn = new Connect();
                    conn.connection();
                    command = new SqlCommand(sql, Connect.cnn); ;
                    command.ExecuteNonQuery();
                    conn.disconnection();
                    if (Role.Text == "Admin_BD")
                    {
                        sql = "GRANT SELECT ON dbo.Staff to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Staff to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Staff to " + login.Text + "; " +
                              "GRANT delete ON dbo.Staff to " + login.Text + "; " +
                              "GRANT Update ON dbo.Staff to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT delete ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT Update ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT delete ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT Update ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Services to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Services to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Services to " + login.Text + "; " +
                              "GRANT delete ON dbo.Services to " + login.Text + "; " +
                              "GRANT Update ON dbo.Services to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT delete ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT Update ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Clients to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Clients to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Clients to " + login.Text + "; " +
                              "GRANT delete ON dbo.Clients to " + login.Text + "; " +
                              "GRANT Update ON dbo.Clients to " + login.Text + "; ";
                        conn.connection();
                        command = new SqlCommand(sql, Connect.cnn); ;
                        command.ExecuteNonQuery();
                        conn.disconnection();
                    }
                    if (Role.Text == "PR_Manager")
                    {
                        sql = "GRANT SELECT ON dbo.Staff to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Staff to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Staff to " + login.Text + "; " +
                              "GRANT delete ON dbo.Staff to " + login.Text + "; " +
                              "GRANT Update ON dbo.Staff to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT INSERT ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT ALTER ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT delete ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT Update ON dbo.Positionen to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Rooms to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Services to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.[Services provided to the client] to " + login.Text + "; " +
                              "GRANT SELECT ON dbo.Clients to " + login.Text + "; ";
                        conn.connection();
                        command = new SqlCommand(sql, Connect.cnn); ;
                        command.ExecuteNonQuery();
                        conn.disconnection();

                    }
                    if (Role.Text == "ST_Manager")
                    {
                        sql = "GRANT SELECT ON dbo.Staff to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Positionen to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Clients to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT INSERT ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT ALTER ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT delete ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT Update ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Services to " + login.Text + "; " +
                        "GRANT INSERT ON dbo.Services to " + login.Text + "; " +
                        "GRANT ALTER ON dbo.Services to " + login.Text + "; " +
                        "GRANT delete ON dbo.Services to " + login.Text + "; " +
                        "GRANT Update ON dbo.Services to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.[Services provided to the client] to " + login.Text + "; ";
                        conn.connection();
                        command = new SqlCommand(sql, Connect.cnn); ;
                        command.ExecuteNonQuery();
                        conn.disconnection();
                    }
                    if (Role.Text == "RP_Manager")
                    {
                        sql = "GRANT SELECT ON dbo.Clients to " + login.Text + "; " +
                        "GRANT INSERT ON dbo.Clients to " + login.Text + "; " +
                        "GRANT ALTER ON dbo.Clients to " + login.Text + "; " +
                        "GRANT delete ON dbo.Clients to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.[Services provided to the client] to " + login.Text + "; " +
                        "GRANT INSERT ON dbo.[Services provided to the client] to " + login.Text + "; " +
                        "GRANT ALTER ON dbo.[Services provided to the client] to " + login.Text + "; " +
                        "GRANT delete ON dbo.[Services provided to the client] to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Rooms to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Services to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Clients to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Staff to " + login.Text + "; " +
                        "GRANT SELECT ON dbo.Positionen to " + login.Text + "; ";
                        conn.connection();
                        command = new SqlCommand(sql, Connect.cnn); ;
                        command.ExecuteNonQuery();
                        conn.disconnection();

                    }
                    MessageBox.Show("Пользователь создан", "Уведомление");
                    login.Clear();
                    Pass.Clear();
                }
            }
        }

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (login_check.Text == string.Empty)
            {
                MessageBox.Show("Введите логин", "Уведомление");
            }
            else
            {
                string db = "staff";
                string sql = "EXEC sp_helprotect Null,Null";
                bool check = false;
                Connect conn = new Connect();
                conn.connection();
                SqlCommand command = new SqlCommand(sql, Connect.cnn); ;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(2).ToString() == login_check.Text)
                    {
                        check = true;
                        break;
                    }
                }
                conn.disconnection();
                if (check == true)
                {
                    sql = "EXEC sp_helprotect Null,'" + login_check.Text + "';";
                    Query_output Query = new Query_output();
                    Query.Output(sql, db, table);
                    login_check.Clear();
                }
                else
                {
                    MessageBox.Show("Профиль не существует", "Уведомление");
                }
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
    }
}
