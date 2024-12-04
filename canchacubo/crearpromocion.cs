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
    public partial class crearpromocion : Form
    {
        public crearpromocion()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            promociones promo = new promociones();
            promo.Show();
            this.Hide();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            String descuento = txt_descuento.Text;                      
            DateTime fechainicio = obtenerFechaideal();
            DateTime fechafin = dtp_fechafin.Value.Date;
            if (string.IsNullOrEmpty(descuento) || dtp_fechainicio.Checked == false)           
            {

                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsPromocion obj_prom = new clsPromocion();
            obj_prom.RegistrarPromocion(fechainicio, fechafin, "1", descuento);
        }
        private DateTime obtenerFechaideal()
        {
            DateTime fechaSeleccionada = dtp_fechainicio.Value.Date;//obtener solo la fecha
            if (dtp_fechainicio.Checked == false)
            {
                fechaSeleccionada = DateTime.Now.Date;
            }
            return fechaSeleccionada;
        }
    }
}
