using AspNetMVC_TercihWeb.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC_TercihWeb.Controllers
{
    public class KullaniciController : _BASE_AccountController
    {
        [Authorize(Roles = "Kullanici")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Giris kullanici)
        {
            base.GirisYap(kullanici);
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Kullanici")]
        public ActionResult Cikis()
        {
            base.CikisYap();
            return View("Index", "Site");
        }
	}
}