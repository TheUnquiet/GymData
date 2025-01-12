using Assembly.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AddMemberWindow.xaml
    /// </summary>
    public partial class AddMemberWindow : Window
    {
        private readonly ApiService apiService;

        public AddMemberWindow()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        private async void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newMember = new Member
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Address = AddressTextBox.Text,
                    Birthday = BirthdayDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate.Value) : DateOnly.FromDateTime(DateTime.Now),
                    Intrest = InterestTextBox.Text,
                    Reservations = new List<Reservation>(),
                    Programs = new List<ProgramModel>(),
                    CyclingssesionDomains = new List<CyclingSession>(),
                    RunningSessionDomains = new List<RunningSession>()
                };

                await SaveMember(newMember);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding member: {ex.Message}");
            }
        }

        private async Task SaveMember(Member member)
        {
            var response = await apiService.CreateMember(member);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Member saved successfully!");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error saving member: {errorMessage}");
            }
        }
    }
}
