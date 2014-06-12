using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GestionInmobiliaria.BusinessEntity;
using GestionInmobiliaria.BusinessLogic;

namespace GestionInmobiliaria.SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        List<Usuario> Listar();

        [OperationContract]
        Usuario Obtener(int id);

        [OperationContract]
        int Agregar(Usuario usuario);

        [OperationContract]
        bool Modificar(Usuario usuario);

        [OperationContract]
        bool Eliminar(int id);
    }
}
