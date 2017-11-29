﻿using POP_SF172015WPF.UI;
using POP_SF172015WPF.UI.View;
using System.Windows;

namespace POP_SF172015WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisnikWindow kw = new KorisnikWindow();
            kw.ShowDialog();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            NamestajWindow nw = new NamestajWindow();
            nw.ShowDialog();
           
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            ProdajaWindow pw = new ProdajaWindow();
            pw.ShowDialog();
        }

        private void btnSalon_Click(object sender, RoutedEventArgs e)
        {
            SalonWindow sw = new SalonWindow();
            sw.ShowDialog();
        }

        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            AkcijeWindow aw = new AkcijeWindow();
            aw.ShowDialog();
           
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.ShowDialog();
            
        }
    }
}
