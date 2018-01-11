using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class RacunWindow : Window
    {
        ICollectionView view;

        public RacunWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Racuni);
            view.Filter = RacunFilter;

            dgRacun.ItemsSource = view;
            dgRacun.IsSynchronizedWithCurrentItem = true;

            dgRacun.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool RacunFilter(object obj)
        {
            return !((Racun)obj).Obrisan;
        }

        private void dgRacun_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }

            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }

            if ((string)e.Column.Header == "UslugaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "DatumProdaje")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "DodatnaUsluga")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Racun noviRacun = new Racun();
            RacunEditWindow rew = new RacunEditWindow(noviRacun);
            rew.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Racun selektovaniR = view.CurrentItem as Racun;
            Racun.Delete(selektovaniR);
            foreach (var racun in Projekat.Instance.Racuni)
            {
                if (racun.Id == selektovaniR.Id)
                {
                    racun.Obrisan = true;
                }
            }
            view.Refresh();
        }
    }
}
