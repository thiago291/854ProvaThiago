namespace Calculadoras
{
    partial class FormIMC
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAlt = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblCM = new System.Windows.Forms.Label();
            this.lblKG = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(110, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(264, 27);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Calculadora de IMC";
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.Location = new System.Drawing.Point(16, 385);
            this.lblAlt.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(110, 27);
            this.lblAlt.TabIndex = 3;
            this.lblAlt.Text = "Altura:";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(16, 436);
            this.lblPeso.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(82, 27);
            this.lblPeso.TabIndex = 4;
            this.lblPeso.Text = "Peso:";
            // 
            // lblResultado
            // 
            this.lblResultado.Location = new System.Drawing.Point(16, 544);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(452, 58);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblResultado.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Calculadoras.Properties.Resources._104620701_prmo_imc_br_nc;
            this.pictureBox1.Location = new System.Drawing.Point(16, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(162, 486);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(160, 40);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(16, 486);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(110, 40);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblCM
            // 
            this.lblCM.AutoSize = true;
            this.lblCM.Location = new System.Drawing.Point(428, 385);
            this.lblCM.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblCM.Name = "lblCM";
            this.lblCM.Size = new System.Drawing.Size(40, 27);
            this.lblCM.TabIndex = 12;
            this.lblCM.Text = "cm";
            // 
            // lblKG
            // 
            this.lblKG.AutoSize = true;
            this.lblKG.Location = new System.Drawing.Point(428, 436);
            this.lblKG.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblKG.Name = "lblKG";
            this.lblKG.Size = new System.Drawing.Size(40, 27);
            this.lblKG.TabIndex = 13;
            this.lblKG.Text = "kg";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(163, 433);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(243, 35);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(163, 382);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(243, 35);
            this.txtAltura.TabIndex = 0;
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(358, 486);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(110, 40);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormIMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 611);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.lblKG);
            this.Controls.Add(this.lblCM);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblAlt);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCalcular);
            this.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MaximizeBox = false;
            this.Name = "FormIMC";
            this.Text = "Calculadora de IMC";
            this.Load += new System.EventHandler(this.FormIMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblTitulo;
        private Label lblAlt;
        private Label lblPeso;
        private Label lblResultado;
        private PictureBox pictureBox1;
        private Button btnCalcular;
        private Button btnLimpar;
        private Label lblCM;
        private Label lblKG;
        private TextBox txtPeso;
        private TextBox txtAltura;
        private Button btnVoltar;
    }
}