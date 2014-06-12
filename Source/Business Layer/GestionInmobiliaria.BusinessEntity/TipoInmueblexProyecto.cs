using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class TipoInmueblexProyecto
    {
        public int id { get; set; }

        public Proyecto Proyecto { get; set; }
        public TipoInmueble TipoInmueble { get; set; }
    }
}