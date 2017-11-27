using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        
        //public DateTime DatumPocetka { get; set; }
        //public DateTime DatumZavrsetka { get; set; }
        //public Boolean Obrisan { get; set; }
        
        

        private int id;
        private int namestajId;
        private int popust;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        public int Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
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
        

      

        //public override string ToString()
        //{
        //    return "ID: " + ID + " Pocetak akcije: " + DatumPocetka + " Datum zavrsetka: " + DatumZavrsetka
        //        + " Namestaj: " + NamestajID + " Popust: " + Popust + "%";
        //}

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.Akcije)
            {
                if (akcija.id == id)
                {
                    return akcija;
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
