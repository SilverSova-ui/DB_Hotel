using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DB_Hotel_prototip_
{
    class Filters
    {
        public void return_main()
        {
            MainWindow transition = new MainWindow();
            transition.Show();
        }

        public void return_authoriazation()
        {
            buffer.login = null;
            buffer.password = null;
            Authoriazation transition = new Authoriazation();
            transition.Show();
        }

        public void build_Change(Grid Grid_Change, CheckBox[] array_check, string[] t_box_name, string[] content)
        {
            int q = 0;
            int[] Coordinates_label_x = new int[] { 30, 455 };
            int[] Coordinates_label_y = new int[] { 145, 145, 206, 206, 268, 268, 330, 330, 407, 399, 471, 471, 539, 539 };
            int[] t_box_coordinates_x = new int[] { 176, 597 };
            int[] t_box_coordinates_y = new int[] { 145, 145, 206, 206, 268, 268, 336, 336, 407, 407, 471, 471, 539, 539 };
            for (int i = 0; i < array_check.Length; i++)
            {
                if (Grid_Change.FindName(t_box_name[i]) != null)
                {
                    Grid_Change.UnregisterName(t_box_name[i]);
                }
            }
            for (int i = 0; i < array_check.Length; i++)
            {
                if (array_check[i].IsChecked == true)
                {
                    Label label = new Label();
                    label.Content = content[i];
                    label.HorizontalAlignment = HorizontalAlignment.Left;
                    label.VerticalAlignment = VerticalAlignment.Top;
                    label.FontSize = 16;
                    label.Margin = new Thickness(Coordinates_label_x[q % 2], Coordinates_label_y[q], 0, 0);

                    TextBox t_box = new TextBox();
                    Grid_Change.RegisterName(t_box.Name = t_box_name[i], t_box);
                    t_box.HorizontalAlignment = HorizontalAlignment.Left;
                    t_box.Height = 32;
                    t_box.Margin = new Thickness(t_box_coordinates_x[q % 2], t_box_coordinates_y[q], 0, 0);
                    t_box.TextWrapping = TextWrapping.Wrap;
                    t_box.Text = "";
                    t_box.FontSize = 20;
                    t_box.VerticalAlignment = VerticalAlignment.Top;
                    t_box.Width = 207;

                    Grid_Change.Children.Add(t_box);
                    Grid_Change.Children.Add(label);
                    q = q + 1;
                }
            }
        }

        public void Filter(string[] array, CheckBox[] array_check, string[] query_output_name, string[] array_ru_name, DataGrid table, string sql_query, string db)
        {
            Query_output Query = new Query_output();
            for (int i = 0; i < array_check.Length; i++)
            {
                if (array_check[i].IsChecked == true)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = query_output_name[i] + array_ru_name[i];
                }
            }
            if (array.Length != 0)
            {
                string sql = "select ";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array.Length > 1)
                    {
                        sql += array[i] + ",";
                    }
                    else
                    {
                        sql += array[i];
                    }
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                }
                sql += " from dbo." + db;
                Query.Output(sql, db, table);
            }
            else
            {
                Query.Output(sql_query, db, table);
            }
        }

        public void explorer_Filter(string sql,string sql_query ,string[] array, CheckBox[] array_check, string[] query_output_name, string[] array_ru_name,string[] explore ,ComboBox explorer_box, TextBox explorer_textBox, string db, DataGrid table)
        {
            if (explorer_textBox.Text == string.Empty)
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else
            {
                for (int i = 0; i < array_check.Length; i++)
                {
                    if (array_check[i].IsChecked == true)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = query_output_name[i] + array_ru_name[i] + ",";
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    sql += array[i];
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                    sql += " from dbo." + db;
                }
                else
                {
                    sql = sql_query;
                }
                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        sql += " WHERE " + query_output_name[i] + " LIKE ";
                    }
                }
                if (explorer_textBox.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    sql += string.Format("\'{0}\'", "%"+ explorer_textBox.Text + "%") + ";";
                }
                explorer_textBox.Clear();
                Query_output Query = new Query_output();
                Query.Output(sql, db, table);
            }

        }

        public void Filter_Query(string[] array, CheckBox[] array_check, string[] query_output_name, string[] array_ru_name, DataGrid table, string sql_query, string db, string sql_fil_end)
        {
            Query_output Query = new Query_output();
            for (int i = 0; i < array_check.Length; i++)
            {
                if (array_check[i].IsChecked == true)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = query_output_name[i] + array_ru_name[i];
                }
            }
            if (array.Length != 0)
            {
                string sql = "select ";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array.Length > 1)
                    {
                        sql += array[i] + ",";
                    }
                    else
                    {
                        sql += array[i];
                    }
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                }
                sql += sql_fil_end;
                Query.Output(sql, db, table);
            }
            else
            {
                Query.Output(sql_query, db, table);
            }
        }

        public void explorer_Query_Fil(string sql, string sql_query, string[] array, CheckBox[] array_check, string[] query_output_name, string[] array_ru_name, string[] explore, ComboBox explorer_box, TextBox explorer_textBox, string db, DataGrid table, string sql_fil_end)
        {
            if (explorer_textBox.Text == string.Empty)
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else if(explorer_box.ItemsSource == new TextBlock())
            {
                MessageBox.Show("Поле поиска пустое", "Уведомление");
            }
            else
            {
                for (int i = 0; i < array_check.Length; i++)
                {
                    if (array_check[i].IsChecked == true)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = query_output_name[i] + array_ru_name[i] + ",";
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    sql += array[i];
                }
                if (sql.EndsWith(","))
                {
                    sql = sql.Remove(sql.Length - 1);
                    sql += sql_fil_end;
                }
                else
                {
                    sql = sql_query;
                }
                for (int i = 0; i < explore.Length; i++)
                {
                    if (explorer_box.Text == explore[i])
                    {
                        sql += " WHERE " + query_output_name[i] + " LIKE ";
                    }
                }
                if (explorer_textBox.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    sql += string.Format("\'{0}\'", "%" + explorer_textBox.Text + "%") + ";";
                }
                explorer_textBox.Clear();
                Query_output Query = new Query_output();
                Query.Output(sql, db, table);
            }
        }

        public void clearing(TextBox[] text_Box_input)
        {
            for (int i = 0; i < text_Box_input.Length; i++)
            {
                text_Box_input[i].Clear();
            }
        }

        public void clearing_fields(CheckBox[] array_check)
        {
            for (int i = 0; i < array_check.Length; i++)
            {
                array_check[i].IsChecked = false;
            }
        }
    }
}
