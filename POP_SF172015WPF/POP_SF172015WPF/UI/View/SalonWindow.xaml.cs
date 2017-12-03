using POP_SF172015WPF.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF172015WPF.UI.View
{
    /// <summary>
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        ICollectionView view;

        public SalonWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Saloni);
            dgSalon.ItemsSource = view;
            dgSalon.IsSynchronizedWithCurrentItem = true;

            dgSalon.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Salon selektovaniSalon = view.CurrentItem as Salon;

            if (selektovaniSalon != null)
            {
                Salon old = (Salon)selektovaniSalon.Clone();
                SalonEditWindow sew = new SalonEditWindow();
                if (sew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.Saloni.IndexOf(selektovaniSalon);
                    Projekat.Instance.Saloni[index] = old;
                }
            }
        }

        private void dgSalon_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
