using canchacubo.clases;
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
    public partial class consultarcliente : Form
    {
        clsCliente cliente_obj = new clsCliente();
        DataTable dtclientes = new DataTable();
        string identificacion;
        public consultarcliente()
        {
            InitializeComponent();
            CargarClientesEnComboBox();
        }


        private void button1_Click(object sender, EventArgs e)
        {

           
            if (cbxclientes.SelectedIndex == -1)
            {
                MessageBox.Show("La cédula no puede estar vacía. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           Boolean resultado=cliente_obj.ConsultarCliente(identificacion);

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            cliente clientes = new cliente();
            clientes.Show(); // 
            this.Hide();
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
       

        private void cbxclientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verifica que haya una selección válida
            if (cbxclientes.SelectedItem is DataRowView selectedRow)
            {
                identificacion = selectedRow["identificacion"].ToString();
            }
        }
    }
}