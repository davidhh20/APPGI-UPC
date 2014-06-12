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
    using System.ServiceModel.Web;
    using System.Net;

    public class datUnidadInmobiliaria : Singleton<datUnidadInmobiliaria>
    {
        private readonly Database BaseDatos = DatabaseFactory.CreateDatabase();

        public IList<UnidadInmobiliaria> Listar()
        {
            var unidadesInmobiliarias = new List<UnidadInmobiliaria>();
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaSelectAll]");

            using (var lector = BaseDatos.ExecuteReader(comando))
            {                
                while (lector.Read())
                {
                    unidadesInmobiliarias.Add(new UnidadInmobiliaria
                    {
                        id = lector.GetInt32(lector.GetOrdinal("IdUnidadInmobiliaria")),
                        IdProyecto = lector.GetInt32(lector.GetOrdinal("IdProyecto")),
                        IdEtapa = lector.GetInt32(lector.GetOrdinal("IdEtapa")),
                        IdEdificio = lector.GetInt32(lector.GetOrdinal("IdEdificio")),
                        NroPiso = lector.GetInt32(lector.GetOrdinal("NroPiso")),
                        NroInmuebleActual = lector.GetString(lector.GetOrdinal("NroInmuebleActual")),
                        Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
                        Observaciones = lector.GetString(lector.GetOrdinal("Observaciones")),
                        Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado")),
                        IdTipoInmueble = lector.GetInt32(lector.GetOrdinal("IdTipoInmueble")),
                        AreaTerreno = lector.GetDecimal(lector.GetOrdinal("AreaTerreno")),
                        NumDormitorio = lector.GetDecimal(lector.GetOrdinal("NumDormitorio")),
                        NumBanios = lector.GetDecimal(lector.GetOrdinal("NumBanios")),
                        PrecioVenta = lector.GetDecimal(lector.GetOrdinal("PrecioVenta"))
                    });
                }
            }

            comando.Dispose();

            return unidadesInmobiliarias;
        }

        public UnidadInmobiliaria Obtener(int id)
        {
            var unidadInmobiliaria = new UnidadInmobiliaria();
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaSelect]");
            BaseDatos.AddInParameter(comando, "IdUnidadInmobiliaria", DbType.Int32, id);

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                if (lector.Read())
                {
                    unidadInmobiliaria.id = lector.GetInt32(lector.GetOrdinal("IdUnidadInmobiliaria"));
                    unidadInmobiliaria.IdProyecto = lector.GetInt32(lector.GetOrdinal("IdProyecto"));
                    unidadInmobiliaria.IdEtapa = lector.GetInt32(lector.GetOrdinal("IdEtapa"));
                    unidadInmobiliaria.IdEdificio = lector.GetInt32(lector.GetOrdinal("IdEdificio"));
                    unidadInmobiliaria.NroPiso = lector.GetInt32(lector.GetOrdinal("NroPiso"));
                    unidadInmobiliaria.NroInmuebleActual = lector.GetString(lector.GetOrdinal("NroInmuebleActual"));
                    unidadInmobiliaria.Direccion = lector.GetString(lector.GetOrdinal("Direccion"));
                    unidadInmobiliaria.Observaciones = lector.GetString(lector.GetOrdinal("Observaciones"));
                    unidadInmobiliaria.Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado"));
                    unidadInmobiliaria.IdTipoInmueble = lector.GetInt32(lector.GetOrdinal("IdTipoInmueble"));
                    unidadInmobiliaria.AreaTerreno = lector.GetDecimal(lector.GetOrdinal("AreaTerreno"));
                    unidadInmobiliaria.NumDormitorio = lector.GetDecimal(lector.GetOrdinal("NumDormitorio"));
                    unidadInmobiliaria.NumBanios = lector.GetDecimal(lector.GetOrdinal("NumBanios"));
                    unidadInmobiliaria.PrecioVenta = lector.GetDecimal(lector.GetOrdinal("PrecioVenta"));
                }
            }

            comando.Dispose();

            return unidadInmobiliaria;
        }

        public int Agregar(UnidadInmobiliaria unidadInmobiliaria)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaInsert]");

            BaseDatos.AddOutParameter(comando, "IdUnidadInmobiliaria", DbType.Int32, 4);
            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, unidadInmobiliaria.IdProyecto);
            BaseDatos.AddInParameter(comando, "IdEtapa", DbType.Int32, unidadInmobiliaria.IdEtapa);
            BaseDatos.AddInParameter(comando, "IdEdificio", DbType.Int32, unidadInmobiliaria.IdEdificio);
            BaseDatos.AddInParameter(comando, "NroPiso", DbType.Int32, unidadInmobiliaria.NroPiso);
            BaseDatos.AddInParameter(comando, "NroInmuebleActual", DbType.String, unidadInmobiliaria.NroInmuebleActual);
            BaseDatos.AddInParameter(comando, "Direccion", DbType.String, unidadInmobiliaria.Direccion);
            BaseDatos.AddInParameter(comando, "Observaciones", DbType.String, unidadInmobiliaria.Observaciones);
            BaseDatos.AddInParameter(comando, "Anulado", DbType.Boolean, unidadInmobiliaria.Anulado);
            BaseDatos.AddInParameter(comando, "IdTipoInmueble", DbType.Int32, unidadInmobiliaria.IdTipoInmueble);
            BaseDatos.AddInParameter(comando, "AreaTerreno", DbType.Decimal, unidadInmobiliaria.AreaTerreno); 
            BaseDatos.AddInParameter(comando, "NumDormitorio", DbType.Decimal, unidadInmobiliaria.NumDormitorio);
            BaseDatos.AddInParameter(comando, "NumBanios", DbType.Decimal, unidadInmobiliaria.NumBanios);
            BaseDatos.AddInParameter(comando, "PrecioVenta", DbType.Decimal, unidadInmobiliaria.PrecioVenta);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo insertar el registro en la base de datos.");

            var valor = (int)BaseDatos.GetParameterValue(comando, "IdUnidadInmobiliaria");

            comando.Dispose();

            return valor;
        }

        public bool Modificar(UnidadInmobiliaria unidadInmobiliaria)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaUpdate]");

            BaseDatos.AddInParameter(comando, "IdUnidadInmobiliaria", DbType.Int32, unidadInmobiliaria.id);
            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, unidadInmobiliaria.IdProyecto);
            BaseDatos.AddInParameter(comando, "IdEtapa", DbType.Int32, unidadInmobiliaria.IdEtapa);
            BaseDatos.AddInParameter(comando, "IdEdificio", DbType.Int32, unidadInmobiliaria.IdEdificio);
            BaseDatos.AddInParameter(comando, "NroPiso", DbType.Int32, unidadInmobiliaria.NroPiso);
            BaseDatos.AddInParameter(comando, "NroInmuebleActual", DbType.String, unidadInmobiliaria.NroInmuebleActual);
            BaseDatos.AddInParameter(comando, "Direccion", DbType.String, unidadInmobiliaria.Direccion);
            BaseDatos.AddInParameter(comando, "Observaciones", DbType.String, unidadInmobiliaria.Observaciones);
            BaseDatos.AddInParameter(comando, "Anulado", DbType.Boolean, unidadInmobiliaria.Anulado);
            BaseDatos.AddInParameter(comando, "IdTipoInmueble", DbType.Int32, unidadInmobiliaria.IdTipoInmueble);
            BaseDatos.AddInParameter(comando, "AreaTerreno", DbType.Decimal, unidadInmobiliaria.AreaTerreno);
            BaseDatos.AddInParameter(comando, "NumDormitorio", DbType.Decimal, unidadInmobiliaria.NumDormitorio);
            BaseDatos.AddInParameter(comando, "NumBanios", DbType.Decimal, unidadInmobiliaria.NumBanios);            
            BaseDatos.AddInParameter(comando, "PrecioVenta", DbType.Decimal, unidadInmobiliaria.PrecioVenta);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("Hubo un error al modificar.");

            comando.Dispose();

            return true;
        }

        public bool Eliminar(int id)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaDelete]");

            BaseDatos.AddInParameter(comando, "IdUnidadInmobiliaria", DbType.Int32, id);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo eliminar el registro.");

            comando.Dispose();

            return true;
        }

        public UnidadInmobiliaria ValidarExistencia(UnidadInmobiliaria unidadInmobiliaria)
        {            
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_UnidadInmobiliariaValidarExistencia]");

            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, unidadInmobiliaria.IdProyecto);
            BaseDatos.AddInParameter(comando, "IdEtapa", DbType.Int32, unidadInmobiliaria.IdEtapa);
            BaseDatos.AddInParameter(comando, "IdEdificio", DbType.Int32, unidadInmobiliaria.IdEdificio);
            BaseDatos.AddInParameter(comando, "NroInmuebleActual", DbType.String, unidadInmobiliaria.NroInmuebleActual);

            UnidadInmobiliaria unidadInmobiliariaExistente = null;

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                if (lector.Read())
                {
                    unidadInmobiliariaExistente = new UnidadInmobiliaria()
                    {
                        id = lector.GetInt32(lector.GetOrdinal("IdUnidadInmobiliaria")),
                        IdProyecto = lector.GetInt32(lector.GetOrdinal("IdProyecto")),
                        IdEtapa = lector.GetInt32(lector.GetOrdinal("IdEtapa")),
                        IdEdificio = lector.GetInt32(lector.GetOrdinal("IdEdificio")),
                        NroPiso = lector.GetInt32(lector.GetOrdinal("NroPiso")),
                        NroInmuebleActual = lector.GetString(lector.GetOrdinal("NroInmuebleActual")),
                        Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
                        Observaciones = lector.GetString(lector.GetOrdinal("Observaciones")),
                        Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado")),
                        IdTipoInmueble = lector.GetInt32(lector.GetOrdinal("IdTipoInmueble")),
                        AreaTerreno = lector.GetDecimal(lector.GetOrdinal("AreaTerreno")),
                        NumDormitorio = lector.GetDecimal(lector.GetOrdinal("NumDormitorio")),
                        NumBanios = lector.GetDecimal(lector.GetOrdinal("NumBanios")),
                        PrecioVenta = lector.GetDecimal(lector.GetOrdinal("PrecioVenta"))
                    };
                }
            }

            comando.Dispose();

            return unidadInmobiliariaExistente;
        }
    }
}