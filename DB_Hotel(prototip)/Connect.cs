using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DB_Hotel_prototip_
{
    class Connect
    {
        Config_connection DB_Config = new Config_connection();
        public static SqlConnection cnn = null;

        public void connection()
        {
            cnn = new SqlConnection(@"server="+ DB_Config.Server + ";uid=" + buffer.login + ";pwd=" + buffer.password + ";database=" + DB_Config.DataBase);
            try
            {       
                cnn.Open();
            }
            catch
            {
                cnn = null;
                MessageBox.Show("Данные пользователя некорректный", "Уведомление");
            }
        }

        public void disconnection()
        {
            cnn.Close();
        }

        public void Check(string db, TabItem Data_entry, TabItem Data_output, TabItem Data_editing)
        {
            string query = "EXEC sp_helprotect 'dbo." + db + "', '" + buffer.login + "'";
            string[] Table_User = new string[] { };
            string[] Right = new string[] { };
            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand(query, Connect.cnn);
            SqlDataReader reader = command.ExecuteReader();
            string sql_alter = "";
            string sql_Insert = "";
            string sql_Select = "";
            while (reader.Read())
            {
                Array.Resize(ref Table_User, Table_User.Length + 1);
                Table_User[Table_User.Length - 1] = reader["Object"].ToString() + "." + reader["Grantee"].ToString();
                Array.Resize(ref Right, Right.Length + 1);
                Right[Right.Length - 1] = "." + reader["Action"].ToString();

            }
            for (int i = 0; i < Table_User.Length; i++)
            {

                if (Table_User[i] + Right[i] == Table_User[i] + ".ALTER")
                {
                    sql_alter += Table_User[i] + Right[i];
                    if (sql_alter == Table_User[0] + ".ALTER")
                    {
                        Data_entry.Visibility = Visibility.Visible;
                    }
                }
            }
            for (int i = 0; i < Table_User.Length; i++)
            {
                if (Table_User[i] + Right[i] == Table_User[i] + ".Insert")
                {
                    sql_Insert += Table_User[i] + Right[i];
                    if (sql_Insert == Table_User[0] + ".Insert")
                    {
                        Data_editing.Visibility = Visibility.Visible;
                    }
                }
            }
            for (int i = 0; i < Table_User.Length; i++)
            {
                if (Table_User[i] + Right[i] == Table_User[i] + ".Select")
                {
                    sql_Select += Table_User[i] + Right[i];
                    if (sql_Select == Table_User[0] + ".Select")
                    {
                        Data_output.Focus();
                        Data_output.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        public void USER()
        {

        }
    }
}
