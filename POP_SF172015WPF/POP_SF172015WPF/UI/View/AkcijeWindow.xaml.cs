using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        ICollectionView view;

        public AkcijeWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcije);
            dgAkcije.ItemsSource = view;
            dgAkcije.IsSynchronizedWithCurrentItem = true;

            dgAkcije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Akcija novaAkcija = new Akcija();
            AkcijeEditWindow aew = new AkcijeEditWindow(novaAkcija);
            aew.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Akcija selektovanaAkcija = view.CurrentItem as Akcija;

            if (selektovanaAkcija != null)
            {
                Akcija old = (Akcija)selektovanaAkcija.Clone();
                AkcijeEditWindow aew = new AkcijeEditWindow(selektovanaAkcija, AkcijeEditWindow.Operacija.IZMENA);
                if (aew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Akcije.IndexOf(selektovanaAkcija);
                    Projekat.Instance.Akcije[index] = old;
                }
            }

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgAkcije_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
