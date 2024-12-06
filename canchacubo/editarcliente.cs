using canchacubo.clases;
using OracleInternal.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canchacubo
{

    public partial class editarcliente : Form
    {
        clsCliente cliente_obj = new clsCliente();
        public event EventHandler ClienteModificado;
        DataTable dtclientes = new DataTable();
        string identificacion;
        string nombre;
        string telefono;
        string estado;
        public editarcliente()
        {
            InitializeComponent();
            CargarClientesEnComboBox();
            modificaraccesoespacios(false);
            cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList;  // Deshabilita la edición
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            cliente clientes = new cliente();
            clientes.Show(); // 
            this.Hide();
        }
        private void btn_crearcliente_Click(object sender, EventArgs e)
        {

             nombre = txtt_nombre.Text;
             telefono = txt_telefono.Text;
            string v_estado;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
        string.IsNullOrEmpty(identificacion) || cbx_estado.SelectedIndex == -1)
            {
                // Mostrar mensaje de error si algún campo está vacío
                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin continuar
            }
            else
            {
                v_estado = obtenerestado();
            }
            clsCliente cliente_obj = new clsCliente();
            this.ClienteModificado += Refrescarclientes;
           bool resultad= cliente_obj.EditarCliente(identificacion, nombre, telefono, v_estado);
            if (resultad)
            {
                MessageBox.Show("Cliente actualizado", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClienteModificado?.Invoke(this, EventArgs.Empty);
            }
           
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxclientes.Text))
            {
                MessageBox.Show("Por favor, seleccione un selecciona un identificacion.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Boolean resultado = cliente_obj.ValidarIdCliente(identificacion);

            if (resultado)
            {
                if (Existecliente(identificacion))
                {
                    modificaraccesoespacios(true);
                    txtt_nombre.Text = nombre;
                    txt_telefono.Text = telefono;
                    actualizarestado();
                }
                else
                {                   
                        MessageBox.Show(" Cliente no encontrado.Verifica la identificación.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modificaraccesoespacios(false);
                }
            }

        }
        private void RecargarDatosClientes()
        {
            try
            {
                clsCliente obj_cliente = new clsCliente();
                DataTable tabla = new DataTable();
                dtclientes = obj_cliente.obtenerTablaClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarClientesEnComboBox()
        {
            
            RecargarDatosClientes();  // Cargar los datos en dtpromociones

            // Verificar si la columna "Informacioncleinteo" ya existe para evitar errores
            if (!dtclientes.Columns.Contains("Informacion"))
            {
                dtclientes.Columns.Add("Informacion", typeof(string));
            }

            // Formatear cada fila existente con el formato deseado para mostrar en el ComboBox
            foreach (DataRow row in dtclientes.Rows)
            {
                string cedula = row["identificacion"].ToString();               
                string informacionCliente = $"cedula: {cedula} ";
                row["Informacion"] = informacionCliente;
            }

            // Asignar la DataSource y definir DisplayMember y ValueMember
            cbxclientes.DataSource = dtclientes;
            cbxclientes.DisplayMember = "Informacion";
            cbxclientes.ValueMember = "identificacion";  // Permite obtener el ID del cliente seleccionada
            cbxclientes.ValueMember = "nombre";
            cbxclientes.ValueMember = "telefono";
            cbxclientes.ValueMember = "estado";
        }
        private String obtenerestado()
        {
            string estado = cbx_estado.SelectedItem.ToString(); ;//obtener estado
            if (estado == "Activo")
            {
                return "1";
            }
            else return "0";

        }
        private void actualizarestado()
        {
           if (estado == "1")
            {
                cbx_estado.SelectedIndex = 0;
            }
            else { cbx_estado.SelectedIndex = 1; 
            }           
        }
        private void cbxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya una selección válida
            if (cbxclientes.SelectedItem is DataRowView selectedRow)
            {
                 identificacion = selectedRow["identificacion"].ToString();
                nombre = selectedRow["nombre"].ToString();
                telefono = selectedRow["telefono"].ToString();
                estado = selectedRow["estado"].ToString();
            }
            else
            {
                // Si no hay selección, usa el texto ingresado
                identificacion = cbxclientes.Text;
            }

        }
        private void Refrescarclientes(object sender, EventArgs e)
        {
            modificaraccesoespacios(false);
            CargarClientesEnComboBox();
        }
        private void modificaraccesoespacios(bool estado)
        {
            txtt_nombre.Clear();
            txt_telefono.Clear();
            txtt_nombre.Enabled = estado;
            txt_telefono.Enabled = estado;
            cbx_estado.Enabled = estado;
            cbx_estado.SelectedIndex = -1;
            btn_crearcliente.Enabled = estado;
        }
        private void cbxclientes_TextChanged(object sender, EventArgs e)
        {
            // Actualiza la identificación con el texto escrito
            identificacion = cbxclientes.Text;
        }
        public bool Existecliente(string identificacion)
        {
            foreach (DataRow row in dtclientes.Rows)
            {
                string cedula = row["identificacion"].ToString();
                string v_nombre = row["nombre"].ToString();
                string v_telefono = row["telefono"].ToString();
                string v_estado = row["estado"].ToString();

                if (identificacion == cedula )
                {
                    nombre = v_nombre;
                    telefono = v_telefono;
                    estado = v_estado;
                    return true;
                }
            }
            return false;
        }
    }
}
