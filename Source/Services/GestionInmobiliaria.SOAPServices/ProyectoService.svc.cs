using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GestionInmobiliaria.BusinessEntity;
using GestionInmobiliaria.BusinessLogic;
using GestionInmobiliaria.Utils;

namespace GestionInmobiliaria.SOAPServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProyectoService" in code, svc and config file together.
    public class ProyectoService : IProyectoService
    {
        public List<BusinessEntity.Proyecto> Listar()
        {
            return busProyecto.Instancia.Listar().ToList();
        }

        public Proyecto Obtener(int id)
        {
            return busProyecto.Instancia.Obtener(id);
        }

        public int Agregar(Proyecto proyecto)
        {
            return busProyecto.Instancia.Agregar(proyecto);
        }

        public bool Modificar(Proyecto proyecto)
        {
            return busProyecto.Instancia.Modificar(proyecto);
        }

        public bool Eliminar(int id)
        {
            return busProyecto.Instancia.Eliminar(id);
        }
    }
}
