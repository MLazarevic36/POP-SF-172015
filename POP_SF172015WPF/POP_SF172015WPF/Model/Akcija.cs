using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace POP_SF172015WPF.Model
{
    public class Akcija : ICloneable, INotifyPropertyChanged
    {

        private int id;
        private int popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private Boolean obrisan;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
               
        }


        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }

        }

        public Boolean Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }

        }

        public int Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }


        public override string ToString()
        {
            return Popust + "%";
        }

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.Akcije)
            {
                if (akcija.id == id)
                {
                    return akcija;
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

        public object Clone()
        {
            Akcija kopija = new Akcija();
            kopija.Id = Id;
            kopija.Popust = Popust;
            kopija.DatumPocetka = DatumPocetka;
            kopija.DatumZavrsetka = DatumZavrsetka;
            kopija.Obrisan = Obrisan;
            return kopija;
        }

        #region Database
        public static ObservableCollection<Akcija> GetAll()
        {
            var akcija = new ObservableCollection<Akcija>();

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija"); //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    Akcija a = new Akcija();
                    a.Id = (int)row["Id"];
                    a.Popust = (int)row["Popust"];
                    a.DatumPocetka = (DateTime)row["DatumPocetka"];
                    a.DatumZavrsetka = (DateTime)row["DatumZavrsetka"];
                    a.Obrisan = (bool)row["Obrisan"];

                    Projekat.Instance.Akcije.Add(a);
                }

            }
            return akcija;
        }

        public static Akcija Create(Akcija a)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO Akcija(Popust, DatumPocetka, DatumZavrsetka, Obrisan) VALUES ( @Popust, @DatumPocetka, @DatumZavrsetka, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Popust", a.Popust );
                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());
                a.Id = newId;

            }
            Projekat.Instance.Akcije.Add(a);

            return a;
        }

        public static void Update(Akcija a)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Akcije SET Popust=@Popust, DatumPocetka=@DatumPocetka, DatumZavrsetka=@DatumZavrsetka, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", a.Id);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var akcija in Projekat.Instance.Akcije)
                {
                    if (akcija.Id == a.Id)
                    {
                        akcija.Popust = a.Popust;
                        akcija.DatumPocetka = a.DatumPocetka;
                        akcija.DatumZavrsetka = a.DatumZavrsetka;
                        akcija.Obrisan = a.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;
            Update(a);
        }

        #endregion
    }

}
