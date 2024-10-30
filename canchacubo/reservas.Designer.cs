namespace canchacubo
{
    partial class reservas
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
            this.cbx_horario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btnvolver = new System.Windows.Forms.Button();
            this.cancha1 = new System.Windows.Forms.PictureBox();
            this.cancha2 = new System.Windows.Forms.PictureBox();
            this.cancha3 = new System.Windows.Forms.PictureBox();
            this.cancha4 = new System.Windows.Forms.PictureBox();
            this.cancha5 = new System.Windows.Forms.PictureBox();
            this.btn_reservar = new System.Windows.Forms.Button();
            this.txt_fecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.cancha1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservas";
            // 
            // cbx_horario
            // 
            this.cbx_horario.AutoCompleteCustomSource.AddRange(new string[] {
            "Ninguno",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cbx_horario.FormattingEnabled = true;
            this.cbx_horario.Items.AddRange(new object[] {
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00"});
            this.cbx_horario.Location = new System.Drawing.Point(153, 90);
            this.cbx_horario.Name = "cbx_horario";
            this.cbx_horario.Size = new System.Drawing.Size(100, 21);
            this.cbx_horario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Location = new System.Drawing.Point(96, 371);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(131, 42);
            this.btn_eliminar.TabIndex = 5;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btnvolver
            // 
            this.btnvolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvolver.Location = new System.Drawing.Point(650, 371);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(112, 33);
            this.btnvolver.TabIndex = 13;
            this.btnvolver.Text = "VOLVER";
            this.btnvolver.UseVisualStyleBackColor = true;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // cancha1
            // 
            this.cancha1.BackgroundImage = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha1.Image = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha1.Location = new System.Drawing.Point(114, 183);
            this.cancha1.Name = "cancha1";
            this.cancha1.Size = new System.Drawing.Size(96, 125);
            this.cancha1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancha1.TabIndex = 19;
            this.cancha1.TabStop = false;
            this.cancha1.Click += new System.EventHandler(this.cancha1_Click);
            // 
            // cancha2
            // 
            this.cancha2.BackgroundImage = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha2.Image = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha2.Location = new System.Drawing.Point(237, 183);
            this.cancha2.Name = "cancha2";
            this.cancha2.Size = new System.Drawing.Size(96, 125);
            this.cancha2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancha2.TabIndex = 20;
            this.cancha2.TabStop = false;
            this.cancha2.Click += new System.EventHandler(this.cancha2_Click);
            // 
            // cancha3
            // 
            this.cancha3.BackgroundImage = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha3.Image = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha3.Location = new System.Drawing.Point(366, 183);
            this.cancha3.Name = "cancha3";
            this.cancha3.Size = new System.Drawing.Size(96, 125);
            this.cancha3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancha3.TabIndex = 21;
            this.cancha3.TabStop = false;
            this.cancha3.Click += new System.EventHandler(this.cancha3_Click);
            // 
            // cancha4
            // 
            this.cancha4.BackgroundImage = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha4.Image = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha4.Location = new System.Drawing.Point(479, 183);
            this.cancha4.Name = "cancha4";
            this.cancha4.Size = new System.Drawing.Size(96, 125);
            this.cancha4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancha4.TabIndex = 22;
            this.cancha4.TabStop = false;
            this.cancha4.Click += new System.EventHandler(this.cancha4_Click);
            // 
            // cancha5
            // 
            this.cancha5.BackgroundImage = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha5.Image = global::canchacubo.Properties.Resources.fondocancha;
            this.cancha5.Location = new System.Drawing.Point(608, 183);
            this.cancha5.Name = "cancha5";
            this.cancha5.Size = new System.Drawing.Size(96, 125);
            this.cancha5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancha5.TabIndex = 23;
            this.cancha5.TabStop = false;
            this.cancha5.Click += new System.EventHandler(this.cancha5_Click);
            // 
            // btn_reservar
            // 
            this.btn_reservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reservar.Location = new System.Drawing.Point(369, 362);
            this.btn_reservar.Name = "btn_reservar";
            this.btn_reservar.Size = new System.Drawing.Size(131, 42);
            this.btn_reservar.TabIndex = 24;
            this.btn_reservar.Text = "Reservar";
            this.btn_reservar.UseVisualStyleBackColor = true;
            this.btn_reservar.Click += new System.EventHandler(this.btn_reservar_Click);
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(366, 90);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(200, 20);
            this.txt_fecha.TabIndex = 26;
            // 
            // reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::canchacubo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_fecha);
            this.Controls.Add(this.btn_reservar);
            this.Controls.Add(this.cancha5);
            this.Controls.Add(this.cancha4);
            this.Controls.Add(this.cancha3);
            this.Controls.Add(this.cancha2);
            this.Controls.Add(this.cancha1);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_horario);
            this.Controls.Add(this.label1);
            this.Name = "reservas";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.cancha1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancha5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_horario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.PictureBox cancha1;
        private System.Windows.Forms.PictureBox cancha2;
        private System.Windows.Forms.PictureBox cancha3;
        private System.Windows.Forms.PictureBox cancha4;
        private System.Windows.Forms.PictureBox cancha5;
        private System.Windows.Forms.Button btn_reservar;
        private System.Windows.Forms.DateTimePicker txt_fecha;
    }
}