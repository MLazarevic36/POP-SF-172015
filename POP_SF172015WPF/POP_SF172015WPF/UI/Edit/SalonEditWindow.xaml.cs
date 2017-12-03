using POP_SF172015WPF.Model;
using System.Windows;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for SalonEditWindow.xaml
    /// </summary>
    public partial class SalonEditWindow : Window
    {
        Salon salon;


        public SalonEditWindow()
        {
            InitializeComponent();



            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbAdresaSajta.DataContext = salon;
            tbEmail.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbPib.DataContext = salon;
            tbZiroRacun.DataContext = salon;


        }

        

        

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Projekat.Instance.Saloni.Add(salon);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
