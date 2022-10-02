using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryPenaltyCase.Classlar
{
    public class Kitap
    {
        public DateTime AlindigiTarih { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public List<DateTime> CezaGunleri { get; set; }
        public Kitap(DateTime AlimTarih, DateTime TeslimTarih, List<DateTime> tatilGunleri)
        {
            this.AlindigiTarih = AlimTarih;
            this.TeslimTarihi = TeslimTarih;
            CezaGunleri = new List<DateTime>();

            for (var i = this.AlindigiTarih; i <= this.TeslimTarihi; i = i.AddDays(1))  //seçilen başlangıç ve bitiş tarihleri arasını for ile dön -- daha sonra bir kitap classı oluşturulup orada bir fonksiyon olarak konulabilir
            {
                if (i.DayOfWeek == DayOfWeek.Sunday || i.DayOfWeek == DayOfWeek.Saturday)
                {
                    //cumartesi ve ya pazar günlerini ceza listesine ekleme
                }
                else if (tatilGunleri.Any(x => x.Day == i.Day && x.Month == i.Month))
                {
                    //Resmi tatilleri ceza listesine ekleme
                }
                else
                    this.CezaGunleri.Add(i);  //içerisinde kitap alınmasından iade edilmesine kadar tatil olmayan her günü barındıran list buradan ilk 10 günü çıkar kalan günü cezalandır.
            }
        }
    }
}