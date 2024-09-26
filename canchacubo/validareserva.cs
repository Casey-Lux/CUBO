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
        string fecha;
        string hora;
        int cancha;
        public validareserva(String fecha, string hora, int cancha)
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
            clsReserva reserva_obj = new clsReserva();
            reserva_obj.registrarreserva(fecha, hora, cancha);
        }
    }
}
