namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    partial class TelaCadastroPlanoDeCobranca
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
            this.lGrupo = new System.Windows.Forms.Label();
            this.lTipoPlano = new System.Windows.Forms.Label();
            this.lValor = new System.Windows.Forms.Label();
            this.lKmIncluso = new System.Windows.Forms.Label();
            this.lPrecoKm = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.cbTipoPlano = new System.Windows.Forms.ComboBox();
            this.tbValorDiaria = new System.Windows.Forms.TextBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.lNumero = new System.Windows.Forms.Label();
            this.tbKmIncluso = new System.Windows.Forms.TextBox();
            this.tbPrecoKm = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lGrupo
            // 
            this.lGrupo.AutoSize = true;
            this.lGrupo.Location = new System.Drawing.Point(12, 68);
            this.lGrupo.Name = "lGrupo";
            this.lGrupo.Size = new System.Drawing.Size(132, 20);
            this.lGrupo.TabIndex = 0;
            this.lGrupo.Text = "Grupo de Veículos:";
            // 
            // lTipoPlano
            // 
            this.lTipoPlano.AutoSize = true;
            this.lTipoPlano.Location = new System.Drawing.Point(40, 117);
            this.lTipoPlano.Name = "lTipoPlano";
            this.lTipoPlano.Size = new System.Drawing.Size(104, 20);
            this.lTipoPlano.TabIndex = 1;
            this.lTipoPlano.Text = "Tipo de Plano:";
            // 
            // lValor
            // 
            this.lValor.AutoSize = true;
            this.lValor.Location = new System.Drawing.Point(33, 165);
            this.lValor.Name = "lValor";
            this.lValor.Size = new System.Drawing.Size(111, 20);
            this.lValor.TabIndex = 2;
            this.lValor.Text = "Valor da Diária:";
            // 
            // lKmIncluso
            // 
            this.lKmIncluso.AutoSize = true;
            this.lKmIncluso.Location = new System.Drawing.Point(60, 214);
            this.lKmIncluso.Name = "lKmIncluso";
            this.lKmIncluso.Size = new System.Drawing.Size(84, 20);
            this.lKmIncluso.TabIndex = 3;
            this.lKmIncluso.Text = "KM Incluso:";
            // 
            // lPrecoKm
            // 
            this.lPrecoKm.AutoSize = true;
            this.lPrecoKm.Location = new System.Drawing.Point(42, 266);
            this.lPrecoKm.Name = "lPrecoKm";
            this.lPrecoKm.Size = new System.Drawing.Size(102, 20);
            this.lPrecoKm.TabIndex = 4;
            this.lPrecoKm.Text = "Preço por KM:";
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(150, 64);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(279, 28);
            this.cbGrupo.TabIndex = 5;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // cbTipoPlano
            // 
            this.cbTipoPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPlano.FormattingEnabled = true;
            this.cbTipoPlano.Items.AddRange(new object[] {
            "Plano Diário",
            "KM Controlado",
            "KM Livre"});
            this.cbTipoPlano.Location = new System.Drawing.Point(150, 113);
            this.cbTipoPlano.Name = "cbTipoPlano";
            this.cbTipoPlano.Size = new System.Drawing.Size(279, 28);
            this.cbTipoPlano.TabIndex = 6;
            this.cbTipoPlano.SelectedIndexChanged += new System.EventHandler(this.cbTipoPlano_SelectedIndexChanged);
            // 
            // tbValorDiaria
            // 
            this.tbValorDiaria.Location = new System.Drawing.Point(150, 162);
            this.tbValorDiaria.Name = "tbValorDiaria";
            this.tbValorDiaria.Size = new System.Drawing.Size(279, 27);
            this.tbValorDiaria.TabIndex = 7;
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(150, 15);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(75, 27);
            this.tbNumero.TabIndex = 9;
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(78, 18);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(66, 20);
            this.lNumero.TabIndex = 8;
            this.lNumero.Text = "Número:";
            // 
            // tbKmIncluso
            // 
            this.tbKmIncluso.Location = new System.Drawing.Point(150, 211);
            this.tbKmIncluso.Name = "tbKmIncluso";
            this.tbKmIncluso.Size = new System.Drawing.Size(279, 27);
            this.tbKmIncluso.TabIndex = 10;
            // 
            // tbPrecoKm
            // 
            this.tbPrecoKm.Location = new System.Drawing.Point(150, 263);
            this.tbPrecoKm.Name = "tbPrecoKm";
            this.tbPrecoKm.Size = new System.Drawing.Size(279, 27);
            this.tbPrecoKm.TabIndex = 11;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(209, 333);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(107, 46);
            this.btnCadastrar.TabIndex = 12;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(322, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 46);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroPlanoDeCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 391);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.tbPrecoKm);
            this.Controls.Add(this.tbKmIncluso);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lNumero);
            this.Controls.Add(this.tbValorDiaria);
            this.Controls.Add(this.cbTipoPlano);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.lPrecoKm);
            this.Controls.Add(this.lKmIncluso);
            this.Controls.Add(this.lValor);
            this.Controls.Add(this.lTipoPlano);
            this.Controls.Add(this.lGrupo);
            this.Name = "TelaCadastroPlanoDeCobranca";
            this.Text = "Cadastro de Plano de Cobrança";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lGrupo;
        private Label lTipoPlano;
        private Label lValor;
        private Label lKmIncluso;
        private Label lPrecoKm;
        private ComboBox cbGrupo;
        private ComboBox cbTipoPlano;
        private TextBox tbValorDiaria;
        private TextBox tbNumero;
        private Label lNumero;
        private TextBox tbKmIncluso;
        private TextBox tbPrecoKm;
        private Button btnCadastrar;
        private Button btnCancelar;
    }
}