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
            this.lId = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lCnh = new System.Windows.Forms.Label();
            this.tfNome = new System.Windows.Forms.TextBox();
            this.tfEmail = new System.Windows.Forms.TextBox();
            this.tfCnh = new System.Windows.Forms.TextBox();
            this.tfId = new System.Windows.Forms.TextBox();
            this.tfTelefone = new System.Windows.Forms.MaskedTextBox();
            this.tfCpf = new System.Windows.Forms.MaskedTextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lCpf = new System.Windows.Forms.Label();
            this.lEndereco = new System.Windows.Forms.Label();
            this.tfEndereco = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(61, 20);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(29, 20);
            this.lId.TabIndex = 0;
            this.lId.Text = "Id: ";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(37, 67);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 20);
            this.lNome.TabIndex = 2;
            this.lNome.Text = "Nome:";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(35, 217);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(55, 20);
            this.lEmail.TabIndex = 4;
            this.lEmail.Text = "E-mail:";
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(21, 270);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(69, 20);
            this.lTelefone.TabIndex = 5;
            this.lTelefone.Text = "Telefone:";
            // 
            // lCnh
            // 
            this.lCnh.AutoSize = true;
            this.lCnh.Location = new System.Drawing.Point(47, 169);
            this.lCnh.Name = "lCnh";
            this.lCnh.Size = new System.Drawing.Size(43, 20);
            this.lCnh.TabIndex = 6;
            this.lCnh.Text = "CNH:";
            // 
            // tfNome
            // 
            this.tfNome.Location = new System.Drawing.Point(96, 64);
            this.tfNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfNome.Name = "tfNome";
            this.tfNome.Size = new System.Drawing.Size(337, 27);
            this.tfNome.TabIndex = 7;
            // 
            // tfEmail
            // 
            this.tfEmail.Location = new System.Drawing.Point(96, 214);
            this.tfEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfEmail.Name = "tfEmail";
            this.tfEmail.Size = new System.Drawing.Size(334, 27);
            this.tfEmail.TabIndex = 8;
            // 
            // tfCnh
            // 
            this.tfCnh.Location = new System.Drawing.Point(96, 166);
            this.tfCnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfCnh.Name = "tfCnh";
            this.tfCnh.Size = new System.Drawing.Size(337, 27);
            this.tfCnh.TabIndex = 10;
            // 
            // tfId
            // 
            this.tfId.Location = new System.Drawing.Point(96, 17);
            this.tfId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfId.Name = "tfId";
            this.tfId.ReadOnly = true;
            this.tfId.Size = new System.Drawing.Size(68, 27);
            this.tfId.TabIndex = 11;
            // 
            // tfTelefone
            // 
            this.tfTelefone.Location = new System.Drawing.Point(96, 267);
            this.tfTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfTelefone.Mask = "(99) 00000-0000";
            this.tfTelefone.Name = "tfTelefone";
            this.tfTelefone.Size = new System.Drawing.Size(112, 27);
            this.tfTelefone.TabIndex = 36;
            // 
            // tfCpf
            // 
            this.tfCpf.Location = new System.Drawing.Point(96, 116);
            this.tfCpf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfCpf.Mask = "000.000.000-00";
            this.tfCpf.Name = "tfCpf";
            this.tfCpf.Size = new System.Drawing.Size(112, 27);
            this.tfCpf.TabIndex = 37;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(212, 383);
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
            this.btnCancelar.Location = new System.Drawing.Point(324, 383);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 44);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lCpf
            // 
            this.lCpf.AutoSize = true;
            this.lCpf.Location = new System.Drawing.Point(54, 119);
            this.lCpf.Name = "lCpf";
            this.lCpf.Size = new System.Drawing.Size(36, 20);
            this.lCpf.TabIndex = 41;
            this.lCpf.Text = "CPF:";
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Location = new System.Drawing.Point(16, 318);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(74, 20);
            this.lEndereco.TabIndex = 43;
            this.lEndereco.Text = "Endereço:";
            // 
            // tfEndereco
            // 
            this.tfEndereco.Location = new System.Drawing.Point(96, 315);
            this.tfEndereco.Name = "tfEndereco";
            this.tfEndereco.Size = new System.Drawing.Size(334, 27);
            this.tfEndereco.TabIndex = 44;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 441);
            this.Controls.Add(this.tfEndereco);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCpf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tfCpf);
            this.Controls.Add(this.tfTelefone);
            this.Controls.Add(this.tfId);
            this.Controls.Add(this.tfCnh);
            this.Controls.Add(this.tfEmail);
            this.Controls.Add(this.tfNome);
            this.Controls.Add(this.lCnh);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.lId);
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

        private Label lId;
        private Label lNome;
        private Label lEmail;
        private Label lTelefone;
        private Label lCnh;
        private TextBox tfNome;
        private TextBox tfEmail;
        private TextBox tfCnh;
        private TextBox tfId;
        private MaskedTextBox tfTelefone;
        private MaskedTextBox tfCpf;
        private Button btnGravar;
        private Button btnCancelar;
        private Label lCpf;
        private Label lEndereco;
        private TextBox tfEndereco;
    }
}