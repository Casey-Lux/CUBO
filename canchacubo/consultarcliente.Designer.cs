namespace canchacubo
{
    partial class consultarcliente
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
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.btn_cliente = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consultar Cliente";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(325, 168);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(329, 22);
            this.txtIdentificacion.TabIndex = 2;
            this.txtIdentificacion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_cliente
            // 
            this.btn_cliente.Location = new System.Drawing.Point(716, 168);
            this.btn_cliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cliente.Name = "btn_cliente";
            this.btn_cliente.Size = new System.Drawing.Size(100, 28);
            this.btn_cliente.TabIndex = 3;
            this.btn_cliente.Text = "ENTER";
            this.btn_cliente.UseVisualStyleBackColor = true;
            this.btn_cliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(960, 458);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(100, 28);
            this.btn_volver.TabIndex = 4;
            this.btn_volver.Text = "VOLVER";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Identificacion";
            // 
            // consultarcliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::canchacubo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.btn_cliente);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "consultarcliente";
            this.Text = "consultarcliente";
            this.Load += new System.EventHandler(this.consultarcliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Button btn_cliente;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Label label2;
    }
}