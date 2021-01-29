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
    /// Логика взаимодействия для SQL_Query.xaml
    /// </summary>
    public partial class SQL_Query : Window
    {
        public SQL_Query()
        {
            InitializeComponent();
            login_object.Text = "Логин: " + buffer.login;
            login_role.Text = buffer.Role;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql_query = SQL.Text;
            string db = "";
            string dbo = "";
            string[] exp = sql_query.ToLower().Split(' ');
            string[] array_db = new string[] {"Staff","Positionen","Client","Rooms","Services","Services provided to the client",
                "staff","positionen","client","rooms","services","services provided to the client"};
            string[] array_dbo = new string[] {"dbo.[Staff]","dbo.[Positionen]","dbo.[Client]","dbo.[Rooms]","dbo.[Services]","dbo.[Services provided to the client]",
                                               "dbo.[staff]","dbo.[positionen]","dbo.[client]","dbo.[rooms]","dbo.[services]","dbo.[services provided to the client]"};
            for (int i = 0; i < array_db.Length; i++)
            {
                if (sql_query.Contains(array_db[i]))
                {
                    db += array_db[i];
                }
                if (sql_query.Contains(array_dbo[i]))
                {
                    dbo += array_db[i];
                }
            }
            foreach (string i in exp)
            {
                if (i == "GRANT SELECT")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "select")
                {
                    sql_query = SQL.Text;
                    Query_output Query = new Query_output();
                    Query.Output(sql_query, db, table);
                    break;
                }
                if (i == "select*from")
                {
                    sql_query = SQL.Text;
                    Query_output Query = new Query_output();
                    Query.Output(sql_query, db, table);
                    break;
                }
                if (i == "alter")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "insert")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "drop")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "update")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "delete")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "exec")
                {
                    sql_query = SQL.Text;
                    Query_output Query = new Query_output();
                    Query.Output(sql_query, db, table);
                    break;
                }
                if (i == "create")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                if (i == "execute")
                {
                    sql_query = SQL.Text;
                    Query_input Query = new Query_input();
                    Query.input(sql_query);
                    break;
                }
                else
                {
                    MessageBox.Show("Запрос задан не верно или данная команда не используется в интерфейсе", "Уведомление");
                    break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
