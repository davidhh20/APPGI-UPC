using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionInmobiliaria.RESTServices.Tests
{
    using System.Net;
    using System.IO;
    using System.Web.Script.Serialization;
    using GestionInmobiliaria.BusinessEntity;

    [TestClass]
    public class UnidadInmobiliariasTest
    {
        //[TestMethod]
        //public void ListarTest()
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
        //    request.Method = "GET";

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    string json = reader.ReadToEnd();

        //    JavaScriptSerializer javascript = new JavaScriptSerializer();
        //    List<UnidadInmobiliaria> unidadesInmobiliarias = javascript.Deserialize<List<UnidadInmobiliaria>>(json);

        //    Assert.AreEqual(2, unidadesInmobiliarias[0].id);
        //    Assert.AreEqual("100", unidadesInmobiliarias[0].NroInmuebleActual);
        //}

        //[TestMethod]
        //public void ObtenerTest()
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias/2");
        //    request.Method = "GET";

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    string json = reader.ReadToEnd();

        //    JavaScriptSerializer javascript = new JavaScriptSerializer();
        //    UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

        //    Assert.AreEqual(2, unidadInmobiliaria.id);
        //    Assert.AreEqual("100", unidadInmobiliaria.NroInmuebleActual);
        //}

        [TestMethod]
        public void AgregarTest()
        {
            string postdata = "{\"IdUnidadInmobiliaria\":0,\"IdProyecto\":3,\"IdEtapa\":1,\"IdEdificio\":1,\"NroPiso\":1,\"NroInmuebleActual\":\"203\",\"Direccion\":\"AV. MEXICO 785\",\"Observaciones\":\"DEPARTAMENTO DE ESTRENO\",\"Anulado\":false,\"IdTipoInmueble\":1,\"AreaTerreno\":69.00,\"NumDormitorio\":3.00,\"NumBanios\":2.00,\"PrecioVenta\":224000.00}";

            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";

            var reqStream = request.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                int id = Convert.ToInt32(reader.ReadToEnd());

                Assert.AreEqual(13, id);

                // Verifica si el inmueble se registró
                request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias/" + id.ToString());
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();

                JavaScriptSerializer javascript = new JavaScriptSerializer();
                UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

                Assert.AreEqual(17, unidadInmobiliaria.id);
                Assert.AreEqual("203", unidadInmobiliaria.NroInmuebleActual);
            }
            catch (WebException we)
            {
                //HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                //string description = ((HttpWebResponse)e.Response).StatusDescription;

                //StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                //string error = reader.ReadToEnd();

                //JavaScriptSerializer javascript = new JavaScriptSerializer();
                //string detail = javascript.Deserialize<string>(error);

                //Assert.AreEqual("La unidad inmobiliaria ya se encuentra registrada.", detail);

                response = (HttpWebResponse)we.Response;
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string json = reader.ReadToEnd();
                JavaScriptSerializer javascript = new JavaScriptSerializer();
                Error error = javascript.Deserialize<Error>(json);

                Assert.AreEqual("La unidad inmobiliaria ya existe.", error.descripcion);
            }
        }

        //[TestMethod]
        //public void ModificarTest()
        //{
        //    string postdata = "{\"id\":13,\"IdProyecto\":3,\"IdEtapa\":1,\"IdEdificio\":1,\"NroPiso\":1,\"NroInmuebleActual\":\"105\",\"Direccion\":\"AV. MEXICO N° 598\",\"Observaciones\":\"DEPARTAMENTO DUPLEX CON MUEBLES BAJOS EN COCINA\",\"Anulado\":false,\"IdTipoInmueble\":1,\"AreaTerreno\":69.00,\"NumDormitorio\":3.00,\"NumBanios\":2.00,\"PrecioVenta\":224000.00}";

        //    byte[] data = Encoding.UTF8.GetBytes(postdata);

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias");
        //    request.Method = "PUT";
        //    request.ContentLength = data.Length;
        //    request.ContentType = "application/json";

        //    var reqStream = request.GetRequestStream();
        //    reqStream.Write(data, 0, data.Length);

        //    HttpWebResponse response = null;

        //    try
        //    {
        //        response = (HttpWebResponse)request.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        bool actualiza = Convert.ToBoolean(reader.ReadToEnd());

        //        Assert.IsTrue(actualiza);

        //        // Verificar si la dirección y observación del inmueble se actualizó
        //        request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias/13");
        //        request.Method = "GET";

        //        response = (HttpWebResponse)request.GetResponse();
        //        reader = new StreamReader(response.GetResponseStream());
        //        string json = reader.ReadToEnd();

        //        JavaScriptSerializer javascript = new JavaScriptSerializer();
        //        UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

        //        Assert.AreEqual(13, unidadInmobiliaria.id);
        //        Assert.AreEqual("AV. MEXICO N° 598", unidadInmobiliaria.Direccion);
        //        Assert.AreEqual("DEPARTAMENTO DUPLEX CON MUEBLES BAJOS EN COCINA", unidadInmobiliaria.Observaciones);
        //    }
        //    catch (WebException e)
        //    {
        //        HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
        //        string description = ((HttpWebResponse)e.Response).StatusDescription;

        //        StreamReader reader = new StreamReader(e.Response.GetResponseStream());
        //        string error = reader.ReadToEnd();

        //        JavaScriptSerializer javascript = new JavaScriptSerializer();
        //        string detail = javascript.Deserialize<string>(error);

        //        Assert.AreEqual("La unidad inmobiliaria no existe.", detail);
        //    }
        //}

        //[TestMethod]
        //public void EliminarTest()
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias/7");
        //    request.Method = "DELETE";

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    bool elimina = Convert.ToBoolean(reader.ReadToEnd());

        //    Assert.IsTrue(elimina);

        //    // Verifica si el registro fue eliminado
        //    request = (HttpWebRequest)WebRequest.Create("http://localhost:7182/UnidadInmobiliarias.svc/UnidadInmobiliarias/7");
        //    request.Method = "GET";

        //    response = (HttpWebResponse)request.GetResponse();
        //    reader = new StreamReader(response.GetResponseStream());
        //    string json = reader.ReadToEnd();

        //    JavaScriptSerializer javascript = new JavaScriptSerializer();
        //    UnidadInmobiliaria unidadInmobiliaria = javascript.Deserialize<UnidadInmobiliaria>(json);

        //    Assert.AreEqual(unidadInmobiliaria.id, 0);
        //}
    }
}