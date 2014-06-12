using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionInmobiliaria.BusinessLogic
{
    using GestionInmobiliaria.BusinessEntity;
    using GestionInmobiliaria.DataAccess;
    using GestionInmobiliaria.Utils;

    public class busProforma : Singleton<busProforma>
    {
        public IList<Proforma> Listar()
        {
            try
            {
                return datProforma.Instancia.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(Proforma proforma)
        {
            try
            {
                return datProforma.Instancia.Agregar(proforma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarCliente(Cliente cliente)
        {
            try
            {
                return datProforma.Instancia.AgregarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
