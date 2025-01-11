using Assembly.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace Assembly.WPF.Reservations
{
    /// <summary>
    /// Interaction logic for SearchReservationWindow.xaml
    /// </summary>
    public partial class SearchReservationWindow : Window
    {
        private ApiService _service;

        public SearchReservationWindow()
        {
            InitializeComponent();
            _service = new ApiService();
        }

        private async void SearchReservationClick(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();

            var response = await _service.GetReservation(int.Parse(ReservationId.Text));

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);


                    // Deserialize the JSON content into a Reservation object
                    reservation = JsonSerializer.Deserialize<Reservation>(content);

                    // Check if the deserialization was successful
                    if (reservation != null)
                    {
                        // Show the reservation window with the fetched data
                        ShowReservationWindow srw = new ShowReservationWindow(reservation);
                        srw.Show();
                    }
                    else
                    {
                        // Handle case when deserialization fails (returns null)
                        MessageBox.Show("Failed to parse reservation data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (JsonException ex)
                {
                    // Log and show deserialization errors
                    MessageBox.Show($"Error parsing the response: {ex.Message}", "Deserialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("Error", "Error loading reservation data.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
