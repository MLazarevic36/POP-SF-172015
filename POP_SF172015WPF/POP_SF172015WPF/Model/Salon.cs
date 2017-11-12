using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF.Model
{
    class Salon
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public String Adresa { get; set; }
        public int Telefon { get; set; }
        public String Email { get; set; }
        public String AdresaSajta { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public int BrZiroRacuna { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
