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
            txtt_nombre.Enabled = false;
            txt_telefono.Enabled = false;           
            txt_estado.Enabled = false;
            btn_crearcliente.Enabled = false;

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
            String estado = txt_estado.Text;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
        string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(estado))
            {
                // Mostrar mensaje de error si algún campo está vacío
                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin continuar
            }
            clsCliente cliente_obj = new clsCliente();
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
                txtt_nombre.Enabled = true;
                txt_telefono.Enabled = true;
                txt_estado.Enabled = true;
                btn_crearcliente.Enabled = true;

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
            cbxclientes.Items.Clear();
            
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
                string nombre = row["nombre"].ToString();
                string informacionPromo = $"cedula: {cedula}  nombre: {nombre} ";
                row["Informacion"] = informacionPromo;
            }

            // Crear una fila para la opción "Ninguno" y agregarla como la primera fila
            
            // Asignar la DataSource y definir DisplayMember y ValueMember
            cbxclientes.DataSource = dtclientes;
            cbxclientes.DisplayMember = "Informacion";
            cbxclientes.ValueMember = "identificacion";  // Permite obtener el ID de la promoción seleccionada
        }

        private void cbxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya una selección válida
            if (cbxclientes.SelectedItem is DataRowView selectedRow)
            {
                 identificacion = selectedRow["identificacion"].ToString();
            }

        }
    }
}
