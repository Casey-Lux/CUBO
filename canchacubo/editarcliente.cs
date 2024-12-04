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

            String nombre = txtt_nombre.Text;
            string telefono = txt_telefono.Text;            
            String estado ;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
        string.IsNullOrEmpty(identificacion) || cbx_estado.SelectedIndex == -1)
            {
                // Mostrar mensaje de error si algún campo está vacío
                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin continuar
            }
            else
            {
                estado = obtenerestado();
            }
            clsCliente cliente_obj = new clsCliente();
            this.ClienteModificado += Refrescarclientes;
            cliente_obj.EditarCliente(identificacion, nombre, telefono, estado);
            ClienteModificado?.Invoke(this, EventArgs.Empty);
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (cbxclientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una opción para la hora.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Boolean resultado = cliente_obj.ConsultarCliente(identificacion);
            if (resultado) {              
                modificaraccesoespacios(true);

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

            // Verificar si la columna "InformacionPromo" ya existe para evitar errores
            if (!dtclientes.Columns.Contains("Informacion"))
            {
                dtclientes.Columns.Add("Informacion", typeof(string));
            }

            // Formatear cada fila existente con el formato deseado para mostrar en el ComboBox
            foreach (DataRow row in dtclientes.Rows)
            {
                string cedula = row["identificacion"].ToString();               
                string informacionPromo = $"cedula: {cedula} ";
                row["Informacion"] = informacionPromo;
            }

            // Crear una fila para la opción "Ninguno" y agregarla como la primera fila
            
            // Asignar la DataSource y definir DisplayMember y ValueMember
            cbxclientes.DataSource = dtclientes;
            cbxclientes.DisplayMember = "Informacion";
            cbxclientes.ValueMember = "identificacion";  // Permite obtener el ID de la promoción seleccionada
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
        private void cbxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya una selección válida
            if (cbxclientes.SelectedItem is DataRowView selectedRow)
            {
                 identificacion = selectedRow["identificacion"].ToString();
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
    }
}
