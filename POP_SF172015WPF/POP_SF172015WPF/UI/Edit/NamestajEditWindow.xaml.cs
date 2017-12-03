using POP_SF172015WPF.Model;
using System.Windows;

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for NamestajEditWindow.xaml
    /// </summary>
    public partial class NamestajEditWindow : Window
    {
        Namestaj namestaj;
        public enum Operacija { DODAVANJE, IZMENA };
        Operacija operacija;

        public NamestajEditWindow(Namestaj namestaj, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;

            tbNaziv.DataContext = namestaj;
            tbId.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;

            if (operacija == Operacija.DODAVANJE)
            {
                namestaj.Id = Projekat.Instance.Namestaj.Count + 1;
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Projekat.Instance.Namestaj.Add(namestaj);
            }
            this.Close();
        }
    }
}
