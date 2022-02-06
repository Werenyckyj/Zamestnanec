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
        private string _Jmeno, _Prijmeni, _Rok;

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
        public string Rok
        {
            get => _Rok;
            set
            {
                _Rok = value;
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
        private string _Misto, _Plat, _Vzdelani;

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
        public string Vzdelani
        {
            get => _Vzdelani;
            set
            {
                _Vzdelani = value;
                OnPropertyChanged("Vzdelani");
            }
        }
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
            for (int i = 2022; i > 1900 ; i--)
            {
                cbYe.Items.Add(i);
            }
        }
        public enum Rok
        {

        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter x = new StreamWriter(@"Zaměstnanci.txt", true))
            {
                x.WriteLine($"Jméno: {tbJmeno.Text}, Příjmení: {tbPrijmeni.Text}, Rok narození: {cbYe.SelectedItem}, Dosažené vzdělání: {cbVz.SelectedItem}, Pozice: {work.Text}, Plat: {money.Text}");
                x.Flush();
            }
            z.Jmeno = z.Prijmeni = z.Misto = z.Plat = string.Empty;

        }
    }
}
