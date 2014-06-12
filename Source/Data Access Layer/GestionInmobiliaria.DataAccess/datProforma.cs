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

    public class datProforma : Singleton<datProforma>
    {
        private readonly Database BaseDatos = DatabaseFactory.CreateDatabase();

        public IList<Proforma> Listar()
        {
            var proformas = new List<Proforma>();
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProformaSelectAll]");

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                while (lector.Read())
                {
                    proformas.Add(new Proforma
                    {
                        IdProforma = lector.GetInt32(lector.GetOrdinal("IdProforma")),
                        Fecproforma = lector.GetDateTime(lector.GetOrdinal("Fecproforma")),

                        Cliente = lector.GetString(lector.GetOrdinal("Cliente")),
                        Cantidad = lector.GetInt32(lector.GetOrdinal("Cantidad")),
                        idmoneda = lector.GetInt32(lector.GetOrdinal("Idmoneda")),

                        Subotal = lector.GetDecimal(lector.GetOrdinal("Subtotal")),
                        Igv = lector.GetDecimal(lector.GetOrdinal("Igv")),
                        Total = lector.GetDecimal(lector.GetOrdinal("Total")),
                        Idunidadinmobiliaria = lector.GetInt32(lector.GetOrdinal("Idunidadinmobiliaria")),

                    });
                }
            }

            comando.Dispose();
            return proformas;
        }

        public int Agregar(Proforma proforma)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProformaInsert]");

            BaseDatos.AddOutParameter(comando, "IdProforma", DbType.Int32, 4);
            BaseDatos.AddInParameter(comando, "Fecproforma", DbType.DateTime, proforma.Fecproforma);
            BaseDatos.AddInParameter(comando, "Cliente", DbType.String, proforma.Cliente);
            BaseDatos.AddInParameter(comando, "Cantidad", DbType.Int32, proforma.Cantidad);
            BaseDatos.AddInParameter(comando, "Idmoneda", DbType.Int32, proforma.idmoneda);
            BaseDatos.AddInParameter(comando, "Subtotal", DbType.Decimal, proforma.Subotal);
            BaseDatos.AddInParameter(comando, "Igv", DbType.Decimal, proforma.Igv);
            BaseDatos.AddInParameter(comando, "Total", DbType.Decimal, proforma.Total);
            BaseDatos.AddInParameter(comando, "Idunidadinmobiliaria", DbType.Int32, proforma.Idunidadinmobiliaria);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo insertar el registro en la base de datos.");

            var valor = (int)BaseDatos.GetParameterValue(comando, "IdProforma");

            comando.Dispose();

            return valor;
        }

        public int AgregarCliente(Cliente cliente)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ClienteInsert]");

            BaseDatos.AddOutParameter(comando, "IdCliente", DbType.Int32, 4);
            BaseDatos.AddInParameter(comando, "Nombre", DbType.String, cliente.Nombre);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo insertar el registro en la base de datos.");

            var valor = (int)BaseDatos.GetParameterValue(comando, "IdCliente");

            comando.Dispose();

            return valor;
        }
    }
}
