using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System.Windows;
using System.Windows.Data;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        

        public KorisnikWindow()
        {
            InitializeComponent();

            //view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);
            //view.Filter = KorisnikFilter;
            dgKorisnik.ItemsSource = Projekat.Instance.Korisnici;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;

            //dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnityType.Star);
            
        }

        

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            KorisnikEditWindow kew = new KorisnikEditWindow(noviKorisnik, KorisnikEditWindow.Operacija.DODAVANJE);
            kew.ShowDialog();
            
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = (Korisnik)dgKorisnik.SelectedItem;
            KorisnikEditWindow few = new KorisnikEditWindow(selektovaniKorisnik, KorisnikEditWindow.Operacija.IZMENA);
            if (few.ShowDialog() == true)
            {
                
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
                    //view.Refresh();
                    break;
                }
            }
            
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private bool KorisnikFilter(object obj)
        {
            return ((Korisnik)obj).Obrisan;
        }
        
    }
}
