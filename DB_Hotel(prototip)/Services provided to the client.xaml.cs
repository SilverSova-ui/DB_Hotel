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
    /// Логика взаимодействия для Services_provided_to_the_client.xaml
    /// </summary>
    public partial class Services_provided_to_the_client : Window
    {
        string sql_query = "select ID_Client as [Код клиента], ID_Services as [Код услуги], The_cost as [Стоимость] from dbo.[Services provided to the client]";
        string db = "[Services provided to the client]";
        string[] query_input_name = new string[] { "ID_Client","ID_Services","The_cost" };
        string[] query_change_name = new string[] { "ID_Services", "The_cost" };
        string[] t_box_name = new string[] {"T_ID_Clie" ,"T_ID_Serv", "T_Cost" };
        string[] query_output_name = new string[] {"ID_Client","ID_Services","The_cost" };
        string[] array_ru_name = new string[] { " as [Код клиента]", " as [Код услуги]", " as [Стоимость]"};

        public Services_provided_to_the_client()
        {
            InitializeComponent();
            login_object_input.Text = "Логин:" + buffer.login;
            login_object_output.Text = "Логин:" + buffer.login;
            login_object_сhange.Text = "Логин:" + buffer.login;
            login_role_input.Text = buffer.Role;
            login_role_output.Text = buffer.Role;
            login_role_change.Text = buffer.Role;
            Data_entry.Visibility = Visibility.Hidden;
            Data_output.Visibility = Visibility.Hidden;
            Data_editing.Visibility = Visibility.Hidden;
            Connect transition = new Connect();
            transition.Check(db, Data_entry, Data_output, Data_editing);
            Query_output Query = new Query_output();
            Query.Output(sql_query, db, table);
            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand("EXEC sp_helpuser '" + buffer.login + "'", Connect.cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sql = null;
                sql = reader["RoleName"].ToString();
                if (sql == "ST_Manager")
                {
                    Delet.Visibility = Visibility.Hidden;
                    Delet_Button.Visibility = Visibility.Hidden;
                    Delet_label.Visibility = Visibility.Hidden;
                    table.Margin = new Thickness(10, 136, 0, 0);
                }
            }
            conn.connection();
            command = new SqlCommand("select ID_Client,Surname,Name,Patronymic from dbo.Clients", Connect.cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ID_Client = reader["ID_Client"].ToString();
                string Surname = reader["Surname"].ToString();
                string Name = reader["Name"].ToString();
                string Patronymic = reader["Patronymic"].ToString();
                ComboBoxItem box_item = new ComboBoxItem();
                box_item.Content = ID_Client + " - " + Surname + " " + Name + " " + Patronymic;
                ID_Cli.Items.Add(box_item);
            }
            conn.disconnection();
            conn.connection();
            command = new SqlCommand("select ID_Services,Name,Description,The_cost from dbo.Services;", Connect.cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ID_Services = reader["ID_Services"].ToString();
                string Name = reader["Name"].ToString();
                string Description = reader["Description"].ToString();
                string The_cost = reader["The_cost"].ToString();
                ComboBoxItem box_item = new ComboBoxItem();
                box_item.Content = ID_Services + " - Наименование:" + Name + " Описание:" + Description + " Цена:" + The_cost;
                ID_Ser.Items.Add(box_item);
            }
            conn.disconnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_Cli, Check_ID_Ser, Check_Cost };
            Filters Fils = new Filters();
            Fils.Filter(array, array_check, query_output_name, array_ru_name, table, sql_query, db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] text_Box_input = new string[] { ID_Cli.Text.Split()[0], ID_Ser.Text.Split()[0], Cos.Text };
            string sql = "INSERT INTO dbo.[Services provided to the client] (";
            Query_input Query = new Query_input();
            Query.sql_build_input(sql, query_input_name, text_Box_input);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid_Change.Children.Clear();
            string[] content = new string[] {"Код клиента" ,"Код услуги", "Стоимость" };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cliet, Check_ID_Serv, Check_Costs };
            Filters Fils = new Filters();
            Fils.build_Change(Grid_Change, array_check, t_box_name, content);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE dbo.[Services provided to the client] SET ";
            string text_ID = " WHERE ID_Client = ";
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cliet, Check_ID_Serv, Check_Costs};
            for (int i = 0; i < array_check.Length; i++)
            {
                if (array_check[i].IsChecked == true)
                {
                    TextBox text_Box = (TextBox)Grid_Change.FindName(t_box_name[i]);
                    if (text_Box == null)
                    {
                        MessageBox.Show("Поле не были созданы и не были заполнены", "Уведомление");
                        break;
                    }
                    if (text_Box.Text.Trim() == string.Empty)
                    {

                    }
                    else
                    {
                        sql += query_input_name[i] + "=" + string.Format("\'{0}\'", text_Box.Text) + ",";
                    }
                }
            }
            if (sql.EndsWith(","))
            {
                sql = sql.Remove(sql.Length - 1);
            }
            sql += text_ID + Services_ID.Text + " and ";
            sql += "ID_Services = " + Client_ID.Text + ";";
            Query_input Query = new Query_input();
            Query.input(sql);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код клиента", "Код услуги", "Стоимость" };
            CheckBox[] array_check = new CheckBox[] { Check_Cli, Check_ID_Ser, Check_Cost };
            Filters Fils = new Filters();
            Fils.explorer_Filter(sql, sql_query, array, array_check, query_output_name, array_ru_name, explore, explorer_box, explorer_textBox, db, table);
        }

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }

        private void return_2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }

        private void return_3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string sql = "DELETE dbo." + db + " WHERE ID_Client =" + Delet.Text;
            Query_input Query = new Query_input();
            Query.delete(sql, Delet, db);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_Cli, Check_ID_Ser, Check_Cost };
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_10(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код клиента", "Код услуги", "Стоимость" };
            string[] explore = new string[] { "Код клиента", "Код услуги", "Стоимость" };
            string[] query_output_name = new string[] { "ID_Client", "ID_Services", "The_cost" };
            string[] array = new string[] { };
            string[] line = new string[] { };
            string sql_fil_end = " from dbo.[Services provided to the client]";
            string full_sql = "select ID_Client, ID_Services, The_cost from dbo.[Services provided to the client]";
            CheckBox[] array_check = new CheckBox[] { Check_Cli, Check_ID_Ser, Check_Cost };

            Query_input Query = new Query_input();
            Query.report(Field_name, query_output_name, array, line, explore, array_check, explorer_box, explorer_textBox, sql_fil_end, full_sql);
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
