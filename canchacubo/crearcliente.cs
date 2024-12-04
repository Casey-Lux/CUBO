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
    public partial class crearcliente : Form
    {
        public event EventHandler ClienteRegistrado;
        public crearcliente()
        {
           InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        { 
            this.Close();
        }       

        private void btn_crearcliente_Click(object sender, EventArgs e)
        {
            String nombre = txtt_nombre.Text;
            string telefono = txt_telefono.Text;
            String identificacion = txt_identificacion.Text;         
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
             string.IsNullOrEmpty(identificacion))
            {
                
                MessageBox.Show("Debe diligenciar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            clsCliente cliente_obj = new clsCliente();
            bool resultado = cliente_obj.InsertarCliente(identificacion, nombre, telefono, "1");

            if (resultado)
            {
                // Si el registro fue exitoso, disparamos el evento ClienteRegistrado
                MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                ClienteRegistrado?.Invoke(this, EventArgs.Empty); // Dispara el evento si no es null
               this.Close();
            }

        }
      
    }
}
 