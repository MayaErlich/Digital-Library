using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient; 

namespace Digital_Library
{
    public partial class MainWindow : Window
    {
        private DatabaseConnection dbconnect;

        public MainWindow()
        {
            InitializeComponent();
            dbconnect = new DatabaseConnection(); 
            Loaded += Window_Loaded; 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable books = dbconnect.GetBooks();
            MessageBox.Show($"Fetched {books.Rows.Count} books from the database!");
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();
            db.TestConnection();
        }
    }
}
