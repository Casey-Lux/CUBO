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
        clsConsulta consulta = new clsConsulta();
        public consultarcliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idCliente = txtIdentificacion.Text.Trim();

            // Llama al método de consulta y pasa el ID
            consulta.consultar_cliente(idCliente);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void consultarcliente_Load(object sender, EventArgs e)
        {

        }
    }
}