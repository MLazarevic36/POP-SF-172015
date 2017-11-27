using POP_SF172015WPF.Model;
using POP_SF172015WPF.Utils;
using System.Collections.ObjectModel;

namespace POP_SF172015WPF
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public static Korisnik LoggedUser = null;

        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja = { get; set; }
        public ObservableCollection<Korisnik> Korisnici = { get; set; }
        public ObservableCollection<Akcija> Akcije = { get; set; }
        public ObservableCollection<Prodaja> Prodaje = { get; set; }
        public ObservableCollection<Salon> SalonNamestaja = { get; set; }

        

        private Projekat()
        {

            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            Prodaje = GenericSerializer.Deserialize<Prodaja>("prodaje.xml");
            SalonNamestaja = GenericSerializer.Deserialize<Salon>("salon.xml");

        }
            

    
       
    }
}
