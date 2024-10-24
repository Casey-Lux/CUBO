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
    public class clsCliente
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";
        public clsCliente()
        { }
        public void insertar_cliente(string cedula, string nombre, string telefono, string estado)
        {
            try
            {
                // Intentamos validar los datos antes de insertar
                if (ValidarDatosCliente(cedula, nombre, telefono, estado))
                {
                    // Si la validación es exitosa, procedemos con la inserción
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "bdcanchascubo.INSERTAR_CLIENTE";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_identificacion", OracleDbType.Decimal).Value = cedula;
                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nombre;
                        command.Parameters.Add("p_telefono", OracleDbType.Decimal).Value = telefono;
                        command.Parameters.Add("p_estado", OracleDbType.Decimal).Value = estado;

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Mostramos un mensaje en caso de éxito
                        MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Mostramos un MessageBox con el mensaje de validación si hay un error
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 20001:
                        MessageBox.Show("Error: La identificación debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show("Error: La identificación solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20003:
                        MessageBox.Show("Error: El teléfono debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20004:
                        MessageBox.Show("Error: El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20005:
                        MessageBox.Show("Error: El nombre solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20006:
                        MessageBox.Show("Error: El estado solo puede ser el número 0 o 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20008:
                        MessageBox.Show("Error: El ID ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void consultar_cliente(string idCliente)
        {
            try
            {
                // Validamos el ID del cliente antes de realizar la consulta
                if (!ValidarIdCliente(idCliente))
                {
                    return; // Si la validación falla, mostramos un mensaje en el método ValidarIdCliente y detenemos la ejecución
                }

                using (OracleConnection connection = new OracleConnection(cadenaConexion))
                {
                    OracleCommand command = new OracleCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Cliente WHERE Identificacion = :p_identificacion";
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add("p_identificacion", OracleDbType.Decimal).Value = idCliente;

                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            string telefono = reader["Telefono"].ToString();
                            string estado = reader["Estado"].ToString() == "1" ? "Activo" : "Inactivo";

                            MostrarResultado($"Cliente encontrado:\n\nNombre: {nombre}\nTeléfono: {telefono}\nEstado: {estado}");
                        }
                    }
                    else
                    {
                        MostrarResultado("Cliente no encontrado. Verifica la identificación.");
                    }
                }
            }
            catch (OracleException ex)
            {
                MostrarResultado("Error al consultar el cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                MostrarResultado("Error inesperado: " + ex.Message);
            }
        }
        public void EditarCliente(string idCliente, string nuevoNombre, string nuevoTelefono, string nuevoEstado)
        {
            try
            {
                if (ValidarDatosCliente(idCliente, nuevoNombre, nuevoTelefono, nuevoEstado))
                {
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "bdcanchascubo.ACTUALIZAR_CLIENTE";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_identificacion", OracleDbType.Decimal).Value = idCliente;
                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nuevoNombre;
                        command.Parameters.Add("p_telefono", OracleDbType.Decimal).Value = nuevoTelefono;
                        command.Parameters.Add("p_estado", OracleDbType.Decimal).Value = nuevoEstado;

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cliente actualizado", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 20001:
                        MessageBox.Show("Error: La identificación debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show("Error: La identificación solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20003:
                        MessageBox.Show("Error: El teléfono debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20004:
                        MessageBox.Show("Error: El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20005:
                        MessageBox.Show("Error: El nombre solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20006:
                        MessageBox.Show("Error: El estado solo puede ser el número 0 o 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20007:
                        MessageBox.Show("Error:Los nuevos datos son iguales a los datos existentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20008:
                        MessageBox.Show("Error: El ID no está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20013:
                        MessageBox.Show("Error: Existe una reserva para esta cancha en este horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarDatosCliente(string cedula, string nombre, string telefono, string estado)
        {
            if (!Regex.IsMatch(cedula, @"^\d+$"))
            {
                // Lanzamos una excepción que será capturada en el método principal
                throw new ArgumentException("La cédula debe ser un número válido.");
            }

            if (!Regex.IsMatch(telefono, @"^\d+$"))
            {
                throw new ArgumentException("El teléfono debe ser un número válido.");
            }

            if (Regex.IsMatch(nombre, @"^\d+$"))
            {
                throw new ArgumentException("El nombre debe contener letras.");
            }
            if (estado != "0" && estado != "1")
            {
                throw new ArgumentException("El estado debe ser '0' o '1'.");
            }
            // Si todas las validaciones son exitosas, retornamos true
            return true;
        }
        private bool ValidarIdCliente(string idCliente)
        {
            // Validamos que no contenga letras ni caracteres inválidos
            if (Regex.IsMatch(idCliente, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("La identificación no puede contener letras. Debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Regex.IsMatch(idCliente, @"^[a-zA-Z0-9]+$") && Regex.IsMatch(idCliente, @"[a-zA-Z]"))
            {
                MessageBox.Show("La identificación no puede contener letras y números. Debe ser solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(idCliente, out _))
            {
                MessageBox.Show("La cédula debe ser un número válido. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void MostrarResultado(string mensaje)
        {
            MessageBox.Show(mensaje, "Resultado de la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
    }
}
