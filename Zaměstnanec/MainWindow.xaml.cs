using System;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Globalization;

namespace Zamestnanec
{
    class Person : INotifyPropertyChanged
    {
        private DateTime _Narozeni;
        private string _Jmeno, _Prijmeni;
        private enum _Vzdelani { }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Jmeno
        {
            get => _Jmeno;
            set
            {
                _Jmeno = value;
                OnPropertyChanged("Jmeno");
            }
        }
        public string Prijmeni
        {
            get => _Prijmeni;
            set
            {
                _Prijmeni = value;
                OnPropertyChanged("Prijmeni");
            }
        }
        public DateTime Narozeni
        {
            get => _Narozeni;
            set
            {
                _Narozeni = value;
                OnPropertyChanged("Narozeni");
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) // jestli někdo poslouchá ...
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    class Worker : Person
    {
        private string _Misto, _Plat;

        public new event PropertyChangedEventHandler PropertyChanged;

        public string Misto
        {
            get => _Misto;
            set
            {
                _Misto = value;
                OnPropertyChanged("Misto");
            }
        }
        public string Plat
        {
            get => _Plat;
            set
            {
                _Plat = value;
                OnPropertyChanged("Plat");
            }
        }
        public enum Vzdelani
        {

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
        Worker z = new Worker();
        public MainWindow()
        {
            InitializeComponent();
            cbVz.Items.Add("Základní vzdělání");
            cbVz.Items.Add("Středoškolské vzdělání");
            cbVz.Items.Add("Vysokoškolské vzdělání");
            for (int i = 2022; i < 1900 ; i--)
            {
                cbYe.Items.Add(i);
            }
            DataContext =
            z = new Worker()
            {
                Narozeni = DateTime.Now
            };
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter x = new StreamWriter(@"Zaměstnanci.txt", true))
            {
                x.WriteLine($"{z.Jmeno}, {z.Prijmeni}, {z.Narozeni}, {z.Misto}, {z.Plat}");
                x.Flush();
            }
            z.Jmeno = z.Prijmeni = z.Misto = z.Plat = string.Empty;
            z.Narozeni = DateTime.Now;
        }
    }
}
