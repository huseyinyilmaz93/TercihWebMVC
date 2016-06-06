using AspNetMVC_TercihWeb.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AspNetMVC_TercihWeb.Controllers
{
    public class KullaniciController : _BASE_AccountController
    {
        [Authorize(Roles = "KULLANICI")]
        public ActionResult Index()
        {
            ViewBag.id = User.Identity.GetUserId();
            ViewBag.name = User.Identity.GetUserName();
            return View();
        }

        [HttpPost]
        public void Giris(Giris kullanici)
        {
            base.GirisYap(kullanici);
        }

        [HttpGet]
        [Authorize(Roles = "KULLANICI")]
        public void Cikis()
        {
            base.CikisYap();
        }
	}
}