using AspNetMVC_TercihWeb.Models.MembershipModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Bolum
    {
        [Key]
        [Display(Name="Bölüm Kodu")]
        public string BolumKodu { get; set; }
        [Display(Name="Bölüm Adı")]
        public string BolumAdi { get; set; }
        [Display(Name="Puan Türü")]
        public string PuanTuru { get; set; }
        public int Kontenjan { get; set; }
        [Display(Name="Yerleşen")]
        public int Yerlesen { get; set; }

        [Display(Name="En Düşük Puan")]
        public double EnDusukPuan { get; set; }
        [Display(Name="En Yüksek Puan")]
        public double EnYuksekPuan { get; set; }
        [Display(Name = "Okul Birincisi En Düşük Puan")]
        public double OkulEnDusukPuan { get; set; }
        [Display(Name = "Okul Birincisi En Yüksek Puan")]
        public double OkulEnYuksekPuan { get; set; }

        public virtual Fakulte Fakulte { get; set; }
        public virtual List<Tercih> Tercihler { get; set; }

    }
}