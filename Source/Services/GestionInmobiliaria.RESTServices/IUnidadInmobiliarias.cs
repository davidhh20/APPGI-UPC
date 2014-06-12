using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionInmobiliaria.RESTServices
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.BusinessLogic;
    using System.ServiceModel.Web;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnidadInmobiliarias" in both code and config file together.
    [ServiceContract]
    public interface IUnidadInmobiliarias
    {
        // La UriTemplate correcta debería de estar en plural, es decir, UnidadesInmobiliarias.
        // EL nombre del servicio UnidadInmobiliarias.svc, puede tener el nombre en singular o como se desee: UnidadInmobiliariaService.svc

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UnidadInmobiliarias", ResponseFormat = WebMessageFormat.Json)]
        List<UnidadInmobiliaria> Listar();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UnidadInmobiliarias/{id}", ResponseFormat = WebMessageFormat.Json)]
        UnidadInmobiliaria Obtener(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UnidadInmobiliarias", ResponseFormat = WebMessageFormat.Json)]
        int Agregar(UnidadInmobiliaria unidadInmobiliaria);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UnidadInmobiliarias", ResponseFormat = WebMessageFormat.Json)]
        bool Modificar(UnidadInmobiliaria unidadInmobiliaria);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "UnidadInmobiliarias/{id}", ResponseFormat = WebMessageFormat.Json)]
        bool Eliminar(string id);
    }
}