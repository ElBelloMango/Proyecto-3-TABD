using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Collections;

namespace Proyecto_3_TABD
{
    class AccesoDatos
    {
        private static string obtenerCadenaConexion(string idCadena)
        {
            return ConfigurationManager.ConnectionStrings[idCadena].ConnectionString;
        }
        
        public static void guardarConsumo(Consumo consumo)
        {
            string cadenaConexion = obtenerCadenaConexion("servicios_db");
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                cxnDB.Execute("insert into consumos (año,mes,id_servicio,consumo,valor_total,valor_unidad) " +
                    "values (@Año, @Mes, @Id_servicio, @Valor_consumo, @Valor_total,@Valor_unidad)", consumo);
            }
        }
        public static DataTable GetConsumos()
        {
            DataTable tablaResultado = new DataTable();
            string cadenaConexion = obtenerCadenaConexion("servicios_DB");
            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                SQLiteDataAdapter daSismos = new SQLiteDataAdapter("select * from consumos", cxnDB);
                daSismos.Fill(tablaResultado);
                return tablaResultado;
            }
        }
        public static DataTable GetValoracionReq01()
        {
            DataTable tablaResultado = new DataTable();
            string cadenaConexion = obtenerCadenaConexion("servicios_DB");
            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                SQLiteDataAdapter daSismos = new SQLiteDataAdapter("select * from req01", cxnDB);
                daSismos.Fill(tablaResultado);
                return tablaResultado;
            }
        }
        public static DataTable GetValoracionReq02()
        {
            DataTable tablaResultado = new DataTable();
            string cadenaConexion = obtenerCadenaConexion("servicios_DB");
            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                SQLiteDataAdapter daSismos = new SQLiteDataAdapter("select * from req02", cxnDB);
                daSismos.Fill(tablaResultado);
                return tablaResultado;
            }
        }

        public static void EditConsumo(Consumo consumo)
        {
            string cadenaConexion = obtenerCadenaConexion("servicios_db");
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                cxnDB.Execute("UPDATE consumos SET año = @Año, mes = @Mes, id_servicio = @Id_servicio, " +
                    "consumo = @Valor_consumo, valor_total = @Valor_total, valor_unidad = @Valor_unidad"+
                    " WHERE id_consumo = @Id_consumo", consumo);
            }
        }
        public static void DeleteConsumo(Consumo consumo)
        {
            string cadenaConexion = obtenerCadenaConexion("servicios_db");
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                cxnDB.Execute("Delete from consumos where id_consumo = @Id_consumo", consumo);
            }
        }

    }
}
