namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    partial class TelaCadastroVeiculo
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
            this.lModelo = new System.Windows.Forms.Label();
            this.lFabricante = new System.Windows.Forms.Label();
            this.tfModelo = new System.Windows.Forms.TextBox();
            this.tfFabricante = new System.Windows.Forms.TextBox();
            this.lAno = new System.Windows.Forms.Label();
            this.lCor = new System.Windows.Forms.Label();
            this.tfCor = new System.Windows.Forms.TextBox();
            this.lPlaca = new System.Windows.Forms.Label();
            this.tfPlaca = new System.Windows.Forms.TextBox();
            this.lKilometragem = new System.Windows.Forms.Label();
            this.lCombustivel = new System.Windows.Forms.Label();
            this.cbCombustivel = new System.Windows.Forms.ComboBox();
            this.lCapacidadeDoTanque = new System.Windows.Forms.Label();
            this.tfCapacidadeDoTanque = new System.Windows.Forms.TextBox();
            this.lGrupoDeVeiculos = new System.Windows.Forms.Label();
            this.cbGrupoDeVeiculos = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lNumero = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.tfAno = new System.Windows.Forms.MaskedTextBox();
            this.cbCambio = new System.Windows.Forms.ComboBox();
            this.lCambio = new System.Windows.Forms.Label();
            this.tfKilometragem = new System.Windows.Forms.MaskedTextBox();
            this.lImagem = new System.Windows.Forms.Label();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.btnSelecionarImagem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lModelo
            // 
            this.lModelo.AutoSize = true;
            this.lModelo.Location = new System.Drawing.Point(50, 85);
            this.lModelo.Name = "lModelo";
            this.lModelo.Size = new System.Drawing.Size(64, 20);
            this.lModelo.TabIndex = 0;
            this.lModelo.Text = "Modelo:";
            // 
            // lFabricante
            // 
            this.lFabricante.AutoSize = true;
            this.lFabricante.Location = new System.Drawing.Point(34, 141);
            this.lFabricante.Name = "lFabricante";
            this.lFabricante.Size = new System.Drawing.Size(80, 20);
            this.lFabricante.TabIndex = 1;
            this.lFabricante.Text = "Fabricante:";
            // 
            // tfModelo
            // 
            this.tfModelo.Location = new System.Drawing.Point(122, 83);
            this.tfModelo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tfModelo.Name = "tfModelo";
            this.tfModelo.Size = new System.Drawing.Size(225, 27);
            this.tfModelo.TabIndex = 2;
            // 
            // tfFabricante
            // 
            this.tfFabricante.Location = new System.Drawing.Point(121, 139);
            this.tfFabricante.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tfFabricante.Name = "tfFabricante";
            this.tfFabricante.Size = new System.Drawing.Size(225, 27);
            this.tfFabricante.TabIndex = 3;
            // 
            // lAno
            // 
            this.lAno.AutoSize = true;
            this.lAno.Location = new System.Drawing.Point(75, 197);
            this.lAno.Name = "lAno";
            this.lAno.Size = new System.Drawing.Size(39, 20);
            this.lAno.TabIndex = 4;
            this.lAno.Text = "Ano:";
            // 
            // lCor
            // 
            this.lCor.AutoSize = true;
            this.lCor.Location = new System.Drawing.Point(80, 308);
            this.lCor.Name = "lCor";
            this.lCor.Size = new System.Drawing.Size(35, 20);
            this.lCor.TabIndex = 6;
            this.lCor.Text = "Cor:";
            // 
            // tfCor
            // 
            this.tfCor.Location = new System.Drawing.Point(121, 305);
            this.tfCor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tfCor.Name = "tfCor";
            this.tfCor.Size = new System.Drawing.Size(227, 27);
            this.tfCor.TabIndex = 7;
            // 
            // lPlaca
            // 
            this.lPlaca.AutoSize = true;
            this.lPlaca.Location = new System.Drawing.Point(67, 364);
            this.lPlaca.Name = "lPlaca";
            this.lPlaca.Size = new System.Drawing.Size(47, 20);
            this.lPlaca.TabIndex = 8;
            this.lPlaca.Text = "Placa:";
            // 
            // tfPlaca
            // 
            this.tfPlaca.Location = new System.Drawing.Point(121, 361);
            this.tfPlaca.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tfPlaca.Name = "tfPlaca";
            this.tfPlaca.Size = new System.Drawing.Size(117, 27);
            this.tfPlaca.TabIndex = 9;
            // 
            // lKilometragem
            // 
            this.lKilometragem.AutoSize = true;
            this.lKilometragem.Location = new System.Drawing.Point(458, 36);
            this.lKilometragem.Name = "lKilometragem";
            this.lKilometragem.Size = new System.Drawing.Size(107, 20);
            this.lKilometragem.TabIndex = 10;
            this.lKilometragem.Text = "Kilometragem:";
            // 
            // lCombustivel
            // 
            this.lCombustivel.AutoSize = true;
            this.lCombustivel.Location = new System.Drawing.Point(471, 87);
            this.lCombustivel.Name = "lCombustivel";
            this.lCombustivel.Size = new System.Drawing.Size(94, 20);
            this.lCombustivel.TabIndex = 12;
            this.lCombustivel.Text = "Combustível:";
            // 
            // cbCombustivel
            // 
            this.cbCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCombustivel.FormattingEnabled = true;
            this.cbCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Alcool"});
            this.cbCombustivel.Location = new System.Drawing.Point(571, 84);
            this.cbCombustivel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbCombustivel.Name = "cbCombustivel";
            this.cbCombustivel.Size = new System.Drawing.Size(228, 28);
            this.cbCombustivel.TabIndex = 13;
            // 
            // lCapacidadeDoTanque
            // 
            this.lCapacidadeDoTanque.AutoSize = true;
            this.lCapacidadeDoTanque.Location = new System.Drawing.Point(401, 136);
            this.lCapacidadeDoTanque.Name = "lCapacidadeDoTanque";
            this.lCapacidadeDoTanque.Size = new System.Drawing.Size(164, 20);
            this.lCapacidadeDoTanque.TabIndex = 14;
            this.lCapacidadeDoTanque.Text = "Capacidade do Tanque:";
            // 
            // tfCapacidadeDoTanque
            // 
            this.tfCapacidadeDoTanque.Location = new System.Drawing.Point(571, 136);
            this.tfCapacidadeDoTanque.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tfCapacidadeDoTanque.Name = "tfCapacidadeDoTanque";
            this.tfCapacidadeDoTanque.Size = new System.Drawing.Size(228, 27);
            this.tfCapacidadeDoTanque.TabIndex = 15;
            // 
            // lGrupoDeVeiculos
            // 
            this.lGrupoDeVeiculos.AutoSize = true;
            this.lGrupoDeVeiculos.Location = new System.Drawing.Point(431, 189);
            this.lGrupoDeVeiculos.Name = "lGrupoDeVeiculos";
            this.lGrupoDeVeiculos.Size = new System.Drawing.Size(134, 20);
            this.lGrupoDeVeiculos.TabIndex = 16;
            this.lGrupoDeVeiculos.Text = "Grupo De Veículos:";
            // 
            // cbGrupoDeVeiculos
            // 
            this.cbGrupoDeVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupoDeVeiculos.FormattingEnabled = true;
            this.cbGrupoDeVeiculos.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Alcool"});
            this.cbGrupoDeVeiculos.Location = new System.Drawing.Point(571, 189);
            this.cbGrupoDeVeiculos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbGrupoDeVeiculos.Name = "cbGrupoDeVeiculos";
            this.cbGrupoDeVeiculos.Size = new System.Drawing.Size(228, 28);
            this.cbGrupoDeVeiculos.TabIndex = 17;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(582, 487);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(104, 55);
            this.btnCadastrar.TabIndex = 18;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(692, 487);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 55);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(48, 33);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(66, 20);
            this.lNumero.TabIndex = 21;
            this.lNumero.Text = "Número:";
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(121, 29);
            this.tbNumero.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(84, 27);
            this.tbNumero.TabIndex = 22;
            // 
            // tfAno
            // 
            this.tfAno.Location = new System.Drawing.Point(121, 195);
            this.tfAno.Mask = "0000";
            this.tfAno.Name = "tfAno";
            this.tfAno.PromptChar = ' ';
            this.tfAno.Size = new System.Drawing.Size(49, 27);
            this.tfAno.TabIndex = 23;
            this.tfAno.Tag = "";
            // 
            // cbCambio
            // 
            this.cbCambio.AutoCompleteCustomSource.AddRange(new string[] {
            "Manual",
            "Automático"});
            this.cbCambio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCambio.FormattingEnabled = true;
            this.cbCambio.Items.AddRange(new object[] {
            "Manual",
            "Automático"});
            this.cbCambio.Location = new System.Drawing.Point(121, 251);
            this.cbCambio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbCambio.Name = "cbCambio";
            this.cbCambio.Size = new System.Drawing.Size(117, 28);
            this.cbCambio.TabIndex = 25;
            // 
            // lCambio
            // 
            this.lCambio.AutoSize = true;
            this.lCambio.Location = new System.Drawing.Point(51, 255);
            this.lCambio.Name = "lCambio";
            this.lCambio.Size = new System.Drawing.Size(64, 20);
            this.lCambio.TabIndex = 24;
            this.lCambio.Text = "Cambio:";
            // 
            // tfKilometragem
            // 
            this.tfKilometragem.Location = new System.Drawing.Point(571, 33);
            this.tfKilometragem.Mask = "000000000000";
            this.tfKilometragem.Name = "tfKilometragem";
            this.tfKilometragem.PromptChar = ' ';
            this.tfKilometragem.Size = new System.Drawing.Size(228, 27);
            this.tfKilometragem.TabIndex = 26;
            // 
            // lImagem
            // 
            this.lImagem.AutoSize = true;
            this.lImagem.Location = new System.Drawing.Point(495, 244);
            this.lImagem.Name = "lImagem";
            this.lImagem.Size = new System.Drawing.Size(67, 20);
            this.lImagem.TabIndex = 27;
            this.lImagem.Text = "Imagem:";
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxImagem.Location = new System.Drawing.Point(571, 248);
            this.pictureBoxImagem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(225, 147);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagem.TabIndex = 28;
            this.pictureBoxImagem.TabStop = false;
            // 
            // btnSelecionarImagem
            // 
            this.btnSelecionarImagem.Location = new System.Drawing.Point(569, 405);
            this.btnSelecionarImagem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSelecionarImagem.Name = "btnSelecionarImagem";
            this.btnSelecionarImagem.Size = new System.Drawing.Size(227, 31);
            this.btnSelecionarImagem.TabIndex = 29;
            this.btnSelecionarImagem.Text = "Selecionar Imagem";
            this.btnSelecionarImagem.UseVisualStyleBackColor = true;
            this.btnSelecionarImagem.Click += new System.EventHandler(this.btnSelecionarImagem_Click);
            // 
            // TelaCadastroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 554);
            this.Controls.Add(this.btnSelecionarImagem);
            this.Controls.Add(this.pictureBoxImagem);
            this.Controls.Add(this.lImagem);
            this.Controls.Add(this.tfKilometragem);
            this.Controls.Add(this.cbCambio);
            this.Controls.Add(this.lCambio);
            this.Controls.Add(this.tfAno);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lNumero);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cbGrupoDeVeiculos);
            this.Controls.Add(this.lGrupoDeVeiculos);
            this.Controls.Add(this.tfCapacidadeDoTanque);
            this.Controls.Add(this.lCapacidadeDoTanque);
            this.Controls.Add(this.cbCombustivel);
            this.Controls.Add(this.lCombustivel);
            this.Controls.Add(this.lKilometragem);
            this.Controls.Add(this.tfPlaca);
            this.Controls.Add(this.lPlaca);
            this.Controls.Add(this.tfCor);
            this.Controls.Add(this.lCor);
            this.Controls.Add(this.lAno);
            this.Controls.Add(this.tfFabricante);
            this.Controls.Add(this.tfModelo);
            this.Controls.Add(this.lFabricante);
            this.Controls.Add(this.lModelo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lModelo;
        private Label lFabricante;
        private TextBox tfModelo;
        private TextBox tfFabricante;
        private Label lAno;
        private Label lCor;
        private TextBox tfCor;
        private Label lPlaca;
        private TextBox tfPlaca;
        private Label lKilometragem;
        private Label lCombustivel;
        private ComboBox cbCombustivel;
        private Label lCapacidadeDoTanque;
        private TextBox tfCapacidadeDoTanque;
        private Label lGrupoDeVeiculos;
        private ComboBox cbGrupoDeVeiculos;
        private Button btnCadastrar;
        private Button btnCancelar;
        private Label lNumero;
        private TextBox tbNumero;
        private MaskedTextBox tfAno;
        private ComboBox cbCambio;
        private Label lCambio;
        private MaskedTextBox tfKilometragem;
        private Label lImagem;
        private PictureBox pictureBoxImagem;
        private Button btnSelecionarImagem;
    }
}