using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class Proyecto
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool TechoPropio { get; set; }
        public bool MiVivienda { get; set; }
        public string Observaciones { get; set; }
        public int NumeroInmuebles { get; set; }
        public bool Anulado { get; set; }
        public decimal MontoSeparacion { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal DescuentoMonto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal CuotaInicialPorcentaje { get; set; }
        public decimal CuotaInicialMonto { get; set; }
        public int PeriodoEstacional { get; set; }
        public int IdEstado { get; set; }
        public string Imagen { get; set; }
        public string Ubicacion { get; set; }
        public string Marcador { get; set; }
    }
}
