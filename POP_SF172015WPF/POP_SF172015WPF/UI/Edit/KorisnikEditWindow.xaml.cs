using POP_SF172015WPF.Model;
using System.Windows;


namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for KorisnikEditWindow.xaml
    /// </summary>
    public partial class KorisnikEditWindow : Window
    {
        Korisnik korisnik;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        Operacija operacija;

        public KorisnikEditWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.operacija = operacija;

            cbTipKorisnika.Items.Add(Korisnik.TipKorisnika.ADMIN);
            cbTipKorisnika.Items.Add(Korisnik.TipKorisnika.PRODAVAC);

            if (operacija == Operacija.DODAVANJE)
            {
                tbId.Text = (Projekat.ListaKorisnika.Count + 1).ToString();
            }
            if (operacija == Operacija.IZMENA)
            {
                tbId.Text = korisnik.ID.ToString();
            }
            tbIme.Text = korisnik.Ime;
            tbPrezime.Text = korisnik.Prezime;
            tbUsername.Text = korisnik.KorIme;
            tbPassword.Text = korisnik.Password;
            cbTipKorisnika.SelectedItem = korisnik.TipKorisnika;
        }


        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            korisnik.Id = int.Parse(tbId.Text);
            korisnik.Ime = tbIme.Text;
            korisnik.Prezime = tbPrezime.Text;
            korisnik.KorIme = tbUsername.Text;
            korisnik.Password = tbPassword.Text;
            korisnik.TipKorisnika = (Korisnik.TipKorisnika)cbTipKorisnika.SelectedItem;

            DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Projekat.ListaKorisnika.Add(korisnik);
            }
            Close();
        }
    }
}
