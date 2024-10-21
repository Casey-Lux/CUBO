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
    public partial class validareserva : Form
    {
        DateTime fecha;
        string hora;
        int cancha;
        public validareserva(DateTime fecha, string hora, int cancha)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.cancha = cancha;
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            reservas reserva = new reservas();
            reserva.Show();
            this.Hide();
        }

        private void txt_id_cliente_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void validareserva_Load(object sender, EventArgs e)
        {

        }

        private void registrar_Click(object sender, EventArgs e)
        {
             string id_cliente = txt_id_cliente.Text;
            if (string.IsNullOrEmpty(id_cliente) )
            {
                MessageBox.Show("Por favor rellene los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsReserva reserva_obj = new clsReserva();
            reserva_obj.registrarreserva(fecha, hora, id_cliente, cancha);
        }
    }
}
