using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsConsulta
    {
        string cadenaConexion = "Data Source = localhost; User ID = MY_USER; Password = USER654321";

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
    }
}