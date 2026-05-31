using SMSProject.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class ResultPrintView : UserControl
    {
        private ResultRepository resultRepository = new ResultRepository();
        public ResultPrintView() { InitializeComponent(); LoadResults(); }
        private void LoadResults()
        {
            try { printResultsGrid.ItemsSource = resultRepository.GetAllResults(); }
            catch (Exception ex) { MessageBox.Show("Błąd: " + ex.Message); }
        }
        private void refreshButton_Click(object sender, RoutedEventArgs e) => LoadResults();
        private void printButton_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Funkcja drukowania do rozbudowy.", "Drukuj");
    }
}
