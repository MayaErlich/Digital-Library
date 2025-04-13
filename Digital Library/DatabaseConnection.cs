using Digital_Library.Models;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
                                   "JOIN genre g ON b.GenreID = g.GenreID";
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

        public double GetAveragePages()
        {
            double avg = 0;
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT AVG(Length) FROM books";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        avg = Convert.ToDouble(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return avg;
        }
        public string GetFavoriteGenre()
        {
            string favorite = "N/A";
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT g.GenreName, COUNT(*) AS Count 
                             FROM books b
                             JOIN genre g ON b.GenreID = g.GenreID
                             GROUP BY g.GenreName
                             ORDER BY Count DESC
                             LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        favorite = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return favorite;
        }
        public DataTable GetInsights()
        {
            using (MySqlConnection conn = GetConnection())
            {
                DataTable insightsTable = new DataTable();
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    ROUND(AVG(length)) AS avgpages,
                    (
                        SELECT g.Genrename 
                        FROM genre g
                        JOIN books b ON b.genreID = g.genreID
                        GROUP BY g.Genrename 
                        ORDER BY COUNT(*) DESC 
                        LIMIT 1
                    ) AS favgenre
                FROM books;
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(insightsTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading insight");
                }

                return insightsTable;
            }
        }






    }
}
