using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Model
{
    public class Korisnik
    {
        public enum TipoviKorisnika { ADMIN, PRODAVAC };
        public TipoviKorisnika TipKorisnika { get; set; }
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String KorIme { get; set; }
        public String Password { get; set; }
        public Boolean Obrisan { get; set; }


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


        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " Username: " + KorIme + " Tip: " + TipKorisnika;
        }

        public static Boolean KorisnikExist(String username)
        {
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.KorIme == username)
                {
                    return true;
                }
            }
            return false;
        }

        public static Korisnik KorisnikExist(String korisnickoIme, String password)
        {
            foreach (var korisnik in Projekat.ListaKorisnika)
            {
                if (korisnik.KorIme.ToLower() == korisnickoIme && korisnik.Password.ToLower() == password)
                {
                    return korisnik;
                }
            }
            return null;
        }
    }
}
