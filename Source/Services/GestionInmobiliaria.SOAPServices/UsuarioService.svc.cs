using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GestionInmobiliaria.BusinessEntity;
using GestionInmobiliaria.BusinessLogic;
using GestionInmobiliaria.Utils;

namespace GestionInmobiliaria.SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : Singleton<UsuarioService>, IUsuarioService
    {
        public List<BusinessEntity.Usuario> Listar()
        {
            return busUsuario.Instancia.Listar().ToList();
        }

        public Usuario Obtener(int id)
        {
            return busUsuario.Instancia.Obtener(id);
        }

        public int Agregar(Usuario usuario)
        {
            return busUsuario.Instancia.Agregar(usuario);
        }

        public bool Modificar(Usuario usuario)
        {
            return busUsuario.Instancia.Modificar(usuario);
        }

        public bool Eliminar(int id)
        {
            return busUsuario.Instancia.Eliminar(id);
        }
    }
}
