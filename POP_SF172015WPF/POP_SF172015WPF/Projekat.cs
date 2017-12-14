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
            // ne radi ucitavanje salon.xml i racuni.xml 

            //Saloni = GenericSerializer.Deserialize<Salon>("salon.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            TipoviNamestaja = TipNamestaja.GetAll();
            Korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            Akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
            Racuni = GenericSerializer.Deserialize<Racun>("racuni.xml");
            //DodatneUsluge = GenericSerializer.Deserialize<DodatnaUsluga>("usluge.xml");
            

        }

        

        public void ProjekatExit()
        {
            GenericSerializer.Serialize("namestaj.xml", Namestaj);
            GenericSerializer.Serialize("korisnici.xml", Korisnici);
            GenericSerializer.Serialize("tipovi_namestaja.xml", TipoviNamestaja);
            GenericSerializer.Serialize("akcije.xml", Akcije);
            GenericSerializer.Serialize("racuni.xml", Racuni);


        }
    }
}
