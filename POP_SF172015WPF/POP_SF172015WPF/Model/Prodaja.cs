using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POP_SF172015.Model;

namespace POP_SF172015.Model
{
    public class Prodaja
    {
        public int ID { get; set; }
        public List<Namestaj> ListaNamestaja { get; set; }
        public DateTime DatumProdaje { get; set; }
        public String Kupac { get; set; }
        public int BrojRacuna { get; set; }
        public int UkupnaCena { get; set; }
        public Boolean Obrisan { get; set; }

        public static Prodaja GetById(int id)
        {
            foreach (var prodaja in Program.ListaProdaja)
            {
                if (prodaja.ID == id)
                {
                    return prodaja;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "Br racuna: " + BrojRacuna + " Ukupna cena: " + UkupnaCena + " Datum prodaje: " + DatumProdaje
                + " Kupac: " + Kupac + " Namestaj: " + ListaNamestaja;
        }
    }
}
