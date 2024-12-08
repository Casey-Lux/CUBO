namespace canchacubo
{
    partial class editarpromocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editarpromocion));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.dtp_fechafin = new System.Windows.Forms.DateTimePicker();
            this.dtp_fechainicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_descuento = new System.Windows.Forms.TextBox();
            this.cbx_promociones = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_estado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Editar Promoción";
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(664, 363);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(107, 33);
            this.btn_volver.TabIndex = 5;
            this.btn_volver.Text = "VOLVER";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(157, 359);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(91, 37);
            this.btn_editar.TabIndex = 26;
            this.btn_editar.Text = "EDITAR";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // dtp_fechafin
            // 
            this.dtp_fechafin.Location = new System.Drawing.Point(94, 313);
            this.dtp_fechafin.Name = "dtp_fechafin";
            this.dtp_fechafin.Size = new System.Drawing.Size(200, 20);
            this.dtp_fechafin.TabIndex = 25;
            // 
            // dtp_fechainicio
            // 
            this.dtp_fechainicio.Location = new System.Drawing.Point(94, 260);
            this.dtp_fechainicio.Name = "dtp_fechainicio";
            this.dtp_fechainicio.Size = new System.Drawing.Size(200, 20);
            this.dtp_fechainicio.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(329, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fecha inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Descuento";
            // 
            // txt_descuento
            // 
            this.txt_descuento.Location = new System.Drawing.Point(94, 146);
            this.txt_descuento.MaxLength = 10;
            this.txt_descuento.Name = "txt_descuento";
            this.txt_descuento.Size = new System.Drawing.Size(131, 20);
            this.txt_descuento.TabIndex = 18;
            // 
            // cbx_promociones
            // 
            this.cbx_promociones.FormattingEnabled = true;
            this.cbx_promociones.Location = new System.Drawing.Point(94, 99);
            this.cbx_promociones.MaxLength = 10;
            this.cbx_promociones.Name = "cbx_promociones";
            this.cbx_promociones.Size = new System.Drawing.Size(138, 21);
            this.cbx_promociones.TabIndex = 29;
            this.cbx_promociones.SelectedIndexChanged += new System.EventHandler(this.cbx_promociones_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(267, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Selecciona una promoción";
            // 
            // cbx_estado
            // 
            this.cbx_estado.FormattingEnabled = true;
            this.cbx_estado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbx_estado.Location = new System.Drawing.Point(87, 206);
            this.cbx_estado.MaxLength = 10;
            this.cbx_estado.Name = "cbx_estado";
            this.cbx_estado.Size = new System.Drawing.Size(138, 21);
            this.cbx_estado.TabIndex = 30;
            // 
            // editarpromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbx_estado);
            this.Controls.Add(this.cbx_promociones);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.dtp_fechafin);
            this.Controls.Add(this.dtp_fechainicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_descuento);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.label1);
            this.Name = "editarpromocion";
            this.Text = "editarpromocion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.DateTimePicker dtp_fechafin;
        private System.Windows.Forms.DateTimePicker dtp_fechainicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_descuento;
        private System.Windows.Forms.ComboBox cbx_promociones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_estado;
    }
}