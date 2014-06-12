using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInmobiliaria.BusinessLogic
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.DataAccess;
    using GestionInmobiliaria.Utils;

    public class busUsuario : Singleton<busUsuario>
    {
        public IList<Usuario> Listar()
        {
            try
            {
                return datUsuario.Instancia.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(Usuario usuario)
        {
            try
            {
                return datUsuario.Instancia.Agregar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Modificar(Usuario usuario)
        {
            try
            {
                return datUsuario.Instancia.Modificar(usuario);
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
                return datUsuario.Instancia.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Obtener(int id)
        {
            try
            {
                return datUsuario.Instancia.Obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
