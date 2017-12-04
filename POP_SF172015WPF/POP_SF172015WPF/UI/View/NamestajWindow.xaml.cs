using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System;

namespace POP_SF172015WPF.UI.View
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        ICollectionView view;

        public NamestajWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = NamestajFilter;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool NamestajFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj noviNamestaj = new Namestaj();
            NamestajEditWindow naew = new NamestajEditWindow(noviNamestaj);
            naew.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj SelektovaniNamestaj = view.CurrentItem as Namestaj;

            if (SelektovaniNamestaj != null)
            {
                Namestaj old = (Namestaj)SelektovaniNamestaj.Clone();
                NamestajEditWindow naew = new NamestajEditWindow(SelektovaniNamestaj, NamestajEditWindow.Operacija.IZMENA);
                if (naew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Namestaj.IndexOf(SelektovaniNamestaj);
                    Projekat.Instance.Namestaj[index] = old;
                }
            }

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Namestaj SelektovaniNamestaj = view.CurrentItem as Namestaj;
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == SelektovaniNamestaj.Id)
                {
                    namestaj.Obrisan = true;
                }
            }
            view.Refresh();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
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
    }
}
