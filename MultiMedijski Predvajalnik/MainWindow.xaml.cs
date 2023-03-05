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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiMedijski_Predvajalnik {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }

        private void Izhod_Click(object sender, RoutedEventArgs e) {
            // Zaprite program ob kliku na »Izhod« v glavnem meniju aplikacije
            this.Close();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            // Dobimo izbrano postavko
            ListViewItem item = sender as ListViewItem;
            // Pridobimo ime postavke
            string itemName = item.Content.ToString();
            // Prikažemo obvestilno okno z imenom postavke
            MessageBox.Show("Izbrali ste " + itemName + ".", "Izbira postavke");
        }

        private void lstMultimedia_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) {
            ListViewItem item = sender as ListViewItem;
            if (item != null && item.IsSelected) {
                MessageBox.Show("Izbrana vsebina: " + item.Content.ToString());
                e.Handled = true;
            }
        }
    }
}
