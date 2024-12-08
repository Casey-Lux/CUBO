namespace canchacubo
{
    partial class editarcliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editarcliente));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.btn_crearcliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.txtt_nombre = new System.Windows.Forms.TextBox();
            this.btn_editar = new System.Windows.Forms.Button();
            this.cbxclientes = new System.Windows.Forms.ComboBox();
            this.cbx_estado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Editar Cliente";
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(648, 356);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(99, 33);
            this.btn_volver.TabIndex = 5;
            this.btn_volver.Text = "VOLVER";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // btn_crearcliente
            // 
            this.btn_crearcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crearcliente.Location = new System.Drawing.Point(132, 356);
            this.btn_crearcliente.Name = "btn_crearcliente";
            this.btn_crearcliente.Size = new System.Drawing.Size(96, 32);
            this.btn_crearcliente.TabIndex = 23;
            this.btn_crearcliente.Text = "EDITAR";
            this.btn_crearcliente.UseVisualStyleBackColor = true;
            this.btn_crearcliente.Click += new System.EventHandler(this.btn_crearcliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(324, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(324, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Teléfono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Identificación";
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(132, 213);
            this.txt_telefono.MaxLength = 10;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(138, 20);
            this.txt_telefono.TabIndex = 17;
            // 
            // txtt_nombre
            // 
            this.txtt_nombre.Location = new System.Drawing.Point(132, 166);
            this.txtt_nombre.MaxLength = 20;
            this.txtt_nombre.Name = "txtt_nombre";
            this.txtt_nombre.Size = new System.Drawing.Size(138, 20);
            this.txtt_nombre.TabIndex = 16;
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(450, 106);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(127, 28);
            this.btn_editar.TabIndex = 24;
            this.btn_editar.Text = "CONSULTAR";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // cbxclientes
            // 
            this.cbxclientes.FormattingEnabled = true;
            this.cbxclientes.Location = new System.Drawing.Point(132, 111);
            this.cbxclientes.MaxLength = 10;
            this.cbxclientes.Name = "cbxclientes";
            this.cbxclientes.Size = new System.Drawing.Size(138, 21);
            this.cbxclientes.TabIndex = 25;
            this.cbxclientes.SelectedIndexChanged += new System.EventHandler(this.cbxclientes_SelectedIndexChanged);
            this.cbxclientes.TextChanged += new System.EventHandler(this.cbxclientes_TextChanged);
            // 
            // cbx_estado
            // 
            this.cbx_estado.FormattingEnabled = true;
            this.cbx_estado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbx_estado.Location = new System.Drawing.Point(132, 278);
            this.cbx_estado.MaxLength = 10;
            this.cbx_estado.Name = "cbx_estado";
            this.cbx_estado.Size = new System.Drawing.Size(138, 21);
            this.cbx_estado.TabIndex = 27;
            // 
            // editarcliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbx_estado);
            this.Controls.Add(this.cbxclientes);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_crearcliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txtt_nombre);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.label1);
            this.Name = "editarcliente";
            this.Text = "editarcliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Button btn_crearcliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.TextBox txtt_nombre;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.ComboBox cbxclientes;
        private System.Windows.Forms.ComboBox cbx_estado;
    }
}