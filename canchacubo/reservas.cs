using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace canchacubo
{
    public partial class reservas : Form
    {
        int canchaSeleccionada = 0;
        public reservas()
        {
            InitializeComponent();


        }



        private void Form2_Load(object sender, EventArgs e)
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


        private void txt_fecha_TextChanged(object sender, EventArgs e)
        {

        }


        private void cancha1_Click(object sender, EventArgs e)
        {
            canchaSeleccionada = 1;
            QuitarBordes();
            cancha1.BorderStyle = BorderStyle.Fixed3D;

        }

        private void cancha2_Click(object sender, EventArgs e)
        {
            canchaSeleccionada = 2;
            QuitarBordes();
            cancha2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void cancha3_Click(object sender, EventArgs e)
        {
            canchaSeleccionada = 3;
            QuitarBordes();
            cancha3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void cancha4_Click(object sender, EventArgs e)
        {
            canchaSeleccionada = 4;
            QuitarBordes();
            cancha4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void cancha5_Click(object sender, EventArgs e)
        {
            canchaSeleccionada = 5;
            QuitarBordes();
            cancha5.BorderStyle = BorderStyle.Fixed3D;
        }
        private void QuitarBordes()
        {
            cancha1.BorderStyle = BorderStyle.None;
            cancha2.BorderStyle = BorderStyle.None;
            cancha3.BorderStyle = BorderStyle.None;
            cancha4.BorderStyle = BorderStyle.None;
            cancha5.BorderStyle = BorderStyle.None;
        }

        private void btn_reservar_Click(object sender, EventArgs e)
        {
            if (cbx_horario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una opción para la hora.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaSeleccionada = txt_fecha.Value.Date;//obtener solo la fecha
            if (txt_fecha.Checked==false)
            {
                fechaSeleccionada = DateTime.Today;
            }
            if (canchaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione una cancha.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hora = cbx_horario.SelectedItem.ToString(); // ontener la hora y convertirla en froma  datetime          
            validareserva objeto = new validareserva(fechaSeleccionada, hora,canchaSeleccionada);
            objeto.Show();
            this.Hide();
        }
    }
}
