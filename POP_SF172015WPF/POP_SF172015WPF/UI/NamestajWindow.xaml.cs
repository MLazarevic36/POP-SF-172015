﻿using POP_SF172015WPF.Model;
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
using POP_SF172015WPF.Menadzeri;

namespace POP_SF172015WPF.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
    
        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(namestaj, operacija);


        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            tbNaziv.Text = namestaj.Naziv;
        }
        private void SacuvajIzmene(object)
        {
            List<Namestaj> postojeciNamestaj = Projekat.Instance.Namestaj;

            switch (operacija)
            {

                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        Naziv = tbNaziv.Text
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciNamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Namestaj = postojeciNamestaj;
            this.Close();
        }
    }
}

