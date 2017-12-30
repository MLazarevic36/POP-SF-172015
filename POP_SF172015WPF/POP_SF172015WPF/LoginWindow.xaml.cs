
using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI;
using System.Windows;

namespace POP_SF172015WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            GetAllDB();
            
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            string username = tbKorIme.Text;
            string password = pbLozinka.Password;

            Korisnik LoggedUser = Korisnik.KorisnikExist(username, password);

            if (LoggedUser == null)
            {
                MessageBox.Show("Korisnicki podaci nisu dobro uneti", "");
            }
            else
            {
                Projekat.LoggedUser = LoggedUser;
                if (LoggedUser.TipKorisnika == Korisnik.TipoviKorisnika.ADMIN)
                {
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    this.Close();
                }
                if (LoggedUser.TipKorisnika == Korisnik.TipoviKorisnika.PRODAVAC)
                {
                    ProdavacWindow pw = new ProdavacWindow();
                    pw.Show();
                    this.Close();
                }
            }


            
        }

        private void GetAllDB()
        {
            TipNamestaja.GetAll();
            Namestaj.GetAll();
            Akcija.GetAll();
            Korisnik.GetAll();
            Racun.GetAll();
            DodatnaUsluga.GetAll();
        }
    }
}
