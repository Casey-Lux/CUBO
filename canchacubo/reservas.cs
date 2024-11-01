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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace canchacubo
{
    public partial class reservas : Form
    {
        int canchaSeleccionada = 0;
        DataTable dtreservas;
        public event EventHandler ReservaGestionada;
        string colorverde = "#80ee0c";
        string colorrojo = "#ee430c";
        private readonly Timer disponibilidadTimer = new Timer();

        public reservas()
        {
            InitializeComponent();
            this.Load += reservas_Load;
            disponibilidadTimer.Interval = 300000; // Intervalo de 5 minutos en milisegundos
            disponibilidadTimer.Tick += (sender, e) => EjecutarDisponibilidad();

        }
        private void reservas_Load(object sender, EventArgs e)
        {
            RecargarDatosReservas();
            EjecutarDisponibilidad();
            disponibilidadTimer.Start();
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (cbx_horario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una  hora.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaSeleccionada = txt_fecha.Value.Date;//obtener solo la fecha
            if (txt_fecha.Checked == false)
            {
                MessageBox.Show("Por favor, seleccione una fecha .", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (canchaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione una cancha.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hora = cbx_horario.SelectedItem.ToString(); // ontener la hora y convertirla en froma  datetime          
            clsReserva objeto = new clsReserva();
            bool resultado = objeto.EliminarReserva(fechaSeleccionada, hora, canchaSeleccionada);
            if (resultado)
            {
                MessageBox.Show("Reserva eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReservaGestionada?.Invoke(this, EventArgs.Empty);
                EjecutarDisponibilidad();
            }


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
        private void btnvolver_Click(object sender, EventArgs e)
        {
            principal inicio = new principal();
            inicio.Show();
            this.Hide();
        }
        private void btn_reservar_Click(object sender, EventArgs e)
        {
            if (cbx_horario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una opción para la hora.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaSeleccionada = obtenerFechaideal();
            if (canchaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione una cancha.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hora = cbx_horario.SelectedItem.ToString(); // ontener la hora y convertirla en froma  datetime          
            validareserva objeto = new validareserva(fechaSeleccionada, hora, canchaSeleccionada);
            objeto.Show();
            this.Close();
        }
        private void RecargarDatosReservas()
        {
            try
            {
                clsReserva obj_reserva = new clsReserva();
                DataTable tabla = new DataTable();
                dtreservas = obj_reserva.ObtenerTablaReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EjecutarDisponibilidad()
        {
            DateTime fechaActual = obtenerFechaideal();
            string horaActual = obtenerHoraIdeal();
            List<PictureBox> numeroCanchas = new List<PictureBox> { cancha1, cancha2, cancha3, cancha4, cancha5 };
            VerificarReservasParaCanchas(fechaActual, horaActual, numeroCanchas);
            foreach (var cancha in numeroCanchas)
            {
                cancha.Refresh(); 
            }
        }
        public void VerificarReservasParaCanchas(DateTime fechaActual, string horaActual, List<PictureBox> canchas)
        {
            for (int i = 0; i < canchas.Count; i++)
            {
                int numeroCancha = i + 1;
                bool reservaExiste = ExisteReserva(numeroCancha, fechaActual, horaActual);

                if (reservaExiste)
                {
                    canchas[i].Paint += MostrarCanchaNoDisponible;
                }
                else
                {
                    canchas[i].Paint += MostrarCanchaDisponible;
                }
            }
        }
        public bool ExisteReserva(int numeroCancha, DateTime fecha, string horaInicio)
        {
            foreach (DataRow row in dtreservas.Rows)
            {
                int canchaEnTabla = Convert.ToInt32(row["Numero_Cancha"]);
                DateTime fechaEnTabla = Convert.ToDateTime(row["Fecha"]);
                string horaEnTabla = row["Hora_Inicio"].ToString();

                if (canchaEnTabla == numeroCancha && fechaEnTabla == fecha && horaEnTabla == horaInicio)
                {
                    return true;
                }
            }
            return false;
        }
        private void MostrarCanchaDisponible(object sender, PaintEventArgs e)
        {

            int borderSize = 8;
            Color borderColor = ColorTranslator.FromHtml(colorverde); ;

            using (Pen pen = new Pen(borderColor, borderSize))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, ((PictureBox)sender).Width - 1, ((PictureBox)sender).Height - 1));
            }
        }
        private void MostrarCanchaNoDisponible(object sender, PaintEventArgs e)
        {

            int borderSize = 8;
            Color borderColor = ColorTranslator.FromHtml(colorrojo); ;

            using (Pen pen = new Pen(borderColor, borderSize))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, ((PictureBox)sender).Width - 1, ((PictureBox)sender).Height - 1));
            }
        }     
        private string obtenerHoraIdeal()
        {
            if (cbx_horario.SelectedIndex == -1)
            {
                  DateTime ahora = DateTime.Now;
                 TimeSpan doceDelMediodia = new TimeSpan(12, 0, 0);

                 if (ahora.TimeOfDay < doceDelMediodia)
                 {
                    return "12:00";
                 }
                 else
                 {
                    return ahora.ToString("HH:00");
                 }
             }
             else { 
                        string hora = cbx_horario.SelectedItem.ToString();
                        return hora;
                  }
        }
        private DateTime obtenerFechaideal()
        {
            DateTime fechaSeleccionada = txt_fecha.Value.Date;//obtener solo la fecha
            if (txt_fecha.Checked == false)
            {
                fechaSeleccionada = DateTime.Now.Date;
            }
            return fechaSeleccionada;
        }
        private void txt_fecha_ValueChanged(object sender, EventArgs e)
        {
            EjecutarDisponibilidad();
        }
        private void cbx_horario_SelectedIndexChanged(object sender, EventArgs e)
        {
            EjecutarDisponibilidad();
        }
    }
}
