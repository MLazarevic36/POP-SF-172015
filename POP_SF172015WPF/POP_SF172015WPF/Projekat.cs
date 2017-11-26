using POP_SF172015WPF.Model;
using POP_SF172015WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF172015WPF
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public static ObservableCollection<Namestaj> ListaNamestaja = Instance.Namestaj;
        public static ObservableCollection<TipNamestaja> ListaTipovaNamestaja = Instance.TipoviNamestaja;
        public static ObservableCollection<Korisnik> ListaKorisnika = Instance.Korisnici;
        public static ObservableCollection<Akcija> ListaAkcija = Instance.Akcije;
        public static ObservableCollection<Prodaja> ListaProdaja = Instance.Prodaje;

        public static Korisnik LoggedUser = null;

        private Projekat()
        {
            TipoviNamestaja = new ObservableCollection<TipNamestaja>(GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml"));
            Namestaj = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
            Korisnici = new ObservableCollection<Korisnik>(GenericSerializer.Deserialize<Korisnik>("korisnici.xml"));
        }

        //public static void ProjekatExit()
        //{
        //    Instance.Namestaj = ListaNamestaja;
        //    Instance.TipoviNamestaja = ListaTipovaNamestaja;
        //    Instance.Korisnici = ListaKorisnika;
        //    Instance.Akcije = ListaAkcija;
        //    Instance.Prodaje = ListaProdaja;
        //}

       

        //private ObservableCollection<Namestaj> namestaj;
        //public ObservableCollection<Namestaj> Namestaj
        //{
        //    get
        //    {
        //        namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
        //        return namestaj;
        //    }
        //    set
        //    {
        //        namestaj = value;
        //        GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
        //    }
        //}

        //private ObservableCollection<TipNamestaja> tipoviNamestaja;
        //public ObservableCollection<TipNamestaja> TipoviNamestaja
        //{
        //    get
        //    {
        //        tipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
        //        return tipoviNamestaja;
        //    }
        //    set
        //    {
        //        tipoviNamestaja = value;
        //        GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", tipoviNamestaja);
        //    }
        //}

        //private ObservableCollection<Korisnik> korisnici;
        //public ObservableCollection<Korisnik> Korisnici
        //{
        ////    get
        ////    {
        ////        korisnici = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
        ////        return korisnici;
        ////    }
        ////    set
        ////    {
        ////        korisnici = value;
        ////        GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisnici);
        ////    }
        //}

        //private ObservableCollection<Akcija> akcije;
        //public ObservableCollection<Akcija> Akcije
        //{
        //    get
        //    {
        //        akcije = GenericSerializer.Deserialize<Akcija>("akcije.xml");
        //        return akcije;
        //    }
        //    set
        //    {
        //        akcije = value;
        //        GenericSerializer.Serialize<Akcija>("akcije.xml", akcije);
        //    }
        //}

        //private ObservableCollection<Prodaja> prodaje;
        //public ObservableCollection<Prodaja> Prodaje
        //{
        //    get
        //    {
        //        prodaje = GenericSerializer.Deserialize<Prodaja>("prodaje.xml");
        //        return prodaje;
        //    }
        //    set
        //    {
        //        prodaje = value;
        //        GenericSerializer.Serialize<Prodaja>("prodaje.xml", prodaje);
        //    }
        //}
    }
}
