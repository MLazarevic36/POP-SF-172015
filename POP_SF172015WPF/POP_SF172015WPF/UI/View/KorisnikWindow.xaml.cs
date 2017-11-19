using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public KorisnikWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbKorisnik.Items.Clear();
            foreach (Korisnik korisnik in Projekat.ListaKorisnika)
            {
                lbKorisnik.Items.Add(korisnik);
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            KorisnikEditWindow kew = new KorisnikEditWindow(noviKorisnik, KorisnikEditWindow.Operacija.DODAVANJE);
            kew.ShowDialog();
            OsveziPrikaz();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
