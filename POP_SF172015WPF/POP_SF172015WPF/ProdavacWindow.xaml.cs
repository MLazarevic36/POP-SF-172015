using POP_SF172015WPF.UI;
using System.Windows;

namespace POP_SF172015WPF
{
    /// <summary>
    /// Interaction logic for ProdavacWindow.xaml
    /// </summary>
    public partial class ProdavacWindow : Window
    {
        public ProdavacWindow()
        {
            InitializeComponent();
        }

        private void btnRacuni_Click(object sender, RoutedEventArgs e)
        {
            RacunWindow rw = new RacunWindow();
            rw.ShowDialog();
        }
    }
}
