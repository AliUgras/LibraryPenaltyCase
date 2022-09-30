using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using LibraryPenaltyCase.Classlar;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryPenaltyCase
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Değişkenler

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static float cezaMiktari;
        public static string paraBirimi;

        #endregion
        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion
        protected void btCezaHesapla_Click1(object sender, EventArgs e)
        {
            var tatilGunleri = TatilGunleriGetir();
            var cezaGunleri = new List<DateTime>();

            for (var i = clAlimTarihi.SelectedDate; i <= clTeslimTarihi.SelectedDate; i = i.AddDays(1))  //seçilen başlangıç ve bitiş tarihleri arasını for ile dön -- daha sonra bir kitap classı oluşturulup orada bir fonksiyon olarak konulabilir
            {
                if (i.DayOfWeek == DayOfWeek.Sunday || i.DayOfWeek == DayOfWeek.Saturday)
                {
                    //cumartesi ve ya pazar günlerini ceza listesine ekleme
                }
                else if (tatilGunleri.Any(x => x.TatilGunu.Day == i.Day && x.TatilGunu.Month == i.Month))
                {
                    //Resmi tatilleri ceza listesine ekleme
                }
                else
                    cezaGunleri.Add(i);  //içerisinde kitap alınmasından iade edilmesine kadar tatil olmayan her günü barındıran list buradan ilk 10 günü çıkar kalan günü cezalandır.
            }

            if (cezaGunleri.Count > 10)
            {
                cezaGunleri.RemoveRange(0, 10);
                lbGunSayisi.Text = cezaGunleri.Count().ToString();
                lbCezaMiktari.Text = (cezaGunleri.Count() * cezaMiktari).ToString();
            }
            else
            {
                lbGunSayisi.Text = "0";
                lbCezaMiktari.Text = "0";
            }
        }
        public List<TatilGunleri> TatilGunleriGetir()
        {
            List<TatilGunleri> tatilGunleri = new List<TatilGunleri>();
            baglanti.Open();

            string sorgu = "select * from TatilGunleri where UlkeAdi = '" + ddlUlkeler.SelectedValue + "'"; //Sadece seçilen ülkeye ait tatil günlerini getir

            SqlCommand komut = new SqlCommand(sorgu, baglanti);

            var dataReader = komut.ExecuteReader();

            while (dataReader.Read())
            {
                var tatilGunu = new TatilGunleri()
                {
                    TatilGunu = (DateTime)dataReader["Tarih"],
                    UlkeAdi = dataReader["UlkeAdi"].ToString()
                };

                tatilGunleri.Add(tatilGunu);   //tatil günlerinin tamamını datareader'dan listeye al kullanım kolaylığı için
            }
            dataReader.Close();

            sorgu= "Select * from Ulkeler where UlkeAdi ='" + ddlUlkeler.SelectedValue + "'";

            komut = new SqlCommand(sorgu, baglanti);

            dataReader = komut.ExecuteReader();

            while (dataReader.Read())
            {
                paraBirimi = dataReader["ParaBirimi"].ToString();
                cezaMiktari = float.Parse(dataReader["CezaMiktari"].ToString());
            }
            dataReader.Close();
            baglanti.Close();
            return tatilGunleri;
        }
    }
}