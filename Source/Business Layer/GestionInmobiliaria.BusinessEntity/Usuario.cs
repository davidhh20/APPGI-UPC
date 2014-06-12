using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string clave { get; set; }
        public bool admin { get; set; }

        public Rol Rol { get; set; }
    }
}