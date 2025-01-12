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

namespace Assembly.WPF.Equipments
{
    /// <summary>
    /// Interaction logic for AddEquipmentWindow.xaml
    /// </summary>
    public partial class AddEquipmentWindow : Window
    {
        private readonly ApiService _apiService;
        private List<Equipment> _equipment;
        public AddEquipmentWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _equipment = new List<Equipment>();
            GetEquipment();
        }

        private async void AddEquipmentClick(object sender, RoutedEventArgs e)
        {
            await _apiService.CreateEquipment(new Equipment
            {
                DeviceType = DevicetypeTextBox.Text,
            });

            AllEquipmentWindow aew = new AllEquipmentWindow(_equipment);
            aew.Show();
            Close();
        }

        private async void GetEquipment()
        {
            try
            {
                var response = await _apiService.GetEquipmentData();
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _equipment = JsonSerializer.Deserialize<List<Equipment>>(content);
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
    }
}
