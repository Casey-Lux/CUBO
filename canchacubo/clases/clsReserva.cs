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
        public bool Registrar_Reserva(DateTime fecha, string horaSeleccionada, string id_cliente, int num_cancha, Decimal idpromo)
        {
            try
            {
                if (validar_reserva(fecha, horaSeleccionada, id_cliente, num_cancha, idpromo))
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
                        command.Parameters.Add("p_promo", OracleDbType.Decimal).Value = idpromo;
                        // Ejecutamos la consulta
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                // Capturamos los errores de validación desde el método validar_reserva
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                    case 20006:
                        MessageBox.Show("Error: Promocion inactiva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20008:
                        MessageBox.Show("Error: Clinete inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool EliminarReserva(DateTime fechaSeleccionada, string hora, int canchaSeleccionada)
        {
            try
            {
                // Validación de los datos antes de la eliminación
                if (!validar_eliminarReserva(fechaSeleccionada, hora, canchaSeleccionada))
                {
                    return false; // Si la validación falla, detenemos la ejecución
                }

                using (OracleConnection connection = new OracleConnection(cadenaConexion))
                {
                    OracleCommand command = new OracleCommand();
                    command.Connection = connection;
                    command.CommandText = "bdcanchascubo.ELIMINAR_RESERVA"; // Nota: corregido el nombre del procedimiento
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregamos los parámetros requeridos por el procedimiento almacenado
                    command.Parameters.Add("p_fecha", OracleDbType.Date).Value = fechaSeleccionada;
                    command.Parameters.Add("p_horai", OracleDbType.Varchar2).Value = hora;
                    command.Parameters.Add("p_cancha", OracleDbType.Decimal).Value = canchaSeleccionada;

                    // Ejecutamos la consulta
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                // Retorna true si la eliminación fue exitosa
                return true;
            }
            catch (ArgumentException ex)
            {
                // Manejo de excepción de validación
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OracleException ex)
            {
                // Manejo de errores específicos de Oracle
                switch (ex.Number)
                {
                    case 20003:
                        MessageBox.Show("Error: No existe una reserva para la fecha, hora y cancha especificadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool validar_reserva(DateTime fecha, string horaSeleccionada, string id_cliente, int num_cancha,Decimal idpromo)
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

            DateTime fechaHoraSeleccionada = new DateTime(fecha.Year, fecha.Month, fecha.Day, horaInicio.Hour, horaInicio.Minute, 0);
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
        public bool validar_eliminarReserva(DateTime fecha, string horaSeleccionada, int num_cancha)
        {

            DateTime horaInicio;
            if (!DateTime.TryParse(horaSeleccionada, out horaInicio))
            {
                throw new ArgumentException("La hora seleccionada no es válida. Asegúrate de seleccionar un formato correcto..");
            }

            if (horaInicio.Hour < 12 || horaInicio.Hour > 23)
            {
                throw new ArgumentException("La hora de la reserva debe estar entre las 12:00 y las 23:00 horas.");
            }

            DateTime fechaHoraSeleccionada = new DateTime(fecha.Year, fecha.Month, fecha.Day, horaInicio.Hour, horaInicio.Minute, 0);
            if (fechaHoraSeleccionada < DateTime.Now)
            {
                throw new ArgumentException("No es posible eliminar una reserva que ha caducado.");
            }

            if (num_cancha < 1 || num_cancha > 5)
            {
                throw new ArgumentException("El número de cancha debe estar entre 1 y 5.");
            }

            return true;
        }
        public DataTable ObtenerTablaReservas()
        {
            using (OracleConnection conn = new OracleConnection(cadenaConexion))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand("bdcanchascubo.OBTENER_RESERVAS", conn))
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
