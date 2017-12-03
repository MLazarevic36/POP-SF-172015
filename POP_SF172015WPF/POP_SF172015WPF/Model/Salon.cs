
using System;
using System.ComponentModel;


namespace POP_SF172015WPF.Model
{
    public class Salon : ICloneable, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaSajta;
        private string pib;
        private string maticniBroj;
        private string brZiroRacun;

        public Salon() {}

        public Salon (string naziv, string adresa, string telefon, string email,
                      string adresaSajta, string pib, string maticniBroj, string brZiroRacun)
        {
            this.naziv = naziv;
            this.adresa = adresa;
            this.telefon = telefon;
            this.email = email;
            this.adresaSajta = adresaSajta;
            this.pib = pib;
            this.maticniBroj = maticniBroj;
            this.brZiroRacun = brZiroRacun;
        }

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

        public String Telefon
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

        public String Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }

        public String MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        public String BrZiroRacun
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
