namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    partial class TelaCadastroTaxa
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
            this.lNumero = new System.Windows.Forms.Label();
            this.lDescricao = new System.Windows.Forms.Label();
            this.lValor = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.lTipoCalculo = new System.Windows.Forms.Label();
            this.cbTipoCalculo = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(62, 22);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(66, 20);
            this.lNumero.TabIndex = 0;
            this.lNumero.Text = "Número:";
            // 
            // lDescricao
            // 
            this.lDescricao.AutoSize = true;
            this.lDescricao.Location = new System.Drawing.Point(51, 73);
            this.lDescricao.Name = "lDescricao";
            this.lDescricao.Size = new System.Drawing.Size(77, 20);
            this.lDescricao.TabIndex = 1;
            this.lDescricao.Text = "Descrição:";
            // 
            // lValor
            // 
            this.lValor.AutoSize = true;
            this.lValor.Location = new System.Drawing.Point(82, 128);
            this.lValor.Name = "lValor";
            this.lValor.Size = new System.Drawing.Size(46, 20);
            this.lValor.TabIndex = 2;
            this.lValor.Text = "Valor:";
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(134, 19);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(64, 27);
            this.tbNumero.TabIndex = 4;
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(134, 70);
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(311, 27);
            this.tbDescricao.TabIndex = 5;
            // 
            // lTipoCalculo
            // 
            this.lTipoCalculo.AutoSize = true;
            this.lTipoCalculo.Location = new System.Drawing.Point(12, 183);
            this.lTipoCalculo.Name = "lTipoCalculo";
            this.lTipoCalculo.Size = new System.Drawing.Size(116, 20);
            this.lTipoCalculo.TabIndex = 3;
            this.lTipoCalculo.Text = "Tipo de Cálculo:";
            // 
            // cbTipoCalculo
            // 
            this.cbTipoCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCalculo.FormattingEnabled = true;
            this.cbTipoCalculo.Items.AddRange(new object[] {
            "Diário",
            "Fixo"});
            this.cbTipoCalculo.Location = new System.Drawing.Point(134, 179);
            this.cbTipoCalculo.Name = "cbTipoCalculo";
            this.cbTipoCalculo.Size = new System.Drawing.Size(311, 28);
            this.cbTipoCalculo.TabIndex = 7;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(219, 253);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(110, 42);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(335, 253);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 42);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(134, 125);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(311, 27);
            this.tbValor.TabIndex = 10;
            // 
            // TelaCadastroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 310);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cbTipoCalculo);
            this.Controls.Add(this.tbDescricao);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lTipoCalculo);
            this.Controls.Add(this.lValor);
            this.Controls.Add(this.lDescricao);
            this.Controls.Add(this.lNumero);
            this.Name = "TelaCadastroTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lNumero;
        private Label lDescricao;
        private Label lValor;
        private TextBox tbNumero;
        private TextBox tbDescricao;
        private Label lTipoCalculo;
        private ComboBox cbTipoCalculo;
        private Button btnCadastrar;
        private Button btnCancelar;
        private TextBox tbValor;
    }
}