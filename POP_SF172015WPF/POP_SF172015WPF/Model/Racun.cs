using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF172015WPF.Model
{
    public class Racun : INotifyPropertyChanged
    {
        
        private int id;
        private string kupac;
        private int brojRacuna;
        private int ukupnaCena;
        private DateTime datumProdaje;
        private int uslugaId;
        private DodatnaUsluga dodatnaUsluga;
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

        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                if (dodatnaUsluga == null)
                {
                    dodatnaUsluga = DodatnaUsluga.GetById(UslugaId);
                }
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                UslugaId = dodatnaUsluga.Id;
                OnPropertyChanged("DodatnaUsluga");
            }
        }

        public int UslugaId
        {
            get { return uslugaId; }
            set
            {
                uslugaId = value;
                OnPropertyChanged("UslugaId");
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

        public static int UkupnaCenaU()
        {
            

            int ukupnaCena = 0;
            int cenaKomad;


            foreach (Namestaj namestaj in Projekat.Instance.ListaNamestaja)
            {
                try
                {
                    cenaKomad = namestaj.Cena - (namestaj.Cena / namestaj.Akcija.Popust);
                }
                catch (Exception)
                {
                    cenaKomad = namestaj.Cena;
                }
               
            }
            return ukupnaCena;
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
                    r.UslugaId = (int)row["UslugaId"];
                    r.Obrisan = (bool)row["Obrisan"];

                    Projekat.Instance.Racuni.Add(r);
                }
            }
            return racun;
        }

        public static Racun Create(Racun r)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO Racun(Kupac, BrojRacuna, UkupnaCena, DatumProdaje, UslugaId, Obrisan) VALUES ( @Kupac, @BrojRacuna, @UkupnaCena, @DatumProdaje, @UslugaId, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Kupac", r.Kupac);
                cmd.Parameters.AddWithValue("BrojRacuna", r.BrojRacuna);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);
                cmd.Parameters.AddWithValue("DatumProdaje", r.DatumProdaje);
                cmd.Parameters.AddWithValue("UslugaId", r.UslugaId);
                cmd.Parameters.AddWithValue("Obrisan", r.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                r.Id = newId;

            }
            Projekat.Instance.Racuni.Add(r);

            return r;
        }

        public static void Update(Racun r)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Racuni SET Kupac=@Kupac, BrojRacuna=@BrojRacuna, UkupnaCena=@UkupnaCena, DatumProdaje=@DatumProdaje, UslugaId=@UslugaId, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", r.Id);
                cmd.Parameters.AddWithValue("Kupac", r.Kupac);
                cmd.Parameters.AddWithValue("BrojRacuna", r.BrojRacuna);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);
                cmd.Parameters.AddWithValue("DatumProdaje", r.DatumProdaje);
                cmd.Parameters.AddWithValue("UslugaId", r.UslugaId);
                cmd.Parameters.AddWithValue("Obrisan", r.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var racun in Projekat.Instance.Racuni)
                {
                    if (racun.Id == r.Id)
                    {
                        racun.Id = r.Id;
                        racun.Kupac = r.Kupac;
                        racun.BrojRacuna = r.BrojRacuna;
                        racun.UkupnaCena = r.UkupnaCena;
                        racun.DatumProdaje = r.DatumProdaje;
                        racun.DodatnaUsluga = r.DodatnaUsluga;
                        racun.UslugaId = r.UslugaId;
                        racun.Obrisan = r.Obrisan;
                        break;
                    }
                }


            }

        }

        public static void Delete(Racun r)
        {
            r.Obrisan = true;
            Update(r);
        }
        

        #endregion
    }
}
