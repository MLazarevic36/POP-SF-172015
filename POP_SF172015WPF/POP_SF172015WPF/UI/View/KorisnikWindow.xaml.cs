using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        ICollectionView view;
        

        public KorisnikWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);
            view.Filter = KorisnikFilter;
            
            dgKorisnik.ItemsSource = view;
            //dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;

            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }
   
        private bool KorisnikFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
        }
        

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            KorisnikEditWindow kew = new KorisnikEditWindow(noviKorisnik);
            kew.ShowDialog();
            
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik SelektovaniKorisnik = view.CurrentItem as Korisnik;

            if (SelektovaniKorisnik != null)
            {
                Korisnik old = (Korisnik)SelektovaniKorisnik.Clone();
                KorisnikEditWindow kew = new KorisnikEditWindow(SelektovaniKorisnik, KorisnikEditWindow.Operacija.IZMENA);
                if (kew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Korisnici.IndexOf(SelektovaniKorisnik);
                    Projekat.Instance.Korisnici[index] = old;

                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            Korisnik SelektovaniKorisnik = view.CurrentItem as Korisnik;
            Korisnik.Delete(SelektovaniKorisnik);

        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.Obrisan == true)
                {
                    korisnik.Obrisan = false;
                }

            }
            view.Refresh();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
