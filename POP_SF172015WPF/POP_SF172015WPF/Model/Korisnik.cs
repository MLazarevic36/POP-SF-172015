using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Model
{
    public class Korisnik
    {
        public enum TipoviKorisnika { ADMINISTRATOR, PRODAVAC };
        public TipoviKorisnika TipKorisnika { get; set; }
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean Obrisan { get; set; }

       

        

        public override string ToString()
        {
            return "Ime: " + Ime + " Prezime: " + Prezime + " Username: " + UserName + " Tip: " + TipoviKorisnika.ADMINISTRATOR;
        }
    }
}
