using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF172015WPF.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string naziv;
        private int cena;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach (DodatnaUsluga dodatnaUsluga in Projekat.Instance.DodatneUsluge)
            {
                if (dodatnaUsluga.Id == id)
                {
                    return dodatnaUsluga;
                }
            }
            return null;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            DodatnaUsluga kopija = new DodatnaUsluga();
            kopija.Cena = cena;
            kopija.Id = id;
            kopija.Naziv = naziv;
            kopija.Obrisan = obrisan;
            return kopija;
        }

        public override string ToString()
        {
            return Naziv + Cena;
        }

        #region Database

        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatnaUsluga = new ObservableCollection<DodatnaUsluga>();

            using (SqlConnection connection = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatneUsluge WHERE Obrisan=0";
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatneUsluge"); //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    DodatnaUsluga du = new DodatnaUsluga();
                    du.Id = (int)row["Id"];
                    du.Naziv = (string)row["Naziv"];
                    du.Cena = (int)row["Cena"];
                    du.Obrisan = (bool)row["Obrisan"];

                    Projekat.Instance.DodatneUsluge.Add(du);
                }

            }
            return dodatnaUsluga;



        }

        #endregion
    }
}
