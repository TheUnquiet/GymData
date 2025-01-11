using Assembly.WPF.Models;
using System.Text.Json;
using System.Windows;

namespace Assembly.WPF.Reservations
{
    /// <summary>
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        private readonly ApiService _apiService;
        private List<Equipment> _equipment;
        private List<TimeSlot> _timeSlots;

        public AddReservationWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();

            _equipment = new List<Equipment>();
            _timeSlots = new List<TimeSlot>();

            LoadEquipmentData();
            LoadTimeSlotsData();
        }

        private void SubmitReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("yeah yeah yeah");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date format. Use yyyy-MM-dd.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadEquipmentData()
        {
            try
            {
                var response = await _apiService.GetEquipmentData();
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _equipment = JsonSerializer.Deserialize<List<Equipment>>(content);

                    EquipmentComboBox.ItemsSource = _equipment;
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

        private async void LoadTimeSlotsData()
        {
            try
            {
                var response = await _apiService.GetTimeSlotsData();
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _timeSlots = JsonSerializer.Deserialize<List<TimeSlot>>(content);
                    TimeSlotComboBox.ItemsSource = _timeSlots;
                }
                else
                {
                    MessageBox.Show("Error", "Error loading time slots data.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", $"Error loading time slots: {ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
