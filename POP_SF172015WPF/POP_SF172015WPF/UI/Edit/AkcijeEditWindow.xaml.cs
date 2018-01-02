using POP_SF172015WPF.Model;
using System.Windows;


namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for AkcijeEditWindow.xaml
    /// </summary>
    public partial class AkcijeEditWindow : Window
    {
        Akcija akcija;
        public enum Operacija { DODAVANJE, IZMENA };
        Operacija operacija;

        public AkcijeEditWindow(Akcija akcija, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbId.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dpDatumP.DataContext = akcija;
            dpDatumZ.DataContext = akcija;

            if (operacija == Operacija.DODAVANJE)
            {
                akcija.Id = Projekat.Instance.Akcije.Count + 1;
            }


        }


        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Akcija.Create(akcija);
                Projekat.Instance.Akcije.Add(akcija);
            }

            if (operacija == Operacija.IZMENA)
            {
                Akcija.Update(akcija);

                Akcija original = Akcija.GetById(akcija.Id);
                original.Id = akcija.Id;
                original.Popust = akcija.Popust;
                original.DatumPocetka = akcija.DatumPocetka;
                original.DatumZavrsetka = akcija.DatumZavrsetka;
                original.Obrisan = akcija.Obrisan;

            }

            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
