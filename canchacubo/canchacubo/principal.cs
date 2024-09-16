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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void b_usuario_Click(object sender, EventArgs e)
        {
            cliente clientes = new cliente() ;
            clientes.Show(); // 
             this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_informe_Click(object sender, EventArgs e)
        {
            informes informe = new informes();
            informe.Show();
            this.Hide();
        }

        private void principal_Load(object sender, EventArgs e)
        {

        }

        private void btn_reserva_Click(object sender, EventArgs e)
        {
            reservas reserva = new reservas();
            reserva.Show();
            this.Hide();

        }

        private void btn_promociones_Click(object sender, EventArgs e)
        {
            promociones promo = new promociones();
            promo.Show();
            this.Hide();
        }
    }
}
