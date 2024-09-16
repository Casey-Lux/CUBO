namespace canchacubo
{
    partial class cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.btn_eliminarcliente = new System.Windows.Forms.Button();
            this.btn_editarcliente = new System.Windows.Forms.Button();
            this.btn_consultarcliente = new System.Windows.Forms.Button();
            this.btn_crearcliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(508, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(8, 8);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(642, 265);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(107, 43);
            this.btn_volver.TabIndex = 5;
            this.btn_volver.Text = "VOLVER";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // btn_eliminarcliente
            // 
            this.btn_eliminarcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminarcliente.Location = new System.Drawing.Point(101, 301);
            this.btn_eliminarcliente.Name = "btn_eliminarcliente";
            this.btn_eliminarcliente.Size = new System.Drawing.Size(107, 43);
            this.btn_eliminarcliente.TabIndex = 6;
            this.btn_eliminarcliente.Text = "Eliminar";
            this.btn_eliminarcliente.UseVisualStyleBackColor = true;
            this.btn_eliminarcliente.Click += new System.EventHandler(this.btn_eliminarcliente_Click);
            // 
            // btn_editarcliente
            // 
            this.btn_editarcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editarcliente.Location = new System.Drawing.Point(101, 224);
            this.btn_editarcliente.Name = "btn_editarcliente";
            this.btn_editarcliente.Size = new System.Drawing.Size(107, 43);
            this.btn_editarcliente.TabIndex = 7;
            this.btn_editarcliente.Text = "Editar";
            this.btn_editarcliente.UseVisualStyleBackColor = true;
            this.btn_editarcliente.Click += new System.EventHandler(this.btn_editarcliente_Click);
            // 
            // btn_consultarcliente
            // 
            this.btn_consultarcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultarcliente.Location = new System.Drawing.Point(101, 165);
            this.btn_consultarcliente.Name = "btn_consultarcliente";
            this.btn_consultarcliente.Size = new System.Drawing.Size(107, 43);
            this.btn_consultarcliente.TabIndex = 8;
            this.btn_consultarcliente.Text = "Consultar";
            this.btn_consultarcliente.UseVisualStyleBackColor = true;
            this.btn_consultarcliente.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_crearcliente
            // 
            this.btn_crearcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crearcliente.Location = new System.Drawing.Point(101, 98);
            this.btn_crearcliente.Name = "btn_crearcliente";
            this.btn_crearcliente.Size = new System.Drawing.Size(107, 43);
            this.btn_crearcliente.TabIndex = 9;
            this.btn_crearcliente.Text = "Crear";
            this.btn_crearcliente.UseVisualStyleBackColor = true;
            this.btn_crearcliente.Click += new System.EventHandler(this.btn_crearcliente_Click);
            // 
            // cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::canchacubo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_crearcliente);
            this.Controls.Add(this.btn_consultarcliente);
            this.Controls.Add(this.btn_editarcliente);
            this.Controls.Add(this.btn_eliminarcliente);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Name = "cliente";
            this.Text = "cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Button btn_eliminarcliente;
        private System.Windows.Forms.Button btn_editarcliente;
        private System.Windows.Forms.Button btn_consultarcliente;
        private System.Windows.Forms.Button btn_crearcliente;
    }
}