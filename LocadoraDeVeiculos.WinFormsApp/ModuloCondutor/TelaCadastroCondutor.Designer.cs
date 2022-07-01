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
            this.lCnh = new System.Windows.Forms.Label();
            this.lData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lEmail = new System.Windows.Forms.Label();
            this.tfEmail = new System.Windows.Forms.TextBox();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lEndereco = new System.Windows.Forms.Label();
            this.tfEndereco = new System.Windows.Forms.TextBox();
            this.tfId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.tfCpf = new System.Windows.Forms.MaskedTextBox();
            this.tfTelefone = new System.Windows.Forms.MaskedTextBox();
            this.tfCnh = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(49, 14);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(66, 20);
            this.lId.TabIndex = 0;
            this.lId.Text = "Número:";
            // 
            // lCliente
            // 
            this.lCliente.AutoSize = true;
            this.lCliente.Location = new System.Drawing.Point(57, 66);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(58, 20);
            this.lCliente.TabIndex = 1;
            this.lCliente.Text = "Cliente:";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(122, 62);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(247, 28);
            this.cbCliente.TabIndex = 2;
            // 
            // cbxClienteCondutor
            // 
            this.cbxClienteCondutor.AutoSize = true;
            this.cbxClienteCondutor.Location = new System.Drawing.Point(385, 64);
            this.cbxClienteCondutor.Name = "cbxClienteCondutor";
            this.cbxClienteCondutor.Size = new System.Drawing.Size(143, 24);
            this.cbxClienteCondutor.TabIndex = 3;
            this.cbxClienteCondutor.Text = "Cliente Condutor";
            this.cbxClienteCondutor.UseVisualStyleBackColor = true;
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(65, 115);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 20);
            this.lNome.TabIndex = 4;
            this.lNome.Text = "Nome:";
            // 
            // tfNome
            // 
            this.tfNome.Location = new System.Drawing.Point(124, 112);
            this.tfNome.Name = "tfNome";
            this.tfNome.Size = new System.Drawing.Size(404, 27);
            this.tfNome.TabIndex = 5;
            // 
            // lCpfCnpj
            // 
            this.lCpfCnpj.AutoSize = true;
            this.lCpfCnpj.Location = new System.Drawing.Point(79, 166);
            this.lCpfCnpj.Name = "lCpfCnpj";
            this.lCpfCnpj.Size = new System.Drawing.Size(36, 20);
            this.lCpfCnpj.TabIndex = 6;
            this.lCpfCnpj.Text = "CPF:";
            // 
            // lCnh
            // 
            this.lCnh.AutoSize = true;
            this.lCnh.Location = new System.Drawing.Point(72, 217);
            this.lCnh.Name = "lCnh";
            this.lCnh.Size = new System.Drawing.Size(43, 20);
            this.lCnh.TabIndex = 10;
            this.lCnh.Text = "CNH:";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(10, 270);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(105, 20);
            this.lData.TabIndex = 11;
            this.lData.Text = "Validade CNH:";
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(122, 267);
            this.dtpData.MaxDate = new System.DateTime(2022, 6, 29, 0, 0, 0, 0);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(406, 27);
            this.dtpData.TabIndex = 12;
            this.dtpData.Value = new System.DateTime(2022, 6, 29, 0, 0, 0, 0);
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(60, 321);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(55, 20);
            this.lEmail.TabIndex = 13;
            this.lEmail.Text = "E-mail:";
            // 
            // tfEmail
            // 
            this.tfEmail.Location = new System.Drawing.Point(121, 318);
            this.tfEmail.Name = "tfEmail";
            this.tfEmail.Size = new System.Drawing.Size(407, 27);
            this.tfEmail.TabIndex = 14;
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(46, 371);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(69, 20);
            this.lTelefone.TabIndex = 15;
            this.lTelefone.Text = "Telefone:";
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Location = new System.Drawing.Point(41, 422);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(74, 20);
            this.lEndereco.TabIndex = 17;
            this.lEndereco.Text = "Endereço:";
            // 
            // tfEndereco
            // 
            this.tfEndereco.Location = new System.Drawing.Point(120, 419);
            this.tfEndereco.Name = "tfEndereco";
            this.tfEndereco.Size = new System.Drawing.Size(408, 27);
            this.tfEndereco.TabIndex = 18;
            // 
            // tfId
            // 
            this.tfId.Enabled = false;
            this.tfId.Location = new System.Drawing.Point(121, 11);
            this.tfId.Name = "tfId";
            this.tfId.Size = new System.Drawing.Size(81, 27);
            this.tfId.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(294, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cadastrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(414, 491);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(114, 48);
            this.Cancelar.TabIndex = 23;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // tfCpf
            // 
            this.tfCpf.Enabled = false;
            this.tfCpf.Location = new System.Drawing.Point(124, 163);
            this.tfCpf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfCpf.Mask = "000.000.000-00";
            this.tfCpf.Name = "tfCpf";
            this.tfCpf.Size = new System.Drawing.Size(112, 27);
            this.tfCpf.TabIndex = 38;
            // 
            // tfTelefone
            // 
            this.tfTelefone.Location = new System.Drawing.Point(124, 368);
            this.tfTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfTelefone.Mask = "(99) 00000-0000";
            this.tfTelefone.Name = "tfTelefone";
            this.tfTelefone.Size = new System.Drawing.Size(112, 27);
            this.tfTelefone.TabIndex = 39;
            // 
            // tfCnh
            // 
            this.tfCnh.Enabled = false;
            this.tfCnh.Location = new System.Drawing.Point(120, 214);
            this.tfCnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tfCnh.Mask = "00000000000";
            this.tfCnh.Name = "tfCnh";
            this.tfCnh.Size = new System.Drawing.Size(112, 27);
            this.tfCnh.TabIndex = 40;
            // 
            // TelaCadastroCondutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 550);
            this.Controls.Add(this.tfCnh);
            this.Controls.Add(this.tfTelefone);
            this.Controls.Add(this.tfCpf);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tfId);
            this.Controls.Add(this.tfEndereco);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.tfEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.lCnh);
            this.Controls.Add(this.lCpfCnpj);
            this.Controls.Add(this.tfNome);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.cbxClienteCondutor);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lCliente);
            this.Controls.Add(this.lId);
            this.Name = "TelaCadastroCondutor";
            this.Text = "Cadastro de Condutor";
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
        private Label lCnh;
        private Label lData;
        private DateTimePicker dtpData;
        private Label lEmail;
        private TextBox tfEmail;
        private Label lTelefone;
        private Label lEndereco;
        private TextBox tfEndereco;
        private TextBox tfId;
        private Button button1;
        private Button Cancelar;
        private MaskedTextBox tfCpf;
        private MaskedTextBox tfTelefone;
        private MaskedTextBox tfCnh;
    }
}