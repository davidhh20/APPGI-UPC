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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProyectoService" in both code and config file together.
    [ServiceContract]
    public interface IProyectoService
    {
        [OperationContract]
        List<Proyecto> Listar();

        [OperationContract]
        Proyecto Obtener(int id);

        [OperationContract]
        int Agregar(Proyecto proyecto);

        [OperationContract]
        bool Modificar(Proyecto proyecto);

        [OperationContract]
        bool Eliminar(int id);
    }
}
