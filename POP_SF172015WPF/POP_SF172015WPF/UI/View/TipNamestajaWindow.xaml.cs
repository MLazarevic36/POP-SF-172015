﻿using POP_SF172015WPF.Model;
using POP_SF172015WPF.UI.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        private ICollectionView view;
        

        public TipNamestajaWindow()
        {
            InitializeComponent();


            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = TipNamestajaFilter;

            dgTipNamestaja.ItemsSource = view;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja noviTip = new TipNamestaja();
            TipNamestajaEditWindow tnew = new TipNamestajaEditWindow(noviTip);
            tnew.ShowDialog();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja selektovaniTip = view.CurrentItem as TipNamestaja;

            if (selektovaniTip != null)
            {
                TipNamestaja old = (TipNamestaja)selektovaniTip.Clone();
                TipNamestajaEditWindow tnew = new TipNamestajaEditWindow(selektovaniTip, TipNamestajaEditWindow.Operacija.IZMENA);
                if (tnew.ShowDialog() != true)
                {
                    int index = Projekat.Instance.TipoviNamestaja.IndexOf(selektovaniTip);
                    Projekat.Instance.TipoviNamestaja[index] = old;
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja selektovaniTip = view.CurrentItem as TipNamestaja;
            TipNamestaja.Delete(selektovaniTip);
        }

        private bool TipNamestajaFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
        }

        private void dgTipNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }

            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
