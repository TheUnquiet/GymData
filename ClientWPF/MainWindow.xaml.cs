using Assembly.WPF.Members;
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

        private void SearchMemberById(object sender, RoutedEventArgs e)
        {
            SearchMemberWindow smw = new SearchMemberWindow();
            smw.Show();
        }

        private void AddMember(object sender, RoutedEventArgs e)
        {
            AddMemberWindow adw = new AddMemberWindow();
            adw.Show();
        }
    }
}