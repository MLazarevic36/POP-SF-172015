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
            
            dgKorisnik.ItemsSource = view;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;

            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            KorisnikEditWindow kew = new KorisnikEditWindow(noviKorisnik);
            kew.ShowDialog();
            
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = view.CurrentItem as Korisnik;

            if (selektovaniKorisnik != null)
            {
                Korisnik old = (Korisnik)selektovaniKorisnik.Clone();
                KorisnikEditWindow kew = new KorisnikEditWindow(selektovaniKorisnik, KorisnikEditWindow.Operacija.IZMENA);
                if (kew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Korisnici.IndexOf(selektovaniKorisnik);
                    Projekat.Instance.Korisnici[index] = old;

                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            int selectedUserID = ((Korisnik)dgKorisnik.SelectedItem).Id;
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.Id == selectedUserID)
                {
                    korisnik.Obrisan = true;
                    view.Refresh();
                    break;
                }
            }
            
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            
        }

        
        
    }
}
