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
        public editarcliente()
        {
            InitializeComponent();
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
            ClienteModificado?.Invoke(this, EventArgs.Empty);
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            String identificacion = txt_identificacion.Text;

            Boolean resultado = cliente_obj.ConsultarCliente(identificacion);
            if (resultado) {
                txtt_nombre.Enabled = true;
                txt_telefono.Enabled = true;
                txt_estado.Enabled = true;
                btn_crearcliente.Enabled = true;

            }

        }
    }
}
