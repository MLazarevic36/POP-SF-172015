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
                if(korisnik.Obrisan == false)
                {
                    lbKorisnik.Items.Add(korisnik);
                }
            }
            lbKorisnik.SelectedIndex = 0;
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
            Korisnik selektovaniKorisnik = (Korisnik)lbKorisnik.SelectedItem;
            KorisnikEditWindow few = new KorisnikEditWindow(selektovaniKorisnik, KorisnikEditWindow.Operacija.IZMENA);
            if (few.ShowDialog() == true)
            {
                OsveziPrikaz();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            int selectedUserID = ((Korisnik)lbKorisnik.SelectedItem).ID;
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.ID == selectedUserID)
                {
                    korisnik.Obrisan = true;
                }
            }
            OsveziPrikaz();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Projekat.ProjekatExit();
        }
    }
}
