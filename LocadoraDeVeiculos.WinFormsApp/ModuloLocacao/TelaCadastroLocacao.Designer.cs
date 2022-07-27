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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelValorEstimado = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(73, 27);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(54, 15);
            this.labelNumero.TabIndex = 0;
            this.labelNumero.Text = "Número:";
            // 
            // labelFuncionario
            // 
            this.labelFuncionario.AutoSize = true;
            this.labelFuncionario.Location = new System.Drawing.Point(52, 70);
            this.labelFuncionario.Name = "labelFuncionario";
            this.labelFuncionario.Size = new System.Drawing.Size(73, 15);
            this.labelFuncionario.TabIndex = 1;
            this.labelFuncionario.Text = "Funcionário:";
            // 
            // labelCondutor
            // 
            this.labelCondutor.AutoSize = true;
            this.labelCondutor.Location = new System.Drawing.Point(66, 111);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(61, 15);
            this.labelCondutor.TabIndex = 2;
            this.labelCondutor.Text = "Condutor:";
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Location = new System.Drawing.Point(78, 152);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(48, 15);
            this.labelVeiculo.TabIndex = 3;
            this.labelVeiculo.Text = "Veículo:";
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(10, 190);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(110, 15);
            this.labelPlano.TabIndex = 4;
            this.labelPlano.Text = "Plano de Cobrança:";
            // 
            // labelTaxa
            // 
            this.labelTaxa.AutoSize = true;
            this.labelTaxa.Location = new System.Drawing.Point(94, 231);
            this.labelTaxa.Name = "labelTaxa";
            this.labelTaxa.Size = new System.Drawing.Size(33, 15);
            this.labelTaxa.TabIndex = 5;
            this.labelTaxa.Text = "Taxa:";
            // 
            // labelDataLocacao
            // 
            this.labelDataLocacao.AutoSize = true;
            this.labelDataLocacao.Location = new System.Drawing.Point(22, 296);
            this.labelDataLocacao.Name = "labelDataLocacao";
            this.labelDataLocacao.Size = new System.Drawing.Size(97, 15);
            this.labelDataLocacao.TabIndex = 6;
            this.labelDataLocacao.Text = "Data da Locação:";
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Location = new System.Drawing.Point(8, 334);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(109, 15);
            this.labelDataDevolucao.TabIndex = 7;
            this.labelDataDevolucao.Text = "Data da Devolução:";
            // 
            // labelKm
            // 
            this.labelKm.AutoSize = true;
            this.labelKm.Location = new System.Drawing.Point(46, 374);
            this.labelKm.Name = "labelKm";
            this.labelKm.Size = new System.Drawing.Size(77, 15);
            this.labelKm.TabIndex = 8;
            this.labelKm.Text = "Km do Carro:";
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(136, 25);
            this.tbNumero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(85, 23);
            this.tbNumero.TabIndex = 9;
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.FormattingEnabled = true;
            this.cbFuncionario.Location = new System.Drawing.Point(136, 67);
            this.cbFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(246, 23);
            this.cbFuncionario.TabIndex = 10;
            // 
            // cbCondutor
            // 
            this.cbCondutor.FormattingEnabled = true;
            this.cbCondutor.Location = new System.Drawing.Point(136, 108);
            this.cbCondutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCondutor.Name = "cbCondutor";
            this.cbCondutor.Size = new System.Drawing.Size(246, 23);
            this.cbCondutor.TabIndex = 11;
            // 
            // cbVeiculo
            // 
            this.cbVeiculo.FormattingEnabled = true;
            this.cbVeiculo.Location = new System.Drawing.Point(136, 149);
            this.cbVeiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVeiculo.Name = "cbVeiculo";
            this.cbVeiculo.Size = new System.Drawing.Size(246, 23);
            this.cbVeiculo.TabIndex = 12;
            // 
            // cbPlano
            // 
            this.cbPlano.FormattingEnabled = true;
            this.cbPlano.Location = new System.Drawing.Point(136, 188);
            this.cbPlano.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPlano.Name = "cbPlano";
            this.cbPlano.Size = new System.Drawing.Size(246, 23);
            this.cbPlano.TabIndex = 13;
            // 
            // cbTaxa
            // 
            this.cbTaxa.FormattingEnabled = true;
            this.cbTaxa.Location = new System.Drawing.Point(136, 228);
            this.cbTaxa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTaxa.Name = "cbTaxa";
            this.cbTaxa.Size = new System.Drawing.Size(246, 23);
            this.cbTaxa.TabIndex = 14;
            // 
            // btnAdicionarTaxa
            // 
            this.btnAdicionarTaxa.Location = new System.Drawing.Point(136, 254);
            this.btnAdicionarTaxa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionarTaxa.Name = "btnAdicionarTaxa";
            this.btnAdicionarTaxa.Size = new System.Drawing.Size(246, 22);
            this.btnAdicionarTaxa.TabIndex = 15;
            this.btnAdicionarTaxa.Text = "Adicionar Taxa";
            this.btnAdicionarTaxa.UseVisualStyleBackColor = true;
            // 
            // dtpLocacao
            // 
            this.dtpLocacao.Location = new System.Drawing.Point(136, 293);
            this.dtpLocacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpLocacao.Name = "dtpLocacao";
            this.dtpLocacao.Size = new System.Drawing.Size(246, 23);
            this.dtpLocacao.TabIndex = 16;
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Location = new System.Drawing.Point(136, 332);
            this.dtpDevolucao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(246, 23);
            this.dtpDevolucao.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 371);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 23);
            this.textBox1.TabIndex = 18;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(177, 503);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 36);
            this.btnCadastrar.TabIndex = 23;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(282, 503);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelValorEstimado
            // 
            this.labelValorEstimado.AutoSize = true;
            this.labelValorEstimado.Location = new System.Drawing.Point(32, 423);
            this.labelValorEstimado.Name = "labelValorEstimado";
            this.labelValorEstimado.Size = new System.Drawing.Size(88, 15);
            this.labelValorEstimado.TabIndex = 25;
            this.labelValorEstimado.Text = "Valor Estimado:";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(130, 423);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(20, 15);
            this.labelValor.TabIndex = 26;
            this.labelValor.Text = "R$";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(32, 440);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(126, 22);
            this.btnCalcular.TabIndex = 27;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 546);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelValorEstimado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.textBox1);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private TextBox textBox1;
        private Button btnCadastrar;
        private Button btnCancelar;
        private Label labelValorEstimado;
        private Label labelValor;
        private Button btnCalcular;
    }
}