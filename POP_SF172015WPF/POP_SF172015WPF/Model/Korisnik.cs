using System;
using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Korisnik : ICloneable, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string korIme;
        private string password;
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

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
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
                if (korisnik.KorIme == korIme && korisnik.Password == password)
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
            kopija.Password = Password;
            kopija.Id = Id;
            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.TipKorisnika = TipKorisnika;
            kopija.Obrisan = Obrisan;
            return kopija;
        }
    }
}
