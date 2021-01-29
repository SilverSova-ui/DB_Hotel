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
    /// Логика взаимодействия для Positionen.xaml
    /// </summary>
    public partial class Positionen : Window
    {
        string sql_query = "select ID_Position as [Код должности], Job_title as [Наименование должности], Duties as [Обязанности], Requirements as [Требования], Salary as [Оклад] from dbo.Positionen";
        string db = "Positionen";
        string[] query_input_name = new string[] { "Job_title", "Duties", "Requirements", "Salary"};
        string[] t_box_name = new string[] {"JOBs", "Duties", "Requir", "Salars" };
        string[] query_output_name = new string[] { "ID_Position", "Job_title", "Duties", "Requirements", "Salary"};
        string[] array_ru_name = new string[] {" as [Код должности]", " as [Наименование должности]", " as [Обязанности]", " as [Требования]", " as [Оклад]" };

        public Positionen()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[] { };
            CheckBox[] array_check = new CheckBox[] {Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal};
            Filters Fils = new Filters();
            Fils.Filter(array, array_check, query_output_name, array_ru_name, table, sql_query, db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] text_Box_input = new string[] {Job.Text,Dut.Text,Requie.Text,Salary.Text};
            string sql = "INSERT INTO dbo.Positionen (";
            Query_input Query = new Query_input();
            Query.sql_build_input(sql, query_input_name, text_Box_input);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid_Change.Children.Clear();
            string[] content = new string[] {"Наименование\nдолжности","Обязанности", "Требование","Оклад"};
            CheckBox[] array_check = new CheckBox[] {Check_JOBS, Check_Duts, Check_Reque, Check_Sali};
            Filters Fils = new Filters();
            Fils.build_Change(Grid_Change, array_check, t_box_name, content);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE dbo.Positionen SET ";
            string text_ID = " WHERE ID_Position = ";
            CheckBox[] array_check = new CheckBox[] {Check_JOBS, Check_Duts, Check_Reque, Check_Sali };
            Query_input Query = new Query_input();
            Query.sql_build_Change(sql, Positionen_ID, text_ID, array_check, t_box_name, query_input_name, Grid_Change);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string sql = "Select ";
            string[] array = new string[] { };
            string[] explore = new string[] { "Код должности","Наименование должности","Обязанности", "Требование","Оклад"};
            CheckBox[] array_check = new CheckBox[] { Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal};
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
            string sql = "DELETE dbo." + db + " WHERE ID_Position = " + Delet.Text;
            Query_input Query = new Query_input();
            Query.delete(sql, Delet, db);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            TextBox[] text_Box_input = new TextBox[] { Job, Dut, Requie, Salary};
            Filters Fils = new Filters();
            Fils.clearing(text_Box_input);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CheckBox[] array_check = new CheckBox[] { Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };
            Filters Fils = new Filters();
            Fils.clearing_fields(array_check);
        }

        private void button_Click_11(object sender, RoutedEventArgs e)
        {
            string[] Field_name = new string[] { "Код должности", "Наименование должности", "Обязанности", "Требование", "Оклад" };
            string[] query_output_name = new string[] { "ID_Position", "Job_title", "Duties", "Requirements", "Salary" };

            string[] array = new string[] { };
            string[] line = new string[] { };
            string[] explore = new string[] { "Код должности", "Наименование должности", "Обязанности", "Требование", "Оклад" };
            string sql_fil_end = " from dbo.Positionen";
            string full_sql = "select ID_Position, Job_title, Duties, Requirements, Salary from dbo.Positionen";

            CheckBox[] array_check = new CheckBox[] { Check_ID, Check_Job, Check_Dut, Check_Requ, Check_Sal };

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
