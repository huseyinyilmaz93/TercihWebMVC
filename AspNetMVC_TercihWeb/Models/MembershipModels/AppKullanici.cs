﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetMVC_TercihWeb.Models.MembershipModels
{
    public class AppKullanici : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}