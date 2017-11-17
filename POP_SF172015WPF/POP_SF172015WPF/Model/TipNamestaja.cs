using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Model
{
    public class TipNamestaja
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public Boolean Obrisan { get; set; }


        public override string ToString()
        {
            return "ID " + ID + " Naziv: " + Naziv;
        }
    }
}
