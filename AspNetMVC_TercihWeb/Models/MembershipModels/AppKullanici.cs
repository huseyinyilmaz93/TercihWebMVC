using AspNetMVC_TercihWeb.Models.ObjectModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace AspNetMVC_TercihWeb.Models.MembershipModels
{
    public class AppKullanici : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime SifremiUnuttum { get; set; }

        public virtual List<Tercih> Tercihler { get; set; }
    }
}