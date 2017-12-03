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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class RacunWindow : Window
    {
        public RacunWindow()
        {
            InitializeComponent();
        }

        private void dgRacun_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
