using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj noviNamestaj = new Namestaj();
            NamestajEditWindow naew = new NamestajEditWindow(noviNamestaj);
            naew.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj selektovaniNamestaj = view.CurrentItem as Namestaj;

            if (selektovaniNamestaj != null)
            {
                Namestaj old = (Namestaj)selektovaniNamestaj.Clone();
                NamestajEditWindow naew = new NamestajEditWindow(selektovaniNamestaj, NamestajEditWindow.Operacija.IZMENA);
                if (naew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Namestaj.IndexOf(selektovaniNamestaj);
                    Projekat.Instance.Namestaj[index] = old;
                }
            }

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            int selektovaniNamestajID = ((Namestaj)dgNamestaj.SelectedItem).Id;
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == selektovaniNamestajID)
                {
                    namestaj.Obrisan = true;

                    break;
                }
            }
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
        }
    }
}
