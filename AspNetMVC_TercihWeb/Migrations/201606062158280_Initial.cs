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
                    })
                .PrimaryKey(t => t.IlceNo);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlNo = c.Int(nullable: false, identity: true),
                        IlAdi = c.String(),
                    })
                .PrimaryKey(t => t.IlNo);
            
            CreateTable(
                "dbo.Lise",
                c => new
                    {
                        LiseNo = c.Int(nullable: false, identity: true),
                        LiseAdi = c.String(),
                        TabanPuani = c.Double(nullable: false),
                        Il_IlNo = c.Int(),
                        Ilce_IlceNo = c.Int(),
                        Kategori_KategoriNo = c.Int(),
                        LiseTuru_TurNo = c.Int(),
                        YabanciDil_DilNo = c.Int(),
                    })
                .PrimaryKey(t => t.LiseNo)
                .ForeignKey("dbo.Il", t => t.Il_IlNo)
                .ForeignKey("dbo.Ilce", t => t.Ilce_IlceNo)
                .ForeignKey("dbo.Kategori", t => t.Kategori_KategoriNo)
                .ForeignKey("dbo.LiseTuru", t => t.LiseTuru_TurNo)
                .ForeignKey("dbo.YabanciDil", t => t.YabanciDil_DilNo)
                .Index(t => t.Il_IlNo)
                .Index(t => t.Ilce_IlceNo)
                .Index(t => t.Kategori_KategoriNo)
                .Index(t => t.LiseTuru_TurNo)
                .Index(t => t.YabanciDil_DilNo);
            
            CreateTable(
                "dbo.LiseTuru",
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
                        SifremiUnuttum = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.Lise", "LiseTuru_TurNo", "dbo.LiseTuru");
            DropForeignKey("dbo.Lise", "Kategori_KategoriNo", "dbo.Kategori");
            DropForeignKey("dbo.Lise", "Ilce_IlceNo", "dbo.Ilce");
            DropForeignKey("dbo.Lise", "Il_IlNo", "dbo.Il");
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
            DropIndex("dbo.Lise", new[] { "LiseTuru_TurNo" });
            DropIndex("dbo.Lise", new[] { "Kategori_KategoriNo" });
            DropIndex("dbo.Lise", new[] { "Ilce_IlceNo" });
            DropIndex("dbo.Lise", new[] { "Il_IlNo" });
            DropIndex("dbo.Universite", new[] { "Kategori_KategoriNo" });
            DropTable("dbo.UniversiteFakulte");
            DropTable("dbo.FakulteBolum");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.YabanciDil");
            DropTable("dbo.LiseTuru");
            DropTable("dbo.Lise");
            DropTable("dbo.Il");
            DropTable("dbo.Ilce");
            DropTable("dbo.Kategori");
            DropTable("dbo.Universite");
            DropTable("dbo.Fakulte");
            DropTable("dbo.Bolum");
        }
    }
}
