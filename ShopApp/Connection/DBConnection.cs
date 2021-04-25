using System.Collections.Generic;
using System.Windows.Documents;
using Npgsql;

namespace ShopApp.Connection
{
    public class DBConnection
    {
        private string con = "Host=localhost;Username=postgres;Password=postgres;Database=shop_db";

        public List<string> DoSqlConnection(string sql, int columns)
        {
            var list = new List<string>();
            
            // using var con = new NpgsqlConnection(cs);
            using (var conn = new NpgsqlConnection(con))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(int i = 0; i < columns; i++)
                        list.Add(reader[i].ToString());                    
                }
            }

            return list;
        }
    }
}