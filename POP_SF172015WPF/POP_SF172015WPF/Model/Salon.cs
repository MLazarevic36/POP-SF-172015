
using System;
using System.ComponentModel;


namespace POP_SF172015WPF.Model
{
    public class Salon : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private String naziv;
        private String adresa;
        private int telefon;
        private String email;
        private String adresaSajta;
        private int pib;
        private int maticniBroj;
        private int brZiroRacun;

        public String Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public String Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public int Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public String AdresaSajta
        {
            get { return adresaSajta; }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }

        public int Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }

        public int MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        public int BrZiroRacun
        {
            get { return brZiroRacun; }
            set
            {
                brZiroRacun = value;
                OnPropertyChanged("BrZiroRacun");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            Salon kopija = new Salon();
            kopija.Naziv = Naziv;
            kopija.Adresa = Adresa;
            kopija.Telefon = Telefon;
            kopija.Email = Email;
            kopija.AdresaSajta = AdresaSajta;
            kopija.Pib = Pib;
            kopija.MaticniBroj = MaticniBroj;
            kopija.BrZiroRacun = BrZiroRacun;
            return kopija;
        }
    }
}
