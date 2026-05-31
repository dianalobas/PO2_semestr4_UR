using Microsoft.Data.SqlClient;
using SMSProject.Data;
using SMSProject.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject
{
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            LoadView(new DashboardView(), "Dashboard");
        }

        // ──────────────────────────────────────────────────────────
        // Obsługa przycisków menu bocznego
        // ──────────────────────────────────────────────────────────
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;

            string section = btn.Content?.ToString() ?? "";

            UserControl? view = btn.Name switch
            {
                "btnRejestracja"           => new StudentRegistrationView(),
                "btnZarzadzanieStudentami" => new StudentManagementView(),
                "btnDrukujStudenta"        => new StudentPrintView(),
                "btnNowyKurs"              => new CourseRegistrationView(),
                "btnZarzadzajKursami"      => new CourseManagementView(),
                "btnDrukujKursy"           => new CoursePrintView(),
                "btnNowyWynik"             => new ResultRegistrationView(),
                "btnZarzadzanieWynikami"   => new ResultManagementView(),
                "btnDrukujWyniki"          => new ResultPrintView(),
                "btnDashboard"             => new DashboardView(),
                "btnRaporty"               => new ReportsView(),
                "btnStatystyki"            => new StatisticsView(),
                _                         => null
            };

            if (view != null) LoadView(view, section);
        }

        private void LoadView(UserControl view, string title)
        {
            sectionTitleText.Text = title;
            contentArea.Children.Clear();
            contentArea.Children.Add(view);
        }

        // ──────────────────────────────────────────────────────────
        // Test połączenia z bazą danych (Zadanie 3 z lab 004)
        // ──────────────────────────────────────────────────────────
        private void TestConnection()
        {
            DBConnection db = new DBConnection();
            try
            {
                using (SqlConnection connection = db.GetConnection())
                {
                    connection.Open();
                    MessageBox.Show("Połączenie z bazą danych nawiązano pomyślnie!",
                                    "Połączenie OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia: " + ex.Message,
                                "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // Przycisk Wyjście
        // ──────────────────────────────────────────────────────────
        private void BtnWyjscie_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
