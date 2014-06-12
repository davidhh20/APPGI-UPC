using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessLogic
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.DataAccess;
    using GestionInmobiliaria.Utils;
    using System.ServiceModel.Web;
    using System.Net;    

    public class busUnidadInmobiliaria : Singleton<busUnidadInmobiliaria>
    {
        public IList<UnidadInmobiliaria> Listar()
        {
            try
            {
                return datUnidadInmobiliaria.Instancia.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UnidadInmobiliaria Obtener(int id)
        {
            try
            {
                return datUnidadInmobiliaria.Instancia.Obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int Agregar(UnidadInmobiliaria unidadInmobiliaria)
        {
            UnidadInmobiliaria unidadInmobiliariaExistente = this.ValidarExistencia(unidadInmobiliaria);

            if (unidadInmobiliariaExistente != null)
            {
                throw new WebFaultException<Error>(
                    new Error()
                    {
                        codigo = "0001",
                        descripcion = "Ya existe una unidad inmobiliaria para el proyecto " + unidadInmobiliariaExistente.IdProyecto.ToString() + ", etapa " + unidadInmobiliariaExistente.IdEtapa.ToString() + " y edificio " + unidadInmobiliariaExistente.IdEdificio.ToString() + "."
                    },
                    HttpStatusCode.InternalServerError);
            }

            return datUnidadInmobiliaria.Instancia.Agregar(unidadInmobiliaria);
        }

        public bool Modificar(UnidadInmobiliaria unidadInmobiliaria)
        {
            UnidadInmobiliaria unidadInmobiliariaExistente = this.Obtener(unidadInmobiliaria.id);

            if (unidadInmobiliaria.IdProyecto != unidadInmobiliariaExistente.IdProyecto ||
                unidadInmobiliaria.IdEtapa != unidadInmobiliariaExistente.IdEtapa ||
                unidadInmobiliaria.IdEdificio != unidadInmobiliariaExistente.IdEdificio ||
                unidadInmobiliaria.NroInmuebleActual != unidadInmobiliariaExistente.NroInmuebleActual)
            {
                UnidadInmobiliaria unidadInmobiliariaExistente2 = this.ValidarExistencia(unidadInmobiliaria);

                if (unidadInmobiliariaExistente2 != null)
                {
                    throw new WebFaultException<Error>(
                        new Error()
                        {
                            codigo = "0001",
                            descripcion = "Ya existe una unidad inmobiliaria para el proyecto " + unidadInmobiliariaExistente.IdProyecto.ToString() + ", etapa " + unidadInmobiliariaExistente.IdEtapa.ToString() + " y edificio " + unidadInmobiliariaExistente.IdEdificio.ToString() + "."
                        },
                        HttpStatusCode.InternalServerError);                 
                }                   
            }

            return datUnidadInmobiliaria.Instancia.Modificar(unidadInmobiliaria);
        }

        public bool Eliminar(int id)
        {
            try
            {
                return datUnidadInmobiliaria.Instancia.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UnidadInmobiliaria ValidarExistencia(UnidadInmobiliaria unidadInmobiliaria)
        {
            try
            {
                return datUnidadInmobiliaria.Instancia.ValidarExistencia(unidadInmobiliaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}