using POP_SF172015WPF;
using POP_SF172015WPF.Model;
using POP_SF172015WPF.Utils;
using System.Collections.ObjectModel;

namespace POP_SF172015WPF
{
    class Projekat
    {
        

        public static Korisnik LoggedUser = null;

        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Racun> Prodaje { get; set; }
        
        

        private static Projekat instance = new Projekat();

        public static Projekat Instance
        {
            get 
            {
                return instance;
            }
        }

        private Projekat()
        {

            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            

        }
    }
}
