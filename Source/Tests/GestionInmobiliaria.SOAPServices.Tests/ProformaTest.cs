using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionInmobiliaria.SOAPServices.Tests
{
    /// <summary>
    /// Descripción resumida de ProformaTest
    /// </summary>
    [TestClass]
    public class ProformaTest
    {

        ProformaWS.ProformaServiceClient proxy = new ProformaWS.ProformaServiceClient();
        ProformaWS.Proforma proforma = new ProformaWS.Proforma();


       // [TestMethod]//Crear
        public void CrearProforma()
        {

            try
            {
                int agregado;
                proforma.Cliente = "Roger Ramos";
                proforma.Fecproforma = Convert.ToDateTime("01/10/2013");
                proforma.Cantidad = 1;
                proforma.idmoneda = Convert.ToInt32(0);
                proforma.Subotal = Convert.ToDecimal(1500);
                proforma.Igv = Convert.ToDecimal(270);
                proforma.Total = Convert.ToDecimal(1770);
                proforma.Idunidadinmobiliaria = Convert.ToInt32(1);
                agregado = proxy.Agregar(proforma);
                Assert.AreEqual(agregado, 12);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "No se pudo insertar el registro en la base de datos.");
            }
        }

        [TestMethod] //Listar
        public void ListarProformas()
        {

            List<ProformaWS.Proforma> listaproformas = new List<ProformaWS.Proforma>();

            try
            {
                listaproformas = proxy.Listar().ToList();
                Assert.IsTrue(listaproformas.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "");
            }


        }

    }
}
