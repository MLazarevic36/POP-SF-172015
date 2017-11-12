using POP_SF172015WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Menadzeri
{
    class NamestajMenadzer
    {
        public static void IzbrisiNamestaj()
        {
            Console.WriteLine("ID Namestaja >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Projekat.ListaNamestaja.Count; i++)
            {
                if (izbor == Projekat.ListaNamestaja[i].ID)
                {
                    Projekat.ListaNamestaja[i].Obrisan = true;
                }
            }
        }

        public static void AzurirajNamestaj()
        {
            Console.WriteLine();
            Console.WriteLine("ID Namestaja >> ");

            try
            {
                int izbor = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Projekat.ListaNamestaja.Count; i++)
                {
                    if (izbor == Projekat.ListaNamestaja[i].ID)
                    {
                        Console.WriteLine("Nova cena >> ");
                        Projekat.ListaNamestaja[i].Cena = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nova kolicina >> ");
                        Projekat.ListaNamestaja[i].KolicinaMagacin = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nPogresan unos!");
            }
        }

        public static void DodajNamestaj()
        {
            Console.WriteLine();
            int ID = Projekat.Instance.Namestaj.Count + 1;
            Console.WriteLine("Naziv >> ");
            string Naziv = Console.ReadLine();
            Console.WriteLine("Cena >> ");
            int Cena = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kolicina >> ");
            int KolicinaMagacin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Tipovi Namestaja: ");
            TipNamestajaMenadzer.IzlistajTipoveNamestaja();
            Console.WriteLine();
            Console.WriteLine("ID Tipa Namestaja >> ");
            int TipNamestajaId = Convert.ToInt32(Console.ReadLine());

            Namestaj NoviN = new Namestaj()
            {
                Naziv = Naziv,
                ID = ID,
                Cena = Cena,
                KolicinaMagacin = KolicinaMagacin,
                TipNamestajaId = TipNamestajaId
            };

            Projekat.ListaNamestaja.Add(NoviN);
        }

        public static void IzlistajNamestaj()
        {
            Console.WriteLine();
            for (int i = 0; i < Projekat.ListaNamestaja.Count; i++)
            {
                if (Projekat.ListaNamestaja[i].Obrisan == false)
                {
                    Console.WriteLine(Projekat.ListaNamestaja[i].ToString());
                }
            }
        }

        public static void NamestajMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa namestajem ###");
                    Projekat.IspisiCRUDMeni();
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        IzlistajNamestaj();
                        break;
                    case 2:
                        DodajNamestaj();
                        break;
                    case 3:
                        AzurirajNamestaj();
                        break;
                    case 4:
                        IzbrisiNamestaj();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.ListaNamestaja)
            {
                if (namestaj.ID == id)
                {
                    return namestaj;
                }
            }
            return null;
        }
    }
}
