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
        SQLSorgulari sql = new SQLSorgulari();
        #endregion
        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion
        #region Fonksiyonlar
        protected void btCezaHesapla_Click1(object sender, EventArgs e)
        {
            Ulkeler ulke = sql.UlkeGetir(ddlUlkeler.SelectedValue); //Dropdown menu ile seçilen ülkenin bilgilerini veritabanımızdan çekiyoruz
            Kitap kitap = new Kitap(clAlimTarihi.SelectedDate, clTeslimTarihi.SelectedDate, sql.TatilGunleriGetir(ddlUlkeler.SelectedValue));  //kitap öğesini oluşturup constructoru ile gerekli bilgileri hesaplıyoruz

            if (kitap.CezaGunleri.Count > 10)
            {
                kitap.CezaGunleri.RemoveRange(0, 10);
                lbGunSayisi.Text = kitap.CezaGunleri.Count().ToString();
                lbCezaMiktari.Text = (kitap.CezaGunleri.Count() * ulke.CezaMiktari).ToString();
                lbParaBirimi.Text = ulke.ParaBirimi;
            }
            else    //Kitap classında önceden hesaplanmış olan ceza gün sayısını seçilen ülkenin ceza miktarı ile çarpıyoruz
            {
                lbGunSayisi.Text = "0";
                lbCezaMiktari.Text = "0";
                lbParaBirimi.Text = "";
            }
        }
        #endregion
    }
}