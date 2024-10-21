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
    internal class clsCliente
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER;Password=USER654321";

        public void insertar_cliente(string cedula, string nombre, string telefono, string estado)
        {
            if (!Regex.IsMatch(cedula, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe ser un numero valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(telefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono debe ser un numero valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Regex.IsMatch(nombre, @"^\d+$"))
            {
                MessageBox.Show("El nombre debe ser un caracter valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cliente registrado", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Error: El ide ya esta registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show("Error al registrar el : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void consultar_cliente(string id_cliente)
        {
            if (string.IsNullOrEmpty(id_cliente) || !int.TryParse(id_cliente, out _))
            {
                MessageBox.Show("La cédula debe ser un número válido. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OracleConnection connection = new OracleConnection(cadenaConexion))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Cliente WHERE Identificacion = :p_identificacion";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("p_identificacion", OracleDbType.Decimal).Value = id_cliente;

                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            string telefono = reader["Telefono"].ToString();
                            string estado = reader["Estado"].ToString() == "1" ? "Activo" : "Inactivo";

                            MessageBox.Show($"Cliente encontrado:\n\nNombre: {nombre}\nTeléfono: {telefono}\nEstado: {estado}",
                                "Consulta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado. Verifica la identificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error al consultar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void EditarCliente(string idCliente, string nuevoNombre, string nuevoTelefono, string nuevoEstado)
        {
            if (!Regex.IsMatch(idCliente, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe ser un numero valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(nuevoTelefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono debe ser un numero valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Regex.IsMatch(nuevoNombre, @"^\d+$"))
            {
                MessageBox.Show("El nombre debe ser un caracter valido,Intentalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cliente actualizado", "Actualizacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Error: El ide no esta registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        default:
                            MessageBox.Show("Error al actualizar el : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }
    }
}
