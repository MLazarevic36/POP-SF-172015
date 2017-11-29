using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Salon : INotifyPropertyChanged
    {

        private string naziv;
        private string adresa;
        private int telefon;
        private string email;
        private string adresaSajta;
        private int pib;
        private int maticniBroj;
        private int brZiroRacun;

        public event PropertyChangedEventHandler PropertyChanged;

        

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Adresa
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

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string AdresaSajta
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
