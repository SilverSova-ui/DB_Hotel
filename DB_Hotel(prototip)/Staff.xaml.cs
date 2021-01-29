using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        string sql_query = "select ID_Employee as [Код сотрудники], ID_Position as [Код должности],Surname as [Фамилия]," +
"Name as [Имя],Patronymic as [Отчество],Age as [Возраст], Gender as [Пол], Registered_address as [Адрес по прописке]," +
"Address_of_actual_residence as [Адрес фактического проживания], Series as [Серия]," +
"ID_Passport as [Номер паспорта], Subdivision as [Подразделения], CAST(Date_of_issue AS varchar) as [Дата выдачи]," +
"Issued_by as [Кто выдал], Phone as [Телефон] from dbo.Staff";
        string db = "Staff";
        string[] query_input_name = new string[] { "ID_Position","Surname","Name","Patronymic","Age","Gender","Registered_address","Address_of_actual_residence", "Series","ID_Passport","Subdivision","Date_of_issue",
        "Issued_by","Phone"};
        string[] t_box_name = new string[] { "ID_Post", "Sur", "Name", "Patr", "Years", "sex", "Registers", "Addres_actual", "Ser", "ID_Pass", "Subd", "D_issues", "Issued", "Phone" };
        string[] query_output_name = new string[] {"ID_Employee" ,"ID_Position","Surname","Name","Patronymic","Age","Gender","Registered_address","Address_of_actual_residence", "Series","ID_Passport","Subdivision","CAST(Date_of_issue AS varchar)",
        "Issued_by","Phone"};
        string[] array_ru_name = new string[] { " as [Код сотрудника]"," as [Код должности]"," as [Фамилия]", " as [Имя]"," as [Отчество]"," as [Возраст]"," as [Пол]"," as [Адрес по прописке]",
                " as [Адрес фактического проживания]"," as [Серия]"," as [Номер паспорта]", " as [Подразделения]"," as [Дата выдачи]"," as [Кто выдал]"," as [Телефон]"};
        public Staff()
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
            SqlCommand command = new SqlCommand("select ID_Position,Job_title from dbo.Positionen", Connect.cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ID_Position = reader["ID_Position"].ToString();
                string Job_title = reader["Job_title"].ToString();
                ComboBoxItem box_item = new ComboBoxItem();
                box_item.Content = ID_Position + " - " + Job_title;
                help.Items.Add(box_item);
            }
            conn.disconnection();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones };
            Filters Fils = new Filters();
            Fils.Filter(array, array_check, query_output_name,array_ru_name, table,sql_query,db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] text_Box_input = new string[] {help.Text.Split()[0], Familya.Text, Imia.Text, Otchestvo.Text, Let.Text, Pol.Text, Registered.Text,
            Actual.Text, Ceria.Text, ID.Text, Podrazdelenia.Text, Date.Text, Vidol.Text, Telephone.Text};
            string sql = "INSERT INTO dbo.Staff (";
            Query_input Query = new Query_input();
            Query.sql_build_input(sql, query_input_name, text_Box_input);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid_Change.Children.Clear();
            string[] content = new string[] {"Код должности", "Фамилия","Имя", "Отчество","Возраст",
                "Пол","Адрес по\nпрописке","Адрес \nфактического \nпроживания","Серия","Номер\nпаспорта","Подразделения",
            "Дата выдачи","Кто выдал","Телефон"};
            CheckBox[] array_check = new CheckBox[] {Check_ID_JOB, Check_Family, Check_Name, Check_Otchestvo, Check_Age, Check_SEX, Check_Adress, Check_Adress_Act, Check_Seria,
            Check_ID_PASS,Check_Pod,Check_Date_of_issue,Check_Issued_by,Check_Phone};
            Filters Fils = new Filters();
            Fils.build_Change(Grid_Change, array_check, t_box_name, content);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE dbo.Staff SET ";
            string text_ID = " WHERE ID_Employee = ";
            CheckBox[] array_check = new CheckBox[] {Check_ID_JOB, Check_Family, Check_Name, Check_Otchestvo, Check_Age, Check_SEX, Check_Adress, Check_Adress_Act, Check_Seria,
            Check_ID_PASS,Check_Pod,Check_Date_of_issue,Check_Issued_by,Check_Phone};
            Query_input Query = new Query_input();
            Query.sql_build_Change(sql,Staff_ID,text_ID, array_check,t_box_name,query_input_name, Grid_Change);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код сотрудника" , "Код должности", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones };
            Filters Fils = new Filters();
            Fils.explorer_Filter(sql,sql_query,array,array_check,query_output_name,array_ru_name,explore,explorer_box,explorer_textBox,db,table);
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
            string sql = "DELETE dbo." + db + " WHERE ID_Employee =" + Delet.Text;
            Query_input Query = new Query_input();
            Query.delete(sql,Delet,db);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            TextBox[] text_Box_input = new TextBox[] {Familya, Imia, Otchestvo, Let, Registered, Actual, Ceria, ID, Podrazdelenia, Date, Vidol, Telephone};
            Filters Fils = new Filters();
            Fils.clearing(text_Box_input);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones };
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_11(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код сотрудника" , "Код должности", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон"};
            string[] query_output_name = new string[] {"ID_Employee" ,"ID_Position","Surname","Name","Patronymic","Age","Gender","Registered_address","Address_of_actual_residence", "Series","ID_Passport","Subdivision","Date_of_issue",
        "Issued_by","Phone"};
           
            string[] array = new string[] { };
            string[] line = new string[] { };
            string[] explore = new string[] { "Код сотрудника" , "Код должности", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон"};
            string sql_fil_end = " from dbo.Staff";
            string full_sql = "select ID_Employee,ID_Position,Surname,Name,Patronymic,Age,Gender,Registered_address,Address_of_actual_residence,Series,ID_Passport,Subdivision,Date_of_issue,Issued_by,Phone from dbo.Staff";
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones };

            Query_input Query = new Query_input();
            Query.report(Field_name,query_output_name,array,line,explore,array_check,explorer_box,explorer_textBox,sql_fil_end,full_sql);

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
