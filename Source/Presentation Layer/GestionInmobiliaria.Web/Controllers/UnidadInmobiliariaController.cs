using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionInmobiliaria.Web.Controllers
{
    using System.Net;
    using System.IO;
    using System.Web.Script.Serialization;
    using GestionInmobiliaria.BusinessEntity;
    using System.Text;

    public class UnidadInmobiliariaController : Controller
    {
        //
        // GET: /UnidadInmobiliaria/

        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JavaScriptSerializer javascript = new JavaScriptSerializer();
            List<UnidadInmobiliaria> unidadesInmobiliarias = javascript.Deserialize<List<UnidadInmobiliaria>>(json);

            return View(unidadesInmobiliarias);
        }

        //
        // GET: /UnidadInmobiliaria/Details/5

        public ActionResult Details(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias" + "/" + id.ToString());
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JavaScriptSerializer javascript = new JavaScriptSerializer();
            UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

            return View(unidadInmobiliaria);
        }

        //
        // GET: /UnidadInmobiliaria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnidadInmobiliaria/Create

        [HttpPost]
        public ActionResult Create(UnidadInmobiliaria unidadInmobiliaria)
        {
            try
            {
                string postdata = "{\"IdProyecto\":" + unidadInmobiliaria.IdProyecto + ",\"IdEtapa\":" + unidadInmobiliaria.IdEtapa + ",\"IdEdificio\":" + unidadInmobiliaria.IdEdificio + ",\"NroPiso\":" + unidadInmobiliaria.NroPiso + ",\"NroInmuebleActual\":\"" + unidadInmobiliaria.NroInmuebleActual + "\",\"Direccion\":\"" + unidadInmobiliaria.Direccion + "\",\"Observaciones\":\"" + unidadInmobiliaria.Observaciones + "\",\"Anulado\":false,\"IdTipoInmueble\":" + unidadInmobiliaria.IdTipoInmueble + ",\"AreaTerreno\":" + unidadInmobiliaria.AreaTerreno + ",\"NumDormitorio\":" + unidadInmobiliaria.NumDormitorio + ",\"NumBanios\":" + unidadInmobiliaria.NumBanios + ",\"PrecioVenta\":" + unidadInmobiliaria.PrecioVenta + "}";

                byte[] data = Encoding.UTF8.GetBytes(postdata);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Invocar al listado de unidades inmobiliarias y visualizarlo en su vista
                request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();

                JavaScriptSerializer javascript = new JavaScriptSerializer();
                List<UnidadInmobiliaria> unidadesInmobiliarias = javascript.Deserialize<List<UnidadInmobiliaria>>(json);

                return View("Index", unidadesInmobiliarias);
            }
            catch (WebException we)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                
                string json = reader.ReadToEnd();
                JavaScriptSerializer javascript = new JavaScriptSerializer();
                Error error = javascript.Deserialize<Error>(json);

                ModelState.AddModelError(String.Empty, error.descripcion);

                return View("Create");
            }
        }

        //
        // GET: /UnidadInmobiliaria/Edit/5

        public ActionResult Edit(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias" + "/" + id.ToString());
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JavaScriptSerializer javascript = new JavaScriptSerializer();
            UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

            return View("Edit", unidadInmobiliaria);
        }

        //
        // POST: /UnidadInmobiliaria/Edit/5

        [HttpPost]
        public ActionResult Edit(UnidadInmobiliaria unidadInmobiliaria)
        {
            try
            {
                string postdata = "{\"id\":" + unidadInmobiliaria.id + ",\"IdProyecto\":" + unidadInmobiliaria.IdProyecto + ",\"IdEtapa\":" + unidadInmobiliaria.IdEtapa + ",\"IdEdificio\":" + unidadInmobiliaria.IdEdificio + ",\"NroPiso\":" + unidadInmobiliaria.NroPiso + ",\"NroInmuebleActual\":\"" + unidadInmobiliaria.NroInmuebleActual + "\",\"Direccion\":\"" + unidadInmobiliaria.Direccion + "\",\"Observaciones\":\"" + unidadInmobiliaria.Observaciones + "\",\"Anulado\":false,\"IdTipoInmueble\":" + unidadInmobiliaria.IdTipoInmueble + ",\"AreaTerreno\":" + unidadInmobiliaria.AreaTerreno + ",\"NumDormitorio\":" + unidadInmobiliaria.NumDormitorio + ",\"NumBanios\":" + unidadInmobiliaria.NumBanios + ",\"PrecioVenta\":" + unidadInmobiliaria.PrecioVenta + "}";

                byte[] data = Encoding.UTF8.GetBytes(postdata);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
                request.Method = "PUT";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                HttpWebResponse response = response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Invocar al listado de unidades inmobiliarias y visualizarlo en su vista
                request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();

                JavaScriptSerializer javascript = new JavaScriptSerializer();
                List<UnidadInmobiliaria> unidadesInmobiliarias = javascript.Deserialize<List<UnidadInmobiliaria>>(json);

                return View("Index", unidadesInmobiliarias);
            }
            catch (WebException we)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string json = reader.ReadToEnd();
                JavaScriptSerializer javascript = new JavaScriptSerializer();
                Error error = javascript.Deserialize<Error>(json);

                ModelState.AddModelError(String.Empty, error.descripcion);

                return View("Edit");
            }
        }

        //
        // GET: /UnidadInmobiliaria/Delete/5

        public ActionResult Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias" + "/" + id.ToString());
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JavaScriptSerializer javascript = new JavaScriptSerializer();
            UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

            return View("Delete", unidadInmobiliaria);
        }

        //
        // POST: /UnidadInmobiliaria/Delete/5

        [HttpPost]
        public ActionResult Delete(UnidadInmobiliaria unidadInmobiliaria)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias" + "/" + unidadInmobiliaria.id.ToString());
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            // Invocar al listado de unidades inmobiliarias y visualizarlo en su vista
            request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            JavaScriptSerializer javascript = new JavaScriptSerializer();
            List<UnidadInmobiliaria> unidadesInmobiliarias = javascript.Deserialize<List<UnidadInmobiliaria>>(json);

            return View("Index", unidadesInmobiliarias);
        }
    }
}