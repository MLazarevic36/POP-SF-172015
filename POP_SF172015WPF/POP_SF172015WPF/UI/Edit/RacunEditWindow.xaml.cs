using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.View;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;
using System;

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for ProdajaEditWindow.xaml
    /// </summary>
    public partial class RacunEditWindow : Window
    {
        Racun racun;
        private ICollectionView view;

        //private ICollectionView view;

        public RacunEditWindow(Racun noviRacun)
        {
            InitializeComponent();

            cbDodatnau.ItemsSource = Projekat.Instance.DodatneUsluge;


            tbKupac.DataContext = racun;
            tbBrRacun.DataContext = racun;
            dpDatum.DataContext = racun;
            tbUkCena.DataContext = racun;
            cbDodatnau.DataContext = racun;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.ListaNamestaja);
            view.Filter = ListaFilter;

            dgIzabraniNamestaj.ItemsSource = view;
            dgIzabraniNamestaj.IsSynchronizedWithCurrentItem = true;
            dgIzabraniNamestaj.DataContext = this;

            dgIzabraniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            this.racun = racun;
            podaci();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Racun.Create(racun);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool ListaFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            SpisakNamestaja sn = new SpisakNamestaja();
            sn.ShowDialog();
        }

        private void dgIzabraniNamestaj_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }

        }

        private void podaci()
        {
            //DateTime datum = DateTime.Now;

            //racun.DatumProdaje = datum;

            racun.UkupnaCena = UkupnaCenaU();
            
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Namestaj SelektovaniNamestaj = view.CurrentItem as Namestaj;
            Namestaj.Delete(SelektovaniNamestaj);
            foreach (var namestaj in Projekat.Instance.ListaNamestaja)
            {
                if (namestaj.Id == SelektovaniNamestaj.Id)
                {
                    namestaj.Obrisan = true;
                }
            }
            view.Refresh();
        }
    }
}
