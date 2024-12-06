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
            cbxopciones.DropDownStyle = ComboBoxStyle.DropDownList;  // Deshabilita la edición
            ajustartabla();

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
                ConvertirColumnaAString();
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
                filaTotales["precio"] = "Total";

                // Agrega la fila al DataTable
                dtcanchas.Rows.Add(filaTotales);
                
            }
        }
        private void ConvertirColumnaAString()
        {
            // Clona la estructura del DataTable original
            DataTable nuevoDataTable = dtcanchas.Clone();

            // Cambia el tipo de la columna deseada a string
            nuevoDataTable.Columns["precio"].DataType = typeof(string);
            
            // Copia los datos al nuevo DataTable
            foreach (DataRow fila in dtcanchas.Rows)
            {
                nuevoDataTable.ImportRow(fila);
            }

            // Asigna el nuevo DataTable al original
            dtcanchas = nuevoDataTable;

        }

        private void cbxopciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                opcionseleccionada = cbxopciones.SelectedItem.ToString();
                CargarDataGreatView(opcionseleccionada);

            
        }
        private void ajustartabla()
        {
            // Ajustar el ancho de columnas automáticamente según el contenido
            dgv_empleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Alternar colores para filas
            dgv_empleado.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar color de fondo
            dgv_empleado.BackgroundColor = Color.White;

            // Personalizar el encabezado de columna
            dgv_empleado.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv_empleado.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv_empleado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Personalizar bordes y celdas
            dgv_empleado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_empleado.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgv_empleado.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alinear texto en celdas
            dgv_empleado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Deshabilitar edición directa (opcional)
            dgv_empleado.ReadOnly = true;

        }
    }
}
