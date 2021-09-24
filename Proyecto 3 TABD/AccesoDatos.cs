using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

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
        public static string test()
        {
            string cadenaConexion = obtenerCadenaConexion("servicios_db");
            string result;
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {

                result = cxnDB.Query("select desc_servicio from servicios where id_servicio = 1").ToList()[0];
            }
            return result;
        }
    }
}
