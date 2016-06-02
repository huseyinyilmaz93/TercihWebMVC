using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.AccountModels
{
    public class Giris
    {
        [Required]
        [Display(Name="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [Display(Name="Şifre")]
        public string Sifre { get; set; }
        [Display(Name="Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}