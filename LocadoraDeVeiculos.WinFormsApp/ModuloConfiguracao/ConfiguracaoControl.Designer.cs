namespace LocadoraDeVeiculos.WinFormsApp.ModuloConfiguracao
{
    partial class ConfiguracaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlGasolina = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.labelValor = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.txtDiretorioLogs = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labelDiretorio = new System.Windows.Forms.Label();
            this.tabControlGasolina.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGasolina
            // 
            this.tabControlGasolina.Controls.Add(this.tabPage1);
            this.tabControlGasolina.Controls.Add(this.tabPage2);
            this.tabControlGasolina.Location = new System.Drawing.Point(3, 3);
            this.tabControlGasolina.Name = "tabControlGasolina";
            this.tabControlGasolina.SelectedIndex = 0;
            this.tabControlGasolina.Size = new System.Drawing.Size(655, 277);
            this.tabControlGasolina.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbUrl);
            this.tabPage1.Controls.Add(this.txtDiretorioLogs);
            this.tabPage1.Controls.Add(this.labelUrl);
            this.tabPage1.Controls.Add(this.labelDiretorio);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(647, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numValor);
            this.tabPage2.Controls.Add(this.labelValor);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gasolina";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numValor
            // 
            this.numValor.DecimalPlaces = 2;
            this.numValor.Location = new System.Drawing.Point(149, 21);
            this.numValor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(137, 27);
            this.numValor.TabIndex = 13;
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(15, 24);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(128, 20);
            this.labelValor.TabIndex = 12;
            this.labelValor.Text = "Valor da Gasolina:";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(402, 286);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(116, 50);
            this.btnGravar.TabIndex = 1;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(524, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 50);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(139, 51);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(259, 27);
            this.tbUrl.TabIndex = 7;
            // 
            // txtDiretorioLogs
            // 
            this.txtDiretorioLogs.Location = new System.Drawing.Point(139, 8);
            this.txtDiretorioLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiretorioLogs.Name = "txtDiretorioLogs";
            this.txtDiretorioLogs.Size = new System.Drawing.Size(259, 27);
            this.txtDiretorioLogs.TabIndex = 5;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(40, 54);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(93, 20);
            this.labelUrl.TabIndex = 6;
            this.labelUrl.Text = "URL do Log: ";
            // 
            // labelDiretorio
            // 
            this.labelDiretorio.AutoSize = true;
            this.labelDiretorio.Location = new System.Drawing.Point(10, 11);
            this.labelDiretorio.Name = "labelDiretorio";
            this.labelDiretorio.Size = new System.Drawing.Size(123, 20);
            this.labelDiretorio.TabIndex = 4;
            this.labelDiretorio.Text = "Diretório do Log:";
            // 
            // ConfiguracaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tabControlGasolina);
            this.Name = "ConfiguracaoControl";
            this.Size = new System.Drawing.Size(658, 350);
            this.tabControlGasolina.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControlGasolina;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private NumericUpDown numValor;
        private Label labelValor;
        private Button btnGravar;
        private Button btnCancelar;
        private TextBox tbUrl;
        private TextBox txtDiretorioLogs;
        private Label labelUrl;
        private Label labelDiretorio;
    }
}
