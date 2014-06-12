using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Pagina
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public int orden { get; set; }
        public string url { get; set; }
        public string img { get; set; }
        public string main { get; set; }
        public bool aud_anulado { get; set; }

        public SubModulo SubModulo { get; set; }
    }
}
