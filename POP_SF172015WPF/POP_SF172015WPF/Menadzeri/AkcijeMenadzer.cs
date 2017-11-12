using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POP_SF172015WPF.Model;

namespace POP_SF172015WPF.Menadzeri
{
    class AkcijeMenadzer
    {
        public static void AkcijeMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa akcijama ###");
                    Projekat.IspisiCRUDMeni();
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        IzlistajAkcije();
                        break;
                    case 2:
                        DodajAkcije();
                        break;
                    case 3:
                        AzurirajAkcije();
                        break;
                    case 4:
                        IzbrisiAkcije();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        private static void IzbrisiAkcije()
        {
            IzlistajAkcije();
            Console.WriteLine("\nID akcije >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Projekat.ListaAkcija.Count; i++)
            {
                if (izbor == Projekat.ListaAkcija[i].ID)
                {
                    Projekat.ListaAkcija[i].Obrisan = true;
                }
            }
        }

        private static void AzurirajAkcije()
        {
            try
            {
                IzlistajAkcije();
                Console.WriteLine("\nProduzi trajanje akcije.");
                Console.WriteLine("ID akcije");
                int izbor = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Projekat.ListaAkcija.Count; i++)
                {
                    if (izbor == Projekat.ListaAkcija[i].ID && Projekat.ListaAkcija[i].Obrisan == false)
                    {
                        Console.WriteLine("Godina Zavrsetka >> ");
                        int GodinaZavrsetka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Mesec  Zavrsetka >> ");
                        int MesecZavrsetka = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Dan Zavrsetka >> ");
                        int DanZavrsetka = Convert.ToInt32(Console.ReadLine());

                        Projekat.ListaAkcija[i].DatumZavrsetka = new DateTime(GodinaZavrsetka, MesecZavrsetka, DanZavrsetka);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Format nekog podatka nije dobar!");
            }
        }

        private static void DodajAkcije()
        {
            try
            {
                int ID = Projekat.Instance.Akcije.Count + 1;
                Console.WriteLine("Popust (u %) >> ");
                int Popust = Convert.ToInt32(Console.ReadLine());
                NamestajMenadzer.IzlistajNamestaj();
                Console.WriteLine("Namesetaj ID >> ");
                int NamestajID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Godina Pocetka >> ");
                int GodinaPocetak = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mesec Pocetka >> ");
                int MesecPocetak = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dan Pocetka >> ");
                int DanPocetak = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Godina Zavrsetka >> ");
                int GodinaZavrsetka = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mesec  Zavrsetka >> ");
                int MesecZavrsetka = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dan Zavrsetka >> ");
                int DanZavrsetka = Convert.ToInt32(Console.ReadLine());

                Akcija novaA = new Akcija()
                {
                    ID = ID,
                    Obrisan = false,
                    Popust = Popust,
                    NamestajID = NamestajID,
                    DatumPocetka = new DateTime(GodinaPocetak, MesecPocetak, DanPocetak),
                    DatumZavrsetka = new DateTime(GodinaZavrsetka, MesecZavrsetka, DanZavrsetka)
                };

                Projekat.ListaAkcija.Add(novaA);
            }
            catch (Exception)
            {
                Console.WriteLine("Format nekog podatka nije dobar!");
            }
        }

        private static void IzlistajAkcije()
        {
            Console.WriteLine();
            for (int i = 0; i < Projekat.ListaAkcija.Count; i++)
            {
                if (Projekat.ListaAkcija[i].Obrisan == false)
                {
                    Console.WriteLine(Projekat.ListaAkcija[i].ToString());
                }
            }
        }
    }
}
