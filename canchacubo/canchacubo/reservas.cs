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
    public partial class reservas : Form
    {
        public reservas()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            validareserva validar = new validareserva();
            validar.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void cancha2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            principal inicio = new principal();
            inicio.Show();
            this.Hide();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
