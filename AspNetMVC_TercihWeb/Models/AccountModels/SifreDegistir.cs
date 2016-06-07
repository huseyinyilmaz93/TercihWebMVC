using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.AccountModels
{
    public class SifreDegistir
    {
        [Required]
        [Display(Name="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [Display(Name="Eski Şifre")]
        public string EskiSifre { get; set; }
        [Required]
        [Display(Name="Yeni Şifre")]
        public string YeniSifre { get; set; }
        [Required]
        [Display(Name="Yeni Şifre Tekrar")]
        [Compare("YeniSifre",ErrorMessage="Şifreler eşleşmiyor")]
        public string YeniSifreTekrar { get; set; }

    }
}