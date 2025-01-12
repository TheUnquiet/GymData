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
    /// Interaction logic for SelectEquipmentWindow.xaml
    /// </summary>
    public partial class SelectEquipmentWindow : Window
    {
        public Equipment SelectedEquipment { get; private set; }

        public SelectEquipmentWindow(List<Equipment> equipment)
        {
            InitializeComponent();
            EquipmentListBox.ItemsSource = equipment;
        }

        private void EquipmentListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EquipmentListBox.SelectedItem is Equipment selectedEquipment)
            {
                SelectedEquipment = selectedEquipment;
                DialogResult = true;
                Close();
            }
        }
    }
}
