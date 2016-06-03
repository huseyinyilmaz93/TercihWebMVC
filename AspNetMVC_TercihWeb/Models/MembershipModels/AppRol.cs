using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetMVC_TercihWeb.Models.MembershipModels
{
    public class AppRol : IdentityRole
    {
        public string Aciklama { get; set; }
        public AppRol()
        {

        }
        public AppRol(string rolAdi, string aciklama) : base(rolAdi)
        {

        }
    }
}