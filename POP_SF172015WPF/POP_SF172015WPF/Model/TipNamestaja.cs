using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015.Model
{
    public class TipNamestaja
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public Boolean Obrisan { get; set; }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Program.ListaTipovaNamestaja)
            {
                if (tipNamestaja.ID == id)
                {
                    return tipNamestaja;
                }
            }
            return null;
        }
        //krace
        //return Program.ListaTipovaNamestaja.SingleorDefault(x => x.ID == id);

        public override string ToString()
        {
            return "ID " + ID + " Naziv: " + Naziv;
        }
    }
}
