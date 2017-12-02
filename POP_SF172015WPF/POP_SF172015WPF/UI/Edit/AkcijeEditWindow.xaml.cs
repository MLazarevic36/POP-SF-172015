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

            cbNamestaj.ItemsSource = Projekat.Instance.Namestaj;
            

            tbId.DataContext = akcija;
            cbNamestaj.DataContext = akcija;
            tbPopust.DataContext = akcija;
            tbDatumP.DataContext = akcija;
            tbDatumZ.DataContext = akcija;

           
            
        }


        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Projekat.Instance.Akcije.Add(akcija);
            }
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
