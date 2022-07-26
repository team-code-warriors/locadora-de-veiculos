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
            this.dtpDevolucao.Location = new System.Drawing.Point(162, 31);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(281, 27);
            this.dtpDevolucao.TabIndex = 19;
            // 
            // labelDataDevolucao
            // 
            this.labelDataDevolucao.AutoSize = true;
            this.labelDataDevolucao.Location = new System.Drawing.Point(16, 34);
            this.labelDataDevolucao.Name = "labelDataDevolucao";
            this.labelDataDevolucao.Size = new System.Drawing.Size(140, 20);
            this.labelDataDevolucao.TabIndex = 18;
            this.labelDataDevolucao.Text = "Data da Devolução:";
            // 
            // tbKm
            // 
            this.tbKm.Location = new System.Drawing.Point(162, 85);
            this.tbKm.Name = "tbKm";
            this.tbKm.Size = new System.Drawing.Size(281, 27);
            this.tbKm.TabIndex = 21;
            // 
            // labelKm
            // 
            this.labelKm.AutoSize = true;
            this.labelKm.Location = new System.Drawing.Point(60, 88);
            this.labelKm.Name = "labelKm";
            this.labelKm.Size = new System.Drawing.Size(96, 20);
            this.labelKm.TabIndex = 20;
            this.labelKm.Text = "Km do Carro:";
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(162, 140);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(281, 28);
            this.cbNivel.TabIndex = 23;
            // 
            // labelNivel
            // 
            this.labelNivel.AutoSize = true;
            this.labelNivel.Location = new System.Drawing.Point(37, 143);
            this.labelNivel.Name = "labelNivel";
            this.labelNivel.Size = new System.Drawing.Size(119, 20);
            this.labelNivel.TabIndex = 22;
            this.labelNivel.Text = "Nível do Tanque:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(44, 221);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(151, 29);
            this.btnCalcular.TabIndex = 30;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(162, 198);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(33, 20);
            this.labelValor.TabIndex = 29;
            this.labelValor.Text = "____";
            // 
            // labelValorAPagar
            // 
            this.labelValorAPagar.AutoSize = true;
            this.labelValorAPagar.Location = new System.Drawing.Point(57, 198);
            this.labelValorAPagar.Name = "labelValorAPagar";
            this.labelValorAPagar.Size = new System.Drawing.Size(99, 20);
            this.labelValorAPagar.TabIndex = 28;
            this.labelValorAPagar.Text = "Valor a Pagar:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(326, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 48);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(206, 299);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(114, 48);
            this.btnCadastrar.TabIndex = 31;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 360);
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