using POP_SF172015WPF.Model;
using POP_SF172015WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public static List<Namestaj> ListaNamestaja = Instance.Namestaj;
        public static List<TipNamestaja> ListaTipovaNamestaja = Instance.TipoviNamestaja;
        public static List<Korisnik> ListaKorisnika = Instance.Korisnici;
        public static List<Akcija> ListaAkcija = Instance.Akcije;
        public static List<Prodaja> ListaProdaja = Instance.Prodaje;

        public static Korisnik UlogovaniKorisnik = null;

        public static bool AdminOn = false;
        public static bool ProdavacOn = false;

        public static void ProjekatExit()
        {
            Instance.Namestaj = ListaNamestaja;
            Instance.TipoviNamestaja = ListaTipovaNamestaja;
            Instance.Korisnici = ListaKorisnika;
            Instance.Akcije = ListaAkcija;
            Instance.Prodaje = ListaProdaja;
        }

        public static void IspisiCRUDMeni()
        {
            Console.WriteLine("1) Izlistaj");
            Console.WriteLine("2) Dodaj");
            Console.WriteLine("3) Azuriraj");
            Console.WriteLine("4) Izbrisi");
            Console.WriteLine("0) Nazad");
        }

        private List<Namestaj> namestaj;
        public List<Namestaj> Namestaj
        {
            get
            {
                namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestaj;
            }
            set
            {
                namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }

        private List<TipNamestaja> tipoviNamestaja;
        public List<TipNamestaja> TipoviNamestaja
        {
            get
            {
                tipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
                return tipoviNamestaja;
            }
            set
            {
                tipoviNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", tipoviNamestaja);
            }
        }

        private List<Korisnik> korisnici;
        public List<Korisnik> Korisnici
        {
            get
            {
                korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
                return korisnici;
            }
            set
            {
                korisnici = value;
                GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisnici);
            }
        }

        private List<Akcija> akcije;
        public List<Akcija> Akcije
        {
            get
            {
                akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
                return akcije;
            }
            set
            {
                akcije = value;
                GenericSerializer.Serialize<Akcija>("akcije.xml", akcije);
            }
        }

        private List<Prodaja> prodaje;
        public List<Prodaja> Prodaje
        {
            get
            {
                prodaje = GenericSerializer.Deserialize<Prodaja>("prodaje.xml");
                return prodaje;
            }
            set
            {
                prodaje = value;
                GenericSerializer.Serialize<Prodaja>("prodaje.xml", prodaje);
            }
        }
    }
}
