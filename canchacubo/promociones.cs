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
    public partial class promociones : Form
    {
        public promociones()
        {
            InitializeComponent();
        }

        private void btn_volverr_Click(object sender, EventArgs e)
        {
            principal inicio = new principal();
            inicio.Show();
            this.Hide();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            crearcliente cliente = new crearcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            consultarcliente cliente = new consultarcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            editarcliente cliente = new editarcliente();
            cliente.Show();
            this.Hide();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
