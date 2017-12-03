﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace POP_SF172015WPF.Model
{
    public class Racun : INotifyPropertyChanged
    {

        public ObservableCollection<Namestaj> Namestaj { get; set; }

        private int id;
        private string kupac;
        private int namestajId;
        private int brojRacuna;
        private int ukupnaCena;
        private DateTime datumProdaje;
        private Boolean obrisan;

        public event PropertyChangedEventHandler PropertyChanged;

        public int UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
            }
        }

        public int BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int NamestajId
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }

        }

        public Boolean Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }

        }



        //public override string ToString()
        //{
        //    return "Br racuna: " + BrojRacuna + " Ukupna cena: " + UkupnaCena + " Datum prodaje: " + DatumProdaje
        //        + " Kupac: " + Kupac + " Namestaj: " + ListaNamestaja;
        //}

        public static Racun GetById(int id)
        {
            foreach (var prodaja in Projekat.Instance.Racuni)
            {
                if (prodaja.id == id)
                {
                    return prodaja;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
