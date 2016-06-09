using AspNetMVC_TercihWeb.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC_TercihWeb.Controllers
{
    public class AdminController : _BASE_AccountController
    {
        [Authorize(Roles = "ADMIN")] 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Giris(Giris kullanici)
        {
            base.GirisYap(kullanici);
        }

        [Authorize(Roles = "ADMIN")] 
        public ActionResult Cikis()
        {
            base.CikisYap();
            return RedirectToAction("Index", "Site");
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult Kullanicilar()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult KullaniciEkle()
        {
            return View();
        }
	}
}