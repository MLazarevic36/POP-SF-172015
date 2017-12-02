using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

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

        private void dgAkcije_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

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
    }
}
