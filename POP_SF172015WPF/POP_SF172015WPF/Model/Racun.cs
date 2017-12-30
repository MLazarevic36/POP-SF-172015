﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF172015WPF.Model
{
    public class Racun : INotifyPropertyChanged
    {
        private List<int> listaNamestaja;
        private int id;
        private string kupac;
        private int brojRacuna;
        private int ukupnaCena;
        private DateTime datumProdaje;
        private Boolean obrisan;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<int> ListaNamestaja
        {
            get { return listaNamestaja; }
            set
            {
                listaNamestaja = value;
                OnPropertyChanged("ListaNamestaja");
            }
        }

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

        #region Database

        public static ObservableCollection<Racun> GetAll()
        {
            var racun = new ObservableCollection<Racun>();

            using (SqlConnection connection = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Racuni WHERE Obrisan=0";
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Racuni");

                foreach (DataRow row in ds.Tables["Racuni"].Rows)
                {
                    Racun r = new Racun();
                    r.Id = (int)row["Id"];
                    r.Kupac = (string)row["Kupac"];
                    r.BrojRacuna = (int)row["BrojRacuna"];
                    r.UkupnaCena = (int)row["UkupnaCena"];
                    r.DatumProdaje = (DateTime)row["DatumProdaje"];
                    r.Obrisan = (bool)row["Obrisan"];

                }
            }
            return racun;
        }

        #endregion
    }
}
