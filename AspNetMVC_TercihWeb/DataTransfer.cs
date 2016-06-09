using AspNetMVC_TercihWeb.DAL;
using AspNetMVC_TercihWeb.Models.ObjectModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb
{
    public class DataTransfer
    {
        public void Method3(SqlConnection con, DBContext db)
        {
            { //IL Çek
                SqlCommand cmd = new SqlCommand("select * from Il", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int ilNo = rdr.GetInt32(0);
                    string ilStr = rdr.GetString(1);
                    Il ill = (from il in db.Iller
                              where il.IlAdi == ilStr
                              select il).FirstOrDefault();
                    Il yeniIl = new Il();
                    yeniIl.IlAdi = ilStr;
                    if (ill == null)
                        db.Iller.Add(yeniIl);
                }
                rdr.Close();
                db.SaveChanges();
            }

            { //ILÇE
                SqlCommand cmd = new SqlCommand("select * from Ilce", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string ilceStr = rdr.GetString(1);
                    Ilce illce = (from ilce in db.Ilceler
                                  where ilce.IlceAdi == ilceStr
                                  select ilce).FirstOrDefault();
                    Ilce yeniIlce = new Ilce();
                    yeniIlce.IlceAdi = ilceStr;
                    if (illce == null)
                        db.Ilceler.Add(yeniIlce);
                }
                rdr.Close();
                db.SaveChanges();
            }
            { //Yabancı DİL
                SqlCommand cmd = new SqlCommand("select * from YabanciDil", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string yabanciDilStr = rdr.GetString(1);
                    YabanciDil yDil = (from ybDil in db.YabanciDiller
                                       where ybDil.DilAdi == yabanciDilStr
                                       select ybDil).FirstOrDefault();
                    YabanciDil yeniDil = new YabanciDil();
                    yeniDil.DilAdi = yabanciDilStr;
                    if (yDil == null)
                        db.YabanciDiller.Add(yeniDil);
                }
                rdr.Close();
                db.SaveChanges();
            }

            { //OKUL TURU
                SqlCommand cmd = new SqlCommand("select * from OkulTuru", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string okulTuruStr = rdr.GetString(1);
                    LiseTuru oTur = (from oTuru in db.LiseTurleri
                                     where oTuru.TurAdi == okulTuruStr
                                     select oTuru).FirstOrDefault();
                    LiseTuru yeniTur = new LiseTuru();
                    yeniTur.TurAdi = okulTuruStr;

                    if (oTur == null)
                        db.LiseTurleri.Add(yeniTur);
                }
                rdr.Close();
                db.SaveChanges();
            }
        }
        public void Method2(SqlConnection con,DBContext db)
        {
            { //UNIVERSITE
                SqlCommand cmd = new SqlCommand("select * from Universite", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Universite u = new Universite();
                    string uniAdi = rdr.GetString(1);
                    string il = rdr.GetString(2);
                    Kategori k = (from i in db.Kategoriler
                                  where i.KategoriAdi == "Üniversite"
                                  select i).FirstOrDefault();
                    u.UniversiteAdi = uniAdi;
                    u.Il = il;
                    u.Kategori = k;
                    Universite varmi = (from uni in db.Universiteler
                                        where uni.Il == il && uni.UniversiteAdi == uniAdi
                                        select uni).FirstOrDefault();
                    if (varmi == null)
                    {
                        db.Universiteler.Add(u);
                    }

                }
                rdr.Close();
                db.SaveChanges();
            }

            { //FAKÜLTE
                SqlCommand cmd = new SqlCommand("select * from Fakulte", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Fakulte f = new Fakulte();
                    string fakAdi = rdr.GetString(1);
                    f.FakulteAdi = fakAdi;
                    Fakulte varmi = (from fak in db.Fakulteler
                                     where fak.FakulteAdi == fakAdi
                                     select fak).FirstOrDefault();
                    if (varmi == null)
                    {
                        db.Fakulteler.Add(f);
                    }

                }
                rdr.Close();
                db.SaveChanges();
            }


            { //BÖLÜM
                SqlCommand cmd = new SqlCommand("select * from Bolum", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Bolum b = new Bolum();
                    string bolumKodu = rdr.GetString(0);
                    string bolAdi = rdr.GetString(1);
                    string puanTuru = rdr.GetString(2);
                    int kontenjan = rdr.GetInt32(4);
                    int yerlesen = rdr.GetInt32(5);
                    float enKucuk = rdr.GetFloat(6);
                    float enBuyuk = rdr.GetFloat(7);
                    float oEnBuyuk = rdr.GetFloat(8);
                    float oEnKucuk = rdr.GetFloat(9);

                    b.BolumAdi = bolAdi;
                    b.BolumKodu = bolumKodu;
                    b.PuanTuru = puanTuru;
                    b.Kontenjan = kontenjan;
                    b.Yerlesen = yerlesen;
                    b.EnDusukPuan = (double)enKucuk;
                    b.EnYuksekPuan = (double)enBuyuk;
                    b.OkulEnDusukPuan = (double)oEnKucuk;
                    b.OkulEnYuksekPuan = (double)oEnBuyuk;

                    Bolum varmi = (from bol in db.Bolumler
                                   where bol.BolumKodu == bolumKodu
                                   select bol).FirstOrDefault();
                    if (varmi == null)
                    {
                        db.Bolumler.Add(b);
                    }

                }
                rdr.Close();
                db.SaveChanges();
            }
            { //UNIFAK
                SqlCommand cmd = new SqlCommand("select * from UniFak", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int uniNo = rdr.GetInt32(0);
                    int fakNo = rdr.GetInt32(1);
                    Fakulte f = (from fak in db.Fakulteler.Include("Universiteler")
                                 where fak.FakulteNo == fakNo
                                 select fak).FirstOrDefault();

                    Universite u = (from uni in db.Universiteler.Include("Fakulteler")
                                    where uni.UniversiteNo == uniNo
                                    select uni).FirstOrDefault();

                    if (u.Fakulteler == null) u.Fakulteler = new List<Fakulte>();
                    if (f != null && u != null)
                        f.Universiteler.Add(u);

                }
                rdr.Close();
                db.SaveChanges();
            }
            { //UNIFAKBOL
                SqlCommand cmd = new SqlCommand("select * from UniFakBol", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int uniNo = rdr.GetInt32(0);
                    string bolKodu = rdr.GetString(2);
                    int fakNo = rdr.GetInt32(1);

                    Universite u = (from universite in db.Universiteler
                                    where universite.UniversiteNo == uniNo
                                    select universite).FirstOrDefault(); 

                    Fakulte f = (from fakulte in db.Fakulteler
                                 where fakulte.FakulteNo == fakNo
                                 select fakulte).FirstOrDefault();

                    Bolum b = (from bol in db.Bolumler
                               where bol.BolumKodu == bolKodu
                               select bol).FirstOrDefault();

                    if(b.Fakulte == null)
                    {
                        b.Fakulte = f;
                    }

                }
                rdr.Close();
                db.SaveChanges();
            }
        }
        public void Method1()
        {
            DBContext db = new DBContext();
            string connectionString = "Server=cp.tercihweb.com;Database=DB_Huseyin;User Id=DB_User_Huseyin;Password=hus123eyin/*-;";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            for (int i = 0; i < 2; i++ )
            {
                Kategori k = new Kategori();
                if ( i == 0) k.KategoriAdi = "Lise";
                if (i == 1) k.KategoriAdi = "Üniversite";

                Kategori varmi = (from a in db.Kategoriler
                                 where a.KategoriAdi == k.KategoriAdi
                                 select a).FirstOrDefault();

                if (varmi == null)
                {
                    db.Kategoriler.Add(k);
                }
            }
            db.SaveChanges();
            con.Open();
            
            Method2(con,db);
            //Method3(con,db);

            //{ //LİSE 
            //    SqlCommand cmd = new SqlCommand("select okulNo,okulAdi,tabanPuani,ilNo,ilceNo,turNo,dilNo from Okul INNER JOIN Iletisim ON Okul.iletNo=Iletisim.iletNo   ", con);

            //    SqlDataReader rdr;
            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {

            //        string liseAdi = rdr.GetString(1);
            //        float tabanPuan = rdr.GetFloat(2);
            //        int ilNo = rdr.GetInt32(3);
            //        int ilceNo = rdr.GetInt32(4);
            //        int turNo = rdr.GetInt32(5);
            //        int dilNo = rdr.GetInt32(6);

            //        Lise lise = (from l in db.Liseler
            //                     where l.LiseAdi == liseAdi
            //                     select l).FirstOrDefault();
            //        Lise yeniLise = new Lise();
            //        yeniLise.LiseAdi = liseAdi;
            //        yeniLise.TabanPuani = tabanPuan;

            //        YabanciDil ydil = (from yd in db.YabanciDiller
            //                           where yd.DilNo == dilNo
            //                           select yd).FirstOrDefault();
            //        LiseTuru ltur = (from lt in db.LiseTurleri
            //                         where lt.TurNo == turNo
            //                         select lt).FirstOrDefault();
            //        Kategori kategori = (from k in db.Kategoriler
            //                             where k.KategoriAdi == "Lise"
            //                             select k).FirstOrDefault();

            //        yeniLise.Kategori = kategori;

            //        yeniLise.YabanciDil = ydil;
            //        yeniLise.LiseTuru = ltur;

            //        Il il = (from i in db.Iller
            //                 where i.IlNo == ilNo
            //                 select i).FirstOrDefault();

            //        Ilce ilce = (from ilc in db.Ilceler
            //                 where ilc.IlceNo == ilceNo
            //                 select ilc).FirstOrDefault();

            //        yeniLise.Il = il;
            //        yeniLise.Ilce = ilce;

            //        if (lise == null)
            //            db.Liseler.Add(yeniLise);
            //    }
            //    rdr.Close();
            //    db.SaveChanges();
            //}

        }

    }
}