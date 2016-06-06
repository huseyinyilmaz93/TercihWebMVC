using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.AccountModels
{
    public class SifremiUnuttum
    {
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}