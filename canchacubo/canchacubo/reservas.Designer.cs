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
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_reservar = new System.Windows.Forms.Button();
            this.btnvolver = new System.Windows.Forms.Button();
            this.cancha1 = new System.Windows.Forms.DataGridView();
            this.cancha2 = new System.Windows.Forms.DataGridView();
            this.cancha3 = new System.Windows.Forms.DataGridView();
            this.cancha4 = new System.Windows.Forms.DataGridView();
            this.cancha5 = new System.Windows.Forms.DataGridView();
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
            this.label1.Location = new System.Drawing.Point(374, 33);
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
            this.cbx_horario.Location = new System.Drawing.Point(144, 94);
            this.cbx_horario.Name = "cbx_horario";
            this.cbx_horario.Size = new System.Drawing.Size(100, 21);
            this.cbx_horario.TabIndex = 1;
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(392, 93);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(108, 20);
            this.txt_fecha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 96);
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
            // btn_reservar
            // 
            this.btn_reservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reservar.Location = new System.Drawing.Point(334, 371);
            this.btn_reservar.Name = "btn_reservar";
            this.btn_reservar.Size = new System.Drawing.Size(100, 42);
            this.btn_reservar.TabIndex = 6;
            this.btn_reservar.Text = "Reservar";
            this.btn_reservar.UseVisualStyleBackColor = true;
            this.btn_reservar.Click += new System.EventHandler(this.button2_Click);
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
            this.cancha1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancha1.Location = new System.Drawing.Point(68, 174);
            this.cancha1.Name = "cancha1";
            this.cancha1.Size = new System.Drawing.Size(80, 143);
            this.cancha1.TabIndex = 14;
            // 
            // cancha2
            // 
            this.cancha2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancha2.Location = new System.Drawing.Point(209, 174);
            this.cancha2.Name = "cancha2";
            this.cancha2.Size = new System.Drawing.Size(80, 143);
            this.cancha2.TabIndex = 15;
            // 
            // cancha3
            // 
            this.cancha3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancha3.Location = new System.Drawing.Point(354, 174);
            this.cancha3.Name = "cancha3";
            this.cancha3.Size = new System.Drawing.Size(80, 143);
            this.cancha3.TabIndex = 16;
            this.cancha3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // cancha4
            // 
            this.cancha4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancha4.Location = new System.Drawing.Point(489, 174);
            this.cancha4.Name = "cancha4";
            this.cancha4.Size = new System.Drawing.Size(80, 143);
            this.cancha4.TabIndex = 17;
            // 
            // cancha5
            // 
            this.cancha5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancha5.Location = new System.Drawing.Point(650, 174);
            this.cancha5.Name = "cancha5";
            this.cancha5.Size = new System.Drawing.Size(80, 143);
            this.cancha5.TabIndex = 18;
            // 
            // reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::canchacubo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancha5);
            this.Controls.Add(this.cancha4);
            this.Controls.Add(this.cancha3);
            this.Controls.Add(this.cancha2);
            this.Controls.Add(this.cancha1);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.btn_reservar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_fecha);
            this.Controls.Add(this.cbx_horario);
            this.Controls.Add(this.label1);
            this.Name = "reservas";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
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
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_reservar;
        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.DataGridView cancha1;
        private System.Windows.Forms.DataGridView cancha2;
        private System.Windows.Forms.DataGridView cancha3;
        private System.Windows.Forms.DataGridView cancha4;
        private System.Windows.Forms.DataGridView cancha5;
    }
}