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
    public partial class validareserva : Form
    {

        DateTime fecha;
        string hora;
        int cancha;
        clsPromocion promo = new clsPromocion();
        clsReserva reserva = new clsReserva();
        clsManager manager = new clsManager();
        DataTable dtpromociones;
        Decimal idpromo = 0;
        Decimal descuentoSeleccionado = 0;
        clsCliente cliente_obj = new clsCliente();
        DataTable dtclientes = new DataTable();
        string identificacion;
        public validareserva(DateTime fecha, string hora, int cancha)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.cancha = cancha;
            InitializeComponent();
            CargarPromocionesEnComboBox();
            CargarClientesEnComboBox();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            reservas reserva = new reservas();
            reserva.Show();
            reserva.EjecutarDisponibilidad();
            this.Close();
        }
        private void registrar_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(cbxclientes.Text))
            {
                MessageBox.Show("Por favor rellene los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool resultado = reserva.Registrar_Reserva(fecha, hora, identificacion, cancha, idpromo);
            if (resultado)
            {
                decimal costo = manager.ObtenerCostoCancha(cancha);
                costo = costo - costo * descuentoSeleccionado / 100;
                MessageBox.Show("Reserva exitosa.  El valor a pagar es: $" + costo.ToString("N2"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RecargarDatosPromocion()
        {
            try
            {
                dtpromociones = promo.ObtenerTablapPromocionesactivas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPromocionesEnComboBox()

        {

            cbx_promociones.Items.Clear();

            cbx_promociones.DropDownStyle = ComboBoxStyle.DropDownList;  // Deshabilita la edición


            RecargarDatosPromocion();  // Cargar los datos en dtpromociones


            // Verificar si la columna "InformacionPromo" ya existe para evitar errores

            if (!dtpromociones.Columns.Contains("InformacionPromo"))

            {

                dtpromociones.Columns.Add("InformacionPromo", typeof(string));

            }


            // Formatear cada fila existente con el formato deseado para mostrar en el ComboBox

            foreach (DataRow row in dtpromociones.Rows)

            {
                       string idepromocion = row["identificador"].ToString();

                        string descuento = row["descuento"].ToString();

                        string informacionPromo = $"Promocion: {idepromocion} -- {descuento} %";

                        row["InformacionPromo"] = informacionPromo;

            }


            // Crear una fila para la opción "Ninguno" y agregarla como la primera fila

            DataRow rowNinguno = dtpromociones.NewRow();

            rowNinguno["identificador"] = DBNull.Value;  // Valor de identificador vacío

            rowNinguno["descuento"] = DBNull.Value;      // Valor de descuento vacío

            rowNinguno["InformacionPromo"] = "Ninguno";

            dtpromociones.Rows.InsertAt(rowNinguno, 0);


            // Asignar la DataSource y definir DisplayMember y ValueMember

            cbx_promociones.DataSource = dtpromociones;

            cbx_promociones.DisplayMember = "InformacionPromo";

            cbx_promociones.ValueMember = "identificador";  // Permite obtener el ID de la promoción seleccionada

        }

        private void cbx_promociones_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Verifica que haya una selección válida
                if (cbx_promociones.SelectedItem is DataRowView selectedRow)
                {
                    // Verifica si la opción seleccionada es "Ninguno"
                    if (selectedRow["InformacionPromo"].ToString() == "Ninguno")
                    {
                        descuentoSeleccionado = 0;
                    }
                    else
                    {
                        string idpromocion = selectedRow["identificador"].ToString();
                        // Intenta convertir el descuento a decima
                        if (decimal.TryParse(idpromocion, out decimal ide))
                        {
                            idpromo = ide;
                        }
                        // Obtiene el valor del descuento de la fila seleccionada
                        string descuentoStr = selectedRow["descuento"].ToString();

                        // Intenta convertir el descuento a decima
                        if (decimal.TryParse(descuentoStr, out decimal descuento))
                        {
                            descuentoSeleccionado = descuento;
                        }
                        else
                        {
                            descuentoSeleccionado = 0;
                        }
                    }
                }

            }
        private void CargarClientesEnComboBox()
        {

            RecargarDatosClientes();  // Cargar los datos en dtpromociones

            // Verificar si la columna "InformacionPromo" ya existe para evitar errores
            if (!dtclientes.Columns.Contains("Informacion"))
            {
                dtclientes.Columns.Add("Informacion", typeof(string));
            }

            // Formatear cada fila existente con el formato deseado para mostrar en el ComboBox
            foreach (DataRow row in dtclientes.Rows)
            {
                string cedula = row["identificacion"].ToString();
                string informacionPromo = $"cedula: {cedula} ";
                row["Informacion"] = informacionPromo;
            }

            // Crear una fila para la opción "Ninguno" y agregarla como la primera fila

            // Asignar la DataSource y definir DisplayMember y ValueMember
            cbxclientes.DataSource = dtclientes;
            cbxclientes.DisplayMember = "Informacion";
            cbxclientes.ValueMember = "identificacion";  // Permite obtener el ID de la promoción seleccionada
        }
        private void RecargarDatosClientes()
        {
            try
            {
                clsCliente obj_cliente = new clsCliente();
                DataTable tabla = new DataTable();
                dtclientes = obj_cliente.obtenerTablaClientesactivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que haya una selección válida
            if (cbxclientes.SelectedItem is DataRowView selectedRow)
            {
                identificacion = selectedRow["identificacion"].ToString();
            }
            else
            {
                // Si no hay selección, usa el texto ingresado
                identificacion = cbxclientes.Text;
            }
        }
        private void cbxclientes_TextChanged(object sender, EventArgs e)
        {
            // Actualiza la identificación con el texto escrito
            identificacion = cbxclientes.Text;
        }
    }
}
    
