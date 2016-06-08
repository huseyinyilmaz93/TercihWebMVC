using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AspNetMVC_TercihWeb.Controllers
{
    public class UniPuanController : Controller
    {
        //
        // GET: /UniPuan/
        public ActionResult Index()
        {
            ViewBag.id = User.Identity.GetUserId();
            return View();
        }
        public ActionResult PuanHesaplama()
        {
            return View();
        }
	}
}