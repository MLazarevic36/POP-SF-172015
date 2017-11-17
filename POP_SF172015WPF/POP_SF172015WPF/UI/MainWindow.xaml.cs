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
using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI;
using POP_SF172015WPF.Menadzeri;

namespace POP_SF172015WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }
            }

            lbNamestaj.SelectedIndex = 0;
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj();
            {
                //Naziv = "";
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.Show();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var selektovaniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e) 
        {
            var izabraniNamestaj = lbNamestaj.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;
            //if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete: { izabraniNamestaj.Naziv }? ", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namestaj namestaj = null;

                foreach (var n in listaNamestaja)
                {
                    //if(n.ID == izabraniNamestaj.ID)
                    {
                        namestaj = n;
                    }
                }

                namestaj.Obrisan = true;

                Projekat.Instance.Namestaj = listaNamestaja;

                OsveziPrikaz();
            }
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

