using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace AspNetMVC_TercihWeb.Models.MembershipModels
{
    public class AppKullanici : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public DateTime SifremiUnuttum { get; set; }

    }
}