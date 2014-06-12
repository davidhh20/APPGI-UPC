using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionInmobiliaria.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Aplicacion de Gestion Inmobiliaria";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
