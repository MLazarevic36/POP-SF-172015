using POP_SF172015WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Menadzeri
{
    class ProdajaMenadzer
    {
        public static void ProdajaMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa prodajama ###");
                    Program.IspisiCRUDMeni();
                    Console.WriteLine("5) Podesi PDV");
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 5);

                switch (izbor)
                {
                    case 1:
                        IzlistajProdaje();
                        break;
                    case 2:
                        DodajProdaju();
                        break;
                    case 3:
                        AzurirajProdaju();
                        break;
                    case 4:
                        IzbrisiProdaju();
                        break;
                    case 5:
                        AdditionalUtils.PodesiPDV();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        private static void DodajProdaju()
        {
            throw new NotImplementedException();
        }

        private static void AzurirajProdaju()
        {
            throw new NotImplementedException();
        }

        private static void IzbrisiProdaju()
        {
            Console.WriteLine("\nID Prodaje >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Program.ListaProdaja.Count; i++)
            {
                if (izbor == Program.ListaProdaja[i].ID)
                {
                    Program.ListaProdaja[i].Obrisan = true;
                }
            }
        }

        private static void IzlistajProdaje()
        {
            for (int i = 0; i < Program.ListaProdaja.Count; i++)
            {
                if (Program.ListaProdaja[i].Obrisan == false)
                {
                    Console.WriteLine(Program.ListaProdaja[i].ToString());
                }
            }
        }
    }
}
