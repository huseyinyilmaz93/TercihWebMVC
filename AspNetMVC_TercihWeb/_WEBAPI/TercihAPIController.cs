﻿using AspNetMVC_TercihWeb.DAL;
using AspNetMVC_TercihWeb.Models.APIFilters;
using AspNetMVC_TercihWeb.Models.MembershipModels;
using AspNetMVC_TercihWeb.Models.ObjectModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetMVC_TercihWeb._WEBAPI
{
    [RoutePrefix("API/Tercih")]
    public class TercihAPIController : ApiController
    {
        DBContext db = new DBContext();

        [HttpGet]
        [Route("Tercihler/{id}")]
        public HttpResponseMessage Tercihler(string id)
        {
            try
            {
                List<Bolum> bolumler = (from tercih in db.Tercihler.Include("Kullanici").Include("Bolum")
                                          where tercih.Kullanici.Id == id
                                          orderby tercih.TercihSirasi ascending
                                          select tercih.Bolum).ToList();
                List<FiltreModel> tercihler = new List<FiltreModel>();
                foreach(Bolum bolum in bolumler) {
                    FiltreModel tercih = (from ufb in db.UniFakBol.Include("Universite").Include("Fakulte").Include("Bolum")
                                          where bolum.BolumKodu == ufb.Bolum.BolumKodu
                                          orderby ufb.Bolum.EnDusukPuan descending
                                          select new FiltreModel
                                          {
                                              BolumAdi = ufb.Bolum.BolumAdi,
                                              UniversiteAdi = ufb.Universite.UniversiteAdi,
                                              FakulteAdi = ufb.Fakulte.FakulteAdi,
                                              Kontenjan = ufb.Bolum.Kontenjan,
                                              PuanTuru = ufb.Bolum.PuanTuru,
                                              Yerlesen = ufb.Bolum.Yerlesen,
                                              OkulEnDusukPuan = ufb.Bolum.OkulEnDusukPuan,
                                              OkulEnYuksekPuan = ufb.Bolum.OkulEnYuksekPuan,
                                              BolumKodu = ufb.Bolum.BolumKodu,
                                              EnDusukPuan = ufb.Bolum.EnDusukPuan,
                                              EnYuksekPuan = ufb.Bolum.EnYuksekPuan,
                                              FakulteNo = ufb.Fakulte.FakulteNo,
                                              UniversiteNo = ufb.Universite.UniversiteNo
                                          }).FirstOrDefault();
                    if (tercih != null)
                        tercihler.Add(tercih);
                }
                return Request.CreateResponse(HttpStatusCode.OK, tercihler);

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);
            }
        }

        [HttpGet]
        [Route("TercihEkle/{id}/{bolumKodu}")]
        public HttpResponseMessage TercihEkle(string id, string bolumKodu)
        {
            try
            {
                List<Tercih> tercihler = (from tercih in db.Tercihler.Include("Kullanici").Include("Bolum")
                                          where tercih.Kullanici.Id == id
                                          select tercih).ToList();
                var tercihSirasi = tercihler.Count + 1;
                Tercih t = (from tercih in db.Tercihler.Include("Kullanici").Include("Bolum")
                            where tercih.Bolum.BolumKodu == bolumKodu && tercih.Kullanici.Id == id
                            select tercih).FirstOrDefault();
                if (t != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }
                Bolum bolum = db.Bolumler.Where(b => b.BolumKodu == bolumKodu).FirstOrDefault();
                AppKullanici kullanici = db.Users.Where(u => u.Id == id).FirstOrDefault();

                if (tercihler.Count >= 30)
                {
                    return Request.CreateResponse(HttpStatusCode.Continue,100);
                }

                db.Tercihler.Add(new Tercih()
                {
                    TercihSirasi = tercihSirasi,
                    Bolum = bolum,
                    Kullanici = kullanici,
                });

                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,200);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Veri eklenirken bir hata oluştu");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);
            }


            
        }
        
        [HttpGet]
        [Route("TercihCikar/{id}/{bolumKodu}")]
        public HttpResponseMessage TercihCikar(string id, string bolumKodu)
        {
            List<Tercih> tercihler = (from tercih in db.Tercihler.Include("Kullanici").Include("Bolum")
                                      where tercih.Kullanici.Id == id
                                      orderby tercih.TercihSirasi ascending
                                      select tercih).ToList();
            Tercih cikacak = (from tercih in tercihler
                              where tercih.Bolum.BolumKodu == bolumKodu
                              select tercih).FirstOrDefault();
            int pos = cikacak.TercihSirasi;
            db.Tercihler.Remove(cikacak);
            tercihler.Remove(cikacak);
            foreach (var item in tercihler)
            {
                if(pos < item.TercihSirasi) {
                    item.TercihSirasi--;
                }
            }
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
