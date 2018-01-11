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

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaEditWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaEditWindow : Window
    {
        DodatnaUsluga dodatnaU;
        public enum Operacija { DODAVANJE, IZMENA };
        Operacija operacija;

        public DodatnaUslugaEditWindow(DodatnaUsluga dodatnaU, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();
            this.dodatnaU = dodatnaU;
            this.operacija = operacija;

            tbNaziv.DataContext = dodatnaU;
            tbCena.DataContext = dodatnaU;

            if (operacija == Operacija.DODAVANJE)
            {
                dodatnaU.Id = Projekat.Instance.DodatneUsluge.Count + 1;
            }

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            if (operacija == Operacija.DODAVANJE)
            {
                DodatnaUsluga.Create(dodatnaU);
            }

            if (operacija == Operacija.IZMENA)
            {
                DodatnaUsluga.Update(dodatnaU);

                DodatnaUsluga gigi = DodatnaUsluga.GetById(dodatnaU.Id);
                gigi.Id = dodatnaU.Id;
                gigi.Naziv = dodatnaU.Naziv;
                gigi.Cena = dodatnaU.Cena;
                gigi.Obrisan = dodatnaU.Obrisan;
            }

            Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
