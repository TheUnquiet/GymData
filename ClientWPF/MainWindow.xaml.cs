using Assembly.WPF.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;
        private List<Equipment> _equipment;
        private readonly List<TimeSlot> _timeSlots;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5062/api/Reservation");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _equipment = new List<Equipment>();
            _timeSlots = new List<TimeSlot>();

            LoadEquipmentData();
        }

        private async void SubmitReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedEquipment = EquipmentComboBox.SelectedItem as Equipment;
                var selectedTimeSlot = TimeSlotComboBox.SelectedItem as TimeSlot;

                if (selectedEquipment == null || selectedTimeSlot == null)
                {
                    StatusTextBlock.Text = "Please select equipment and time slot.";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    LoadingTextBlock.Visibility = Visibility.Collapsed;
                    return;
                }

                var reservation = new Reservation()
                {
                    Date = DateOnly.Parse(DateTextBox.Text),
                    EquipmentId = selectedEquipment.Id,
                    MemberId = int.Parse(MemberIdTextBox.Text),
                    TimeSlotId = selectedTimeSlot.
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(reservation), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    StatusTextBlock.Text = "Reservation added successfully!";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    StatusTextBlock.Text = $"Error: {error}";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            catch (FormatException)
            {
                StatusTextBlock.Text = "Invalid date format. Use yyyy-MM-dd.";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Exception: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private async void LoadEquipmentData()
        {
            try
            {
                var response = await _httpClient.GetAsync("Equipment");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _equipment = JsonSerializer.Deserialize<List<Equipment>>(content);
                    EquipmentComboBox.ItemsSource = _equipment;
                }
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error loading equipment: {ex.Message}";
                StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
    }
}