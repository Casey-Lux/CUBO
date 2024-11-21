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
            this.Close();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            crearpromocion promo = new crearpromocion();
            promo.Show();
            this.Close();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            consultarpromocion promo = new consultarpromocion();
            promo.Show();
            this.Close();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            editarpromocion promo = new editarpromocion();
            promo.Show();
            this.Close();
        }

    }
}
