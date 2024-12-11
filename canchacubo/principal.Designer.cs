namespace canchacubo
{
    partial class principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principal));
            this.btn_cliente = new System.Windows.Forms.Button();
            this.btn_promociones = new System.Windows.Forms.Button();
            this.btn_informe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_reserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cliente
            // 
            this.btn_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cliente.Location = new System.Drawing.Point(66, 341);
            this.btn_cliente.Name = "btn_cliente";
            this.btn_cliente.Size = new System.Drawing.Size(108, 45);
            this.btn_cliente.TabIndex = 1;
            this.btn_cliente.Text = "CLIENTE";
            this.btn_cliente.UseVisualStyleBackColor = true;
            this.btn_cliente.Click += new System.EventHandler(this.b_usuario_Click);
            // 
            // btn_promociones
            // 
            this.btn_promociones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_promociones.Location = new System.Drawing.Point(427, 341);
            this.btn_promociones.Name = "btn_promociones";
            this.btn_promociones.Size = new System.Drawing.Size(108, 45);
            this.btn_promociones.TabIndex = 4;
            this.btn_promociones.Text = "PROMO";
            this.btn_promociones.UseVisualStyleBackColor = true;
            this.btn_promociones.Click += new System.EventHandler(this.btn_promociones_Click);
            // 
            // btn_informe
            // 
            this.btn_informe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_informe.Location = new System.Drawing.Point(235, 341);
            this.btn_informe.Name = "btn_informe";
            this.btn_informe.Size = new System.Drawing.Size(134, 45);
            this.btn_informe.TabIndex = 5;
            this.btn_informe.Text = "INFORMES";
            this.btn_informe.UseVisualStyleBackColor = true;
            this.btn_informe.Click += new System.EventHandler(this.btn_informe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Canchas \"El Cubo\"";
            // 
            // btn_reserva
            // 
            this.btn_reserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reserva.Location = new System.Drawing.Point(582, 344);
            this.btn_reserva.Name = "btn_reserva";
            this.btn_reserva.Size = new System.Drawing.Size(105, 42);
            this.btn_reserva.TabIndex = 7;
            this.btn_reserva.Text = "RESERVA";
            this.btn_reserva.UseVisualStyleBackColor = true;
            this.btn_reserva.Click += new System.EventHandler(this.btn_reserva_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_reserva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_informe);
            this.Controls.Add(this.btn_promociones);
            this.Controls.Add(this.btn_cliente);
            this.Name = "principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cliente;
        private System.Windows.Forms.Button btn_promociones;
        private System.Windows.Forms.Button btn_informe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reserva;
    }
}

