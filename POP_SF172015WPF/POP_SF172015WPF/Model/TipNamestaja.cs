using System;
using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private String naziv;
        private Boolean obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
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

        public Boolean Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public override string ToString()
        {
            return naziv;
        }

        public object Clone()
        {
            TipNamestaja kopija = new TipNamestaja();
            kopija.Id = Id;
            kopija.Naziv = Naziv;
            kopija.Obrisan = Obrisan;
            return kopija;
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                if (tipNamestaja.id == id)
                {
                    return tipNamestaja;
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
