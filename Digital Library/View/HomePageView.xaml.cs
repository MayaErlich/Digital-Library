using System.Windows;
using System.Windows.Controls;

namespace Digital_Library
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
        }

     
        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Content = new AddBookView(); 
        }

 
        private void btnViewLibrary_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Content = new LibraryView(); 
        }

       
        private void btnViewInsights_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Content = new InsightsView(); 
        }
    }
}
