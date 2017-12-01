using System;
using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Akcija : INotifyPropertyChanged
    {

        private int id;
        private int namestajId;
        private int popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private Boolean obrisan;

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

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
               
        }


        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }

        }

        public Boolean Obrisan
        {
            get { return Obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
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
