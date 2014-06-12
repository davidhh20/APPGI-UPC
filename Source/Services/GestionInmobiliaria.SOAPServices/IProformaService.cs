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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProformaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProformaService
    {
        [OperationContract]
        List<Proforma> Listar();

        [OperationContract]
        int Agregar(Proforma proforma);
    }
}
