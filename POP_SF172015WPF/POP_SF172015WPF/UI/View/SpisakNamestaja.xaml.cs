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

        public NamestajWindow SelektovaniNamestaj { get; set; }

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

        }

        private bool NamestajFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void btnPreuzmi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
