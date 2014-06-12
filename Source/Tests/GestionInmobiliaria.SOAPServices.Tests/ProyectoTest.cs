using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionInmobiliaria.SOAPServices.Tests
{
    /// <summary>
    /// Descripción resumida de ProyectoTest
    /// </summary>
    [TestClass]
    public class ProyectoTest
    {
        ProyectoWS.ProyectoServiceClient Proxy = new ProyectoWS.ProyectoServiceClient();
        ProyectoWS.Proyecto  Proyect = new ProyectoWS.Proyecto();

       [TestMethod] //crear
        public void TestMethod1()
        {
            int agregado;
            Proyect.Anulado = true;
            Proyect.CuotaInicialMonto = 2;
            Proyect.CuotaInicialPorcentaje = 2;
            Proyect.DescuentoMonto = 2;
            Proyect.DescuentoPorcentaje = 2;
            Proyect.Direccion = "ffffffff";
            Proyect.FechaCreacion = Convert.ToDateTime("01/12/2013");
            Proyect.FechaEntrega = Convert.ToDateTime("01/12/2013");
            Proyect.FechaInicio = Convert.ToDateTime("01/12/2013");
            Proyect.id = 1;
            Proyect.IdEstado = 1;
            Proyect.Imagen = "wwwww";
            Proyect.Marcador = "sdddd";
            Proyect.MiVivienda = true;
            Proyect.MontoSeparacion = 100;
            Proyect.Nombre = "LOS PORTALES";
            Proyect.NumeroInmuebles = 2;
            Proyect.Observaciones = "dhfg ghgfh gf hg";
            Proyect.PeriodoEstacional = 1;
            Proyect.TechoPropio = true;
            Proyect.Ubicacion = "";

            //para mostrar si hay repetidos
            ProyectoWS.Proyecto project = new ProyectoWS.Proyecto();
            project = Proxy.Obtener(1);

            if (Proyect.Nombre == project.Nombre)
            {
                Assert.AreEqual(Proyect.Nombre, project.Nombre);
            }
            else
            {
                agregado = Proxy.Agregar(Proyect);
                Assert.AreEqual(agregado, 12);
            }
        }

        //[TestMethod]
        //public void ObtenerProyecto()
        //{
        //    // OBTENER   
        //    Proyect = Proxy.Obtener(1);

        //    if (Proyect.Nombre == null)
        //    {
        //        Assert.AreEqual(Proyect.Nombre, null);
        //    }
        //    else
        //    {
        //        Assert.AreEqual(Proyect.Nombre, "LOS PORTALES");
        //    }
        //}


        //[TestMethod]//Modificar
        //public void ModificarProyecto()
        //{
        //    Boolean modifica;

        //    Proyect.Anulado = true;
        //    Proyect.CuotaInicialMonto = 2;
        //    Proyect.CuotaInicialPorcentaje = 2;
        //    Proyect.DescuentoMonto = 2;
        //    Proyect.DescuentoPorcentaje = 2;
        //    Proyect.Direccion = "ffffffff";
        //    Proyect.FechaCreacion = Convert.ToDateTime("01/12/2013");
        //    Proyect.FechaEntrega = Convert.ToDateTime("01/12/2013");
        //    Proyect.FechaInicio = Convert.ToDateTime("01/12/2013");
        //    Proyect.id = 10;
        //    Proyect.IdEstado = 1;
        //    Proyect.Imagen = "wwwww";
        //    Proyect.Marcador = "sdddd";
        //    Proyect.MiVivienda = true;
        //    Proyect.MontoSeparacion = 100;
        //    Proyect.Nombre = "LOS PORTALES III";
        //    Proyect.NumeroInmuebles = 2;
        //    Proyect.Observaciones = "dhfg ghgfh gf hg";
        //    Proyect.PeriodoEstacional = 1;
        //    Proyect.TechoPropio = true;
        //    Proyect.Ubicacion = "";

        //    modifica = Proxy.Modificar(Proyect);

        //    try
        //    {
        //        Assert.AreEqual(modifica, true);
        //    }
        //    catch
        //    {
        //        Assert.AreEqual(modifica, false);
        //    }
        //}

    }
}
