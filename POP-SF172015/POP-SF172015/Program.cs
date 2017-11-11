using POP_SF172015.Model;
using POP_SF172015.Menadzeri;
using POP_SF172015.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015
{
    class Program
    {
        public static List<Namestaj> ListaNamestaja = Projekat.Instance.Namestaj;
        public static List<TipNamestaja> ListaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;
        public static List<Korisnik> ListaKorisnika = Projekat.Instance.Korisnici;
        public static List<Akcija> ListaAkcija = Projekat.Instance.Akcije;
        public static List<Prodaja> ListaProdaja = Projekat.Instance.Prodaje;

        static void Main(string[] args)
        {
            Salon s1 = new Salon()
            {
                ID = 066,
                Naziv = "Salon Namestaja Surdulica",
                Adresa = "Bulevar Cara Lazara 36",
                Telefon = 0617674362,
                Email = "salonnamestaja@gmail.com",
                AdresaSajta = "www.snsurdulica.com",
                PIB = 21000,
                MaticniBroj = 0,
                BrZiroRacuna = 0
            };
            AdditionalUtils.IzbrisiStareAkcije();
            Console.WriteLine($"# Dobrodosli u {s1.Naziv}. #");
            GlavniMeni();
        }

        private static void GlavniMeni()
        {
            int izbor = 1;

            do
            {
                do
                {
                    Console.WriteLine("\n## Glavni meni ##");
                    Console.WriteLine("1) Rad sa namestajem");
                    Console.WriteLine("2) Rad sa korisnicima");
                    Console.WriteLine("3) Rad sa akcijama");
                    Console.WriteLine("4) Rad sa tipovima namestaja");
                    Console.WriteLine("5) Rad sa prodajama");
                    Console.WriteLine("0) Izlaz");
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 5);

                switch (izbor)
                {
                    case 1:
                        NamestajMenadzer.NamestajMeni();
                        break;
                    case 2:
                        KorisnikMenadzer.KorisniciMeni();
                        break;
                    case 3:
                        AkcijeMenadzer.AkcijeMeni();
                        break;
                    case 4:
                        TipNamestajaMenadzer.TipNamestajaMeni();
                        break;
                    case 5:
                        ProdajaMenadzer.ProdajaMeni();
                        break;
                    default:
                        Projekat.Instance.Namestaj = ListaNamestaja;
                        Projekat.Instance.TipoviNamestaja = ListaTipovaNamestaja;
                        Projekat.Instance.Korisnici = ListaKorisnika;
                        Projekat.Instance.Akcije = ListaAkcija;
                        Projekat.Instance.Prodaje = ListaProdaja;
                        break;
                }

            } while (izbor != 0);
        }

        public static void IspisiCRUDMeni()
        {
            Console.WriteLine("1) Izlistaj");
            Console.WriteLine("2) Dodaj");
            Console.WriteLine("3) Azuriraj");
            Console.WriteLine("4) Izbrisi");
            Console.WriteLine("0) Nazad");
        }
    }
}
