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
    public partial class cliente : Form
    {
        public cliente()
        {
            InitializeComponent();          
        }
        clsCliente obj_cliente = new clsCliente();
        private void btn_consultar_Click(object sender, EventArgs e)
        {
            consultarcliente cliente = new consultarcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            principal objeto = new principal();
            objeto.Show();
            this.Close();
        }

        private void btn_crearcliente_Click(object sender, EventArgs e)
        {
            crearcliente Form_cliente = new crearcliente();
            Form_cliente.ClienteRegistrado += RefrescarListaClientees;
            Form_cliente.Show();
                       
        }

        private void btn_editarcliente_Click(object sender, EventArgs e)
        {            
            editarcliente Form_cliente = new editarcliente();
            Form_cliente.ClienteModificado += RefrescarListaClientees;
            Form_cliente.Show();
            this.Close();
        }     
       
        public void RefrescarListaClientees(object sender, EventArgs e)
        {
            try
            {
                DataTable dtclientes = obj_cliente.obtenerTablaClientes();              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
