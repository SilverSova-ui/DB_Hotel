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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        string sql_query = "select ID_Client as [Код клиента],ID_Employee as [Код сотрудника],ID_Numbers as [Код номера],Surname as [Фамилия],Name as [Имя],Patronymic as [Отчество]," +
            "Registered_address as [Адрес по прописке],Series as [Серия],ID_Passport as [Номер паспорта],Subdivision as [Подразделение],CAST(Date_of_issue AS varchar) as [Дата выдачи],Issued_by as [Кто выдал],CAST(Check_in_date AS varchar) as [Дата выезда],CAST(Date_of_departure AS varchar) as [Дата заселения] from dbo.Clients";
        string db = "Clients";
        string[] query_input_name = new string[] { "ID_Employee", "ID_Numbers", "Surname", "Name", "Patronymic", "Registered_address", "Series", "ID_Passport", "Subdivision", "Date_of_issue", "Issued_by", "Check_in_date", "Date_of_departure"};
        string[] t_box_name = new string[] {"T_emp","T_ID","T_Sur","T_Name","T_Part","T_Regist","T_Series","T_pass","T_Subdiv","T_Date", "T_Issued_by", "T_check_in_date","T_Date_of_depat"};
        string[] query_output_name = new string[] { "ID_Client", "ID_Employee", "ID_Numbers", "Surname", "Name", "Patronymic", "Registered_address", "Series", "ID_Passport", "Subdivision", "CAST(Date_of_issue AS varchar)", "Issued_by", "CAST(Check_in_date AS varchar)", "CAST(Date_of_departure AS varchar)" };
        string[] array_ru_name = new string[] { " as [Код клиента]"," as [Код сотрудника]"," as [Код номера]"," as [Фамилия]"," as [Имя]"," as [Отчество]",
        " as [Адрес по прописке]"," as [Серия]"," as [Номер паспорта]"," as [Подразделение]"," as [Дата выдачи]"," as [Кто выдал]"," as [Дата выезда]"," as [Дата заселения]"};
        public Clients()
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
            conn.disconnection();
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
                help.Items.Add(box_item);
            }
            conn.disconnection();
            conn.connection();
            command = new SqlCommand("select ID_Numbers,Name,Capacity,Description,The_cost from dbo.Rooms", Connect.cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ID_Numbers = reader["ID_Numbers"].ToString();
                string Name = reader["Name"].ToString();
                string Capacit = reader["Capacity"].ToString();
                string Description = reader["Description"].ToString();
                string The_cost = reader["The_cost"].ToString();
                ComboBoxItem box_item = new ComboBoxItem();
                box_item.Content = ID_Numbers + " - Наименование:" + Name + " Вместимость:" + Capacit + " Описание:" + Description +  " Цена:" + The_cost;
                ID_NUM.Items.Add(box_item);
            }
            conn.disconnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cli, Check_ID_EMP, Check_ID_NUM, Check_Familys, Check_Names, Check_Patr, Check_Register, Check_Ceria,
            Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za};
            Filters Fils = new Filters();
            Fils.Filter(array, array_check, query_output_name, array_ru_name, table, sql_query, db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] text_Box_input = new string[] { help.Text.Split()[0], ID_NUM.Text.Split()[0], Family.Text, Imia.Text, Othestvo.Text, Registered.Text, Ceria.Text, ID_P.Text,
            Podrazdelenia.Text,Date.Text,Is_Date.Text,Date_Vi.Text,Data_Za.Text};
            string sql = "INSERT INTO dbo.Clients (";
            Query_input Query = new Query_input();
            Query.sql_build_input(sql, query_input_name, text_Box_input);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid_Change.Children.Clear();
            string[] content = new string[] {"Код сотрудника","Код номера","Фамилия","Имя","Отчество",
            "Адрес по\nпрописке","Серия","Номер\nпаспорта","Подразделение","Дата выдачи","Кто выдал","Дата выезда", "Дата заселения"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Sotr, Check_Numb, Check_Part, Check_Name, Check_Otchestvo, Check_Adress, Check_Ceri, Check_ID_PASS,
            Check_Pod,Check_Date_of_issue,Check_Date_of_issue,Check_Date_vie, Check_Date_zas};
            Filters Fils = new Filters();
            Fils.build_Change(Grid_Change, array_check, t_box_name, content);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE dbo.Clients SET ";
            string text_ID = " WHERE ID_Client = ";
            CheckBox[] array_check = new CheckBox[] { Check_ID_Sotr, Check_Numb, Check_Part, Check_Name, Check_Otchestvo, Check_Adress, Check_Ceri, Check_ID_PASS,
            Check_Pod,Check_Date_of_issue,Check_Date_of_issue,Check_Date_vie, Check_Date_zas};
            Query_input Query = new Query_input();
            Query.sql_build_Change(sql, Client_ID, text_ID, array_check, t_box_name, query_input_name, Grid_Change);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код клиента" , "Код сотрудника", "Код номера", "Фамилия", "Имя", "Отчество", "Адрес по прописке", "Серия",
            "Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Дата выезда","Дата заселения"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cli, Check_ID_EMP, Check_ID_NUM, Check_Familys, Check_Names, Check_Patr, Check_Register, Check_Ceria,
            Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za};
            Filters Fils = new Filters();
            Fils.explorer_Filter(sql, sql_query, array, array_check, query_output_name, array_ru_name, explore, explorer_box, explorer_textBox, db, table);
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

        private void return_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
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
            TextBox[] text_Box_input = new TextBox[] { Family, Imia, Othestvo, Registered, Ceria, ID_P, Podrazdelenia, Date, Is_Date, Date_Vi, Data_Za};
            Filters Fils = new Filters();
            Fils.clearing(text_Box_input);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cli, Check_ID_EMP, Check_ID_NUM, Check_Familys, Check_Names, Check_Patr, Check_Register, Check_Ceria,
            Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za};
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_11(object sender, RoutedEventArgs e)
        {

            string[] Field_name = new string[] { "Код клиента" , "Код сотрудника", "Код номера", "Фамилия", "Имя", "Отчество", "Адрес по прописке", "Серия",
            "Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Дата выезда","Дата заселения" };
            string[] query_output_name = new string[] { "ID_Client", "ID_Employee", "ID_Numbers", "Surname", "Name", "Patronymic", "Registered_address", "Series", "ID_Passport", "Subdivision", "Date_of_issue", "Issued_by", "Check_in_date", "Date_of_departure" };
            
            string[] array = new string[] { };
            string[] line = new string[] { };
            string sql_fil_end = " from dbo.Clients";
            string full_sql = "select ID_Client,ID_Employee,ID_Numbers,Surname,Name,Patronymic,Registered_address,Series,ID_Passport,Subdivision,Date_of_issue,Issued_by,Check_in_date,Date_of_departure from dbo.Clients";
            string[] explore = new string[] { "Код клиента" , "Код сотрудника", "Код номера", "Фамилия", "Имя", "Отчество", "Адрес по прописке", "Серия",
            "Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Дата выезда","Дата заселения"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Cli, Check_ID_EMP, Check_ID_NUM, Check_Familys, Check_Names, Check_Patr, Check_Register, Check_Ceria,
            Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za};

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
