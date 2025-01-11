using Assembly.WPF.Models;
using Assembly.WPF.Reservations;
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

namespace Assembly.WPF.Members
{
    /// <summary>
    /// Interaction logic for SearchMemberWindow.xaml
    /// </summary>
    public partial class SearchMemberWindow : Window
    {
        private readonly ApiService _service;

        public SearchMemberWindow()
        {
            InitializeComponent();
            _service = new ApiService();
        }

        private async void SearchMemberClick(object sender, RoutedEventArgs e)
        {
            Member member = new Member();

            var response = await _service.GetMember(int.Parse(MemberId.Text));

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);


                    // Deserialize the JSON content into a Reservation object
                    member = JsonSerializer.Deserialize<Member>(content);

                    // Check if the deserialization was successful
                    if (member != null)
                    {
                        // Show the reservation window with the fetched data
                        ShowMemberWindow smw = new ShowMemberWindow(member);
                        smw.Show();
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
        }
    }
}
