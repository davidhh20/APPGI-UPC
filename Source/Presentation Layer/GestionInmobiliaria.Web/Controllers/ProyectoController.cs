using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace GestionInmobiliaria.Web.Controllers
{
    public class ProyectoController : Controller
    {
        //
        // GET: /Proyecto/

        public ActionResult Index()
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            return View(proxy.Listar().ToList());
        }

        //
        // GET: /Proyecto/Details/5

        public ActionResult Details(int id)
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            return View(proxy.Obtener(id));
        }

        //
        // GET: /Proyecto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Proyecto/Create

        [HttpPost]
        public ActionResult Create(ProyectoWS.Proyecto proyecto)
        {
            try
            {
                ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
                proxy.Agregar(proyecto);

                return View("Index", proxy.Listar().ToList());
            }
            catch (FaultException ex)
            {
                ModelState.AddModelError(String.Empty, "Error: " + ex.Message);
                return View();
            }
            //catch (Exception e)
            //{
            //    ModelState.AddModelError(String.Empty, "Error: " + e.Message);
            //    return View();
            //}
        }
        
        //
        // GET: /Proyecto/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            return View("Edit", proxy.Obtener(id));
        }

        //
        // POST: /Proyecto/Edit/5

        [HttpPost]
        public ActionResult Edit(ProyectoWS.Proyecto proyecto)
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            proxy.Modificar(proyecto);

            return View("Index", proxy.Listar().ToList());
        }

        //
        // GET: /Proyecto/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            return View("Delete", proxy.Obtener(id));
        }

        //
        // POST: /Proyecto/Delete/5

        [HttpPost]
        public ActionResult Delete(ProyectoWS.Proyecto proyecto)
        {
            ProyectoWS.ProyectoServiceClient proxy = new ProyectoWS.ProyectoServiceClient();
            proxy.Eliminar(proyecto.id);

            return View("Index", proxy.Listar().ToList());
        }
    }
}
