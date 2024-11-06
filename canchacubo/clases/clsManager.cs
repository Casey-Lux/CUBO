using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canchacubo.clases
{
    internal class clsManager
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";

        public decimal ObtenerCostoCancha(int numeroCancha)
        {
            using (OracleConnection conn = new OracleConnection(cadenaConexion))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand("bdcanchascubo.OBTENER_COSTO_CANCHA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada: número de cancha
                    cmd.Parameters.Add("p_numero_cancha", OracleDbType.Int32).Value = numeroCancha;

                    // Parámetro de salida: precio (costo de la cancha)
                    var costoParameter = cmd.Parameters.Add("p_costo", OracleDbType.Decimal);
                    costoParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Convertir el valor de OracleDecimal a decimal
                    if (costoParameter.Value is Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal)
                    {
                        return oracleDecimal.Value;
                    }
                    else
                    {
                        throw new InvalidCastException("El valor de 'p_costo' no es un tipo decimal válido.");
                    }
                }
            }
        }






    }
}
