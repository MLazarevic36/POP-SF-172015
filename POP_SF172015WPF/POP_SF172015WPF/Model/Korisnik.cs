using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015.Model
{
    public class Korisnik
    {
        public enum TipoviKorisnika { ADMINISTRATOR, PRODAVAC };
        public TipoviKorisnika tipKorisnika { get; set; }
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean Obrisan { get; set; }

        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Program.ListaKorisnika)
            {
                if (korisnik.ID == id)
                {
                    return korisnik;
                }
            }
            return null;
        }

        public static Boolean KorisnikExist(String username)
        {
            foreach (var korisnik in Program.ListaKorisnika)
            {
                if (korisnik.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " Username: " + Username + " Tip: " + TipoviKorisnika.ADMINISTRATOR;
        }
    }
}
