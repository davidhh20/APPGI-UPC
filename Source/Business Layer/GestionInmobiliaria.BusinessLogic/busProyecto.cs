using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessLogic
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.DataAccess;
    using GestionInmobiliaria.Utils;
    using System.ServiceModel;
    using GestionInmobiliaria.BusinessLogic.Excepciones;

    public class busProyecto : Singleton<busProyecto>
    {
        public IList<Proyecto> Listar()
        {
            try
            {
                return datProyecto.Instancia.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(Proyecto proyecto)
        {
            Proyecto proyectoExistente = this.ValidarExistencia(proyecto);

            if (proyectoExistente != null)
            {
                ValidationException error = new ValidationException { ValidationError = "El proyecto ya se encuentra registrado." };
                throw new FaultException<ValidationException>(error, error.ValidationError);
            }

            return datProyecto.Instancia.Agregar(proyecto);
        }

        public bool Modificar(Proyecto proyecto)
        {
            try
            {
                return datProyecto.Instancia.Modificar(proyecto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return datProyecto.Instancia.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Proyecto Obtener(int id)
        {
            try
            {
                return datProyecto.Instancia.Obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Proyecto ValidarExistencia(Proyecto proyecto)
        {
            try
            {
                return datProyecto.Instancia.ValidarExistencia(proyecto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
