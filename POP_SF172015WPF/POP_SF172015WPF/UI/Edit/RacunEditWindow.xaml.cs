using POP_SF172015WPF.Model;
using System.Windows;

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for ProdajaEditWindow.xaml
    /// </summary>
    public partial class RacunEditWindow : Window
    {
        Racun racun;

        public RacunEditWindow(Racun noviRacun)
        {
            InitializeComponent();

            this.racun = racun;

            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;

            tbId.DataContext = racun;
            tbKupac.DataContext = racun;
            tbBrRacun.DataContext = racun;
            tbDatum.DataContext = racun;
            tbUkCena.DataContext = racun;
            cbNamestaj.DataContext = racun;

            //racun.Id = Projekat.Instance.Racuni.Count + 1;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Projekat.Instance.Racuni.Add(racun);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
