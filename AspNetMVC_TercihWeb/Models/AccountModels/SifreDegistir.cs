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
        public string KullaniciAdi { get; set; }
        [Required]
        public string EskiSifre { get; set; }
        [Required]
        public string YeniSifre { get; set; }
        [Required]
        [Compare("YeniSifre",ErrorMessage="Şifreler eşleşmiyor")]
        public string YeniSifreTekrar { get; set; }

    }
}