using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiMedijski_Predvajalnik {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public ObservableCollection<MultiMedijskiElement> VideoList { get; set; }
        private MultiMedijskiElement _selectedItem;
        public MultiMedijskiElement SelectedItem {
            get { return _selectedItem; }
            set {
                if (_selectedItem != value) {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public ICommand DodajCommand { get; set; }
        public ICommand OdstraniCommand { get; set; }
        public ICommand UrediCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel() {
            VideoList = new ObservableCollection<MultiMedijskiElement> {
                new MultiMedijskiElement("video1.mp4", "thumbnail1.jpg", "Video 1", "Kategorija 1", "Opis 1", false),
                new MultiMedijskiElement("video2.mp4", "thumbnail2.jpg", "Video 2", "Kategorija 2", "Opis 2", true),
                new MultiMedijskiElement("video3.mp4", "thumbnail3.jpg", "Video 3", "Kategorija 3", "Opis 3", false)
            };

            DodajCommand = new RelayCommand(Dodaj, CanDodaj);
            OdstraniCommand = new RelayCommand(Odstrani, CanOdstrani);
            UrediCommand = new RelayCommand(Uredi, CanUredi);
        }

        private void Dodaj(object parameter) {
            VideoList.Add(new MultiMedijskiElement("video4.mp4", "thumbnail4.jpg", "Video 4", "Kategorija 4", "Opis 4", false));
        }

        private bool CanDodaj(object parameter) {
            return true; // Vedno omogočeno
        }

        private void Odstrani(object parameter) {
            if (SelectedItem != null) {
                VideoList.Remove(SelectedItem);
            }
        }

        private bool CanOdstrani(object parameter) {
            return SelectedItem != null; // Omogočeno, če je izbran element
        }

        private void Uredi(object parameter) {
            if (SelectedItem != null) {
                SelectedItem.VideoPath = "novo-ime-datoteke.mp4";
                SelectedItem.Name = "novo-ime";
            }
        }

        private bool CanUredi(object parameter) {
            return SelectedItem != null; // Omogočeno, če je izbran element
        }

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
