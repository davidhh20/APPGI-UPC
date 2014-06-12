using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionInmobiliaria.RESTServices
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.BusinessLogic;
    using GestionInmobiliaria.Utils;
    using System.ServiceModel.Web;
    using System.Net;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UnidadInmobiliarias" in code, svc and config file together.
    public class UnidadInmobiliarias : IUnidadInmobiliarias
    {
        public List<UnidadInmobiliaria> Listar()
        {
            return busUnidadInmobiliaria.Instancia.Listar().ToList();
        }

        public UnidadInmobiliaria Obtener(string id)
        {
            return busUnidadInmobiliaria.Instancia.Obtener(Convert.ToInt32(id));
        }

        public int Agregar(UnidadInmobiliaria unidadInmobiliaria)
        {
            // Esta validación no utiliza la clase Error.
            //if ("203".Equals(unidadInmobiliaria.NroInmuebleActual))
            //{
            //    throw new WebFaultException<string>(
            //        "La unidad inmobiliaria ya existe.", HttpStatusCode.InternalServerError);
            //}

            return busUnidadInmobiliaria.Instancia.Agregar(unidadInmobiliaria);
        }

        public bool Modificar(UnidadInmobiliaria unidadInmobiliaria)
        {
            //if ("1".Equals(alumnoACrear.Codigo))
            //{
            //    throw new WebFaultException<string>(
            //        "Alumno imposible", HttpStatusCode.InternalServerError);
            //}
            return busUnidadInmobiliaria.Instancia.Modificar(unidadInmobiliaria);
        }

        public bool Eliminar(string id)
        {
            return busUnidadInmobiliaria.Instancia.Eliminar(Convert.ToInt32(id));
        }
    }
}