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
    public partial class informes : Form
    {
        public informes()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            principal objeto = new principal();
            objeto.Show();
            this.Hide();
        }

        private void btn_ingresos_Click(object sender, EventArgs e)
        {
            ingresos objeto = new ingresos();
            objeto.Show();
            this.Hide();
        }
    }
}
