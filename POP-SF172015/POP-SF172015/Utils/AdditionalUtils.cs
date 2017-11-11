using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015.Utils
{
    public class AdditionalUtils
    {
        public static int PDV = 10;

        public static void IzbrisiStareAkcije()
        {
            DateTime trenutniDatum = DateTime.Now;

            for (int i = 0; i < Program.ListaAkcija.Count; i++)
            {
                if (Program.ListaAkcija[i].DatumZavrsetka < trenutniDatum)
                {
                    Program.ListaAkcija[i].Obrisan = true;
                }
            }
        }

        public static void PodesiPDV()
        {
            Console.WriteLine("Trenutni PDV iznosi: " + Convert.ToString(PDV) + "%");
            Console.WriteLine("<Enter> za izlaz");
            Console.WriteLine("Novi PDV >> ");
            try
            {
                PDV = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception) { }
        }
    }
}
