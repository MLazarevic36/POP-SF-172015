using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF172015WPF.UI.View
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        private ICollectionView view;

        public DodatnaUslugaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatneUsluge);
            view.Filter = DodatneUFilter;

            dgDodatnau.ItemsSource = view;
            dgDodatnau.IsSynchronizedWithCurrentItem = true;

            dgDodatnau.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool DodatneUFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga novaUsluga = new DodatnaUsluga();
            DodatnaUslugaEditWindow duew = new DodatnaUslugaEditWindow(novaUsluga);
            duew.ShowDialog();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = view.CurrentItem as DodatnaUsluga;

            if (selektovanaUsluga != null)
            {
                DodatnaUsluga old = (DodatnaUsluga)selektovanaUsluga.Clone();
                DodatnaUslugaEditWindow duew = new DodatnaUslugaEditWindow(selektovanaUsluga, DodatnaUslugaEditWindow.Operacija.IZMENA);
                if (duew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.DodatneUsluge.IndexOf(selektovanaUsluga);
                    Projekat.Instance.DodatneUsluge[index] = old;
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga selektovanaUsluga = view.CurrentItem as DodatnaUsluga;
            DodatnaUsluga.Delete(selektovanaUsluga);
            foreach (var dodatnaU in Projekat.Instance.DodatneUsluge)
            {
                if (dodatnaU.Id == selektovanaUsluga.Id)
                {
                    dodatnaU.Obrisan = true;
                }
            }
            view.Refresh();
        }

        private void dgDodatnau_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }

            if((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
