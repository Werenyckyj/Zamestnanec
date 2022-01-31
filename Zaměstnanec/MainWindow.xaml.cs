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
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.Globalization;

namespace Zamestnanec
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    class Worker : INotifyPropertyChanged
    {
        private string _Jmeno, _Prijmeni, _Misto, _Plat;
        private DateTime _Narozeni;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Jmeno
        {
            get => _Jmeno;
            set
            {
                _Jmeno = value;
                OnPropertyChanged("Jmeno");
                OnPropertyChanged("Status");
            }
        }
        public string Prijmeni
        {
            get => _Prijmeni;
            set
            {
                _Prijmeni = value;
                OnPropertyChanged("Prijmeni");
                OnPropertyChanged("Status");
            }
        }
        public string Misto
        {
            get => _Misto;
            set
            {
                _Misto = value;
                OnPropertyChanged("Misto");
                OnPropertyChanged("Status");
            }
        }
        public string Plat
        {
            get => _Plat;
            set
            {
                _Plat = value;
                OnPropertyChanged("Plat");
                OnPropertyChanged("Status");
            }
        }
        public DateTime Narozeni
        {
            get => _Narozeni;
            set
            {
                _Narozeni = value;
                OnPropertyChanged("Narozeni");
                OnPropertyChanged("Status");
            }
        }

        public string Status
        {
            get => Jmeno + " " + Prijmeni + " " + Narozeni.ToString();
        }

        public override string ToString()
        {
            return Jmeno + " " + Prijmeni + " " + Narozeni.ToShortDateString();
        }

        // pomocná metoda pro informaci o změně v datech
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) // jestli někdo poslouchá ...
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    public partial class MainWindow : Window
    {
        Worker z;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = z = new Worker()
            {
                Narozeni = DateTime.Now()
            };
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            z.Jmeno = z.Prijmeni = z.Misto = z.Plat = string.Empty;
            z.Narozeni = DateTime.Now;
        }
    }
}
