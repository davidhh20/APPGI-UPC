using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class SubModulo
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public int orden { get; set; }
        public bool aud_anulado { get; set; }

        public Modulo Modulo { get; set; }
    }
}
