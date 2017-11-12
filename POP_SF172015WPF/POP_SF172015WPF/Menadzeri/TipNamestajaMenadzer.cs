using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Menadzeri
{
    class TipNamestajaMenadzer
    {
        public static void IzlistajTipoveNamestaja()
        {
            for (int i = 0; i < Program.ListaTipovaNamestaja.Count; i++)
            {
                if (Program.ListaTipovaNamestaja[i].Obrisan == false)
                {
                    Console.WriteLine(Program.ListaTipovaNamestaja[i].ToString());
                }
            }
        }

        public static void IzbrisiTipNamestaja()
        {
            Console.WriteLine("\nID Tipa namestaja >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Program.ListaTipovaNamestaja.Count; i++)
            {
                if (izbor == Program.ListaTipovaNamestaja[i].ID)
                {
                    Program.ListaTipovaNamestaja[i].Obrisan = true;
                }
            }
        }

        public static void TipNamestajaMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa tipovima namestaja ###");
                    Console.WriteLine("1) Izlistaj");
                    Console.WriteLine("2) Izbrsi");
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 2);

                switch (izbor)
                {
                    case 1:
                        IzlistajTipoveNamestaja();
                        break;
                    case 2:
                        IzbrisiTipNamestaja();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }
    }
}
