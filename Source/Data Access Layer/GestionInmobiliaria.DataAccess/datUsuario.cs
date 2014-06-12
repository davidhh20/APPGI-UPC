using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.DataAccess
{
    using System.Data;
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.Utils;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    public class datUsuario : Singleton<datUsuario>
    {        
        private readonly Database BaseDatos = DatabaseFactory.CreateDatabase();

        public IList<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            var comando = BaseDatos.GetStoredProcCommand("[sistemas].[usp_UsuarioSelectAll]");

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                while (lector.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        id = lector.GetInt32(lector.GetOrdinal("id")),
                        login = lector.GetString(lector.GetOrdinal("login")),
                        clave = lector.GetString(lector.GetOrdinal("clave")),
                        admin = lector.GetBoolean(lector.GetOrdinal("admin"))
                    });
                }
            }

            comando.Dispose();

            return usuarios;
        }

        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();
            var comando = BaseDatos.GetStoredProcCommand("[sistemas].[usp_UsuarioSelect]");
            BaseDatos.AddInParameter(comando, "id", DbType.Int32, id);

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                if (lector.Read())
                {
                    usuario.id = lector.GetInt32(lector.GetOrdinal("id"));
                    usuario.login = lector.GetString(lector.GetOrdinal("login"));
                    usuario.clave = lector.GetString(lector.GetOrdinal("clave"));
                    usuario.admin = lector.GetBoolean(lector.GetOrdinal("admin"));

                    var rol = new Rol();
                    rol.id = lector.GetInt32(lector.GetOrdinal("rolid"));

                    usuario.Rol = rol;
                }
            }

            comando.Dispose();

            return usuario;
        }

        public int Agregar(Usuario usuario)
        {
            var comando = BaseDatos.GetStoredProcCommand("[sistemas].[usp_UsuarioInsert]");

            BaseDatos.AddOutParameter(comando, "id", DbType.Int32, 4);
            BaseDatos.AddInParameter(comando, "login", DbType.String, usuario.login);
            BaseDatos.AddInParameter(comando, "clave", DbType.String, usuario.clave);
            BaseDatos.AddInParameter(comando, "admin", DbType.Boolean, usuario.admin);
            BaseDatos.AddInParameter(comando, "rolid", DbType.Int32, usuario.Rol.id);

            var resultado = BaseDatos.ExecuteNonQuery(comando);
            
            if (resultado == 0) throw new Exception("No se pudo insertar el registro en la base de datos.");

            var valor = (int)BaseDatos.GetParameterValue(comando, "id");

            comando.Dispose();

            return valor;
        }

        public bool Modificar(Usuario usuario)
        {
            var comando = BaseDatos.GetStoredProcCommand("[sistemas].[usp_UsuarioUpdate]");

            BaseDatos.AddInParameter(comando, "id", DbType.Int32, usuario.id);
            BaseDatos.AddInParameter(comando, "login", DbType.String, usuario.login);
            BaseDatos.AddInParameter(comando, "clave", DbType.String, usuario.clave);
            BaseDatos.AddInParameter(comando, "admin", DbType.Boolean, usuario.admin);
            BaseDatos.AddInParameter(comando, "rolid", DbType.Int32, usuario.Rol.id);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("Hubo un error al modificar.");

            comando.Dispose();

            return true;
        }

        public bool Eliminar(int id)
        {
            var comando = BaseDatos.GetStoredProcCommand("[sistemas].[usp_UsuarioDelete]");
            
            BaseDatos.AddInParameter(comando, "id", DbType.Int32, id);

            var resultado = BaseDatos.ExecuteNonQuery(comando);
            
            if (resultado == 0) throw new Exception("No se pudo eliminar el registro.");

            comando.Dispose();

            return true;
        }
    }
}
