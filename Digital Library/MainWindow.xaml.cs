using System.Windows;

namespace Digital_Library
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
            MainFrame.Content = new HomePageView();
        }

      
        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddBookView(); 
        }


        private void btnViewLibrary_Click(object sender, RoutedEventArgs e)
        {
            ViewLibrary viewLibraryWindow = new ViewLibrary();
            viewLibraryWindow.Show();
        }



        private void btnViewInsights_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new InsightsView();
        }
    }
}
