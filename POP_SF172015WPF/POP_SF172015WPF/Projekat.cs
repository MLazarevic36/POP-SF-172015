using POP_SF172015WPF.Model;


using System.Collections.ObjectModel;

namespace POP_SF172015WPF
{
    class Projekat
    {
        public const string CONNECTION_STRING = @"Integrated Security=true;
                                                      Initial Catalog=SalonNamestaja;
                                                      Data Source=.\SQLEXPRESS";

        public static Korisnik LoggedUser = null;

        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<Racun> Racuni { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }




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

            TipoviNamestaja = TipNamestaja.GetAll();
        }


        
    }
}
