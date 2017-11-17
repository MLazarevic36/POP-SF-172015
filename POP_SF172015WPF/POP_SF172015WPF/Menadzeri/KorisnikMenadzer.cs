using POP_SF172015WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POP_SF172015WPF.Model.Korisnik;

namespace POP_SF172015WPF.Menadzeri
{
    class KorisnikMenadzer
    {
        public static void KorisniciMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa korisnicima ###");
                    Projekat.IspisiCRUDMeni();
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        IzlistajKorisnike();
                        break;
                    case 2:
                        DodajKorisnika();
                        break;
                    case 3:
                        AzurirajKorisnika();
                        break;
                    case 4:
                        IzbrisiKorisnika();
                        break;
                    default:
                        break;
                }

            } while (izbor != 0);
        }

        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.ID == id)
                {
                    return korisnik;
                }
            }
            return null;
        }

        public static void IzlistajKorisnike()
        {
            Console.WriteLine();
            for (int i = 0; i < Projekat.ListaKorisnika.Count; i++)
            {
                if (Projekat.ListaKorisnika[i].Obrisan == false)
                {
                    Console.WriteLine(Projekat.ListaKorisnika[i].ToString());
                }
            }
        }

        private static void DodajKorisnika()
        {
            String msg = "";
            TipoviKorisnika tipoviKorisnika;
            Console.WriteLine();
            try
            {
                Console.WriteLine("Tip korisnika >> ");
                Console.WriteLine("\n1) Administrator");
                Console.WriteLine("2) Prodavac");
                int tipKorisnika = Convert.ToInt32(Console.ReadLine());
                if (tipKorisnika == 1)
                {
                    tipoviKorisnika = TipoviKorisnika.ADMINISTRATOR;
                }
                else if (tipKorisnika == 2)
                {
                    tipoviKorisnika = TipoviKorisnika.PRODAVAC;
                }
                else
                {
                    msg = "Pogresan unos!";
                    throw new Exception();
                }

                int ID = Projekat.ListaKorisnika.Count + 1;
                Console.WriteLine("Username >> ");
                String Username = Console.ReadLine();
                if (KorisnikExist(Username) == true)
                {
                    msg = "\nUsername vec postoji!";
                    throw new Exception();
                }
                Console.WriteLine("Ime >> ");
                String Ime = Console.ReadLine();
                Console.WriteLine("Prezime >> ");
                String Prezime = Console.ReadLine();
                Console.WriteLine("Password >> ");
                String Password = Console.ReadLine();

                Korisnik noviK = new Korisnik()
                {
                    ID = ID,
                    Ime = Ime,
                    Prezime = Prezime,
                    Password = Password,
                    UserName = Username,
                    Obrisan = false,
                    TipKorisnika = tipoviKorisnika
                };
                Projekat.ListaKorisnika.Add(noviK);
            }
            catch (Exception)
            {

                Console.WriteLine(msg);
            }
        }

        private static void AzurirajKorisnika()
        {
            String msg = "";
            Console.WriteLine();
            Console.WriteLine("ID korisnika >> ");

            try
            {
                int izbor = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Projekat.ListaKorisnika.Count; i++)
                {
                    if (izbor == Projekat.ListaKorisnika[i].ID)
                    {
                        Console.WriteLine("Novo ime >> ");
                        Projekat.ListaKorisnika[i].Ime = Console.ReadLine();
                        Console.WriteLine("Novo prezime >> ");
                        Projekat.ListaKorisnika[i].Prezime = Console.ReadLine();
                        Console.WriteLine("Nov username >> ");
                        String Username = Console.ReadLine();
                        if (KorisnikExist(Username) == true)
                        {
                            msg = "\nUsername vec postoji!";
                            throw new Exception();
                        }
                        Projekat.ListaKorisnika[i].UserName = Username;
                        Console.WriteLine("Nov password >> ");
                        Projekat.ListaKorisnika[i].Password = Console.ReadLine();

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(msg);
            }
        }

        private static void IzbrisiKorisnika()
        {
            IzlistajKorisnike();
            Console.WriteLine("\nID korisnika >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Projekat.ListaKorisnika.Count; i++)
            {
                if (izbor == Projekat.ListaKorisnika[i].ID)
                {
                    Projekat.ListaKorisnika[i].Obrisan = true;
                }
            }
        }

        public static Boolean KorisnikExist(String username)
        {
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }

        public static Korisnik KorisnikExist(String username, String password)
        {
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.UserName.ToLower() == username && korisnik.Password.ToLower() == password)
                {
                    return korisnik;
                }
            }
            return null;
        }
    }
}
