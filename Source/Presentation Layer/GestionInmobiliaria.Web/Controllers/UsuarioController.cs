using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionInmobiliaria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
       
        public ActionResult Index()
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            return View(proxy.Listar().ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            return View(proxy.Obtener(id));
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(UsuarioWS.Usuario usuario)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            proxy.Agregar(usuario);

            return View("Index", proxy.Listar().ToList());
        }
        
        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            return View("Edit", proxy.Obtener(id));
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(UsuarioWS.Usuario usuario)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            proxy.Modificar(usuario);

            return View("Index", proxy.Listar().ToList());
        }

        //
        // GET: /Usuario/Delete/5
 
        public ActionResult Delete(int id)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            return View("Delete", proxy.Obtener(id));
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost]
        public ActionResult Delete(UsuarioWS.Usuario usuario)
        {
            UsuarioWS.UsuarioServiceClient proxy = new UsuarioWS.UsuarioServiceClient();
            proxy.Eliminar(usuario.id);

            return View("Index", proxy.Listar().ToList());
        }
    }
}
