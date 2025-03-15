using System;
using System.Windows;
using Digital_Library.Models;
using System.Data;
using System.Windows.Controls;

namespace Digital_Library
{
    public partial class AddBookView : UserControl
    {
        private DatabaseConnection dbconnect;

        public AddBookView()
        {
            InitializeComponent();
            dbconnect = new DatabaseConnection();
            Loaded += AddBookView_Loaded;
            LoadGenres();
        }

        private void AddBookView_Loaded(object sender, RoutedEventArgs e)
        {
    
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            
                if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

            
                var selectedItem = cbGenre.SelectedItem as System.Windows.Controls.ComboBoxItem;
                int genreID = selectedItem != null ? Convert.ToInt32(selectedItem.Tag) : 0;

         
                int length;
                if (!int.TryParse(txtLength.Text, out length))
                {
                    MessageBox.Show("Please enter a valid number for the length.");
                    return;
                }

           
                Books newBook = new Books
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    GenreID = genreID,
                    Length = length
                };

        
                bool success = dbconnect.AddBook(newBook);

                if (success)
                    MessageBox.Show("Book added successfully!");
                else
                    MessageBox.Show("Failed to add book.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadGenres()
        {
            DataTable genres = dbconnect.GetGenres();

            cbGenre.Items.Clear();
            foreach (DataRow row in genres.Rows)
            {
                var item = new System.Windows.Controls.ComboBoxItem
                {
                    Content = row["GenreName"].ToString(),
                    Tag = row["GenreID"]
                };

                cbGenre.Items.Add(item);
            }
        }
    }
}
