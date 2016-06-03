using AspNetMVC_TercihWeb.Models.MembershipModels;
using AspNetMVC_TercihWeb.Models.ObjectModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetMVC_TercihWeb.DAL
{
    public class DBContext : IdentityDbContext<AppKullanici>
    {
        public DbSet<Universite> Universiteler { get; set; }
        public DbSet<Fakulte> Fakulteler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Lise> Liseler { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<YabanciDil> YabanciDiller { get; set; }
        public DbSet<LiseTuru> LiseTurleri { get; set; }

        public DBContext() : base("DbConnect")
        { }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}