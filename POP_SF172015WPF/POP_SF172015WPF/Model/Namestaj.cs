using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace POP_SF172015WPF.Model
{
    public class Namestaj : ICloneable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int id;
        private string naziv;
        private int cena;
        private int raspolozivost;
        private int tipNamestajaId;
        private bool obrisan;
        private int akcijaId;
        private TipNamestaja tipNamestaja;
        private Akcija akcija;

        public String Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Id");
            }
        }

        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int Raspolozivost
        {
            get { return raspolozivost; }
            set
            {
                raspolozivost = value;
                OnPropertyChanged("Raspolozivost");
            }
        }

        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = Akcija.GetById(AkcijaId);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                AkcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }


        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public object Clone()
        {
            Namestaj kopija = new Namestaj();
            kopija.Cena = cena;
            kopija.Id = id;
            kopija.Raspolozivost = raspolozivost;
            kopija.Naziv = naziv;
            kopija.TipNamestajaId = tipNamestajaId;
            kopija.Obrisan = obrisan;
            return kopija;
        }


        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.id == id)
                {
                    return namestaj;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Database

        public static ObservableCollection<Namestaj> GetAll()
        {

            var namestaj = new ObservableCollection<Namestaj>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Salon"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Cena = int.Parse(row["Cena"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }

            }
            return namestaj;

        }

        #endregion

    }
}
