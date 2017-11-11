using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015.Model
{
    public class Akcija
    {
        public int ID { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public Boolean Obrisan { get; set; }
        public int NamestajID { get; set; }
        public int Popust { get; set; }

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Program.ListaAkcija)
            {
                if (akcija.ID == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "ID: " + ID + " Pocetak akcije: " + DatumPocetka + " Datum zavrsetka: " + DatumZavrsetka
                + " Namestaj: " + NamestajID + " Popust: " + Popust + "%";
        }
    }
}
