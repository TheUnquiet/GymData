using Assembly.WPF.Models;
using System.Text.Json;
using System.Windows;
using System.Windows.Documents;

namespace Assembly.WPF.Reservations
{
    /// <summary>
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        private readonly Member _member;
        private readonly ApiService _apiService;
        private List<Equipment> _equipment;

        public AddReservationWindow(Member member)
        {
            InitializeComponent();

            _apiService = new ApiService();
            _equipment = new List<Equipment>();
            _member = member;

            LoadTimeSlotsData();
            LoadEquipmentData();

            MemberTextBox.Text = _member.ToString();
        }

        private void SubmitReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reservation = new Reservation
                {
                    ReservationDate = string.IsNullOrEmpty(DateTextBox.Text) ? DateOnly.FromDateTime(DateTime.Now).AddDays(1) : DateOnly.Parse(DateTextBox.Text),
                    MemberId = _member.MemberId,
                    Equipment = YourEquipmentListBox.Items.Cast<Equipment>().ToList(),
                    TimeSlots = YourTimeSlotListBox.Items.Cast<TimeSlot>().ToList()
                };
                SaveReservation(reservation);
                Close();
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
                    var timeSlots = JsonSerializer.Deserialize<List<TimeSlot>>(content);
                    AllTimeSlotListBox.ItemsSource = timeSlots;

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

        private void AllTimeSlotListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (AllTimeSlotListBox.SelectedItem is TimeSlot selectedTimeSlot)
            {
                YourTimeSlotListBox.Items.Add(selectedTimeSlot);
                var selectEquipmentWindow = new SelectEquipmentWindow(_equipment);
                if (selectEquipmentWindow.ShowDialog() == true)
                {
                    var selectedEquipment = selectEquipmentWindow.SelectedEquipment;
                    var reservation = new Reservation
                    {
                        ReservationDate = string.IsNullOrEmpty(DateTextBox.Text) ? DateOnly.FromDateTime(DateTime.Now).AddDays(1) : DateOnly.Parse(DateTextBox.Text),
                        MemberId = _member.MemberId,
                    };
                    reservation.Equipment.Add(selectedEquipment);
                    reservation.TimeSlots.Add(selectedTimeSlot);
                }
                YourEquipmentListBox.Items.Add(selectEquipmentWindow.SelectedEquipment);
            }
        }

        private async void SaveReservation(Reservation reservation)
        {
            try
            {
                var response = await _apiService.CreateReservation(reservation);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reservation created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error creating reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
