using POP_SF172015WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POP_SF172015WPF.Model;

namespace POP_SF172015WPF.Menadzeri
{
    class ProdajaMenadzer
    {
        public static int PDV = 10;

        public static void ProdajaMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa prodajama ###");
                    Projekat.IspisiCRUDMeni();
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
                        PodesiPDV();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        public static Prodaja GetById(int id)
        {
            foreach (var prodaja in Projekat.ListaProdaja)
            {
                if (prodaja.ID == id)
                {
                    return prodaja;
                }
            }
            return null;
        }

        private static void IzlistajProdaje()
        {
            for (int i = 0; i < Projekat.ListaProdaja.Count; i++)
            {
                if (Projekat.ListaProdaja[i].Obrisan == false)
                {
                    Console.WriteLine(Projekat.ListaProdaja[i].ToString());
                }
            }
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
            for (int i = 0; i < Projekat.ListaProdaja.Count; i++)
            {
                if (izbor == Projekat.ListaProdaja[i].ID)
                {
                    Projekat.ListaProdaja[i].Obrisan = true;
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
