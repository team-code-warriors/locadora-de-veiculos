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
            this.tfKilometragem = new System.Windows.Forms.TextBox();
            this.lCombustivel = new System.Windows.Forms.Label();
            this.cbCombustivel = new System.Windows.Forms.ComboBox();
            this.lCapacidadeDoTanque = new System.Windows.Forms.Label();
            this.tfCapacidadeDoTanque = new System.Windows.Forms.TextBox();
            this.lGrupoDeVeiculos = new System.Windows.Forms.Label();
            this.cbGrupoDeVeiculos = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tfAno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lModelo
            // 
            this.lModelo.AutoSize = true;
            this.lModelo.Location = new System.Drawing.Point(90, 44);
            this.lModelo.Name = "lModelo";
            this.lModelo.Size = new System.Drawing.Size(51, 15);
            this.lModelo.TabIndex = 0;
            this.lModelo.Text = "Modelo:";
            // 
            // lFabricante
            // 
            this.lFabricante.AutoSize = true;
            this.lFabricante.Location = new System.Drawing.Point(76, 96);
            this.lFabricante.Name = "lFabricante";
            this.lFabricante.Size = new System.Drawing.Size(65, 15);
            this.lFabricante.TabIndex = 1;
            this.lFabricante.Text = "Fabricante:";
            // 
            // tfModelo
            // 
            this.tfModelo.Location = new System.Drawing.Point(153, 41);
            this.tfModelo.Name = "tfModelo";
            this.tfModelo.Size = new System.Drawing.Size(197, 23);
            this.tfModelo.TabIndex = 2;
            // 
            // tfFabricante
            // 
            this.tfFabricante.Location = new System.Drawing.Point(153, 93);
            this.tfFabricante.Name = "tfFabricante";
            this.tfFabricante.Size = new System.Drawing.Size(197, 23);
            this.tfFabricante.TabIndex = 3;
            // 
            // lAno
            // 
            this.lAno.AutoSize = true;
            this.lAno.Location = new System.Drawing.Point(106, 145);
            this.lAno.Name = "lAno";
            this.lAno.Size = new System.Drawing.Size(32, 15);
            this.lAno.TabIndex = 4;
            this.lAno.Text = "Ano:";
            // 
            // lCor
            // 
            this.lCor.AutoSize = true;
            this.lCor.Location = new System.Drawing.Point(112, 185);
            this.lCor.Name = "lCor";
            this.lCor.Size = new System.Drawing.Size(29, 15);
            this.lCor.TabIndex = 6;
            this.lCor.Text = "Cor:";
            // 
            // tfCor
            // 
            this.tfCor.Location = new System.Drawing.Point(153, 182);
            this.tfCor.Name = "tfCor";
            this.tfCor.Size = new System.Drawing.Size(103, 23);
            this.tfCor.TabIndex = 7;
            // 
            // lPlaca
            // 
            this.lPlaca.AutoSize = true;
            this.lPlaca.Location = new System.Drawing.Point(100, 226);
            this.lPlaca.Name = "lPlaca";
            this.lPlaca.Size = new System.Drawing.Size(38, 15);
            this.lPlaca.TabIndex = 8;
            this.lPlaca.Text = "Placa:";
            // 
            // tfPlaca
            // 
            this.tfPlaca.Location = new System.Drawing.Point(153, 223);
            this.tfPlaca.Name = "tfPlaca";
            this.tfPlaca.Size = new System.Drawing.Size(103, 23);
            this.tfPlaca.TabIndex = 9;
            // 
            // lKilometragem
            // 
            this.lKilometragem.AutoSize = true;
            this.lKilometragem.Location = new System.Drawing.Point(53, 273);
            this.lKilometragem.Name = "lKilometragem";
            this.lKilometragem.Size = new System.Drawing.Size(85, 15);
            this.lKilometragem.TabIndex = 10;
            this.lKilometragem.Text = "Kilometragem:";
            // 
            // tfKilometragem
            // 
            this.tfKilometragem.Location = new System.Drawing.Point(153, 270);
            this.tfKilometragem.Name = "tfKilometragem";
            this.tfKilometragem.Size = new System.Drawing.Size(103, 23);
            this.tfKilometragem.TabIndex = 11;
            // 
            // lCombustivel
            // 
            this.lCombustivel.AutoSize = true;
            this.lCombustivel.Location = new System.Drawing.Point(61, 321);
            this.lCombustivel.Name = "lCombustivel";
            this.lCombustivel.Size = new System.Drawing.Size(77, 15);
            this.lCombustivel.TabIndex = 12;
            this.lCombustivel.Text = "Combustível:";
            // 
            // cbCombustivel
            // 
            this.cbCombustivel.FormattingEnabled = true;
            this.cbCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Alcool"});
            this.cbCombustivel.Location = new System.Drawing.Point(153, 313);
            this.cbCombustivel.Name = "cbCombustivel";
            this.cbCombustivel.Size = new System.Drawing.Size(103, 23);
            this.cbCombustivel.TabIndex = 13;
            // 
            // lCapacidadeDoTanque
            // 
            this.lCapacidadeDoTanque.AutoSize = true;
            this.lCapacidadeDoTanque.Location = new System.Drawing.Point(11, 365);
            this.lCapacidadeDoTanque.Name = "lCapacidadeDoTanque";
            this.lCapacidadeDoTanque.Size = new System.Drawing.Size(130, 15);
            this.lCapacidadeDoTanque.TabIndex = 14;
            this.lCapacidadeDoTanque.Text = "Capacidade do Tanque:";
            // 
            // tfCapacidadeDoTanque
            // 
            this.tfCapacidadeDoTanque.Location = new System.Drawing.Point(153, 362);
            this.tfCapacidadeDoTanque.Name = "tfCapacidadeDoTanque";
            this.tfCapacidadeDoTanque.Size = new System.Drawing.Size(103, 23);
            this.tfCapacidadeDoTanque.TabIndex = 15;
            // 
            // lGrupoDeVeiculos
            // 
            this.lGrupoDeVeiculos.AutoSize = true;
            this.lGrupoDeVeiculos.Location = new System.Drawing.Point(32, 414);
            this.lGrupoDeVeiculos.Name = "lGrupoDeVeiculos";
            this.lGrupoDeVeiculos.Size = new System.Drawing.Size(106, 15);
            this.lGrupoDeVeiculos.TabIndex = 16;
            this.lGrupoDeVeiculos.Text = "Grupo De Veículos:";
            // 
            // cbGrupoDeVeiculos
            // 
            this.cbGrupoDeVeiculos.FormattingEnabled = true;
            this.cbGrupoDeVeiculos.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Alcool"});
            this.cbGrupoDeVeiculos.Location = new System.Drawing.Point(153, 411);
            this.cbGrupoDeVeiculos.Name = "cbGrupoDeVeiculos";
            this.cbGrupoDeVeiculos.Size = new System.Drawing.Size(103, 23);
            this.cbGrupoDeVeiculos.TabIndex = 17;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(175, 469);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(81, 37);
            this.btnCadastrar.TabIndex = 18;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(269, 469);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 37);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tfAno
            // 
            this.tfAno.Location = new System.Drawing.Point(153, 142);
            this.tfAno.Name = "tfAno";
            this.tfAno.Size = new System.Drawing.Size(103, 23);
            this.tfAno.TabIndex = 20;
            // 
            // TelaCadastroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 537);
            this.Controls.Add(this.tfAno);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cbGrupoDeVeiculos);
            this.Controls.Add(this.lGrupoDeVeiculos);
            this.Controls.Add(this.tfCapacidadeDoTanque);
            this.Controls.Add(this.lCapacidadeDoTanque);
            this.Controls.Add(this.cbCombustivel);
            this.Controls.Add(this.lCombustivel);
            this.Controls.Add(this.tfKilometragem);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículo";
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
        private TextBox tfKilometragem;
        private Label lCombustivel;
        private ComboBox cbCombustivel;
        private Label lCapacidadeDoTanque;
        private TextBox tfCapacidadeDoTanque;
        private Label lGrupoDeVeiculos;
        private ComboBox cbGrupoDeVeiculos;
        private Button btnCadastrar;
        private Button btnCancelar;
        private TextBox tfAno;
    }
}