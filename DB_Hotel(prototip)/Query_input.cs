using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DB_Hotel_prototip_
{
    class Query_input
    {
        public void sql_build_input(string sql, string [] query_input_name, string[] text_Box_input)
        {
            Query_input Query = new Query_input();
            for (int i = 0; i < query_input_name.Length; i++)
            {
                sql += query_input_name[i] + ",";
            }
            if (sql.EndsWith(","))
            {
                sql = sql.Remove(sql.Length - 1);
            }
            sql += ") values (";
            for (int i = 0; i < text_Box_input.Length; i++)
            {
                if (text_Box_input[i].Trim() == string.Empty)
                {

                }
                else
                {
                    sql += string.Format("\'{0}\'", text_Box_input[i]) + ",";
                }
            }
            if (sql.EndsWith(","))
            {
                sql = sql.Remove(sql.Length - 1);
            }
            sql += ")";
            Query.input(sql);
        }


        public void sql_build_Change(string sql, TextBox ID, string text_ID, CheckBox [] array_check, string[] t_box_name, string[] query_input_name,Grid Grid_Change)
        {
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
                        MessageBox.Show("Поле было пустое", "Уведомление");
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
            sql += text_ID + ID.Text + ";";
            Query_input Query = new Query_input();
            Query.input(sql);
        }

        public void delete(string sql, TextBox Delet, string db)
        {
            if (Delet.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Поле удаление пустое", "Уведомление");
            }
            else
            {
                Query_input Query = new Query_input();
                Query.input(sql);
            }
        }

        public void input(string query)
        {
            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand(query, Connect.cnn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Данные не отправлены", "Уведомление");
            }
            conn.disconnection();
        }

        public void report(string[] Field_name, string[] query_output_name, string[] array, string[] line, string[] explore, CheckBox[] array_check,ComboBox explorer_box,TextBox explorer_textBox, string sql_fil_end, string full_sql)
        {
            dynamic Excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var wb = Excel.Workbooks.Add();
            Excel.DisplayAlerts = false;
            var sh = wb.Sheets[1];

            for (int t = 0; t < array_check.Length; t++)
            {
                if (array_check[t].IsChecked == true)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = query_output_name[t];
                }
            }
            if (array.Length != 0)
            {
                string sql = "select ";
                for (int t = 0; t < array.Length; t++)
                {
                    if (array.Length > 1)
                    {
                        sql += array[t] + ",";
                    }
                    else
                    {
                        sql += array[t];
                    }
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                }
                sql += sql_fil_end;

                Connect conn = new Connect();

                int p = 1;
                int z = 2;
                int j = 1;

                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        sql += " WHERE " + query_output_name[i] + " LIKE ";
                        sql += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                    }
                }

                for (int q = 0; q < array_check.Length; q++)
                {
                    if (array_check[q].IsChecked == true)
                    {
                        conn.connection();
                        SqlCommand command = new SqlCommand(sql, Connect.cnn);
                        SqlDataReader reader = command.ExecuteReader();
                        sh.Cells[1, p].value = Field_name[q];
                        p = p + 1;

                    while (reader.Read())
                    {
                        Array.Resize(ref line, line.Length + 1);
                        line[line.Length - 1] = reader[query_output_name[q]].ToString();
                    }
                    conn.disconnection();
                    for (int i = 0; i < line.Length; i++)
                    {
                        sh.Cells[z, j].value = line[i];
                        z = z + 1;
                    }
                        z = 2;
                        j = j + 1;

                        line = new string[] { };
                    }
                }

                Excel.visible = true;
            }
            else
            {

                int p = 1;
                int z = 2;
                int j = 1;

                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        full_sql += " WHERE " + query_output_name[i] + " LIKE ";
                        full_sql += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                    }
                }

                for (int q = 0; q < Field_name.Length; q++)
                {
                    sh.Cells[1, p].value = Field_name[q];
                    p = p + 1;
                    Connect conn = new Connect();
                    conn.connection();
                    SqlCommand command = new SqlCommand(full_sql, Connect.cnn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Array.Resize(ref line, line.Length + 1);
                        line[line.Length - 1] = reader[query_output_name[q]].ToString();
                    }
                    conn.disconnection();
                    for (int i = 0; i < line.Length; i++)
                    {
                        sh.Cells[z, j].value = line[i];
                        z = z + 1;
                    }
                    z = 2;
                    j = j + 1;
                    line = new string[] { };
                }
                Excel.visible = true;
            }
        }


        public void report_query(string[] Field_name, string[] query_output_name, string[] query_input_name, string[] array, string[] line, string[] explore, CheckBox[] array_check, ComboBox explorer_box, TextBox explorer_textBox, string sql_fil_end, string full_sql)
        {
            dynamic Excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var wb = Excel.Workbooks.Add();
            Excel.DisplayAlerts = false;
            var sh = wb.Sheets[1];

            for (int t = 0; t < array_check.Length; t++)
            {
                if (array_check[t].IsChecked == true)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = query_input_name[t];
                }
            }
            if (array.Length != 0)
            {
                string sql = "select ";
                for (int t = 0; t < array.Length; t++)
                {
                    if (array.Length > 1)
                    {
                        sql += array[t] + ",";
                    }
                    else
                    {
                        sql += array[t];
                    }
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                }
                sql += sql_fil_end;

                Connect conn = new Connect();

                int p = 1;
                int z = 2;
                int j = 1;

                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        sql += " WHERE " + query_input_name[i] + " LIKE ";
                        sql += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                    }
                }
                int o = 0;
                for (int q = 0; q < array_check.Length; q++)
                {
                    if (array_check[q].IsChecked == true)
                    {
                        conn.connection();
                        SqlCommand command = new SqlCommand(sql, Connect.cnn);
                        SqlDataReader reader = command.ExecuteReader();
                        sh.Cells[1, p].value = Field_name[q];
                        p = p + 1;


                        while (reader.Read())
                        {
                            Array.Resize(ref line, line.Length + 1);
                            line[line.Length - 1] = reader.GetValue(o).ToString();
                        }
                        o = o + 1;
                        conn.disconnection();
                        for (int i = 0; i < line.Length; i++)
                        {
                            sh.Cells[z, j].value = line[i];
                            z = z + 1;
                        }
                        z = 2;
                        j = j + 1;

                        line = new string[] { };
                    }
                }
                Excel.visible = true;
            }
            else
            {

                int p = 1;
                int z = 2;
                int j = 1;

                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        full_sql += " WHERE " + query_input_name[i] + " LIKE ";
                        full_sql += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                    }
                }

                for (int q = 0; q < Field_name.Length; q++)
                {
                    sh.Cells[1, p].value = Field_name[q];
                    p = p + 1;
                    Connect conn = new Connect();
                    conn.connection();
                    SqlCommand command = new SqlCommand(full_sql, Connect.cnn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Array.Resize(ref line, line.Length + 1);
                        line[line.Length - 1] = reader.GetValue(q).ToString();
                    }
                    conn.disconnection();
                    for (int i = 0; i < line.Length; i++)
                    {
                        sh.Cells[z, j].value = line[i];
                        z = z + 1;
                    }
                    z = 2;
                    j = j + 1;
                    line = new string[] { };
                }
                Excel.visible = true;
            }
        }
    }
}
