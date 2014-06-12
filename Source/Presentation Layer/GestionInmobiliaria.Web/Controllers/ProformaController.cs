using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionInmobiliaria.Web.Controllers
{
    public class ProformaController : Controller
    {
        //
        // GET: /Proforma/

        public ActionResult Index()
        {
            ProformaWS.ProformaServiceClient proxy = new ProformaWS.ProformaServiceClient();
            return View(proxy.Listar().ToList());
        }

        ////
        //// GET: /Proforma/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        // GET: /Proforma/Create

        public ActionResult Create()
        {
            return View();
        }

        ////
        //// POST: /Proforma/Create

        [HttpPost]
        public ActionResult Create(ProformaWS.Proforma proforma)
        {
            try
            {

                ProformaWS.ProformaServiceClient proxy = new ProformaWS.ProformaServiceClient();
                proxy.Agregar(proforma);

                ViewBag.message = "Creado";

                return View("Index", proxy.Listar().ToList());
            }
            catch
            {
                return View();
            }
        }

        ////
        //// GET: /Proforma/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Proforma/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Proforma/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Proforma/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
