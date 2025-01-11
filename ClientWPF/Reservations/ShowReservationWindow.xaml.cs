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

namespace Assembly.WPF.Reservations
{
    /// <summary>
    /// Interaction logic for ShowReservationWindow.xaml
    /// </summary>
    public partial class ShowReservationWindow : Window
    {
        private Reservation _reservation;

        public ShowReservationWindow(Reservation reservation)
        {
            InitializeComponent();
            _reservation = reservation;
            ReservationId.Text = _reservation.Id.ToString();
            ReservationDate.Text = _reservation.ReservationDate.ToString("yyyy-MM-dd");
            ReservationMember.Text = _reservation.Member.ToString();
            TimeSlotListBox.ItemsSource = _reservation.TimeSlots;
            EquipmentListBox.ItemsSource = _reservation.Equipment;
        }

        private void DeleteReservationClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("yeah");
        }
    }
}
