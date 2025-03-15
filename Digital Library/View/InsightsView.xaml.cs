using System;
using System.Data;
using System.Windows;
using Digital_Library.Models;

namespace Digital_Library
{
    public partial class InsightsView : Window
    {
        private DatabaseConnection dbconnect;

        
        

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the Insights view window
        }
    }
}
