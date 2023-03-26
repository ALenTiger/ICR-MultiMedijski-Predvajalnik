using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMedijski_Predvajalnik {
    public class MultiMedijskiElement : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        string video_path;
        string thumbnail_path;
        string name;
        string category;
        string description;
        bool mature_content;

        bool debug_ignore_check = true;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MultiMedijskiElement(string video_path, string thumbnail_path, string name="brez imena", string category="brez kategorije", string description="brez opisa", bool mature_content=false) {
            Name = name;
            VideoPath = video_path;
            ThumbnailPath = thumbnail_path;
            Category = category;
            Description = description;
            MatureContent = mature_content;
        }

        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Ime ne sme biti prazno.");
                }
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string VideoPath {
            get { return video_path; }
            set {
                if (!File.Exists(value) && !debug_ignore_check) {
                    throw new FileNotFoundException("Videoposnetek ne obstaja v datotečnem sistemu.", value);
                }
                video_path = value;
                OnPropertyChanged("VideoPath");
            }
        }

        public string ThumbnailPath {
            get { return thumbnail_path; }
            set {
                if (!File.Exists(value) && !debug_ignore_check) {
                    throw new FileNotFoundException("Slika za thumbnail ne obstaja v datotečnem sistemu.", value);
                }
                thumbnail_path = value;
            }
        }

        public string Category {
            get { return category; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Kategorija ne sme biti prazno.");
                }
                category = value;
            }
        }

        public string Description {
            get { return description; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Opis ne sme biti prazno.");
                }
                description = value;
            }
        }

        public bool MatureContent {
            get { return mature_content; }
            set { mature_content = value; }
        }

        public override string ToString() {
            string output = String.Format("\n name: {0}\n video path: {1}\n thumbnail path: {2}\n category: {3}\n description: {4}\n mature content: {5} ", name, video_path, thumbnail_path, category, description, mature_content);
            return output; // ali karkoli drugega želite vrniti kot niz
        }
    }
}
