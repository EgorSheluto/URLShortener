using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LinkShorteningService
{
    class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = string.Format(@"Server={0};Database={1};port={2};User id={3};Password={4};", 
                host, database, port, username, password);
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }

        public static void DeleteUrlInfo(string query, MySqlConnection conn, int rowId)
        {
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = string.Format(query, rowId);
            command.ExecuteNonQuery();
        }

       /* public static int UrlSelector(string query, MySqlConnection conn, string condition)
        {
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = string.Format(query, condition);
            int count = command.ExecuteNonQuery();

            return count;
        }*/

        public static void QuerysUrlInfo(string query, MySqlConnection conn)
        {
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public static object ScalarUrlInfo(string query, MySqlConnection conn)
        {
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
    }
}
