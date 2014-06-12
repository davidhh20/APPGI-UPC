using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Etapa
    {
        public int id { get; set; }
        public decimal Area { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int NumeroInmuebles { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public int NumeroEdificios { get; set; }

        public Proyecto Proyecto { get; set; }
    }
}
