using POP_SF172015WPF.Model;
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
using POP_SF172015WPF.Menadzeri;

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

        public KorisnikEditWindow()
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.operacija = operacija;
        }

        if (operacija == Operacija.DODAVANJE)
        {
            tbId.Text = (Projekat.ListaKorisnika.Count + 1).ToString();
            tbTipKorisnika
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
