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
            foreach (var namestaj in Projekat.Instance.Namestajm)
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

            using (SqlConnection connection = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj();
                    n.Id = (int)row["Id"];
                    n.TipNamestajaId = (int)row["TipNamestajaId"];
                    n.AkcijaId = (int)row["AkcijaId"];
                    n.Naziv = (string)row["Naziv"];
                    n.Cena = (int)row["Cena"];
                    n.Raspolozivost = (int)row["Raspolozivost"];
                    n.Obrisan = (bool)row["Obrisan"];

                    Projekat.Instance.Namestajm.Add(n);
                }

            }
            return namestaj;

        }

        public static Namestaj Create(Namestaj n)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Cena, Raspolozivost, Obrisan) VALUES ( @TipNamestajaId, @AkcijaId, @Naziv, @Cena, @Raspolozivost, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("Raspolozivost", n.Raspolozivost);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                n.Id = newId;

            }
            Projekat.Instance.Namestajm.Add(n);

            return n;
        }

        public static void Update(Namestaj n)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipNamestajaId, AkcijaId=@AkcijaId, Naziv=@Naziv, Cena=@Cena, Raspolozivost=@Raspolozivost, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", n.Akcija);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("Raspolozivost", n.Raspolozivost);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var namestaj in Projekat.Instance.Namestajm)
                {
                    if (namestaj.Id == n.Id)
                    {
                        namestaj.TipNamestajaId = n.TipNamestajaId;
                        namestaj.AkcijaId = n.AkcijaId;
                        namestaj.Naziv = n.Naziv;
                        namestaj.Cena = n.Cena;
                        namestaj.Raspolozivost = n.Raspolozivost;
                        namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }

        #endregion

    }
}
