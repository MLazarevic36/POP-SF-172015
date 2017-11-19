using POP_SF172015WPF.Model;
using System.Windows;


namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(namestaj, operacija);


        }



        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            tbNaziv.Text = namestaj.Naziv;

            foreach (var tipNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                cbTipNamestaja.Items.Add(tipNamestaja);
            }

            foreach (TipNamestaja tipNamestaja in cbTipNamestaja.Items)
            {
                //if(TipNamestaja.ID == namestaj.TipNamestajaId)
                {
                    cbTipNamestaja.SelectedItem = tipNamestaja;
                }
            }
        }



        //private void SacuvajIzmene(object) 
        //{
        //    List<Namestaj> postojeciNamestaj = Projekat.Instance.Namestaj;

        //    switch (operacija)
        //    {

        //        case Operacija.DODAVANJE:
        //            var noviNamestaj = new Namestaj()
        //            {
        //                Naziv = tbNaziv.Text
        //            };
        //            postojeciNamestaj.Add(noviNamestaj);
        //            break;
        //        case Operacija.IZMENA:
        //            foreach (var n in postojeciNamestaj)
        //            {
        //                if (n.ID == namestaj.ID)
        //                {
        //                    n.Naziv = tbNaziv.Text;
                            
        //                    break;
        //                }
        //            }
        //            break;
        //    }
        //    Projekat.Instance.Namestaj = postojeciNamestaj;
        //    this.Close();
        //}
    }
}

