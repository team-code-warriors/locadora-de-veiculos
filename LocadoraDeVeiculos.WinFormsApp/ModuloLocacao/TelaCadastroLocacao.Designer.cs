namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    partial class TelaCadastroLocacao
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
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelFuncionario = new System.Windows.Forms.Label();
            this.labelCondutor = new System.Windows.Forms.Label();
            this.labelVeiculo = new System.Windows.Forms.Label();
            this.labelPlano = new System.Windows.Forms.Label();
            this.labelTaxa = new System.Windows.Forms.Label();
            this.labelDataLocacao = new System.Windows.Forms.Label();
            this.labelDataDevolucao = new System.Windows.Forms.Label();
            this.labelKm = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.cbFuncionario = new System.Windows.Forms.ComboBox();
            this.cbCondutor = new System.Windows.Forms.ComboBox();
            this.cbVeiculo = new System.Windows.Forms.ComboBox();
            this.cbPlano = new System.Windows.Forms.ComboBox();
            this.cbTaxa = new System.Windows.Forms.ComboBox();
            this.btnAdicionarTaxa = new System.Windows.Forms.Button();
            this.dtpLocacao = new System.Windows.Forms.DateTimePicker();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.tbKm = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelValorEstimado = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.listTaxas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(83, 36);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(66, 20);
            this.labelNumero.TabIndex = 0;
            this.labelNumero.Text = "Número:";
            // 
            // labelFuncionario
            // 
            this.labelFuncionario.AutoSize = true;
            this.labelFuncionario.Location = new System.Drawing.Point(59, 93);
            this.labelFuncionario.Name = "labelFuncionario";
            this.labelFuncionario.Size = new System.Drawing.Size(89, 20);
            this.labelFuncionario.TabIndex = 1;
            this.labelFuncionario.Text = "Funcionário:";
            // 
            // labelCondutor
            // 
            this.labelCondutor.AutoSize = true;
            this.labelCondutor.Location = new System.Drawing.Point(75, 148);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(74, 20);
            this.labelCondutor.TabIndex = 2;
            this.labelCondutor.Text = "Condutor:";
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Location = new System.Drawing.Point(89, 203);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(60, 20);
            this.labelVeiculo.TabIndex = 3;
            this.labelVeiculo.Text = "Veículo:";
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(11, 253);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(137, 20);
            this.labelPlano.TabIndex = 4;
            this.labelPlano.Text = "Plano de Cobrança:";
            // 
            // labelTaxa
            // 
            this.labelTaxa.AutoSize = true;
            this.labelTaxa.Location = new System.Drawing.Point(107, 308);
            this.labelTaxa.Name = "labelTaxa";
            this.labelTaxa.Size = new System.Drawing.Size(41, 20);
            this.labelTaxa.TabIndex = 5;
            this.labelTaxa.Text = "Taxa:";
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(528, 33);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(124, 20);
            this.labelDataLocacao.TabIndex = 6;
            this.labelDataLocacao.Text = "Data da Locação:";
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Location = new System.Drawing.Point(512, 83);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(140, 20);
            this.labelDataDevolucao.TabIndex = 7;
            this.labelDataDevolucao.Text = "Data da Devolução:";
            // 
            // labelKm
            // 
            this.labelKm.AutoSize = true;
            this.labelKm.Location = new System.Drawing.Point(556, 137);
            this.labelKm.Name = "labelKm";
            this.labelKm.Size = new System.Drawing.Size(96, 20);
            this.labelKm.TabIndex = 8;
            this.labelKm.Text = "Km do Carro:";
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(155, 33);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(97, 27);
            this.tbNumero.TabIndex = 9;
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncionario.FormattingEnabled = true;
            this.cbFuncionario.Location = new System.Drawing.Point(155, 89);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(281, 28);
            this.cbFuncionario.TabIndex = 10;
            // 
            // cbCondutor
            // 
            this.cbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondutor.FormattingEnabled = true;
            this.cbCondutor.Location = new System.Drawing.Point(155, 144);
            this.cbCondutor.Name = "cbCondutor";
            this.cbCondutor.Size = new System.Drawing.Size(281, 28);
            this.cbCondutor.TabIndex = 11;
            // 
            // cbVeiculo
            // 
            this.cbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVeiculo.FormattingEnabled = true;
            this.cbVeiculo.Location = new System.Drawing.Point(155, 199);
            this.cbVeiculo.Name = "cbVeiculo";
            this.cbVeiculo.Size = new System.Drawing.Size(281, 28);
            this.cbVeiculo.TabIndex = 12;
            // 
            // cbPlano
            // 
            this.cbPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlano.FormattingEnabled = true;
            this.cbPlano.Location = new System.Drawing.Point(155, 251);
            this.cbPlano.Name = "cbPlano";
            this.cbPlano.Size = new System.Drawing.Size(281, 28);
            this.cbPlano.TabIndex = 13;
            // 
            // cbTaxa
            // 
            this.cbTaxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTaxa.FormattingEnabled = true;
            this.cbTaxa.Location = new System.Drawing.Point(155, 304);
            this.cbTaxa.Name = "cbTaxa";
            this.cbTaxa.Size = new System.Drawing.Size(281, 28);
            this.cbTaxa.TabIndex = 14;
            // 
            // btnAdicionarTaxa
            // 
            this.btnAdicionarTaxa.Location = new System.Drawing.Point(155, 339);
            this.btnAdicionarTaxa.Name = "btnAdicionarTaxa";
            this.btnAdicionarTaxa.Size = new System.Drawing.Size(281, 29);
            this.btnAdicionarTaxa.TabIndex = 15;
            this.btnAdicionarTaxa.Text = "Adicionar Taxa";
            this.btnAdicionarTaxa.UseVisualStyleBackColor = true;
            this.btnAdicionarTaxa.Click += new System.EventHandler(this.btnAdicionarTaxa_Click);
            // 
            // dtpLocacao
            // 
            this.dtpLocacao.Location = new System.Drawing.Point(658, 29);
            this.dtpLocacao.Name = "dtpLocacao";
            this.dtpLocacao.Size = new System.Drawing.Size(281, 27);
            this.dtpLocacao.TabIndex = 16;
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Location = new System.Drawing.Point(658, 81);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(281, 27);
            this.dtpDevolucao.TabIndex = 17;
            // 
            // tbKm
            // 
            this.tbKm.Location = new System.Drawing.Point(658, 133);
            this.tbKm.Name = "tbKm";
            this.tbKm.Size = new System.Drawing.Size(281, 27);
            this.tbKm.TabIndex = 18;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(705, 309);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(114, 48);
            this.btnCadastrar.TabIndex = 23;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(825, 309);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 48);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelValorEstimado
            // 
            this.labelValorEstimado.AutoSize = true;
            this.labelValorEstimado.Location = new System.Drawing.Point(540, 215);
            this.labelValorEstimado.Name = "labelValorEstimado";
            this.labelValorEstimado.Size = new System.Drawing.Size(112, 20);
            this.labelValorEstimado.TabIndex = 25;
            this.labelValorEstimado.Text = "Valor Estimado:";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(652, 215);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(26, 20);
            this.labelValor.TabIndex = 26;
            this.labelValor.Text = "R$";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(540, 238);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(144, 29);
            this.btnCalcular.TabIndex = 27;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // listTaxas
            // 
            this.listTaxas.FormattingEnabled = true;
            this.listTaxas.ItemHeight = 20;
            this.listTaxas.Location = new System.Drawing.Point(12, 374);
            this.listTaxas.Name = "listTaxas";
            this.listTaxas.Size = new System.Drawing.Size(425, 104);
            this.listTaxas.TabIndex = 28;
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 490);
            this.Controls.Add(this.listTaxas);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelValorEstimado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.tbKm);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.dtpLocacao);
            this.Controls.Add(this.btnAdicionarTaxa);
            this.Controls.Add(this.cbTaxa);
            this.Controls.Add(this.cbPlano);
            this.Controls.Add(this.cbVeiculo);
            this.Controls.Add(this.cbCondutor);
            this.Controls.Add(this.cbFuncionario);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.labelKm);
            this.Controls.Add(this.labelDataDevolucao);
            this.Controls.Add(this.labelDataLocacao);
            this.Controls.Add(this.labelTaxa);
            this.Controls.Add(this.labelPlano);
            this.Controls.Add(this.labelVeiculo);
            this.Controls.Add(this.labelCondutor);
            this.Controls.Add(this.labelFuncionario);
            this.Controls.Add(this.labelNumero);
            this.Name = "TelaCadastroLocacao";
            this.Text = "Cadastro de Locação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelNumero;
        private Label labelFuncionario;
        private Label labelCondutor;
        private Label labelVeiculo;
        private Label labelPlano;
        private Label labelTaxa;
        private Label labelDataLocacao;
        private Label labelDataDevolucao;
        private Label labelKm;
        private TextBox tbNumero;
        private ComboBox cbFuncionario;
        private ComboBox cbCondutor;
        private ComboBox cbVeiculo;
        private ComboBox cbPlano;
        private ComboBox cbTaxa;
        private Button btnAdicionarTaxa;
        private DateTimePicker dtpLocacao;
        private DateTimePicker dtpDevolucao;
        private TextBox tbKm;
        private Button btnCadastrar;
        private Button btnCancelar;
        private Label labelValorEstimado;
        private Label labelValor;
        private Button btnCalcular;
        private ListBox listTaxas;
    }
}