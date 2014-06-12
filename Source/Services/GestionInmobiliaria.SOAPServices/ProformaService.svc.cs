using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionInmobiliaria.SOAPServices
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.BusinessLogic;
    using GestionInmobiliaria.Utils;
    using System.Messaging;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProformaService" en el código, en svc y en el archivo de configuración a la vez.
    public class ProformaService : IProformaService
    {
        public List<BusinessEntity.Proforma> Listar()
        {
            string rutaColaIn = @".\private$\dherrera";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);

            MessageQueue colaIn = new MessageQueue(rutaColaIn);
            colaIn.Formatter = new XmlMessageFormatter(new Type[] { typeof(BusinessEntity.Cliente) });

            var cantidad = colaIn.GetAllMessages().Count();

            //List<BusinessEntity.UnidadInmobiliaria> lista = new List<BusinessEntity.UnidadInmobiliaria>();

            for (int i = 0; i < cantidad; i++)
            {
                Message mensajeIn = colaIn.Receive();

                BusinessEntity.Cliente cliente = (BusinessEntity.Cliente)mensajeIn.Body;

                //lista.Add(consumo);

                busProforma.Instancia.AgregarCliente(cliente);
            }   

            return busProforma.Instancia.Listar().ToList();
        }

        public int Agregar(Proforma proforma)
        {
            string rutaCola = @".\private$\dherrera";

            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);

            Cliente cliente = new Cliente();
            cliente.Nombre = proforma.Cliente;

            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Registrar cliente";
            mensaje.Body = cliente;
            cola.Send(mensaje);

            return busProforma.Instancia.Agregar(proforma);
        }
    }
}
