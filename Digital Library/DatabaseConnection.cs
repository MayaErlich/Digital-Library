using Digital_Library.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            DataTable books = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT b.Title, b.Author, g.GenreName, b.Length FROM books b " +
                                   "JOIN genres g ON b.GenreID = g.GenreID";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(books);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching books: " + ex.Message);
            }
            return books;
        }

        public bool AddBook(Books book)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO books (title, author, genreid, length) VALUES (@Title, @Author, @GenreID, @Length)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@GenreID", book.GenreID);
                    cmd.Parameters.AddWithValue("@Length", book.Length);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        public DataTable GetGenres()
        {
            using (MySqlConnection conn = GetConnection())
            {
                DataTable genreTable = new DataTable();
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Genre"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(genreTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return genreTable;
            }
        }



    }
}
