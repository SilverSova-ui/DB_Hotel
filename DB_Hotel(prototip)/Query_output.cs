using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DB_Hotel_prototip_
{
    class Query_output
    {
        public void Output(string query,string db, DataGrid table)
        {

            Connect conn = new Connect();
            conn.connection();
            SqlCommand command = new SqlCommand(query, Connect.cnn);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable(db);
            dataAdp.Fill(dt);
            table.ItemsSource = dt.DefaultView;
            conn.disconnection();
        }
    }
}
