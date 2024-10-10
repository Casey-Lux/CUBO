using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsReserva
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";
        int estado = 1;

        public void registrarreserva(DateTime fecha, string horaSeleccionada, string id_cliente, int num_cancha)
        {
            if (!Regex.IsMatch(id_cliente, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe ser un número válido. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime horaInicio;
            if (!DateTime.TryParse(horaSeleccionada, out horaInicio))
            {
                MessageBox.Show("La hora seleccionada no es válida. Asegúrate de seleccionar un formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            horaInicio = new DateTime(1, 1, 1, horaInicio.Hour, horaInicio.Minute, 0); // Establece un año, mes, y día ficticio


            using (OracleConnection connection = new OracleConnection(cadenaConexion))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "bdcanchascubo.insertar_reserva";
                command.CommandType = CommandType.StoredProcedure;

                // Pasamos el valor de fecha directamente desde el DateTimePicker
                command.Parameters.Add("p_fecha", OracleDbType.Date).Value = fecha;
                command.Parameters.Add("p_horai", OracleDbType.Date).Value = horaInicio;
                command.Parameters.Add("p_cliente", OracleDbType.Decimal).Value = id_cliente;
                command.Parameters.Add("p_estado", OracleDbType.Decimal).Value = estado;
                command.Parameters.Add("p_cancha", OracleDbType.Decimal).Value = num_cancha;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Reserva registrada", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (OracleException ex)
                {
                    switch (ex.Number)
                    {
                        case 20008:
                            MessageBox.Show("Error: LA cancha ya se encuentra reservada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 20009:
                            MessageBox.Show("Error: violación de clave foránea, cliente inexistente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 20010:
                            MessageBox.Show("Error: la fecha de la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show("Error al registrar el: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
