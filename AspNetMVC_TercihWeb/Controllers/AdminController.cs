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
        [Authorize(Roles="Admin")]
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
        [Authorize(Roles="Admin")]
        public ActionResult Cikis()
        {
            base.CikisYap();
            return View("Index", "Site");
        }
	}
}