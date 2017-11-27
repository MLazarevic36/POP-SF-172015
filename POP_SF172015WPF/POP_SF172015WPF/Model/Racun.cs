using System.ComponentModel;
namespace POP_SF172015WPF.Model
{
    public class Racun : INotifyPropertyChanged
    {
        
        //public List<Namestaj> ListaNamestaja { get; set; }
        //public DateTime DatumProdaje { get; set; }
        
        
        //public Boolean Obrisan { get; set; }

        private int id;
        private string kupac;
        private int brojRacuna;
        private int ukupnaCena;

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

       

        //public override string ToString()
        //{
        //    return "Br racuna: " + BrojRacuna + " Ukupna cena: " + UkupnaCena + " Datum prodaje: " + DatumProdaje
        //        + " Kupac: " + Kupac + " Namestaj: " + ListaNamestaja;
        //}

        public static Racun GetById(int id)
        {
            foreach (var prodaja in Projekat.Instance.Prodaje)
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
