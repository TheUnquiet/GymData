using Assembly.WPF.Models;
using Assembly.WPF.Reservations;
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
    /// Interaction logic for ShowMemberWindow.xaml
    /// </summary>
    public partial class ShowMemberWindow : Window
    {
        public Member Member { get; set; }
        public ShowMemberWindow(Member member)
        {
            InitializeComponent();
            Member = member;
            DataContext = Member;
            LoadMemberDetails();
        }

        private void LoadMemberDetails()
        {
            AdressLabel.Content = Member.Address;
            NameLabel.Content = $"{Member.FirstName} {Member.LastName}";
            EmailLabel.Content = Member.Email;
            BirthdayLabel.Content = Member.Birthday.ToString("d");
            IntrestLabel.Content = Member.Intrest ?? "No Intrest";
            MemberTypeLabel.Content = Member.MemberType;

            ProgramsListBox.ItemsSource = Member.Programs;
            ReservationsListBox.ItemsSource = Member.Reservations;
            CyclingSessionsListBox.ItemsSource = Member.CyclingssesionDomains;
            RunningSessionsListBox.ItemsSource = Member.RunningSessionDomains;
        }

        private void CloseWindowClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddReservationButtonClick(object sender, RoutedEventArgs e)
        {
            AddReservationWindow addReservationWindow = new AddReservationWindow(Member);
            addReservationWindow.Show();
        }
    }
}
