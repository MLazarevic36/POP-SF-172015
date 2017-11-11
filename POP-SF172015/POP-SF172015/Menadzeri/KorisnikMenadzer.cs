using POP_SF172015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POP_SF172015.Model.Korisnik;

namespace POP_SF172015.Menadzeri
{
    class KorisnikMenadzer
    {
        public static void IzlistajKorisnike()
        {
            Console.WriteLine();
            for (int i = 0; i < Program.ListaKorisnika.Count; i++)
            {
                if (Program.ListaKorisnika[i].Obrisan == false)
                {
                    Console.WriteLine(Program.ListaKorisnika[i].ToString());
                }
            }
        }

        public static void KorisniciMeni()
        {
            int izbor = 1;
            do
            {
                do
                {
                    Console.WriteLine("\n### Rad sa korisnicima ###");
                    Program.IspisiCRUDMeni();
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

        private static void IzbrisiKorisnika()
        {
            IzlistajKorisnike();
            Console.WriteLine("\nID korisnika >> ");
            int izbor = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Program.ListaKorisnika.Count; i++)
            {
                if (izbor == Program.ListaKorisnika[i].ID)
                {
                    Program.ListaKorisnika[i].Obrisan = true;
                }
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
                for (int i = 0; i < Program.ListaKorisnika.Count; i++)
                {
                    if (izbor == Program.ListaKorisnika[i].ID)
                    {
                        Console.WriteLine("Novo ime >> ");
                        Program.ListaKorisnika[i].Ime = Console.ReadLine();
                        Console.WriteLine("Novo prezime >> ");
                        Program.ListaKorisnika[i].Prezime = Console.ReadLine();
                        Console.WriteLine("Nov username >> ");
                        String Username = Console.ReadLine();
                        if (Korisnik.KorisnikExist(Username) == true)
                        {
                            msg = "\nUsername vec postoji!";
                            throw new Exception();
                        }
                        Program.ListaKorisnika[i].Username = Username;
                        Console.WriteLine("Nov password >> ");
                        Program.ListaKorisnika[i].Password = Console.ReadLine();

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(msg);
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

                int ID = Projekat.Instance.Korisnici.Count + 1;
                Console.WriteLine("Username >> ");
                String Username = Console.ReadLine();
                if (Korisnik.KorisnikExist(Username) == true)
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
                    Username = Username,
                    Obrisan = false,
                    tipKorisnika = tipoviKorisnika
                };
                Program.ListaKorisnika.Add(noviK);
            }
            catch (Exception)
            {

                Console.WriteLine(msg);
            }
        }
    }
}
