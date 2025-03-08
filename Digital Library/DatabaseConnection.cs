using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library
{
    internal class DatabaseConnection
    {
        private string connectionString = "server=localhost;database=Library;user=root;password=leelawashere123!;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void TestConnection()
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("✅ Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Connection failed: " + ex.Message);
                }
            }
        }


        public DataTable GetBooks()
        {
            using (MySqlConnection conn = GetConnection())
            {
                DataTable booksTable = new DataTable();
                try
                {
                    conn.Open();
                    string query = "USE Library; SELECT * FROM books"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(booksTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return booksTable;
            }
        }
    }
}
