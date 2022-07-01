namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    partial class TelaCadastroCliente
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
            this.lNome = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.tfNome = new System.Windows.Forms.TextBox();
            this.tfEmail = new System.Windows.Forms.TextBox();
            this.tfId = new System.Windows.Forms.TextBox();
            this.tfTelefone = new System.Windows.Forms.MaskedTextBox();
            this.tfCpf = new System.Windows.Forms.MaskedTextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lCpf = new System.Windows.Forms.Label();
            this.lEndereco = new System.Windows.Forms.Label();
            this.tfEndereco = new System.Windows.Forms.TextBox();
            this.lCpnj = new System.Windows.Forms.Label();
            this.tfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.rbPessoaFisica = new System.Windows.Forms.RadioButton();
            this.rbPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.lTipo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(53, 15);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(70, 20);
            this.lNumero.TabIndex = 0;
            this.lNumero.Text = "Número: ";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(70, 108);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 20);
            this.lNome.TabIndex = 2;
            this.lNome.Text = "Nome:";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(68, 265);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(55, 20);
            this.lEmail.TabIndex = 4;
            this.lEmail.Text = "E-mail:";
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(54, 318);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(69, 20);
            this.lTelefone.TabIndex = 5;
            this.lTelefone.Text = "Telefone:";
            // 
            // tfNome
            // 
            this.tfNome.Location = new System.Drawing.Point(129, 105);
            this.tfNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfNome.Name = "tfNome";
            this.tfNome.Size = new System.Drawing.Size(337, 27);
            this.tfNome.TabIndex = 7;
            // 
            // tfEmail
            // 
            this.tfEmail.Location = new System.Drawing.Point(129, 262);
            this.tfEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfEmail.Name = "tfEmail";
            this.tfEmail.Size = new System.Drawing.Size(334, 27);
            this.tfEmail.TabIndex = 8;
            // 
            // tfId
            // 
            this.tfId.Location = new System.Drawing.Point(129, 12);
            this.tfId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfId.Name = "tfId";
            this.tfId.ReadOnly = true;
            this.tfId.Size = new System.Drawing.Size(68, 27);
            this.tfId.TabIndex = 11;
            // 
            // tfTelefone
            // 
            this.tfTelefone.Location = new System.Drawing.Point(129, 315);
            this.tfTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfTelefone.Mask = "(99) 00000-0000";
            this.tfTelefone.Name = "tfTelefone";
            this.tfTelefone.Size = new System.Drawing.Size(112, 27);
            this.tfTelefone.TabIndex = 36;
            // 
            // tfCpf
            // 
            this.tfCpf.Enabled = false;
            this.tfCpf.Location = new System.Drawing.Point(129, 156);
            this.tfCpf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfCpf.Mask = "000.000.000-00";
            this.tfCpf.Name = "tfCpf";
            this.tfCpf.Size = new System.Drawing.Size(112, 27);
            this.tfCpf.TabIndex = 37;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(245, 435);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(106, 46);
            this.btnGravar.TabIndex = 39;
            this.btnGravar.Text = "Cadastrar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(357, 435);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 46);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lCpf
            // 
            this.lCpf.AutoSize = true;
            this.lCpf.Location = new System.Drawing.Point(87, 159);
            this.lCpf.Name = "lCpf";
            this.lCpf.Size = new System.Drawing.Size(36, 20);
            this.lCpf.TabIndex = 41;
            this.lCpf.Text = "CPF:";
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Location = new System.Drawing.Point(49, 368);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(74, 20);
            this.lEndereco.TabIndex = 43;
            this.lEndereco.Text = "Endereço:";
            // 
            // tfEndereco
            // 
            this.tfEndereco.Location = new System.Drawing.Point(129, 365);
            this.tfEndereco.Name = "tfEndereco";
            this.tfEndereco.Size = new System.Drawing.Size(334, 27);
            this.tfEndereco.TabIndex = 44;
            // 
            // lCpnj
            // 
            this.lCpnj.AutoSize = true;
            this.lCpnj.Location = new System.Drawing.Point(79, 213);
            this.lCpnj.Name = "lCpnj";
            this.lCpnj.Size = new System.Drawing.Size(44, 20);
            this.lCpnj.TabIndex = 45;
            this.lCpnj.Text = "CNPJ:";
            // 
            // tfCnpj
            // 
            this.tfCnpj.Enabled = false;
            this.tfCnpj.Location = new System.Drawing.Point(129, 210);
            this.tfCnpj.Mask = "00.000.000/0000-00";
            this.tfCnpj.Name = "tfCnpj";
            this.tfCnpj.Size = new System.Drawing.Size(159, 27);
            this.tfCnpj.TabIndex = 46;
            // 
            // rbPessoaFisica
            // 
            this.rbPessoaFisica.AutoSize = true;
            this.rbPessoaFisica.Location = new System.Drawing.Point(131, 58);
            this.rbPessoaFisica.Name = "rbPessoaFisica";
            this.rbPessoaFisica.Size = new System.Drawing.Size(66, 24);
            this.rbPessoaFisica.TabIndex = 47;
            this.rbPessoaFisica.TabStop = true;
            this.rbPessoaFisica.Text = "Física";
            this.rbPessoaFisica.UseVisualStyleBackColor = true;
            this.rbPessoaFisica.CheckedChanged += new System.EventHandler(this.rbPessoaFisica_CheckedChanged);
            // 
            // rbPessoaJuridica
            // 
            this.rbPessoaJuridica.AutoSize = true;
            this.rbPessoaJuridica.Location = new System.Drawing.Point(203, 58);
            this.rbPessoaJuridica.Name = "rbPessoaJuridica";
            this.rbPessoaJuridica.Size = new System.Drawing.Size(80, 24);
            this.rbPessoaJuridica.TabIndex = 48;
            this.rbPessoaJuridica.TabStop = true;
            this.rbPessoaJuridica.Text = "Jurídica";
            this.rbPessoaJuridica.UseVisualStyleBackColor = true;
            this.rbPessoaJuridica.CheckedChanged += new System.EventHandler(this.rbPessoaJuridica_CheckedChanged);
            // 
            // lTipo
            // 
            this.lTipo.AutoSize = true;
            this.lTipo.Location = new System.Drawing.Point(12, 60);
            this.lTipo.Name = "lTipo";
            this.lTipo.Size = new System.Drawing.Size(111, 20);
            this.lTipo.TabIndex = 49;
            this.lTipo.Text = "Tipo de Pessoa:";
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 494);
            this.Controls.Add(this.lTipo);
            this.Controls.Add(this.rbPessoaJuridica);
            this.Controls.Add(this.rbPessoaFisica);
            this.Controls.Add(this.tfCnpj);
            this.Controls.Add(this.lCpnj);
            this.Controls.Add(this.tfEndereco);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCpf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tfCpf);
            this.Controls.Add(this.tfTelefone);
            this.Controls.Add(this.tfId);
            this.Controls.Add(this.tfEmail);
            this.Controls.Add(this.tfNome);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.lNumero);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lNumero;
        private Label lNome;
        private Label lEmail;
        private Label lTelefone;
        private TextBox tfNome;
        private TextBox tfEmail;
        private TextBox tfId;
        private MaskedTextBox tfTelefone;
        private MaskedTextBox tfCpf;
        private Button btnGravar;
        private Button btnCancelar;
        private Label lCpf;
        private Label lEndereco;
        private TextBox tfEndereco;
        private Label lCpnj;
        private MaskedTextBox tfCnpj;
        private RadioButton rbPessoaFisica;
        private RadioButton rbPessoaJuridica;
        private Label lTipo;
    }
}