using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace AspNetMVC_TercihWeb.Controllers
{
    public class HesapController : Controller
    {
        //
        // GET: /Hesap/
        public ActionResult Giris()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();
        }
        [Authorize]
        public ActionResult SifreDegistir()
        {
            ViewBag.id = User.Identity.GetUserId();
            return View();
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        public ActionResult SifremiUnuttumOnay(string id)
        {
            ViewBag.id = id;
            return View();
        }
        //Email göndermek için kullanılmaktadır.
        public ActionResult KayitOnaylama(string id)
        {
            ViewBag.id = id;
            return View();
        }
        //Emaildeki linke tıklandıktan sonraki işlemler.
        public ActionResult KayitBasarili(string id)
        {
            ViewBag.id = id;
            return View();
        }
        
	}
}