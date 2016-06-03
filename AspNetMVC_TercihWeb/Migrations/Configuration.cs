namespace AspNetMVC_TercihWeb.Migrations
{
    using AspNetMVC_TercihWeb.Models.MembershipModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMVC_TercihWeb.DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AspNetMVC_TercihWeb.DAL.DBContext context)
        {
            var roleManager = new RoleManager<AppRol>(new RoleStore<AppRol>(context));
            var userManager = new UserManager<AppKullanici>(new UserStore<AppKullanici>(context));

            if (!roleManager.RoleExists("ADMIN"))
            {
                AppRol adminRol = new AppRol("ADMIN", "Sistem yöneticisi");
                roleManager.Create(adminRol);
            }

            if (!roleManager.RoleExists("KULLANICI"))
            {
                AppRol kullaniciRol = new AppRol("KULLANICI", "Tercih seçebilme");
                roleManager.Create(kullaniciRol);
            }

            if (userManager.Find("admin", "admin123") == null)
            {
                AppKullanici admin = new AppKullanici()
                {
                    UserName = "admin",
                    EmailConfirmed = true
                };

                IdentityResult idResult = userManager.Create(admin, "admin123");

                if (idResult.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "ADMIN");
                }

            }

           

            if (userManager.Find("kullanici", "kullanici123") == null)
            {
                AppKullanici kullanici = new AppKullanici()
                {
                    UserName = "kullanici",
                    EmailConfirmed = true
                };

                IdentityResult idResult = userManager.Create(kullanici, "kullanici123");

                if (idResult.Succeeded)
                {
                    userManager.AddToRole(kullanici.Id, "KULLANICI");
                }

            }


            
        }
    }
}
