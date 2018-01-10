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
            cbAkcija.ItemsSource = Projekat.Instance.Akcije;

            tbNaziv.DataContext = namestaj;
            //tbId.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbRaspolozivost.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            cbAkcija.DataContext = namestaj;

            if (operacija == Operacija.DODAVANJE)
            {
                namestaj.Id = Projekat.Instance.Namestajm.Count + 1;
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Namestaj.Create(namestaj);
                Projekat.Instance.Namestajm.Add(namestaj);
            }
            if (operacija == Operacija.IZMENA)
            {
                Namestaj.Update(namestaj);

                Namestaj original = Namestaj.GetById(namestaj.Id);
                original.Id = namestaj.Id;
                original.Naziv = namestaj.Naziv;
                original.Cena = namestaj.Cena;
                original.Raspolozivost = namestaj.Raspolozivost;
                original.Akcija = namestaj.Akcija;
                original.TipNamestaja = namestaj.TipNamestaja;
                original.AkcijaId = namestaj.AkcijaId;
                original.TipNamestajaId = namestaj.TipNamestajaId;
                original.Obrisan = namestaj.Obrisan;

            }
            this.Close();
        }
    }
}
