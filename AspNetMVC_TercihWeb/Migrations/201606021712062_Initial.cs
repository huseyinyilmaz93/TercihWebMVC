namespace AspNetMVC_TercihWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolum",
                c => new
                    {
                        BolumKodu = c.String(nullable: false, maxLength: 128),
                        BolumAdi = c.String(),
                        PuanTuru = c.String(),
                        Kontenjan = c.Int(nullable: false),
                        Yerlesen = c.Int(nullable: false),
                        EnDusukPuan = c.Double(nullable: false),
                        EnYuksekPuan = c.Double(nullable: false),
                        OkulEnDusukPuan = c.Double(nullable: false),
                        OkulEnYuksekPuan = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BolumKodu);
            
            CreateTable(
                "dbo.Fakulte",
                c => new
                    {
                        FakulteNo = c.Int(nullable: false, identity: true),
                        FakulteAdi = c.String(),
                    })
                .PrimaryKey(t => t.FakulteNo);
            
            CreateTable(
                "dbo.Universite",
                c => new
                    {
                        UniversiteNo = c.Int(nullable: false, identity: true),
                        UniversiteAdi = c.String(),
                        Il = c.String(),
                        UniTuru = c.String(),
                        WebAdresi = c.String(),
                        Kategori_KategoriNo = c.Int(),
                    })
                .PrimaryKey(t => t.UniversiteNo)
                .ForeignKey("dbo.Kategori", t => t.Kategori_KategoriNo)
                .Index(t => t.Kategori_KategoriNo);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriNo = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                    })
                .PrimaryKey(t => t.KategoriNo);
            
            CreateTable(
                "dbo.Ilce",
                c => new
                    {
                        IlceNo = c.Int(nullable: false, identity: true),
                        IlceAdi = c.String(),
                        Iletisim_IletisimNo = c.Int(),
                    })
                .PrimaryKey(t => t.IlceNo)
                .ForeignKey("dbo.Iletisim", t => t.Iletisim_IletisimNo)
                .Index(t => t.Iletisim_IletisimNo);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimNo = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IletisimNo);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlNo = c.Int(nullable: false, identity: true),
                        IlAdi = c.String(),
                        Iletisim_IletisimNo = c.Int(),
                    })
                .PrimaryKey(t => t.IlNo)
                .ForeignKey("dbo.Iletisim", t => t.Iletisim_IletisimNo)
                .Index(t => t.Iletisim_IletisimNo);
            
            CreateTable(
                "dbo.Lise",
                c => new
                    {
                        LiseNo = c.Int(nullable: false, identity: true),
                        OkulAdi = c.String(),
                        TabanPuani = c.Double(nullable: false),
                        Iletisim_IletisimNo = c.Int(),
                        Kategori_KategoriNo = c.Int(),
                        OkulTuru_TurNo = c.Int(),
                        YabanciDil_DilNo = c.Int(),
                    })
                .PrimaryKey(t => t.LiseNo)
                .ForeignKey("dbo.Iletisim", t => t.Iletisim_IletisimNo)
                .ForeignKey("dbo.Kategori", t => t.Kategori_KategoriNo)
                .ForeignKey("dbo.OkulTuru", t => t.OkulTuru_TurNo)
                .ForeignKey("dbo.YabanciDil", t => t.YabanciDil_DilNo)
                .Index(t => t.Iletisim_IletisimNo)
                .Index(t => t.Kategori_KategoriNo)
                .Index(t => t.OkulTuru_TurNo)
                .Index(t => t.YabanciDil_DilNo);
            
            CreateTable(
                "dbo.OkulTuru",
                c => new
                    {
                        TurNo = c.Int(nullable: false, identity: true),
                        TurAdi = c.String(),
                    })
                .PrimaryKey(t => t.TurNo);
            
            CreateTable(
                "dbo.YabanciDil",
                c => new
                    {
                        DilNo = c.Int(nullable: false, identity: true),
                        DilAdi = c.String(),
                    })
                .PrimaryKey(t => t.DilNo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Aciklama = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FakulteBolum",
                c => new
                    {
                        Fakulte_FakulteNo = c.Int(nullable: false),
                        Bolum_BolumKodu = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Fakulte_FakulteNo, t.Bolum_BolumKodu })
                .ForeignKey("dbo.Fakulte", t => t.Fakulte_FakulteNo, cascadeDelete: true)
                .ForeignKey("dbo.Bolum", t => t.Bolum_BolumKodu, cascadeDelete: true)
                .Index(t => t.Fakulte_FakulteNo)
                .Index(t => t.Bolum_BolumKodu);
            
            CreateTable(
                "dbo.UniversiteFakulte",
                c => new
                    {
                        Universite_UniversiteNo = c.Int(nullable: false),
                        Fakulte_FakulteNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Universite_UniversiteNo, t.Fakulte_FakulteNo })
                .ForeignKey("dbo.Universite", t => t.Universite_UniversiteNo, cascadeDelete: true)
                .ForeignKey("dbo.Fakulte", t => t.Fakulte_FakulteNo, cascadeDelete: true)
                .Index(t => t.Universite_UniversiteNo)
                .Index(t => t.Fakulte_FakulteNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Lise", "YabanciDil_DilNo", "dbo.YabanciDil");
            DropForeignKey("dbo.Lise", "OkulTuru_TurNo", "dbo.OkulTuru");
            DropForeignKey("dbo.Lise", "Kategori_KategoriNo", "dbo.Kategori");
            DropForeignKey("dbo.Lise", "Iletisim_IletisimNo", "dbo.Iletisim");
            DropForeignKey("dbo.Il", "Iletisim_IletisimNo", "dbo.Iletisim");
            DropForeignKey("dbo.Ilce", "Iletisim_IletisimNo", "dbo.Iletisim");
            DropForeignKey("dbo.Universite", "Kategori_KategoriNo", "dbo.Kategori");
            DropForeignKey("dbo.UniversiteFakulte", "Fakulte_FakulteNo", "dbo.Fakulte");
            DropForeignKey("dbo.UniversiteFakulte", "Universite_UniversiteNo", "dbo.Universite");
            DropForeignKey("dbo.FakulteBolum", "Bolum_BolumKodu", "dbo.Bolum");
            DropForeignKey("dbo.FakulteBolum", "Fakulte_FakulteNo", "dbo.Fakulte");
            DropIndex("dbo.UniversiteFakulte", new[] { "Fakulte_FakulteNo" });
            DropIndex("dbo.UniversiteFakulte", new[] { "Universite_UniversiteNo" });
            DropIndex("dbo.FakulteBolum", new[] { "Bolum_BolumKodu" });
            DropIndex("dbo.FakulteBolum", new[] { "Fakulte_FakulteNo" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Lise", new[] { "YabanciDil_DilNo" });
            DropIndex("dbo.Lise", new[] { "OkulTuru_TurNo" });
            DropIndex("dbo.Lise", new[] { "Kategori_KategoriNo" });
            DropIndex("dbo.Lise", new[] { "Iletisim_IletisimNo" });
            DropIndex("dbo.Il", new[] { "Iletisim_IletisimNo" });
            DropIndex("dbo.Ilce", new[] { "Iletisim_IletisimNo" });
            DropIndex("dbo.Universite", new[] { "Kategori_KategoriNo" });
            DropTable("dbo.UniversiteFakulte");
            DropTable("dbo.FakulteBolum");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.YabanciDil");
            DropTable("dbo.OkulTuru");
            DropTable("dbo.Lise");
            DropTable("dbo.Il");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Ilce");
            DropTable("dbo.Kategori");
            DropTable("dbo.Universite");
            DropTable("dbo.Fakulte");
            DropTable("dbo.Bolum");
        }
    }
}
