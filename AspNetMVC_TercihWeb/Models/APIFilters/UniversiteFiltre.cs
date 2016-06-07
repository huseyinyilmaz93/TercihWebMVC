using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.APIFilters
{
    public class UniversiteFiltre
    {
        public int UniversiteNo { get; set; } // 0 if empty
        public int FakulteNo { get; set; } // 0 if empty
        public string BolumKodu { get; set; } // "" if null
        public string AramaKelime { get; set; } //isim ile arama yapılırsa kullanılacak.
        public double EnDusukPuan { get; set; } //0.0 if empty
        public double EnYuksekPuan { get; set; } //0.0 if empty
        public int SayfaSayisi { get; set; } // default 1 if empty
        public int KayitSayisi { get; set; } //default 15 if empty
    }
    public class FiltreModel
    {
        public int UniversiteNo { get; set; } // 0 if empty
        public int FakulteNo { get; set; } // 0 if empty
        public string BolumKodu { get; set; } // "" if null
        public string BolumAdi { get; set; }
        public double EnDusukPuan { get; set; } //0.0 if empty
        public double EnYuksekPuan { get; set; } //0.0 if empty
        public string PuanTuru { get; set; }
        public int Kontenjan { get; set; }
        public int Yerlesen { get; set; }
        public double OkulEnDusukPuan { get; set; }
        public double OkulEnYuksekPuan { get; set; }
        public string FakulteAdi { get; set; }
        public string UniversiteAdi { get; set; }
    }
}