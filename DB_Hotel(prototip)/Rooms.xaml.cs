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
    /// Логика взаимодействия для Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        string sql_query = "select ID_Numbers as [Код номера],ID_Employee as [Код сотрудника],Name as [Наименование],Capacity as [Вместимость],Description as [Описание],The_cost as [Стоимость] from dbo.Rooms";
        string db = "Rooms";
        string[] query_input_name = new string[] {"ID_Employee", "Name", "Capacity", "Description", "The_cost" };
        string[] t_box_name = new string[] {"ID_Employ", "Names", "Capacitys", "De", "The" };
        string[] query_output_name = new string[] {"ID_Numbers","ID_Employee", "Name" , "Capacity", "Description", "The_cost" };
        string[] array_ru_name = new string[] {" as [Код номера]"," as [Код сотрудника]"," as [Наименование]"," as [Вместимость]"," as [Описание]"," as [Стоимость]" };


        public Rooms()
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
                if (sql == "RP_Manager")
                {
                    Delet.Visibility = Visibility.Hidden;
                    Delet_Button.Visibility = Visibility.Hidden;
                    Delet_label.Visibility = Visibility.Hidden;
                    table.Margin = new Thickness(10, 136, 0, 0);
                }
            }

            conn.connection();
            command = new SqlCommand("select ID_Employee,Surname,Name,Patronymic,Job_title FROM Staff INNER JOIN " +
                "Positionen ON Staff.ID_Position = Positionen.ID_Position", Connect.cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ID_Employee = reader["ID_Employee"].ToString();
                string Surname = reader["Surname"].ToString();
                string Name = reader["Name"].ToString();
                string Patronymic = reader["Patronymic"].ToString();
                string Job_title = reader["Job_title"].ToString();
                ComboBoxItem box_item = new ComboBoxItem();
                box_item.Content = ID_Employee + " - " + Job_title + " " + Surname + " " + Name + " " + Patronymic;
                ID_EMP.Items.Add(box_item);
            }
            conn.disconnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Num, Check_ID_Emp, Check_Names, Check_Capa, Check_Descr, Check_Cos };
            Filters Fils = new Filters();
            Fils.Filter(array, array_check, query_output_name, array_ru_name, table, sql_query, db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] text_Box_input = new string[] { ID_EMP.Text.Split()[0], Nam.Text,Capac.Text,Descr.Text,Cost.Text};
            string sql = "INSERT INTO dbo.Rooms (";
            Query_input Query = new Query_input();
            Query.sql_build_input(sql, query_input_name, text_Box_input);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid_Change.Children.Clear();
            string[] content = new string[] {"Код сотрудника", "Наименование", "Вместимость", "Описание", "Стоимость"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emplo, Check_Name, Check_Capaci, Check_Descript, Check_Costs };
            Filters Fils = new Filters();
            Fils.build_Change(Grid_Change, array_check, t_box_name, content);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE dbo.Rooms SET ";
            string text_ID = " WHERE ID_Numbers = ";
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emplo, Check_Name, Check_Capaci, Check_Descript, Check_Costs };
            Query_input Query = new Query_input();
            Query.sql_build_Change(sql, Staff_ID, text_ID, array_check, t_box_name, query_input_name, Grid_Change);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] {"Код номера" ,"Код сотрудника", "Наименование", "Вместимость", "Описание", "Стоимость" };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Num, Check_ID_Emp, Check_Names, Check_Capa, Check_Descr, Check_Cos };
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

        private void return_3_MouseUp(object sender, MouseButtonEventArgs e)
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
            string sql = "DELETE dbo." + db + " WHERE ID_Numbers =" + Delet.Text;
            Query_input Query = new Query_input();
            Query.delete(sql, Delet, db);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            TextBox[] text_Box_input = new TextBox[] { Nam, Capac, Descr, Cost };
            Filters Fils = new Filters();
            Fils.clearing(text_Box_input);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID_Num, Check_ID_Emp, Check_Names, Check_Capa, Check_Descr, Check_Cos };
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_11(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код номера", "Код сотрудника", "Наименование", "Вместимость", "Описание", "Стоимость" };
            string[] explore = new string[] { "Код номера", "Код сотрудника", "Наименование", "Вместимость", "Описание", "Стоимость" };
            string[] query_output_name = new string[] { "ID_Numbers", "ID_Employee", "Name", "Capacity", "Description", "The_cost" };
            string[] array = new string[] { };
            string[] line = new string[] { };
            string sql_fil_end = " from dbo.Rooms";
            string full_sql = "select ID_Numbers,ID_Employee,Name,Capacity,Description,The_cost from dbo.Rooms";
            CheckBox[] array_check = new CheckBox[] { Check_ID_Num, Check_ID_Emp, Check_Names, Check_Capa, Check_Descr, Check_Cos };

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
