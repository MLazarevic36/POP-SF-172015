using POP_SF172015WPF.Model;


using System.Collections.ObjectModel;

namespace POP_SF172015WPF
{
    public class Projekat
    {
        public const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;
                                                    Initial Catalog=SalonNamestaja;
                                                    Trusted_Connection=True;";


        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Namestaj> Namestajm { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Racun> Racuni { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }




        private static Projekat instance = new Projekat();

        

        private Projekat()
        {

            Namestajm = new ObservableCollection<Namestaj>();
            TipoviNamestaja = new ObservableCollection<TipNamestaja>();
            Korisnici = new ObservableCollection<Korisnik>();
            Akcije = new ObservableCollection<Akcija>();
            Racuni = new ObservableCollection<Racun>();
            DodatneUsluge = new ObservableCollection<DodatnaUsluga>();
            
            
        }

        public static Projekat Instance
        {
            get
            {
                return instance;
            }
        }

        public static Korisnik LoggedUser = null;
        
    }
}
