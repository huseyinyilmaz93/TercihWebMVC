using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.AccountModels
{
    public class SifremiUnuttumOnay
    {
        [Required]
        [Display(Name="Yeni Şifre")]
        public string YeniSifre { get; set; }
        [Required]
        [Display(Name="Yeni Şifre Tekrar")]
        [Compare("YeniSifre",ErrorMessage="Şifreler eşleşmiyor")]
        public string YeniSifreTekrar { get; set; }
    }
}