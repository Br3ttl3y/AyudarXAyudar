using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AyudarXAyudar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
           return View();
        }

        public ActionResult English()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Espanol()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;

            return RedirectToAction("Index", "Home");
        }
    }
}