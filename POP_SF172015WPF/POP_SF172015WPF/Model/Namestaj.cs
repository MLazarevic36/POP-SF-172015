using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015.Model
{
    public class Namestaj
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public int Cena { get; set; }
        public int KolicinaMagacin { get; set; }
        public int TipNamestajaId { get; set; }
        public Boolean Obrisan { get; set; }

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Program.ListaNamestaja)
            {
                if (namestaj.ID == id)
                {
                    return namestaj;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "Id: " + ID + " Naziv: " + Naziv + " Sifra: " + ID
                + " Cena: " + Cena + " Kolicina: " + KolicinaMagacin;
        }
    }
}
