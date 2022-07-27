namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    partial class TelaCadastroDevolucao
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
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.labelDataDevolucao = new System.Windows.Forms.Label();
            this.tbKm = new System.Windows.Forms.TextBox();
            this.labelKm = new System.Windows.Forms.Label();
            this.cbNivel = new System.Windows.Forms.ComboBox();
            this.labelNivel = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelValorAPagar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Location = new System.Drawing.Point(142, 23);
            this.dtpDevolucao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(246, 23);
            this.dtpDevolucao.TabIndex = 19;
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Location = new System.Drawing.Point(14, 26);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(109, 15);
            this.labelDataDevolucao.TabIndex = 18;
            this.labelDataDevolucao.Text = "Data da Devolução:";
            // 
            // tbKm
            // 
            this.tbKm.Location = new System.Drawing.Point(142, 64);
            this.tbKm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbKm.Name = "tbKm";
            this.tbKm.Size = new System.Drawing.Size(246, 23);
            this.tbKm.TabIndex = 21;
            // 
            // labelKm
            // 
            this.labelKm.AutoSize = true;
            this.labelKm.Location = new System.Drawing.Point(52, 66);
            this.labelKm.Name = "labelKm";
            this.labelKm.Size = new System.Drawing.Size(77, 15);
            this.labelKm.TabIndex = 20;
            this.labelKm.Text = "Km do Carro:";
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(142, 105);
            this.cbNivel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(246, 23);
            this.cbNivel.TabIndex = 23;
            // 
            // labelNivel
            // 
            this.labelNivel.AutoSize = true;
            this.labelNivel.Location = new System.Drawing.Point(32, 107);
            this.labelNivel.Name = "labelNivel";
            this.labelNivel.Size = new System.Drawing.Size(95, 15);
            this.labelNivel.TabIndex = 22;
            this.labelNivel.Text = "Nível do Tanque:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(37, 177);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(132, 22);
            this.btnCalcular.TabIndex = 30;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(142, 148);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(23, 15);
            this.labelValor.TabIndex = 29;
            this.labelValor.Text = "R$ ";
            // 
            // labelValorAPagar
            // 
            this.labelValorAPagar.AutoSize = true;
            this.labelValorAPagar.Location = new System.Drawing.Point(50, 148);
            this.labelValorAPagar.Name = "labelValorAPagar";
            this.labelValorAPagar.Size = new System.Drawing.Size(78, 15);
            this.labelValorAPagar.TabIndex = 28;
            this.labelValorAPagar.Text = "Valor a Pagar:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(285, 224);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(180, 224);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 36);
            this.btnCadastrar.TabIndex = 31;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // TelaCadastroDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 270);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelValorAPagar);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.labelNivel);
            this.Controls.Add(this.tbKm);
            this.Controls.Add(this.labelKm);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.labelDataDevolucao);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TelaCadastroDevolucao";
            this.Text = "Cadastro de Devolução";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dtpDevolucao;
        private Label labelDataDevolucao;
        private TextBox tbKm;
        private Label labelKm;
        private ComboBox cbNivel;
        private Label labelNivel;
        private Button btnCalcular;
        private Label labelValor;
        private Label labelValorAPagar;
        private Button btnCancelar;
        private Button btnCadastrar;
    }
}