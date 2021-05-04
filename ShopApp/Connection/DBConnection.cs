using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Npgsql;

namespace ShopApp.Connection
{
    public class DBConnection
    {
        private static string con = "Host=localhost;Username=postgres;Password=postgres;Database=shop_db";

        public static List<List<object>> DoSqlCommand(string sql, int columns)
        {
            List<List<object>> data = new List<List<object>>();
            
            using (var conn = new NpgsqlConnection(con))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var list = new List<object>();
                    for(int i = 0; i < columns; i++)
                        list.Add(reader[i]); 
                    data.Add(list);
                }
            }

            return data;
        }

        public static void DoSqlCommand(string sql)
        {
            try
            {
                using (var conn = new NpgsqlConnection(con))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}