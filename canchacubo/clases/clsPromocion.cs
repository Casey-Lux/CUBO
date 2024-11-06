using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsPromocion
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";
        int estado = 1;

        public void RegistrarPromocion(DateTime fechainicio, DateTime fechafin, string estado, string descuento)
        {
            try
            {
                if (validarPromocion(fechainicio, fechafin, estado, descuento))
                {
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "bdcanchascubo.INSERTAR_PROMOCION";
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregamos los parámetros requeridos por el procedimiento almacenado
                        command.Parameters.Add("p_descuento", OracleDbType.Decimal).Value = descuento;
                        command.Parameters.Add("p_estado", OracleDbType.Decimal).Value = estado;
                        command.Parameters.Add("p_fecha_inicio", OracleDbType.Date).Value = fechainicio;
                        command.Parameters.Add("p_frecha_fin", OracleDbType.Date).Value = fechafin; 
                     

                        // Ejecutamos la consulta
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("promocion registrada", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Capturamos los errores de validación desde el método validar_reserva
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OracleException ex)
            {
                // Manejo de errores específicos de Oracle
                switch (ex.Number)
                {
                    case 20001:
                        MessageBox.Show("Error: La Fecha_Fin no puede ser anterior a la Fecha_Inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show("Error: La duración de la promoción no puede exceder los 8 días.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20003:                   
                             MessageBox.Show(" Error: Ya existe una promoción activa con la misma informacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;                   
                    default:
                        MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier otro tipo de error
                MessageBox.Show("Error al registrar la Promocion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Boolean validarPromocion(DateTime fechainicio, DateTime fechafin, string estado, string descuento)
        {
            if (Regex.IsMatch(descuento, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El descuento no puede contener letras. Debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Regex.IsMatch(descuento, @"^[a-zA-Z0-9]+$") && Regex.IsMatch(descuento, @"[a-zA-Z]"))
            {
                MessageBox.Show("El descuento no puede contener letras y números. Debe ser solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(descuento, out _))
            {
                MessageBox.Show("El descuento debe ser un número válido. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                       
            if (estado != "0" && estado != "1")
            {
                throw new ArgumentException("El estado debe ser '0' o '1'.");
            }
            if (fechafin<fechainicio)
            {
                throw new ArgumentException("La fecha de finalizacion no puede anterior a la fecha de incio ");
            }
            return true;
        }
       
        public DataTable ObtenerTablapPromociones()
        {
            using (OracleConnection conn = new OracleConnection(cadenaConexion))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand("bdcanchascubo.OBTENERPROMOCIONES", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }
    }
}
    