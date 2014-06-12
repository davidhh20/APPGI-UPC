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

    public class datProyecto : Singleton<datProyecto>
    {
        private readonly Database BaseDatos = DatabaseFactory.CreateDatabase();

        public IList<Proyecto> Listar()
        {
            var proyectos = new List<Proyecto>();
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoSelectAll]");

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                while (lector.Read())
                {
                    proyectos.Add(new Proyecto
                    {
                        id = lector.GetInt32(lector.GetOrdinal("IdProyecto")),
                        Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                        Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
                        TechoPropio = lector.GetBoolean(lector.GetOrdinal("TechoPropio")),
                        MiVivienda = lector.GetBoolean(lector.GetOrdinal("MiVivienda")),
                        Observaciones = lector.GetString(lector.GetOrdinal("Observaciones")),
                        NumeroInmuebles = lector.GetInt32(lector.GetOrdinal("NumeroInmuebles")),
                        Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado")),
                        MontoSeparacion = lector.GetDecimal(lector.GetOrdinal("MontoSeparacion")),
                        DescuentoPorcentaje = lector.GetDecimal(lector.GetOrdinal("DescuentoPorcentaje")),
                        DescuentoMonto = lector.GetDecimal(lector.GetOrdinal("DescuentoMonto")),
                        FechaCreacion = lector.GetDateTime(lector.GetOrdinal("FechaCreacion")),
                        FechaInicio = lector.GetDateTime(lector.GetOrdinal("FechaInicio")),
                        FechaEntrega = lector.GetDateTime(lector.GetOrdinal("FechaEntrega")),
                        CuotaInicialPorcentaje = lector.GetDecimal(lector.GetOrdinal("CuotaInicialPorcentaje")),
                        CuotaInicialMonto = lector.GetDecimal(lector.GetOrdinal("CuotaInicialMonto")),
                        PeriodoEstacional = lector.GetInt32(lector.GetOrdinal("PeriodoEstacional")),
                        IdEstado = lector.GetInt32(lector.GetOrdinal("IdEstado")),
                        Imagen = lector.GetString(lector.GetOrdinal("Imagen")),
                        Ubicacion = lector.GetString(lector.GetOrdinal("Ubicacion")),
                        Marcador = lector.GetString(lector.GetOrdinal("Marcador"))
                    });
                }
            }

            comando.Dispose();

            return proyectos;
        }

        public Proyecto Obtener(int id)
        {
            var proyecto = new Proyecto();
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoSelect]");
            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, id);

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                if (lector.Read())
                {
                    proyecto.id = lector.GetInt32(lector.GetOrdinal("IdProyecto"));
                    proyecto.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    proyecto.Direccion = lector.GetString(lector.GetOrdinal("Direccion"));
                    proyecto.TechoPropio = lector.GetBoolean(lector.GetOrdinal("TechoPropio"));
                    proyecto.MiVivienda = lector.GetBoolean(lector.GetOrdinal("MiVivienda"));
                    proyecto.Observaciones = lector.GetString(lector.GetOrdinal("Observaciones"));
                    proyecto.NumeroInmuebles = lector.GetInt32(lector.GetOrdinal("NumeroInmuebles"));
                    proyecto.Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado"));
                    proyecto.MontoSeparacion = lector.GetDecimal(lector.GetOrdinal("MontoSeparacion"));
                    proyecto.DescuentoPorcentaje = lector.GetDecimal(lector.GetOrdinal("DescuentoPorcentaje"));
                    proyecto.DescuentoMonto = lector.GetDecimal(lector.GetOrdinal("DescuentoMonto"));
                    proyecto.FechaCreacion = lector.GetDateTime(lector.GetOrdinal("FechaCreacion"));
                    proyecto.FechaInicio = lector.GetDateTime(lector.GetOrdinal("FechaInicio"));
                    proyecto.FechaEntrega = lector.GetDateTime(lector.GetOrdinal("FechaEntrega"));
                    proyecto.CuotaInicialPorcentaje = lector.GetDecimal(lector.GetOrdinal("CuotaInicialPorcentaje"));
                    proyecto.CuotaInicialMonto = lector.GetDecimal(lector.GetOrdinal("CuotaInicialMonto"));
                    proyecto.PeriodoEstacional = lector.GetInt32(lector.GetOrdinal("PeriodoEstacional"));
                    proyecto.IdEstado = lector.GetInt32(lector.GetOrdinal("IdEstado"));
                    proyecto.Imagen = lector.GetString(lector.GetOrdinal("Imagen"));
                    proyecto.Ubicacion = lector.GetString(lector.GetOrdinal("Ubicacion"));
                    proyecto.Marcador = lector.GetString(lector.GetOrdinal("Marcador"));
                }
            }

            comando.Dispose();

            return proyecto;
        }

        public int Agregar(Proyecto proyecto)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoInsert]");

            BaseDatos.AddOutParameter(comando, "IdProyecto", DbType.Int32, 4);
            BaseDatos.AddInParameter(comando, "Nombre", DbType.String, proyecto.Nombre);
            BaseDatos.AddInParameter(comando, "Direccion", DbType.String, proyecto.Direccion);
            BaseDatos.AddInParameter(comando, "TechoPropio", DbType.Boolean, proyecto.TechoPropio);
            BaseDatos.AddInParameter(comando, "MiVivienda", DbType.Boolean, proyecto.MiVivienda);
            BaseDatos.AddInParameter(comando, "Observaciones", DbType.String, proyecto.Observaciones);
            BaseDatos.AddInParameter(comando, "NumeroInmuebles", DbType.Int32, proyecto.NumeroInmuebles);
            BaseDatos.AddInParameter(comando, "Anulado", DbType.Boolean, proyecto.Anulado);
            BaseDatos.AddInParameter(comando, "MontoSeparacion", DbType.Decimal, proyecto.MontoSeparacion);
            BaseDatos.AddInParameter(comando, "DescuentoPorcentaje", DbType.Decimal, proyecto.DescuentoPorcentaje);
            BaseDatos.AddInParameter(comando, "DescuentoMonto", DbType.Decimal, proyecto.DescuentoMonto);
            BaseDatos.AddInParameter(comando, "FechaCreacion", DbType.DateTime, proyecto.FechaCreacion);
            BaseDatos.AddInParameter(comando, "FechaInicio", DbType.DateTime, proyecto.FechaInicio);
            BaseDatos.AddInParameter(comando, "FechaEntrega", DbType.DateTime, proyecto.FechaEntrega);
            BaseDatos.AddInParameter(comando, "CuotaInicialPorcentaje", DbType.Decimal, proyecto.CuotaInicialPorcentaje);
            BaseDatos.AddInParameter(comando, "CuotaInicialMonto", DbType.Decimal, proyecto.CuotaInicialMonto);
            BaseDatos.AddInParameter(comando, "PeriodoEstacional", DbType.Int32, proyecto.PeriodoEstacional);
            BaseDatos.AddInParameter(comando, "IdEstado", DbType.Int32, proyecto.IdEstado);
            BaseDatos.AddInParameter(comando, "Imagen", DbType.String, proyecto.Imagen);
            BaseDatos.AddInParameter(comando, "Ubicacion", DbType.String, proyecto.Ubicacion);
            BaseDatos.AddInParameter(comando, "Marcador", DbType.String, proyecto.Marcador);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo insertar el registro en la base de datos.");

            var valor = (int)BaseDatos.GetParameterValue(comando, "IdProyecto");

            comando.Dispose();

            return valor;
        }

        public bool Modificar(Proyecto proyecto)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoUpdate]");

            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, proyecto.id);
            BaseDatos.AddInParameter(comando, "Nombre", DbType.String, proyecto.Nombre);
            BaseDatos.AddInParameter(comando, "Direccion", DbType.String, proyecto.Direccion);
            BaseDatos.AddInParameter(comando, "TechoPropio", DbType.Boolean, proyecto.TechoPropio);
            BaseDatos.AddInParameter(comando, "MiVivienda", DbType.Boolean, proyecto.MiVivienda);
            BaseDatos.AddInParameter(comando, "Observaciones", DbType.String, proyecto.Observaciones);
            BaseDatos.AddInParameter(comando, "NumeroInmuebles", DbType.Int32, proyecto.NumeroInmuebles);
            BaseDatos.AddInParameter(comando, "Anulado", DbType.Boolean, proyecto.Anulado);
            BaseDatos.AddInParameter(comando, "MontoSeparacion", DbType.Decimal, proyecto.MontoSeparacion);
            BaseDatos.AddInParameter(comando, "DescuentoPorcentaje", DbType.Decimal, proyecto.DescuentoPorcentaje);
            BaseDatos.AddInParameter(comando, "DescuentoMonto", DbType.Decimal, proyecto.DescuentoMonto);
            BaseDatos.AddInParameter(comando, "FechaCreacion", DbType.DateTime, proyecto.FechaCreacion);
            BaseDatos.AddInParameter(comando, "FechaInicio", DbType.DateTime, proyecto.FechaInicio);
            BaseDatos.AddInParameter(comando, "FechaEntrega", DbType.DateTime, proyecto.FechaEntrega);
            BaseDatos.AddInParameter(comando, "CuotaInicialPorcentaje", DbType.Decimal, proyecto.CuotaInicialPorcentaje);
            BaseDatos.AddInParameter(comando, "CuotaInicialMonto", DbType.Decimal, proyecto.CuotaInicialMonto);
            BaseDatos.AddInParameter(comando, "PeriodoEstacional", DbType.Int32, proyecto.PeriodoEstacional);
            BaseDatos.AddInParameter(comando, "IdEstado", DbType.Int32, proyecto.IdEstado);
            BaseDatos.AddInParameter(comando, "Imagen", DbType.String, proyecto.Imagen);
            BaseDatos.AddInParameter(comando, "Ubicacion", DbType.String, proyecto.Ubicacion);
            BaseDatos.AddInParameter(comando, "Marcador", DbType.String, proyecto.Marcador);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("Hubo un error al modificar.");

            comando.Dispose();

            return true;
        }

        public bool Eliminar(int id)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoDelete]");

            BaseDatos.AddInParameter(comando, "IdProyecto", DbType.Int32, id);

            var resultado = BaseDatos.ExecuteNonQuery(comando);

            if (resultado == 0) throw new Exception("No se pudo eliminar el registro.");

            comando.Dispose();

            return true;
        }

        public Proyecto ValidarExistencia(Proyecto proyecto)
        {
            var comando = BaseDatos.GetStoredProcCommand("[inmueble].[usp_ProyectoValidarExistencia]");

            BaseDatos.AddInParameter(comando, "Nombre", DbType.String, proyecto.Nombre);

            Proyecto proyectoExistente = null;

            using (var lector = BaseDatos.ExecuteReader(comando))
            {
                if (lector.Read())
                {
                    proyectoExistente = new Proyecto()
                    {
                        id = lector.GetInt32(lector.GetOrdinal("IdProyecto")),
                        Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                        Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
                        TechoPropio = lector.GetBoolean(lector.GetOrdinal("TechoPropio")),
                        MiVivienda = lector.GetBoolean(lector.GetOrdinal("MiVivienda")),
                        Observaciones = lector.GetString(lector.GetOrdinal("Observaciones")),
                        NumeroInmuebles = lector.GetInt32(lector.GetOrdinal("NumeroInmuebles")),
                        Anulado = lector.GetBoolean(lector.GetOrdinal("Anulado")),
                        MontoSeparacion = lector.GetDecimal(lector.GetOrdinal("MontoSeparacion")),
                        DescuentoPorcentaje = lector.GetDecimal(lector.GetOrdinal("DescuentoPorcentaje")),
                        DescuentoMonto = lector.GetDecimal(lector.GetOrdinal("DescuentoMonto")),
                        FechaCreacion = lector.GetDateTime(lector.GetOrdinal("FechaCreacion")),
                        FechaInicio = lector.GetDateTime(lector.GetOrdinal("FechaInicio")),
                        FechaEntrega = lector.GetDateTime(lector.GetOrdinal("FechaEntrega")),
                        CuotaInicialPorcentaje = lector.GetDecimal(lector.GetOrdinal("CuotaInicialPorcentaje")),
                        CuotaInicialMonto = lector.GetDecimal(lector.GetOrdinal("CuotaInicialMonto")),
                        PeriodoEstacional = lector.GetInt32(lector.GetOrdinal("PeriodoEstacional")),
                        IdEstado = lector.GetInt32(lector.GetOrdinal("IdEstado")),
                        Imagen = lector.GetString(lector.GetOrdinal("Imagen")),
                        Ubicacion = lector.GetString(lector.GetOrdinal("Ubicacion")),
                        Marcador = lector.GetString(lector.GetOrdinal("Marcador"))
                    };
                }
            }

            comando.Dispose();

            return proyectoExistente;
        }
    }
}