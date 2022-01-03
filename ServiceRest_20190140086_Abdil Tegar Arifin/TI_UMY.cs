using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceRest_20190140086_Abdil_Tegar_Arifin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {

        public string CreateMahasiswa(Mahasiswa mhs)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-ECRNKVS;Initial Catalog=TI_UMY;Persist Security Info=True; User ID=sa;password=Bismillah12");
            string msg;
            string query = String.Format("INSERT INTO dbo.Mahasiswa VALUES('{0}','{1}','{2}','{3}')", mhs.nim, mhs.nama, mhs.prodi, mhs.angkatan);
            SqlCommand sqlCom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
                msg = "sukses";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "gagal";
            }
            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-ECRNKVS;Initial Catalog=TI_UMY;Persist Security Info=True; User ID=sa;password=Bismillah12");
            List<Mahasiswa> list = new List<Mahasiswa>();
            string query = String.Format("SELECT Nama, Nim, Prodi, Angkatan from dbo.Mahasiswa");
            SqlCommand sqlCom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                SqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                    list.Add(mhs);
                }

                sqlcon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            return list;
        }

        public Mahasiswa GetMahasiswaByNim(string nim)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-ECRNKVS;Initial Catalog=TI_UMY;Persist Security Info=True; User ID=sa;password=Bismillah12");
            Mahasiswa mhs = new Mahasiswa();
            string query = String.Format("SELECT Nama, Nim, Prodi, Angkatan from dbo.Mahasiswa WHERE Nim='{0}'",nim);
            SqlCommand sqlCom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                SqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }

                sqlcon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }
    }
}
