using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Model
{
    public class Namestaj
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public int Cena { get; set; }
        public int KolicinaMagacin { get; set; }
        public int TipNamestajaId { get; set; }
        public Boolean Obrisan { get; set; }

        public override string ToString()
        {
            return "Id: " + ID + " Naziv: " + Naziv + " Sifra: " + ID
                + " Cena: " + Cena + " Kolicina: " + KolicinaMagacin;
        }
    }
}
