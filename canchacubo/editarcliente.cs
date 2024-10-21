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
    public partial class editarcliente : Form
    {
        public editarcliente()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            cliente clientes = new cliente();
            clientes.Show(); // 
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_crearcliente_Click(object sender, EventArgs e)
        {
            String nombre = txtt_nombre.Text;
            string telefono = txt_telefono.Text;
            String identificacion = txt_identificacion.Text;
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
        }
    }
}
