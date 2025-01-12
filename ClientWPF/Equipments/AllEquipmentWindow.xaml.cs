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

namespace Assembly.WPF.Equipments
{
    /// <summary>
    /// Interaction logic for AllEquipmentWindow.xaml
    /// </summary>
    public partial class AllEquipmentWindow : Window
    {
        public AllEquipmentWindow(List<Equipment> equipment)
        {
            InitializeComponent();
            EquipmentListBox.ItemsSource = equipment;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
