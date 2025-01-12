using Assembly.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assembly.WPF.Program
{
    /// <summary>
    /// Interaction logic for AllProgramsWindow.xaml
    /// </summary>
    public partial class AllProgramsWindow : Window
    {
        private readonly ApiService _apiService;

        public AllProgramsWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadPrograms();
        }

        private async void LoadPrograms()
        {
            try
            {
                var response = await _apiService.GetProgramData();
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ProgramListBox.ItemsSource = JsonSerializer.Deserialize<List<ProgramModel>>(content);
                }
                else
                {
                    MessageBox.Show("Error", "Error loading equipment data.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", $"Error loading equipment: {ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
