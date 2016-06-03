using AspNetMVC_TercihWeb.Models.AccountModels;
using AspNetMVC_TercihWeb.Models.MembershipModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC_TercihWeb.Controllers
{
    public class _BASE_AccountController : Controller
    {
        protected void GirisYap(Giris kullanici)
        {
            AspNetMVC_TercihWeb.DAL.DBContext db = new AspNetMVC_TercihWeb.DAL.DBContext();
            UserStore<AppKullanici> userStore = new UserStore<AppKullanici>(db);
            UserManager<AppKullanici> userManager = new UserManager<AppKullanici>(userStore);

            AppKullanici girisYapacak = userManager.Find(kullanici.KullaniciAdi, kullanici.Sifre);

            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            ClaimsIdentity identity = userManager.CreateIdentity(girisYapacak, "ApplicationCookie");
            AuthenticationProperties authProps = new AuthenticationProperties();
            authProps.IsPersistent = kullanici.BeniHatirla;
            authManager.SignIn(authProps, identity);
        }
        protected void CikisYap()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
        }
	}
}