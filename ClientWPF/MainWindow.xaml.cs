using Assembly.WPF.Reservations;
using System.Windows;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddReservationButtonClick(object sender, RoutedEventArgs e)
        {
            AddReservationWindow arw = new AddReservationWindow();
            arw.Show();
        }

        private void SearchReservationClick(object sender, RoutedEventArgs e)
        {
            SearchReservationWindow srw = new SearchReservationWindow();
            srw.Show();
        }
    }
}