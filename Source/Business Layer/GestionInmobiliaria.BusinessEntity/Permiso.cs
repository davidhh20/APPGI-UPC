using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Permiso
    {
        public int id { get; set; }
        public bool acceder { get; set; }
        public bool agregar { get; set; }
        public bool modificar { get; set; }
        public bool eliminar { get; set; }

        public Pagina Pagina { get; set; }
        public Rol Rol { get; set; }
    }
}
