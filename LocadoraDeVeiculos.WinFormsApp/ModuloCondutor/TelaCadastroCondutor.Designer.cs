namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    partial class TelaCadastroCondutor
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
            this.lCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbxClienteCondutor = new System.Windows.Forms.CheckBox();
            this.lNome = new System.Windows.Forms.Label();
            this.tfNome = new System.Windows.Forms.TextBox();
            this.lCpfCnpj = new System.Windows.Forms.Label();
            this.tfCpfCnpj = new System.Windows.Forms.TextBox();
            this.tfCnh = new System.Windows.Forms.TextBox();
            this.lCnh = new System.Windows.Forms.Label();
            this.lData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lEmail = new System.Windows.Forms.Label();
            this.tfEmail = new System.Windows.Forms.TextBox();
            this.lTelefone = new System.Windows.Forms.Label();
            this.tfTelefone = new System.Windows.Forms.TextBox();
            this.lEndereco = new System.Windows.Forms.Label();
            this.tfEndereco = new System.Windows.Forms.TextBox();
            this.tfId = new System.Windows.Forms.TextBox();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(128, 37);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(25, 20);
            this.lId.TabIndex = 0;
            this.lId.Text = "Id:";
            // 
            // lCliente
            // 
            this.lCliente.AutoSize = true;
            this.lCliente.Location = new System.Drawing.Point(101, 113);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(58, 20);
            this.lCliente.TabIndex = 1;
            this.lCliente.Text = "Cliente:";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(174, 110);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(274, 28);
            this.cbCliente.TabIndex = 2;
            // 
            // cbxClienteCondutor
            // 
            this.cbxClienteCondutor.AutoSize = true;
            this.cbxClienteCondutor.Location = new System.Drawing.Point(478, 113);
            this.cbxClienteCondutor.Name = "cbxClienteCondutor";
            this.cbxClienteCondutor.Size = new System.Drawing.Size(143, 24);
            this.cbxClienteCondutor.TabIndex = 3;
            this.cbxClienteCondutor.Text = "Cliente Condutor";
            this.cbxClienteCondutor.UseVisualStyleBackColor = true;
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(103, 176);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 20);
            this.lNome.TabIndex = 4;
            this.lNome.Text = "Nome:";
            // 
            // tfNome
            // 
            this.tfNome.Location = new System.Drawing.Point(176, 169);
            this.tfNome.Name = "tfNome";
            this.tfNome.Size = new System.Drawing.Size(445, 27);
            this.tfNome.TabIndex = 5;
            // 
            // lCpfCnpj
            // 
            this.lCpfCnpj.AutoSize = true;
            this.lCpfCnpj.Location = new System.Drawing.Point(85, 236);
            this.lCpfCnpj.Name = "lCpfCnpj";
            this.lCpfCnpj.Size = new System.Drawing.Size(74, 20);
            this.lCpfCnpj.TabIndex = 6;
            this.lCpfCnpj.Text = "CPF/CNPJ:";
            // 
            // tfCpfCnpj
            // 
            this.tfCpfCnpj.Location = new System.Drawing.Point(176, 233);
            this.tfCpfCnpj.Name = "tfCpfCnpj";
            this.tfCpfCnpj.Size = new System.Drawing.Size(445, 27);
            this.tfCpfCnpj.TabIndex = 7;
            // 
            // tfCnh
            // 
            this.tfCnh.Location = new System.Drawing.Point(176, 294);
            this.tfCnh.Name = "tfCnh";
            this.tfCnh.Size = new System.Drawing.Size(445, 27);
            this.tfCnh.TabIndex = 8;
            // 
            // lCnh
            // 
            this.lCnh.AutoSize = true;
            this.lCnh.Location = new System.Drawing.Point(110, 301);
            this.lCnh.Name = "lCnh";
            this.lCnh.Size = new System.Drawing.Size(43, 20);
            this.lCnh.TabIndex = 10;
            this.lCnh.Text = "CNH:";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(48, 365);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(105, 20);
            this.lData.TabIndex = 11;
            this.lData.Text = "Validade CNH:";
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(174, 365);
            this.dtpData.MaxDate = new System.DateTime(2022, 6, 29, 0, 0, 0, 0);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(447, 27);
            this.dtpData.TabIndex = 12;
            this.dtpData.Value = new System.DateTime(2022, 6, 29, 0, 0, 0, 0);
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(98, 432);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(55, 20);
            this.lEmail.TabIndex = 13;
            this.lEmail.Text = "E-mail:";
            // 
            // tfEmail
            // 
            this.tfEmail.Location = new System.Drawing.Point(173, 429);
            this.tfEmail.Name = "tfEmail";
            this.tfEmail.Size = new System.Drawing.Size(448, 27);
            this.tfEmail.TabIndex = 14;
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(84, 499);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(69, 20);
            this.lTelefone.TabIndex = 15;
            this.lTelefone.Text = "Telefone:";
            // 
            // tfTelefone
            // 
            this.tfTelefone.Location = new System.Drawing.Point(172, 496);
            this.tfTelefone.Name = "tfTelefone";
            this.tfTelefone.Size = new System.Drawing.Size(449, 27);
            this.tfTelefone.TabIndex = 16;
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Location = new System.Drawing.Point(79, 564);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(74, 20);
            this.lEndereco.TabIndex = 17;
            this.lEndereco.Text = "Endereço:";
            // 
            // tfEndereco
            // 
            this.tfEndereco.Location = new System.Drawing.Point(172, 561);
            this.tfEndereco.Name = "tfEndereco";
            this.tfEndereco.Size = new System.Drawing.Size(449, 27);
            this.tfEndereco.TabIndex = 18;
            // 
            // tfId
            // 
            this.tfId.Location = new System.Drawing.Point(173, 30);
            this.tfId.Name = "tfId";
            this.tfId.Size = new System.Drawing.Size(65, 27);
            this.tfId.TabIndex = 19;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(399, 641);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(94, 38);
            this.btnCadastro.TabIndex = 20;
            this.btnCadastro.Text = "Cadastrar";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(527, 641);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 38);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroCondutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 707);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.tfId);
            this.Controls.Add(this.tfEndereco);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.tfTelefone);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.tfEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.lCnh);
            this.Controls.Add(this.tfCnh);
            this.Controls.Add(this.tfCpfCnpj);
            this.Controls.Add(this.lCpfCnpj);
            this.Controls.Add(this.tfNome);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.cbxClienteCondutor);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lCliente);
            this.Controls.Add(this.lId);
            this.Name = "TelaCadastroCondutor";
            this.Text = "TelaCadastroCondutor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lId;
        private Label lCliente;
        private ComboBox cbCliente;
        private CheckBox cbxClienteCondutor;
        private Label lNome;
        private TextBox tfNome;
        private Label lCpfCnpj;
        private TextBox tfCpfCnpj;
        private TextBox tfCnh;
        private Label lCnh;
        private Label lData;
        private DateTimePicker dtpData;
        private Label lEmail;
        private TextBox tfEmail;
        private Label lTelefone;
        private TextBox tfTelefone;
        private Label lEndereco;
        private TextBox tfEndereco;
        private TextBox tfId;
        private Button btnCadastro;
        private Button btnCancelar;
    }
}