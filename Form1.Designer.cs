namespace Practica_A_star
{
    partial class Form1
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
            this.lbRuta = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbObstaculos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDimenciones = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbOrigen = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDestino = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pTablero = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRuta
            // 
            this.lbRuta.FormattingEnabled = true;
            this.lbRuta.Location = new System.Drawing.Point(121, 145);
            this.lbRuta.Name = "lbRuta";
            this.lbRuta.Size = new System.Drawing.Size(87, 199);
            this.lbRuta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta Generada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Obstaculos";
            // 
            // lbObstaculos
            // 
            this.lbObstaculos.FormattingEnabled = true;
            this.lbObstaculos.Location = new System.Drawing.Point(13, 145);
            this.lbObstaculos.Name = "lbObstaculos";
            this.lbObstaculos.Size = new System.Drawing.Size(87, 199);
            this.lbObstaculos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dimenciones del tablero";
            // 
            // lbDimenciones
            // 
            this.lbDimenciones.FormattingEnabled = true;
            this.lbDimenciones.Location = new System.Drawing.Point(13, 26);
            this.lbDimenciones.Name = "lbDimenciones";
            this.lbDimenciones.Size = new System.Drawing.Size(87, 17);
            this.lbDimenciones.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Origen";
            // 
            // lbOrigen
            // 
            this.lbOrigen.FormattingEnabled = true;
            this.lbOrigen.Location = new System.Drawing.Point(13, 62);
            this.lbOrigen.Name = "lbOrigen";
            this.lbOrigen.Size = new System.Drawing.Size(87, 17);
            this.lbOrigen.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Destino";
            // 
            // lbDestino
            // 
            this.lbDestino.FormattingEnabled = true;
            this.lbDestino.Location = new System.Drawing.Point(13, 98);
            this.lbDestino.Name = "lbDestino";
            this.lbDestino.Size = new System.Drawing.Size(87, 17);
            this.lbDestino.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbDimenciones);
            this.panel1.Controls.Add(this.lbDestino);
            this.panel1.Controls.Add(this.lbRuta);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbObstaculos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 358);
            this.panel1.TabIndex = 10;
            // 
            // pTablero
            // 
            this.pTablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTablero.Location = new System.Drawing.Point(244, 13);
            this.pTablero.Name = "pTablero";
            this.pTablero.Size = new System.Drawing.Size(384, 357);
            this.pTablero.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(640, 382);
            this.Controls.Add(this.pTablero);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbObstaculos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbDimenciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbOrigen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbDestino;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pTablero;
    }
}

