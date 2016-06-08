using AspNetMVC_TercihWeb.DAL;
using AspNetMVC_TercihWeb.Models.APIFilters;
using AspNetMVC_TercihWeb.Models.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetMVC_TercihWeb._WEBAPI
{
    [RoutePrefix("API/UniversitePuan")]
    public class UniversitePuanAPIController : ApiController
    {
        DBContext db = new DBContext();

        [HttpGet]
        [Route("TumUniversiteler")]
        public HttpResponseMessage TumUniversiteler()
        {
            try
            {
                List<Universite> tumUniversiteler = (from uni in db.Universiteler
                                        select uni).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, tumUniversiteler);

            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Verileri alırken bir hata oluştu. Lütfen tekrar deneyin.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        
        [HttpGet]
        [Route("Fakulteler/{universiteNo}")]
        public HttpResponseMessage Fakulteler(int universiteNo)
        {
            try
            {
                List<Fakulte> fakulteler = (from fakulte in db.Fakulteler.Include("Universiteler")
                                     from uni in fakulte.Universiteler
                                     where uni.UniversiteNo == universiteNo
                                     select fakulte).ToList();

                return Request.CreateResponse(HttpStatusCode.OK,fakulteler);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Verileri alırken bir hata oluştu. Lütfen tekrar deneyin.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
        }

        [HttpGet]
        [Route("Bolumler/{universiteNo}/{fakulteNo}")]
        public HttpResponseMessage Bolumler(int universiteNo,int fakulteNo)
        {
            try
            {
                List<Bolum> bolumler = (from fakulte in db.Fakulteler.Include("Universiteler").Include("Bolumler")
                                        from uni in fakulte.Universiteler
                                        from bolum in fakulte.Bolumler
                                        where uni.UniversiteNo == universiteNo && fakulte.FakulteNo == fakulteNo
                                        select bolum).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, bolumler);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Verileri alırken bir hata oluştu. Lütfen tekrar deneyin.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
        }

        [HttpPost]
        [Route("BolumFiltrele")]
        public HttpResponseMessage BolumFiltrele(UniversiteFiltre filtre)
        {
            List<FiltreModel> bolumler = (from fakulte in db.Fakulteler.Include("Universiteler").Include("Fakulteler")
                                    from bolum in fakulte.Bolumler
                                    from universite in fakulte.Universiteler
                                    orderby bolum.EnDusukPuan descending
                                    select new FiltreModel{
                                    BolumAdi=bolum.BolumAdi,
                                    UniversiteAdi = universite.UniversiteAdi,
                                    FakulteAdi = fakulte.FakulteAdi,
                                    Kontenjan = bolum.Kontenjan, 
                                    PuanTuru = bolum.PuanTuru,
                                    Yerlesen = bolum.Yerlesen, 
                                    OkulEnDusukPuan = bolum.OkulEnDusukPuan,
                                    OkulEnYuksekPuan = bolum.OkulEnYuksekPuan,
                                    BolumKodu= bolum.BolumKodu, EnDusukPuan = bolum.EnDusukPuan,
                                    EnYuksekPuan=bolum.EnYuksekPuan, FakulteNo = fakulte.FakulteNo,
                                    UniversiteNo  = universite.UniversiteNo
                                    }).ToList();

            if (filtre.UniversiteNo != 0)
            {
                bolumler = (from filter in bolumler
                            where filter.UniversiteNo == filtre.UniversiteNo
                            orderby filter.EnDusukPuan descending
                            select filter).ToList();
            }
            if (filtre.FakulteNo != 0)
            {
                bolumler = (from filter in bolumler
                            where filter.FakulteNo == filtre.FakulteNo
                            orderby filter.EnDusukPuan descending
                            select filter).ToList();
            }
            if (filtre.BolumKodu != "")
            {
                bolumler = (from filter in bolumler
                            where filter.BolumKodu == filtre.BolumKodu
                            orderby filter.EnDusukPuan descending
                            select filter).ToList();
            }
            if (filtre.EnDusukPuan != 0.0)
            {
                bolumler = (from filter in bolumler
                            where filter.EnDusukPuan >= filtre.EnDusukPuan
                            orderby filter.EnDusukPuan descending
                            select filter).ToList();
            }
            if (filtre.EnYuksekPuan != 0.0)
            {
                bolumler = (from filter in bolumler
                            where filter.EnYuksekPuan <= filtre.EnYuksekPuan
                            orderby filter.EnDusukPuan descending
                            select filter).ToList();
            }
            if (filtre.AramaKelime != "")
            {
                bolumler = (from filter in bolumler
                         where filter.BolumAdi.Contains(filtre.AramaKelime)
                         orderby filter.EnDusukPuan descending
                         select filter).ToList();
            }
            float topKayit = bolumler.Count;
            int skip = (filtre.SayfaSayisi - 1) * filtre.KayitSayisi; //Baştan itibaren kaç adet veri atlanması gerektiği
            if (skip != 0) bolumler = bolumler.Skip(skip).ToList(); //Veri atlama
            bolumler = bolumler.Take(filtre.KayitSayisi).ToList(); //sonraki KayitSayisi kadar veriyi alma
            bolumler.Add(new FiltreModel() { EnYuksekPuan = topKayit });
            return Request.CreateResponse(HttpStatusCode.OK,bolumler);
        }


    }
}
