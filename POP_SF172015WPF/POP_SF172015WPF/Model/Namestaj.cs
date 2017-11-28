using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Namestaj : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int id;
        private string naziv;
        private int cena;
        private int kolicinaMagacin;
        private int tipNamestajaId;
        private bool obrisan;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int KolicinaMagacin
        {
            get { return kolicinaMagacin; }
            set
            {
                kolicinaMagacin = value;
                OnPropertyChanged("KolicinaMagacin");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public object Clone()
        {
            Namestaj kopija = new Namestaj();
            kopija.Cena = cena;
            kopija.Id = id;
            kopija.KolicinaMagacin = kolicinaMagacin;
            kopija.Naziv = naziv;
            kopija.Obrisan = obrisan;
            return kopija;
        }


        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.id == id)
                {
                    return namestaj;
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
