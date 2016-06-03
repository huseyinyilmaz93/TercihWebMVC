using AspNetMVC_TercihWeb.Models.AccountModels;
using AspNetMVC_TercihWeb.Models.MembershipModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Host.SystemWeb;

namespace AspNetMVC_TercihWeb._WEBAPI
{
    [RoutePrefix("API/Hesap")]
    public class HesapAPIController : ApiController
    {
        AspNetMVC_TercihWeb.DAL.DBContext db = new AspNetMVC_TercihWeb.DAL.DBContext();
        UserStore<AppKullanici> userStore { get; set; }
        UserManager<AppKullanici> userManager { get; set; }
        
        public HesapAPIController()
        {
            userStore = new UserStore<AppKullanici>(db);
            userManager = new UserManager<AppKullanici>(userStore);
            //var provider = new DpapiDataProtectionProvider();

        }

        [Route("Kayit")]
        [HttpPost]
        public HttpResponseMessage Kayit(Kayit kullanici)
        {
            if (kullanici == null)
            {
                ModelState.AddModelError("BosForm","Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (userManager.FindByName(kullanici.KullaniciAdi) != null)
            {
                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı başka bir kullanıcı tarafından kullanılmaktadır!");
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ModelState);
            }
            else if (userManager.FindByEmail(kullanici.Email) != null)
            {
                ModelState.AddModelError("Email", "Girilen Email başka bir kullanıcı tarafından kullanılmaktadır!");
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ModelState);
            }

            AppKullanici yeniKullanici = new AppKullanici();
            yeniKullanici.Ad = kullanici.Ad;
            yeniKullanici.Soyad = kullanici.Soyad;
            yeniKullanici.UserName = kullanici.KullaniciAdi;
            yeniKullanici.Email = kullanici.Email;
            yeniKullanici.EmailConfirmed = false;

            try
            {
                IdentityResult idtResult = userManager.Create(yeniKullanici, kullanici.Sifre);
                if (idtResult.Succeeded)
                {
                    userManager.AddToRole(yeniKullanici.Id, "KULLANICI");
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    ModelState.AddModelError("Kayıt", "Kullanıcıya rol atanamadı!");
                    return Request.CreateErrorResponse(HttpStatusCode.Ambiguous, ModelState);
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("Kayıt", "Kullanıcıyı kaydederken bir hata meydana geldi.");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
        }

        [Route("GirisYap")]
        [HttpPost]
        public HttpResponseMessage GirisYap(Giris kullanici)
        {
            if (kullanici == null)
            {
                ModelState.AddModelError("BosForm", "Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                AppKullanici girisYapacak = userManager.Find(kullanici.KullaniciAdi, kullanici.Sifre);
                
                if (girisYapacak == null)
                {
                    ModelState.AddModelError("GirisHatasi", "Kullanıcı adı veya şifre yanlış");
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, userManager.GetRoles(girisYapacak.Id));
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("ServerHatasi", "Giriş yaparken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable,ModelState);
            }


        }
    }
}
