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

namespace POP_SF172015WPF.UI.View
{
    /// <summary>
    /// Interaction logic for SpisakNamestaja.xaml
    /// </summary>
    public partial class SpisakNamestaja : Window
    {
        public SpisakNamestaja()
        {
            InitializeComponent();
        }

        private void dgListaNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
