using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// 
    
    public partial class MainWindow : Window {
        public ObservableCollection<MultiMedijskiElement> video_list { get; set; }
        public MainWindow() {
            InitializeComponent();

            /*video_list = new ObservableCollection<MultiMedijskiElement>
            {
                new MultiMedijskiElement("video1.mp4", "thumbnail1.jpg", "Video 1", "Kategorija 1", "Opis 1", false),
                new MultiMedijskiElement("video2.mp4", "thumbnail2.jpg", "Video 2", "Kategorija 2", "Opis 2", true),
                new MultiMedijskiElement("video3.mp4", "thumbnail3.jpg", "Video 3", "Kategorija 3", "Opis 3", false)
            };
            VideoSeznam.Items.Clear();
            VideoSeznam.ItemsSource = video_list;*/
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
