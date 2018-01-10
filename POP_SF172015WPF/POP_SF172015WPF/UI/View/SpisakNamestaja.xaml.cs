using POP_SF172015WPF.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF172015WPF.UI.View
{
    /// <summary>
    /// Interaction logic for SpisakNamestaja.xaml
    /// </summary>
    public partial class SpisakNamestaja : Window
    {
        private ICollectionView namestajView;

        

        Racun racun;

        public SpisakNamestaja()
        {
            InitializeComponent();

            namestajView = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestajm);

            dgListaNamestaja.ItemsSource = namestajView;
            dgListaNamestaja.DataContext = this;
            dgListaNamestaja.IsSynchronizedWithCurrentItem = true;

            dgListaNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgListaNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        

        private void btnPreuzmi_Click(object sender, RoutedEventArgs e)
        {
            Namestaj SelektovaniNamestaj = namestajView.CurrentItem as Namestaj;
            SelektovaniNamestaj = dgListaNamestaja.SelectedItem as Namestaj;
            this.DialogResult = true;
            this.Close();


        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
