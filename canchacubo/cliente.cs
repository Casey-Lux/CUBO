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

        private void button4_Click(object sender, EventArgs e)
        {
            consultarcliente cliente = new consultarcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            principal objeto = new principal();
            objeto.Show();
            this.Hide();
        }

        private void btn_crearcliente_Click(object sender, EventArgs e)
        {
            crearcliente cliente = new crearcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_editarcliente_Click(object sender, EventArgs e)
        {
            editarcliente cliente = new editarcliente();
            cliente.Show();
            this.Hide();

        }

        private void btn_eliminarcliente_Click(object sender, EventArgs e)
        {
            eliminarcliente cliente = new eliminarcliente();
            cliente.Show();
            this.Hide();
        }
    }
}
