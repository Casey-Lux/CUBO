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
    public partial class informes : Form
    {
        DataTable dtcanchas;
        clsManager manager = new clsManager();
        string opcionseleccionada;
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

        private void RecargarDatoscanchas(string valor)
        {
            try
            {
                dtcanchas = manager.obtenerTablaDatos(valor);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDataGreatView(string valor)
        {
            RecargarDatoscanchas(valor);
            AgregarFilaDeTotales();
            dgv_empleado.DataSource = dtcanchas; // Enlazar los datos al DataGridView
        }
        private void AgregarFilaDeTotales()
        {
            if (opcionseleccionada == "canchas")
            {
                // Calcula las sumas
                decimal totalReservas = 0;
                decimal totalIngresos = 0;

                foreach (DataRow fila in dtcanchas.Rows)
                {
                    if (fila["reservas"] != DBNull.Value)
                        totalReservas += Convert.ToDecimal(fila["reservas"]);

                    if (fila["ingresos"] != DBNull.Value)
                        totalIngresos += Convert.ToDecimal(fila["ingresos"]);
                }
                // Crea una nueva fila con los totales
                DataRow filaTotales = dtcanchas.NewRow();                
                filaTotales["reservas"] = totalReservas;
                filaTotales["ingresos"] = totalIngresos;
                // Agrega la fila al DataTable
                dtcanchas.Rows.Add(filaTotales);
                
            }
        }

        private void cbxopciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                opcionseleccionada = cbxopciones.SelectedItem.ToString();
                CargarDataGreatView(opcionseleccionada);

            
        }
}
}
