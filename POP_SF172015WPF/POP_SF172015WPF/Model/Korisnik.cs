using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF172015WPF.Model
{
    public class Korisnik : ICloneable, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string korIme;
        private string lozinka;
        private int id;
        private string ime;
        private string prezime;
        public enum TipoviKorisnika { ADMIN, PRODAVAC };
        private bool obrisan;

        public Korisnik()
        {
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string KorIme
        {
            get { return korIme; }
            set
            {
                korIme = value;
                OnPropertyChanged("KorIme");
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Password");
            }
        }


        public TipoviKorisnika TipKorisnika { get; set; }

        public bool Obrisan 
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
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

        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.Id == id)
                {
                    return korisnik;
                }
            }
            return null;
        }


        public static Boolean KorisnikExist(String username)
        {
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.KorIme == username)
                {
                    return true;
                }
            }
            return false;
        }


        public static Korisnik KorisnikExist(String korIme, String password)
        {
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.KorIme == korIme && korisnik.Lozinka == password)
                {
                    return korisnik;
                }
            }
            return null;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            Korisnik kopija = new Korisnik();
            kopija.KorIme = KorIme;
            kopija.Lozinka = Lozinka;
            kopija.Id = Id;
            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.TipKorisnika = TipKorisnika;
            kopija.Obrisan = Obrisan;
            return kopija;
        }

        #region Database

        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnik = new ObservableCollection<Korisnik>();
            using (SqlConnection connection = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnici WHERE Obrisan=0";
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnici");

                foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (int)row["Id"];
                    k.KorIme = (string)row["KorIme"];
                    k.Lozinka = (string)row["Lozinka"];
                    k.Ime = (string)row["Ime"];
                    k.Prezime = (string)row["Prezime"];
                    k.Obrisan = (bool)row["Obrisan"];

                    if (row["TipKorisnika"].ToString() == Korisnik.TipoviKorisnika.ADMIN.ToString())
                    {
                        k.TipKorisnika = Korisnik.TipoviKorisnika.ADMIN;
                    }
                    if (row["TipKorisnika"].ToString() == Korisnik.TipoviKorisnika.PRODAVAC.ToString())
                    {
                        k.TipKorisnika = Korisnik.TipoviKorisnika.PRODAVAC;
                    }

                    Projekat.Instance.Korisnici.Add(k);
                }


            }
            return korisnik;
        }

        #endregion
    }
}
