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
    /// Логика взаимодействия для Service_to_customers.xaml
    /// </summary>
    public partial class Service_to_customers : Window
    {
        string sql_query = "SELECT Staff.ID_Employee as [Код сотрудники],Staff.ID_Position as [Код должности],Staff.Surname as [Фамилия сотрудника],Staff.Name as [Имя сотрудника],Staff.Patronymic as [Отчество сотрудника],Staff.Age as [Возраст сотрудника],Staff.Gender as [Пол сотрудника],Staff.Registered_address as [Адрес по прописке сотрудника],Staff.Address_of_actual_residence as [Адрес фактического проживания сотрудника], Staff.Series as [Серия],Staff.ID_Passport as [Номер паспорта сотрудника], Staff.Subdivision as [Код подразделения сотрудника], CAST(Staff.Date_of_issue as varchar) as [Дата выдачи паспорта сотруднику]," +
            "Staff.Issued_by as [Кто выдал паспорт сотруднику], Staff.Phone as [Телефон сотрудника],Clients.ID_Client as [Код клиента],Clients.Surname as [Фамилия клиента],Clients.Name as [Имя клиента],Clients.Patronymic as [Отчество клиента],Clients.Registered_address as [Адрес по прописке клиента],Clients.Series as [Серия паспорта клиента]," +
            "Clients.ID_Passport as [Номер паспорта клиента],Clients.Subdivision as [Код подразделение клиента],CAST(Clients.Date_of_issue AS varchar) as [Дата выдачи паспорта клиенту],Clients.Issued_by as [Кто выдал паспорт клиенту],CAST(Clients.Check_in_date AS varchar) as [Дата выезда],CAST(Clients.Date_of_departure AS varchar) as [Дата заселения],Services.ID_Services as [Код услуги], Services.Name as [Наименование услуги]," +
            "Services.Description as [Описание услуги],Services.The_cost as [Стоимость услуги],Rooms.Name as [Наименование номера],Rooms.Capacity as [Вместимость номера],Rooms.Description as [Описание номера],Rooms.The_cost as [Стоимость номера]" +
            " FROM Clients INNER JOIN " +
            "Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN " +
            "[Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN " +
            "Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN " +
            "Staff ON Clients.ID_Employee = Staff.ID_Employee";
        string db = "Staff";
        string[] query_output_name = new string[] {"Staff.ID_Employee","Staff.ID_Position","Staff.Surname","Staff.Name","Staff.Patronymic","Staff.Age","Staff.Gender","Staff.Registered_address","Staff.Address_of_actual_residence",
"Staff.Series","Staff.ID_Passport", "Staff.Subdivision","Staff.Date_of_issue","Staff.Issued_by","Staff.Phone","Clients.ID_Client","Clients.Surname","Clients.Name","Clients.Patronymic","Clients.Registered_address",
"Clients.Series","Clients.ID_Passport","Clients.Subdivision","Clients.Date_of_issue","Clients.Issued_by","Clients.Check_in_date","Clients.Date_of_departure","Services.ID_Services","Services.Name","Services.Description","Services.The_cost","Rooms.Name","Rooms.Capacity","Rooms.Description","Rooms.The_cost"};
        string sql_fil_end = " FROM Clients INNER JOIN " +
            "Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN " +
            "[Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN " +
            "Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN " +
            "Staff ON Clients.ID_Employee = Staff.ID_Employee";
        string[] array_ru_name = new string[] { " as [Код сотрудники]", " as [Код должности]", " as [Фамилия сотрудника]", " as [Имя сотрудника]", "  as [Отчество сотрудника]", " as [Возраст сотрудника]", " as [Пол сотрудника]", " as [Адрес по прописке сотрудника]", " as [Адрес фактического проживания сотрудника]", " as [Серия паспорта сотрудника]", " as [Номер паспорта сотрудника]", " as [Код подразделения сотрудника]", " as [Дата выдачи паспорта сотруднику]",
        " as [Кто выдал паспорт сотруднику]"," as [Телефон сотрудника]"," as [Код клиента]"," as [Фамилия клиента]"," as [Имя клиента]"," as [Отчество клиента]"," as [Адрес по прописке клиента]"," as [Серия паспорта клиента]"," as [Номер паспорта клиента]"," as [Подразделение клиента]"," as [Дата выдачи паспорта клиенту]"," as [Кто выдал паспорт клиенту]"," as [Дата выезда]"," as [Дата заселения]"," as [Код услуги]"," as [Наименование услуги]",
        " as [Описание услуги]"," as [Стоимость услуги]"," as [Наименование номера]"," as [Вместимость номера]"," as [Описание номера]"," as [Стоимость номера]"};

        public Service_to_customers()
        {
            InitializeComponent();
            login_role.Text = buffer.Role;
            login_object_output.Text = "Логин:" + buffer.login;
            Query_output Query = new Query_output();
            Query.Output(sql_query, db, table);
            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand("EXEC sp_helpuser '" + buffer.login + "'", Connect.cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sql_Role = null;
                sql_Role = reader["RoleName"].ToString();
                if (sql_Role == "RP_Manager")
                {
                    staff.Visibility = Visibility.Hidden;
                    client.Margin = new Thickness(835, 116, 0, 0);
                    service.Margin = new Thickness(835, 181, 0, 0);
                    rooms.Margin = new Thickness(835, 243, 0, 0);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones,
            Check_ID_Cli, Check_Familys, Check_Name, Check_Patrе, Check_Register, Check_Ceria,Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za,Check_ID_Ser, Check_Nam, Check_Desc, Check_Cost,
            Check_Nameq,Check_Capa,Check_Descr,Check_Cos};
            Filters Fils = new Filters();
            Fils.Filter_Query(array, array_check, query_output_name, array_ru_name, table, sql_query, db, sql_fil_end);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код сотрудника","Код должности", "Фамилия сотрудника", "Имя сотрудника", "Отчество сотрудника", "Возраст сотрудника", "Пол сотрудника", "Адрес по прописке сотрудника","Адрес фактического проживание сотрудника","Серия паспорта сотрудника","Номер паспорта сотрудника","Код подразделение сотрудника","Дата выдачи паспорта сотруднику","Кто выдал паспорт сотруднику","Телефон сотрудника",
            "Код клиента","Фамилия клиента","Имя клиента","Отчество клиента","Адрес по прописке клиента","Серия паспорта клиента","Номер паспорта клиента","Код подразделение клиента","Дата выдачи паспорта клиента","Кто выдал паспорт клиенту","Дата выезда клиента","Дата заселения клиента",
            "Код услуги","Наименование услуги","Описание услуги","Стоимость услуги","Наименование номера","Вместимость номера","Описание номера","Стоимость номера"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones,
            Check_ID_Cli, Check_Familys, Check_Name, Check_Patrе, Check_Register, Check_Ceria,Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za,Check_ID_Ser, Check_Nam, Check_Desc, Check_Cost,
            Check_Nameq,Check_Capa,Check_Descr,Check_Cos};
            Filters Fils = new Filters();
            Fils.explorer_Query_Fil(sql, sql_query, array, array_check, query_output_name, array_ru_name, explore, explorer_box, explorer_textBox, db, table, sql_fil_end);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Customer_account transition = new Customer_account();
            transition.Show();
            this.Close();
        }

        private void return_2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Filters Fils = new Filters();
            Fils.return_main();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Staff transition= new Staff();
            transition.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Staff transition = new Staff();
            transition.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Clients transition = new Clients();
            transition.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Services transition = new Services();
            transition.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Rooms transition = new Rooms();
            transition.Show();
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones,
            Check_ID_Cli, Check_Familys, Check_Name, Check_Patrе, Check_Register, Check_Ceria,Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za,Check_ID_Ser, Check_Nam, Check_Desc, Check_Cost,
            Check_Nameq,Check_Capa,Check_Descr,Check_Cos};
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);

        }

        private void button_Click_9(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код сотрудника","Код должности", "Фамилия сотрудника", "Имя сотрудника", "Отчество сотрудника", "Возраст сотрудника", "Пол сотрудника", "Адрес по прописке сотрудника","Адрес фактического проживание сотрудника","Серия паспорта сотрудника","Номер паспорта сотрудника","Код подразделение сотрудника","Дата выдачи паспорта сотруднику","Кто выдал паспорт сотруднику","Телефон сотрудника",
            "Код клиента","Фамилия клиента","Имя клиента","Отчество клиента","Адрес по прописке клиента","Серия паспорта клиента","Номер паспорта клиента","Код подразделение клиента","Дата выдачи паспорта клиента","Кто выдал паспорт клиенту","Дата выезда клиента","Дата заселения клиента",
            "Код услуги","Наименование услуги","Описание услуги","Стоимость услуги","Наименование номера","Вместимость номера","Описание номера","Стоимость номера"};
            string[] query_input_name = new string[] {"Staff.ID_Employee","Staff.ID_Position","Staff.Surname","Staff.Name","Staff.Patronymic","Staff.Age","Staff.Gender","Staff.Registered_address","Staff.Address_of_actual_residence",
"Staff.Series","Staff.ID_Passport", "Staff.Subdivision","Staff.Date_of_issue","Staff.Issued_by","Staff.Phone","Clients.ID_Client","Clients.Surname","Clients.Name","Clients.Patronymic","Clients.Registered_address",
"Clients.Series","Clients.ID_Passport","Clients.Subdivision","Clients.Date_of_issue","Clients.Issued_by","Clients.Check_in_date","Clients.Date_of_departure","Services.ID_Services","Services.Name","Services.Description","Services.The_cost","Rooms.Name","Rooms.Capacity","Rooms.Description","Rooms.The_cost"};
            string[] query_output_name = new string[] {"ID_Employee","ID_Position","Surname","Name","Patronymic","Age","Gender","Registered_address","Address_of_actual_residence",
"Series","ID_Passport", "Subdivision","Date_of_issue","Issued_by","Phone","ID_Client","Surname","Name","Patronymic","Registered_address",
"Series","ID_Passport","Subdivision","Date_of_issue","Issued_by","Check_in_date","Date_of_departure","ID_Services","Name","Description","The_cost","Name","Capacity","Description","The_cost"};

            string[] array = new string[] { };
            string[] line = new string[] { };
            string sql_fil_end = " FROM Clients INNER JOIN " +
            "Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN " +
            "[Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN " +
            "Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN " +
            "Staff ON Clients.ID_Employee = Staff.ID_Employee";
            string full_sql = "SELECT Staff.ID_Employee,Staff.ID_Position,Staff.Surname,Staff.Name,Staff.Patronymic,Staff.Age,Staff.Gender,Staff.Registered_address,Staff.Address_of_actual_residence, Staff.Series,Staff.ID_Passport, Staff.Subdivision,Staff.Date_of_issue," +
            "Staff.Issued_by, Staff.Phone,Clients.ID_Client,Clients.Surname,Clients.Name,Clients.Patronymic,Clients.Registered_address,Clients.Series," +
            "Clients.ID_Passport,Clients.Subdivision,Clients.Date_of_issue,Clients.Issued_by,Clients.Check_in_date,Clients.Date_of_departure,Services.ID_Services, Services.Name," +
            "Services.Description,Services.The_cost,Rooms.Name,Rooms.Capacity,Rooms.Description,Rooms.The_cost" +
            " FROM Clients INNER JOIN " +
            "Rooms ON Clients.ID_Numbers = Rooms.ID_Numbers INNER JOIN " +
            "[Services provided to the client] ON Clients.ID_Client = [Services provided to the client].ID_Client INNER JOIN " +
            "Services ON [Services provided to the client].ID_Services = Services.ID_Services INNER JOIN " +
            "Staff ON Clients.ID_Employee = Staff.ID_Employee";
            string[] explore = new string[] { "Код сотрудника","Код должности", "Фамилия сотрудника", "Имя сотрудника", "Отчество сотрудника", "Возраст сотрудника", "Пол сотрудника", "Адрес по прописке сотрудника","Адрес фактического проживание сотрудника","Серия паспорта сотрудника","Номер паспорта сотрудника","Код подразделение сотрудника","Дата выдачи паспорта сотруднику","Кто выдал паспорт сотруднику","Телефон сотрудника",
            "Код клиента","Фамилия клиента","Имя клиента","Отчество клиента","Адрес по прописке клиента","Серия паспорта клиента","Номер паспорта клиента","Код подразделение клиента","Дата выдачи паспорта клиента","Кто выдал паспорт клиенту","Дата выезда клиента","Дата заселения клиента",
            "Код услуги","Наименование услуги","Описание услуги","Стоимость услуги","Наименование номера","Вместимость номера","Описание номера","Стоимость номера"};
            CheckBox[] array_check = new CheckBox[] { Check_ID_Emp, Check_ID_Post, Check_Sur, Check_Names, Check_Patr, Check_Year, Check_Gendr, Check_Registered, Check_actual, Check_Series, Check_ID_Pass, Check_Subdivision, Check_Date, Check_Issued, Check_Phones,
            Check_ID_Cli, Check_Familys, Check_Name, Check_Patrе, Check_Register, Check_Ceria,Check_ID_P,Check_Podrazdelenia,Check_Dates,Check_Is_Date,Check_Date_Vi,Check_Data_Za,Check_ID_Ser, Check_Nam, Check_Desc, Check_Cost,
            Check_Nameq,Check_Capa,Check_Descr,Check_Cos};

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
