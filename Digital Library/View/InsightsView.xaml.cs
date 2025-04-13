using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Digital_Library
{
    public partial class InsightsPage : Page
    {
        public InsightsPage()
        {
            InitializeComponent();
            LoadInsights();
        }

        private void LoadInsights()
        {
            DatabaseConnection db = new DatabaseConnection();
            DataTable insightsTable = db.GetInsights();

            if (insightsTable.Rows.Count > 0)
            {
                DataRow row = insightsTable.Rows[0];
                AvgPagesText.Text = row["avgpages"].ToString();
                FavGenreText.Text = row["favgenre"].ToString();
            }
            else
            {
                AvgPagesText.Text = "No data available";
                FavGenreText.Text = "No data available";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            main.MainFrame.GoBack();
        }
    }
}
