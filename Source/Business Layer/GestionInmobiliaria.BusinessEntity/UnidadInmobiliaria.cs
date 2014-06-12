using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessEntity
{
    public class UnidadInmobiliaria
    {
        public int id { get; set; }
        public string NroInmuebleOriginal { get; set; }
        public int NroPiso { get; set; }
        public string NroInmuebleActual { get; set; }
        public string Direccion { get; set; }
        public string FichaIndependizacion { get; set; }
        public string NumeroCertificado { get; set; }
        public string Observaciones { get; set; }
        public bool Anulado { get; set; }
        public string Modelo { get; set; }
        public bool BonoTP { get; set; }
        public int EstadoInmueble { get; set; }
        public int IdVista { get; set; }
        public decimal AreaTerreno { get; set; }
        public decimal AreaTechada { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaTerraza { get; set; }
        public decimal AreaJardin { get; set; }
        public decimal AreaLibre { get; set; }
        public decimal NumDormitorio { get; set; }
        public decimal NumBanios { get; set; }
        public int IdCargaStock { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioLista { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdMoneda { get; set; }

        public Proyecto Proyecto { get; set; }
        public Etapa Etapa { get; set; }
        public Edificio Edificio { get; set; }               
        public TipoInmueble TipoInmueble { get; set; }

        public int IdProyecto { get; set; }        
        public int IdEtapa { get; set; }
        public int IdEdificio { get; set; }
        public int IdTipoInmueble { get; set; }
    }
}