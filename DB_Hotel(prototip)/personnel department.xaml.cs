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
    /// Логика взаимодействия для personnel_department.xaml
    /// </summary>
    public partial class personnel_department : Window
    {
        string sql_query = "SELECT Staff.ID_Employee as [Код сотрудника], Staff.Surname as [Фамилия], Staff.Name as [Имя], Staff.Patronymic as [Отчество], Staff.Age as [Возраст], Staff.Gender as [Пол], Staff.Registered_address as [Адрес по прописке], Staff.Address_of_actual_residence as [Адрес фактического проживание], Staff.Series as [Серия], Staff.ID_Passport as [Паспортные данные], Staff.Subdivision as [Подразделение], " +
            " CAST(Staff.Date_of_issue as varchar) as [Дата выдачи], Staff.Issued_by as [Кто выдал], Staff.Phone as [Телефон], Positionen.ID_Position as [Код должности], Positionen.Job_title as [Наименование должности], Positionen.Duties as [Обязанности], Positionen.Requirements as [Требования], Positionen.Salary as [Оклад]" +
            " FROM Staff INNER JOIN Positionen ON Staff.ID_Position = Positionen.ID_Position";
        string db = "Staff";
        string[] query_output_name = new string[] {"Staff.ID_Employee","Staff.Surname","Staff.Name","Staff.Patronymic","Staff.Age","Staff.Gender","Staff.Registered_address","Staff.Address_of_actual_residence", "Staff.Series","Staff.ID_Passport","Staff.Subdivision","CAST(Staff.Date_of_issue AS varchar)",
        "Staff.Issued_by","Staff.Phone","Positionen.ID_Position", "Positionen.Job_title", "Positionen.Duties", "Positionen.Requirements", "Positionen.Salary"};
        string[] array_ru_name = new string[] { " as [Код сотрудника]"," as [Фамилия]", " as [Имя]"," as [Отчество]"," as [Возраст]"," as [Пол]"," as [Адрес по прописке]",
                " as [Адрес фактического проживания]"," as [Серия]"," as [Номер паспорта]", " as [Подразделения]"," as [Дата выдачи]"," as [Кто выдал]"," as [Телефон]",
                " as [Код должности]", " as [Наименование должности]", " as [Обязанности]", " as [Требования]", " as [Оклад]" };
        string sql_fil_end = "FROM Staff INNER JOIN Positionen ON Staff.ID_Position = Positionen.ID_Position";
        public personnel_department()
        {
            InitializeComponent();
            login_role.Text = buffer.Role;
            login_object_output.Text = "Логин:" + buffer.login;
            Query_output Query = new Query_output();
            Query.Output(sql_query, db, table);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones, Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };
            Filters Fils = new Filters();
            Fils.Filter_Query(array, array_check, query_output_name, array_ru_name, table, sql_query, db, sql_fil_end);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код сотрудника", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон","Код должности","Наименование должности","Обязанности", "Требование","Оклад"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones, Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };
            Filters Fils = new Filters();
            Fils.explorer_Query_Fil(sql, sql_query, array, array_check, query_output_name, array_ru_name, explore, explorer_box, explorer_textBox, db, table, sql_fil_end);
        }

        private void return_2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_authoriazation();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Staff transition = new Staff();
            transition.Show();
            this.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Positionen transition = new Positionen();
            transition.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones, Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_6(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код сотрудника", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон","Код должности","Наименование должности","Обязанности", "Требование","Оклад"};
            string[] query_input_name = new string[] {"Staff.ID_Employee","Staff.Surname","Staff.Name","Staff.Patronymic","Staff.Age","Staff.Gender","Staff.Registered_address","Staff.Address_of_actual_residence", "Staff.Series","Staff.ID_Passport","Staff.Subdivision","CAST(Staff.Date_of_issue AS varchar)",
        "Staff.Issued_by","Staff.Phone","Positionen.ID_Position", "Positionen.Job_title", "Positionen.Duties", "Positionen.Requirements", "Positionen.Salary"};
            string[] query_output_name = new string[] {"ID_Employee","Surname","Name","Patronymic","Age","Gender","Registered_address","Address_of_actual_residence", "Series","ID_Passport","Subdivision","Date_of_issue",
        "Issued_by","Phone","ID_Position", "Job_title", "Duties", "Requirements", "Salary"};

            string[] array = new string[] { };
            string[] line = new string[] { };
            string sql_fil_end = " FROM Staff INNER JOIN Positionen ON Staff.ID_Position = Positionen.ID_Position";
            string full_sql = "SELECT Staff.ID_Employee, Staff.Surname, Staff.Name, Staff.Patronymic, Staff.Age, Staff.Gender, Staff.Registered_address, Staff.Address_of_actual_residence, Staff.Series, Staff.ID_Passport, Staff.Subdivision, " +
            " Staff.Date_of_issue, Staff.Issued_by, Staff.Phone, Positionen.ID_Position, Positionen.Job_title, Positionen.Duties, Positionen.Requirements, Positionen.Salary" +
            " FROM Staff INNER JOIN Positionen ON Staff.ID_Position = Positionen.ID_Position";
            string[] explore = new string[] { "Код сотрудника", "Фамилия", "Имя", "Отчество", "Возраст", "Пол", "Адрес по прописке",
            "Адрес фактического проживание","Серия","Номер паспорта","Подразделение","Дата выдачи","Кто выдал","Телефон","Код должности","Наименование должности","Обязанности", "Требование","Оклад"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones, Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };

            Query_input Query = new Query_input();
            Query.report_query(Field_name, query_output_name, query_input_name, array, line, explore, array_check, explorer_box, explorer_textBox, sql_fil_end, full_sql);
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
