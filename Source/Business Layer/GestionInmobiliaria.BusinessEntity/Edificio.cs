using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Edificio
    {
        public int id { get; set; }
        public int IdTipoConstruccion { get; set; }
        public string Nombre { get; set; }
        public int NumeroUnidades { get; set; }
        public int NumeroPisos { get; set; }
        public decimal AreaTerreno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int EstadoEdificio { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public bool Anulado { get; set; }

        public Etapa Etapa { get; set; }
    }
}
