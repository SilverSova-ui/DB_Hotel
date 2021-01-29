using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Hotel_prototip_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            login_object.Text = "Логин: " + buffer.login;
            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand("EXEC sp_helpuser '"+ buffer.login +"'", Connect.cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sql = null;
                sql = reader["RoleName"].ToString();
                if (sql == "Admin_BD")
                {
                    Hotel_room.Margin = new Thickness(560,362,0,0);
                    Hotel_room_text.Margin = new Thickness(555, 481, 0,0);
                    Personnel.Margin = new Thickness(82, 593, 0, 0);
                    Personnel_text.Margin = new Thickness(66, 686, 0, 0);
                    Service_Client.Margin = new Thickness(245, 594, 0, 0);
                    Service_Client_text.Margin = new Thickness(232, 686, 0, 0);
                    buffer.Role = "Право доступа: " + sql;
                    login_role.Text = buffer.Role;

                }
                if (sql == "PR_Manager")
                {
                    User.Visibility = Visibility.Hidden;
                    Create.Visibility = Visibility.Hidden;
                    Sql_query.Visibility = Visibility.Hidden;
                    Sql_query_Text.Visibility = Visibility.Hidden;
                    Service_Client.Visibility = Visibility.Hidden;
                    Service_Client_text.Visibility = Visibility.Hidden;
                    Hotel_room.Visibility = Visibility.Hidden;
                    Hotel_room_text.Visibility = Visibility.Hidden;
                    Hotel.Visibility = Visibility.Hidden;
                    Hotel_text.Visibility = Visibility.Hidden;
                    Service.Visibility = Visibility.Hidden;
                    Service_text.Visibility = Visibility.Hidden;
                    Service_Cli.Visibility = Visibility.Hidden;
                    Service_Cli_text.Visibility = Visibility.Hidden;
                    Cli.Visibility = Visibility.Hidden;
                    Cli_text.Visibility = Visibility.Hidden;
                    buffer.Role = "Право доступа: " + sql;
                    login_role.Text = buffer.Role;
                }
                if (sql == "ST_Manager")
                {
                    User.Visibility = Visibility.Hidden;
                    Create.Visibility = Visibility.Hidden;
                    staff.Visibility = Visibility.Hidden;
                    staff_text.Visibility = Visibility.Hidden;
                    job.Visibility = Visibility.Hidden;
                    job_text.Visibility = Visibility.Hidden;
                    Sql_query.Visibility = Visibility.Hidden;
                    Sql_query_Text.Visibility = Visibility.Hidden;
                    Personnel.Visibility = Visibility.Hidden;
                    Personnel_text.Visibility = Visibility.Hidden;
                    Service_Client.Visibility = Visibility.Hidden;
                    Service_Client_text.Visibility = Visibility.Hidden;
                    Hotel.Margin = new Thickness(250, 176, 0, 0);
                    Hotel_text.Margin = new Thickness(210, 286, 0, 0);
                    Service.Margin = new Thickness(400, 176, 0, 0);
                    Service_text.Margin = new Thickness(400, 286, 0, 0);
                    Service_Cli.Margin = new Thickness(540, 176, 0, 0);
                    Service_Cli_text.Margin = new Thickness(500, 286, 0, 0);
                    Cli.Margin = new Thickness(82, 362, 0, 0);
                    Cli_text.Margin = new Thickness(80, 480, 0, 0);
                    buffer.Role = "Право доступа: " + sql;
                    login_role.Text = buffer.Role;
                }
                if (sql == "RP_Manager")
                {
                    User.Visibility = Visibility.Hidden;
                    Create.Visibility = Visibility.Hidden;
                    Sql_query.Visibility = Visibility.Hidden;
                    Sql_query_Text.Visibility = Visibility.Hidden;
                    Personnel_text.Visibility = Visibility.Hidden;
                    job.Visibility = Visibility.Hidden;
                    job_text.Visibility = Visibility.Hidden;
                    Personnel.Visibility = Visibility.Hidden;
                    Personnel_text.Visibility = Visibility.Hidden;
                    staff.Visibility = Visibility.Hidden;
                    staff_text.Visibility = Visibility.Hidden;
                    Hotel.Margin = new Thickness(250, 176, 0, 0);
                    Hotel_text.Margin = new Thickness(210, 286, 0, 0);
                    Service.Margin = new Thickness(400, 176, 0, 0);
                    Service_text.Margin = new Thickness(400, 286, 0, 0);
                    Service_Cli.Margin = new Thickness(540, 176, 0, 0);
                    Service_Cli_text.Margin = new Thickness(500, 286, 0, 0);
                    Cli.Margin = new Thickness(82, 362, 0, 0);
                    Cli_text.Margin = new Thickness(80, 480, 0, 0);
                    Hotel_room.Margin = new Thickness(235, 364, 0, 0);
                    Hotel_room_text.Margin = new Thickness(235, 478, 0, 0);
                    buffer.Role = "Право доступа: " + sql;
                    login_role.Text = buffer.Role;
                }
            }
            conn.disconnection();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Staff transition = new Staff();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Staff transition = new Staff();
            transition.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Positionen transition = new Positionen();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Positionen transition = new Positionen();
            transition.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Rooms transition = new Rooms();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Rooms transition = new Rooms();
            transition.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            Services transition = new Services();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            Services transition = new Services();
            transition.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            Services_provided_to_the_client transition = new Services_provided_to_the_client();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            Services_provided_to_the_client transition = new Services_provided_to_the_client();
            transition.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            Clients transition = new Clients();
            transition.Show();
            this.Close();
        }


        private void image_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            Hotel_rooms transition = new Hotel_rooms();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            Hotel_rooms transition = new Hotel_rooms();
            transition.Show();
            this.Close();
        }

        private void Personnel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            personnel_department transition = new personnel_department();
            transition.Show();
            this.Close();
        }

        private void Personnel_text_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            personnel_department transition = new personnel_department();
            transition.Show();
            this.Close();
        }

        private void Service_Client_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Service_to_customers transition = new Service_to_customers();
            transition.Show();
            this.Close();
        }

        private void Service_Client_text_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Service_to_customers transition = new Service_to_customers();
            transition.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            Clients transition = new Clients();
            transition.Show();
            this.Close();
        }

        private void Sql_query_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SQL_Query transition = new SQL_Query();
            transition.Show();
            this.Close();
        }

        private void Sql_query_Text_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SQL_Query transition = new SQL_Query();
            transition.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_7(object sender, MouseButtonEventArgs e)
        {
            Choice_User transition = new Choice_User();
            transition.Show();
            this.Close();
        }

        private void Create_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Choice_User transition = new Choice_User();
            transition.Show();
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
