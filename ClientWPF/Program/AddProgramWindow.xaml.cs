using Assembly.WPF.Models;
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

namespace Assembly.WPF.Program
{
    /// <summary>
    /// Interaction logic for AddProgramWindow.xaml
    /// </summary>
    public partial class AddProgramWindow : Window
    {
        private readonly ApiService _apiService;
        private List<ProgramModel> _programs;

        public AddProgramWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _programs = new List<ProgramModel>();
        }

        private async void AddProgramClick(object sender, RoutedEventArgs e)
        {
            ProgramModel program = new ProgramModel
            {
                ProgramCode = ProgramCodeTextBox.Text,
                Name = NameTextBox.Text,
                Target = TargetTextBox.Text,
                StartDate = DateTime.Parse(StartDateTextBox.Text),
                MaxMembers = int.Parse(MaxMembersTextBox.Text)
            };

            await _apiService.CreateProgram(program);

            AllProgramsWindow apw = new AllProgramsWindow();
            apw.Show();

            Close();
        }

       
    }
}
