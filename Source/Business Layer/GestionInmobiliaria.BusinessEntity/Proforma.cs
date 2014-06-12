using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Proforma
    {
        public int IdProforma { get; set; }
        public DateTime Fecproforma { get; set; }
        public string Cliente { get; set; }
        public int Cantidad { get; set; }
        public int idmoneda { get; set; }
        public decimal Subotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        public UnidadInmobiliaria Unidad { get; set; }

        public int Idunidadinmobiliaria { get; set; }
    }
}
