using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsReserva
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";
        int estado = 1;         
        public void Registrar_Reserva(DateTime fecha, string horaSeleccionada, string id_cliente, int num_cancha)
        {
            try
            {
                if (validar_reserva(fecha, horaSeleccionada, id_cliente, num_cancha))
                {
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "bdcanchascubo.insertar_reserva";
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregamos los parámetros requeridos por el procedimiento almacenado
                        command.Parameters.Add("p_fecha", OracleDbType.Date).Value = fecha;
                        command.Parameters.Add("p_horai", OracleDbType.Varchar2).Value = horaSeleccionada;
                        command.Parameters.Add("p_cliente", OracleDbType.Decimal).Value = id_cliente;
                        command.Parameters.Add("p_estado", OracleDbType.Decimal).Value = estado; // Asegúrate de definir este valor
                        command.Parameters.Add("p_cancha", OracleDbType.Decimal).Value = num_cancha;

                        // Ejecutamos la consulta
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Reserva registrada", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Error: la fecha de la reserva no puede ser anterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show("Error: ya existe una reserva para esta cancha en el mismo horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20004:
                        DialogResult result = MessageBox.Show(
                            "Error: cliente inexistente. ¿Desea registrar al cliente?",
                            "Cliente no encontrado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                           
                            crearcliente cliente = new crearcliente();
                            cliente.Show(); // Redirigimos al formulario de creación de cliente
                        }
                        break;
                    case 20005:
                        MessageBox.Show("Error: formato de fecha incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier otro tipo de error
                MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool validar_reserva(DateTime fecha, string horaSeleccionada, string id_cliente, int num_cancha)
        {           
            if (!Regex.IsMatch(id_cliente, @"^\d+$"))
            {
                throw new ArgumentException("La cédula debe ser un número válido. Inténtalo de nuevo.");
            }
            DateTime horaInicio;
            if (!DateTime.TryParse(horaSeleccionada, out horaInicio))
            {
                throw new ArgumentException("La hora seleccionada no es válida. Asegúrate de seleccionar un formato correcto..");
            }
            if (horaInicio.Hour < 12 || horaInicio.Hour > 23)
            {
                throw new ArgumentException("La hora de la reserva debe estar entre las 12:00 y las 23:00 horas.");
            }

            DateTime fechaHoraSeleccionada = new DateTime(fecha.Year, fecha.Month, fecha.Day, horaInicio.Hour, horaInicio.Minute,0);
            // Validar si la fecha y hora seleccionadas son menores a la fecha y hora actual
            if (fechaHoraSeleccionada < DateTime.Now)
            {
                throw new ArgumentException("La fecha y hora de la reserva no puede ser anterior a la fecha actual.");
            }
            
            if (num_cancha < 1 || num_cancha > 5)
            {
                throw new ArgumentException("El número de cancha debe estar entre 1 y 5.");
            }

            return true;
        }
    }
}
