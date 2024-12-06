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

        public bool InsertarCliente(string cedula, string nombre, string telefono, string estado)
        {
            try
            {
                // Validación de datos antes de insertar
                if (ValidarDatosCliente(cedula, nombre, telefono, estado))
                {
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
                    }
                    // Retorna true si la inserción fue exitosa
                    return true;
                }
                else
                {
                    // Datos no válidos; retorna false
                    return false;
                }
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
                        MessageBox.Show("Error: El estado solo puede ser el número 0 o 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20008:
                        MessageBox.Show("Error: El ID ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ConsultarCliente(string idCliente)
        {
            try
            {
                // Validación del ID del cliente antes de la consulta
                if (!ValidarIdCliente(idCliente))
                {
                    return false; // Si la validación falla, detenemos la ejecución
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
                // Retorna true si la consulta fue exitosa y se encontraron datos
                return true;
            }
            catch (OracleException ex)
            {
                // Manejo de errores específicos de Oracle
                MostrarResultado("Error al consultar el cliente: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MostrarResultado("Error inesperado: " + ex.Message);
                return false;
            }
        }

        public bool EditarCliente(string idCliente, string nuevoNombre, string nuevoTelefono, string nuevoEstado)
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
                    }
                    // Retorna true si la inserción fue exitosa
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
        public bool ValidarIdCliente(string idCliente)
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
        
        public DataTable obtenerTablaClientes()
        {
            DataTable dtclientes = new DataTable();
            using (OracleConnection connection = new OracleConnection(cadenaConexion))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "bdcanchascubo.OBTENER_CLIENTES";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    connection.Open();

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dtclientes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            return dtclientes;

        }
        public DataTable obtenerTablaClientesactivos()
        {
            DataTable dtclientes = new DataTable();
            using (OracleConnection connection = new OracleConnection(cadenaConexion))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "bdcanchascubo.OBTENERCLIENTESACTIVOS";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    connection.Open();

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dtclientes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            return dtclientes;

        }
    }
}
