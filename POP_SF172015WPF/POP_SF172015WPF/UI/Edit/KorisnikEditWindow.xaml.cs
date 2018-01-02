﻿using POP_SF172015WPF.Model;
using System;
using System.Windows;
using static POP_SF172015WPF.Model.Korisnik;

namespace POP_SF172015WPF.UI.Edit
{
    /// <summary>
    /// Interaction logic for KorisnikEditWindow.xaml
    /// </summary>
    public partial class KorisnikEditWindow : Window
    {
        Korisnik korisnik;
        public enum Operacija { DODAVANJE, IZMENA };
        Operacija operacija;

        public KorisnikEditWindow(Korisnik korisnik, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;

            

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipoviKorisnika)) ;

            if (operacija == Operacija.DODAVANJE)
            {
                tbId.Text = (Projekat.Instance.Korisnici.Count + 1).ToString();
            }
            //if (operacija == Operacija.IZMENA)
            //{
            //    tbId.Text = korisnik.Id.ToString();
            //}
            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbUsername.DataContext = korisnik;
            tbPassword.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;


        }


        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            if (operacija == Operacija.DODAVANJE)
            {
                Korisnik.Create(korisnik);
                Projekat.Instance.Korisnici.Add(korisnik);
            }

            if (operacija == Operacija.IZMENA)
            {
                Korisnik.Update(korisnik);

                Korisnik original = Korisnik.GetById(korisnik.Id);
                original.Id = korisnik.Id;
                original.Ime = korisnik.Ime;
                original.Prezime = korisnik.Prezime;
                original.KorIme = korisnik.KorIme;
                original.Prezime = korisnik.Prezime;
                original.TipKorisnika = korisnik.TipKorisnika;
                original.Obrisan = korisnik.Obrisan;


            }

            Close();
        }
    }
}
