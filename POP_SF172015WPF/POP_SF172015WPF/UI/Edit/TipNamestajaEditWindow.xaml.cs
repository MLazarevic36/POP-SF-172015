﻿using POP_SF172015WPF.Model;
using System.Windows;

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for TipNamestajaEditWindow.xaml
    /// </summary>
    public partial class TipNamestajaEditWindow : Window
    {
        TipNamestaja tipNamestaja;
        public enum Operacija { DODAVANJE, IZMENA };
        Operacija operacija;

        public TipNamestajaEditWindow(TipNamestaja tipNamestaja, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNaziv.DataContext = tipNamestaja;
            //tbId.DataContext = tipNamestaja;

            if (operacija == Operacija.DODAVANJE)
            {
                tipNamestaja.Id = Projekat.Instance.TipoviNamestaja.Count + 1;
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if ( operacija == Operacija.DODAVANJE)
            {
                TipNamestaja.Create(tipNamestaja);
                
            }

            if (operacija == Operacija.IZMENA)
            {
                TipNamestaja.Update(tipNamestaja);

                TipNamestaja original = TipNamestaja.GetById(tipNamestaja.Id);
                original.Id = tipNamestaja.Id;
                original.Naziv = tipNamestaja.Naziv;
                original.Obrisan = tipNamestaja.Obrisan;
                
                
            }

            Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
