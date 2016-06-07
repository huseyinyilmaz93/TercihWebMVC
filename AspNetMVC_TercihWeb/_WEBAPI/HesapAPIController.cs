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
using AspNetMVC_TercihWeb.Models;
using System.Threading.Tasks;

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
        }

        [Route("Kayit")]
        [HttpPost]
        public HttpResponseMessage Kayit([FromBody]Kayit kullanici)
        {
            if (kullanici == null)
            {
                ModelState.AddModelError("Hata","Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (userManager.FindByName(kullanici.KullaniciAdi) != null)
            {
                ModelState.AddModelError("Hata", "Bu kullanıcı adı başka bir kullanıcı tarafından kullanılmaktadır!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
            else if (userManager.FindByEmail(kullanici.Email) != null)
            {
                ModelState.AddModelError("Hata", "Girilen Email başka bir kullanıcı tarafından kullanılmaktadır!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

            AppKullanici yeniKullanici = new AppKullanici();
            yeniKullanici.Ad = kullanici.Ad;
            yeniKullanici.Soyad = kullanici.Soyad;
            yeniKullanici.UserName = kullanici.KullaniciAdi;
            yeniKullanici.Email = kullanici.Email;
            yeniKullanici.EmailConfirmed = false;
            yeniKullanici.SifremiUnuttum = DateTime.Now;
            yeniKullanici.SifremiUnuttum = yeniKullanici.SifremiUnuttum.AddHours(-3);

            try
            {
                IdentityResult idtResult = userManager.Create(yeniKullanici, kullanici.Sifre);
                if (idtResult.Succeeded)
                {
                    userManager.AddToRole(yeniKullanici.Id, "KULLANICI");
                    return Request.CreateResponse(HttpStatusCode.OK,yeniKullanici.Id);
                }
                else
                {
                    ModelState.AddModelError("Hata", "Kullanıcıya rol atanamadı!");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Hata", e.Message + " Kullanıcıyı kaydederken bir hata meydana geldi.");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
        }

        [Route("GirisYap")]
        [HttpPost]
        public HttpResponseMessage GirisYap([FromBody]Giris kullanici)
        {
            if (kullanici == null)
            {
                ModelState.AddModelError("Hata", "Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
            if (kullanici.KullaniciAdi == "")
            {
                ModelState.AddModelError("Hata", "Kullanıcı Adı boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);

            } 
            else if(kullanici.Sifre == "")
            {
                ModelState.AddModelError("Hata", "Şifre boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);

            }
            try
            {
                AppKullanici girisYapacak = userManager.Find(kullanici.KullaniciAdi, kullanici.Sifre);
                
                if (girisYapacak == null)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre yanlış");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, userManager.GetRoles(girisYapacak.Id));
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Giriş yaparken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }


        }

        [Route("SifreDegistir/{id}")]
        [HttpPost]
        public HttpResponseMessage SifreDegistir([FromBody]SifreDegistir sifreDegisim,[FromUri] string id)
        {
            if (sifreDegisim == null)
            {
                ModelState.AddModelError("Hata", "Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                AppKullanici sifreDegisecek = userManager.FindById(id);
                AppKullanici sifreKontrol = userManager.Find(sifreDegisim.KullaniciAdi, sifreDegisim.YeniSifre);
                if (sifreKontrol == null)
                {
                    ModelState.AddModelError("Hata", "Lütfen Eski Sifre alanını kontrol edin. Yanlış giriş yapıldı");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                if (sifreDegisecek.UserName != sifreDegisim.KullaniciAdi)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı adı değeriniz eşleşmiyor. Lütfen şifresini değiştirmek istediğiniz kullanıcı ile giriş yapın");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }

                userManager.ChangePassword(sifreDegisecek.Id, sifreDegisim.EskiSifre, sifreDegisim.YeniSifre);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Şifre değiştirirken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
        }

        [HttpPost]
        [Route("SifremiUnuttum")]
        public HttpResponseMessage SifremiUnuttum([FromBody]SifremiUnuttum sifremiUnuttum)
        {
            if (sifremiUnuttum == null)
            {
                ModelState.AddModelError("Hata", "Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                AppKullanici kullanici = userManager.FindByEmail(sifremiUnuttum.Email);
                if (kullanici == null)
                {
                    ModelState.AddModelError("Hata", "Verilen Email adresi sistemde kayıtlı değil");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                else if (sifremiUnuttum.KullaniciAdi != kullanici.UserName)
                {
                    ModelState.AddModelError("Hata", "Email adresi ile Kullanıcı Adı eşleşmiyor");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }

                MailGonder.SifremiUnuttum(kullanici);
                kullanici.SifremiUnuttum = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"Email adresinize sıfırlama isteğiniz için Email gönderildi");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Form işlenirken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

        }

        [HttpGet]
        [Route("SifremiUnuttumSure/{id}")]
        public HttpResponseMessage SifremiUnuttumSure(string id)
        {
            AppKullanici kullanici = userManager.FindById(id);
            if (DateTime.Compare(kullanici.SifremiUnuttum.AddHours(3), DateTime.Now) >= 0)
                return Request.CreateResponse(HttpStatusCode.OK);
            else return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "İstek zaman aşımına uğradı!");
        }

        [Route("SifremiUnuttumOnay/{id}")]
        [HttpPost]
        public HttpResponseMessage SifremiUnuttumOnay([FromBody]SifremiUnuttumOnay sifremiUnuttumOnay, [FromUri] string id)
        {
            if (sifremiUnuttumOnay == null)
            {
                ModelState.AddModelError("Hata", "Form bilgileri boş geçilemez");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                AppKullanici sifreDegisecek = userManager.FindById(id);
                if (sifreDegisecek == null)
                {
                    ModelState.AddModelError("Hata", "Geçersiz id değeri");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                AppKullanici kullanici = userManager.FindById(id);
                String hashSifre = userManager.PasswordHasher.HashPassword(sifremiUnuttumOnay.YeniSifre);
                Task t = (userStore.SetPasswordHashAsync(kullanici, hashSifre));
                t.Wait();
                t = (userStore.UpdateAsync(kullanici));
                t.Wait();
                kullanici.SifremiUnuttum = kullanici.SifremiUnuttum.AddHours(-3);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"OK");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Şifre değiştirirken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }
        }

        [HttpGet]
        [Route("KayitOnaylama/{id}")]
        public HttpResponseMessage KayitOnaylama(string id)
        {
            try
            {
                AppKullanici kullanici = userManager.FindById(id);
                if (kullanici.EmailConfirmed == true)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                MailGonder.EMailOnaylama(kullanici);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "Mail gönderilirken bir hata oluşturuldu. Tekrar deneyin!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

        }

        [HttpGet]
        [Route("KayitBasarili/{id}")]
        public HttpResponseMessage KayitBasarili(string id)
        {
            try
            {
                AppKullanici kullanici = userManager.FindById(id);
                if (kullanici == null)
                {
                    ModelState.AddModelError("Hata", "Verilen id değerine uygun kullanıcı bulunamadı!");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                kullanici.EmailConfirmed = true;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata", "İşlem onaylanırken bir hata oluştu!");
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
            }

        }

        [HttpGet]
        [Route("KullaniciBilgi/{id}")]
        public HttpResponseMessage KullaniciBilgi(string id)
        {
            try
            {
                AppKullanici kullanici = userManager.FindById(id);
                if (kullanici == null)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı bulunamadı.");
                    return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, ModelState);
                }
                return Request.CreateResponse(HttpStatusCode.OK, kullanici);

            }
            catch (Exception)
            {
                ModelState.AddModelError("Hata","Kullanıcıya ulaşırken bir hata oluştu.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
