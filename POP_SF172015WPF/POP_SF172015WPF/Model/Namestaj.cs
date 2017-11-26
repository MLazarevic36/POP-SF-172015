using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POP_SF172015WPF.Model
{
    public class Namestaj : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public int ID { get; set; }
        //public String Naziv { get; set; }
        //public int Cena { get; set; }
        //public int KolicinaMagacin { get; set; }
        //public int TipNamestajaId { get; set; }
        //public Boolean Obrisan { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }





        public override string ToString()
        {
            return "Id: " + ID + " Naziv: " + Naziv + " Sifra: " + ID
                + " Cena: " + Cena + " Kolicina: " + KolicinaMagacin;
        }

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.ListaNamestaja)
            {
                if (namestaj.ID == id)
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
