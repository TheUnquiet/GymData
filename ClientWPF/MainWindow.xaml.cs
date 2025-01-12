using Assembly.WPF.Equipments;
using Assembly.WPF.Members;
using Assembly.WPF.Program;
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

        private void AddEquipment(object sender, RoutedEventArgs e)
        {
            AddEquipmentWindow aew = new AddEquipmentWindow();
            aew.Show();
        }

        private void AddProgram(object sender, RoutedEventArgs e)
        {
            AddProgramWindow apw = new AddProgramWindow();
            apw.Show();
        }
    }
}