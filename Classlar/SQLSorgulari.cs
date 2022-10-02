using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryPenaltyCase.Classlar
{
    public class SQLSorgulari
    {
        //ToDo: Zaman kalırsa sql sorgularını ve veritabanı sistemini Entity Framework sistemine çevir

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public List<DateTime> TatilGunleriGetir(string ulkeAdi)
        {
            List<DateTime> tatilGunleri = new List<DateTime>();
            baglanti.Open();

            string sorgu = "select * from TatilGunleri where UlkeAdi = '" + ulkeAdi + "'"; //Sadece seçilen ülkeye ait tatil günlerini getir

            SqlCommand komut = new SqlCommand(sorgu, baglanti);

            var dataReader = komut.ExecuteReader();

            while (dataReader.Read())
            {
                var tatilGunu = (DateTime)dataReader["Tarih"];

                tatilGunleri.Add(tatilGunu);   //tatil günlerinin tamamını datareader'dan listeye al kullanım kolaylığı için
            }
            dataReader.Close();
            baglanti.Close();
            
            return tatilGunleri;
        }

        public Ulkeler UlkeGetir(string ulkeAdi)
        {
            Ulkeler ulke = new Ulkeler();
            baglanti.Open();

            string sorgu = "Select * from Ulkeler where UlkeAdi ='" + ulkeAdi + "'";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);

            SqlDataReader dataReader = komut.ExecuteReader();

            while (dataReader.Read())
            {
                ulke.UlkeAdi = dataReader["UlkeAdi"].ToString();
                ulke.ParaBirimi = dataReader["ParaBirimi"].ToString();
                ulke.CezaMiktari = float.Parse(dataReader["CezaMiktari"].ToString());
            }
            dataReader.Close();
            baglanti.Close();

            return ulke;
        }
    }
}