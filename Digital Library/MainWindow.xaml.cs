using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Digital_Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            InitializeComponent();
            DatabaseConnection dbconnect = new DatabaseConnection();

             void Window_Loaded(object sender, RoutedEventArgs e)
            {
                DataTable books = dbconnect.GetBooks();
                MessageBox.Show($"Fetched {books.Rows.Count} books from the database!");
            }

        }
    }
}
