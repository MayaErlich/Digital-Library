using System;
using System.Data;
using System.Windows;
using Digital_Library.Models;

namespace Digital_Library
{
    public partial class ViewLibrary : Window
    {
        private DatabaseConnection dbconnect;

        public ViewLibrary()
        {
            InitializeComponent();
            dbconnect = new DatabaseConnection();
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                DataTable books = dbconnect.GetBooks(); 
                BooksDataGrid.ItemsSource = books.DefaultView; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
