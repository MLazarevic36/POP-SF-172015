using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.View;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;

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

            this.racun = racun;

            tbKupac.DataContext = racun;
            tbBrRacun.DataContext = racun;
            dpDatum.DataContext = racun;
            tbUkCena.DataContext = racun;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.ListaNamestaja);
            //view.Filter = RacunFilter;

            dgIzabraniNamestaj.ItemsSource = view;
            dgIzabraniNamestaj.IsSynchronizedWithCurrentItem = true;

            dgIzabraniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            //racun.Id = Projekat.Instance.Racuni.Count + 1;
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
    }
}
