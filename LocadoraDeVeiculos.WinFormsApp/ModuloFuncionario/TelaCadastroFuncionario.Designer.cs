namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    partial class TelaCadastroFuncionario
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
            this.lData = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.lSenha = new System.Windows.Forms.Label();
            this.lTipoPerfil = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.cbTipoPerfil = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbSalario = new System.Windows.Forms.TextBox();
            this.lSalario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(80, 32);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(66, 20);
            this.lNumero.TabIndex = 0;
            this.lNumero.Text = "Número:";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(93, 85);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(53, 20);
            this.lNome.TabIndex = 1;
            this.lNome.Text = "Nome:";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(12, 198);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(134, 20);
            this.lData.TabIndex = 2;
            this.lData.Text = "Data de Admissão:";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(97, 250);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(49, 20);
            this.lLogin.TabIndex = 3;
            this.lLogin.Text = "Login:";
            // 
            // lSenha
            // 
            this.lSenha.AutoSize = true;
            this.lSenha.Location = new System.Drawing.Point(94, 306);
            this.lSenha.Name = "lSenha";
            this.lSenha.Size = new System.Drawing.Size(52, 20);
            this.lSenha.TabIndex = 4;
            this.lSenha.Text = "Senha:";
            // 
            // lTipoPerfil
            // 
            this.lTipoPerfil.AutoSize = true;
            this.lTipoPerfil.Location = new System.Drawing.Point(46, 360);
            this.lTipoPerfil.Name = "lTipoPerfil";
            this.lTipoPerfil.Size = new System.Drawing.Size(100, 20);
            this.lTipoPerfil.TabIndex = 5;
            this.lTipoPerfil.Text = "Tipo de Perfil:";
            // 
            // tbNumero
            // 
            this.tbNumero.Enabled = false;
            this.tbNumero.Location = new System.Drawing.Point(152, 29);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(301, 27);
            this.tbNumero.TabIndex = 6;
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(152, 82);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(301, 27);
            this.tbNome.TabIndex = 7;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(152, 247);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(301, 27);
            this.tbLogin.TabIndex = 8;
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(152, 303);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(301, 27);
            this.tbSenha.TabIndex = 9;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(152, 195);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(301, 27);
            this.dtpData.TabIndex = 10;
            // 
            // cbTipoPerfil
            // 
            this.cbTipoPerfil.FormattingEnabled = true;
            this.cbTipoPerfil.Items.AddRange(new object[] {
            "Comum",
            "Administrador"});
            this.cbTipoPerfil.Location = new System.Drawing.Point(152, 356);
            this.cbTipoPerfil.Name = "cbTipoPerfil";
            this.cbTipoPerfil.Size = new System.Drawing.Size(301, 28);
            this.cbTipoPerfil.TabIndex = 11;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(233, 425);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(107, 43);
            this.btnCadastrar.TabIndex = 12;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(346, 425);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 43);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tbSalario
            // 
            this.tbSalario.Location = new System.Drawing.Point(152, 138);
            this.tbSalario.Name = "tbSalario";
            this.tbSalario.Size = new System.Drawing.Size(301, 27);
            this.tbSalario.TabIndex = 15;
            // 
            // lSalario
            // 
            this.lSalario.AutoSize = true;
            this.lSalario.Location = new System.Drawing.Point(88, 141);
            this.lSalario.Name = "lSalario";
            this.lSalario.Size = new System.Drawing.Size(58, 20);
            this.lSalario.TabIndex = 14;
            this.lSalario.Text = "Salário:";
            // 
            // TelaCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 483);
            this.Controls.Add(this.tbSalario);
            this.Controls.Add(this.lSalario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cbTipoPerfil);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lTipoPerfil);
            this.Controls.Add(this.lSenha);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.lNumero);
            this.Name = "TelaCadastroFuncionario";
            this.Text = "Cadastro de Funcionário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lNumero;
        private Label lNome;
        private Label lData;
        private Label lLogin;
        private Label lSenha;
        private Label lTipoPerfil;
        private TextBox tbNumero;
        private TextBox tbNome;
        private TextBox tbLogin;
        private TextBox tbSenha;
        private DateTimePicker dtpData;
        private ComboBox cbTipoPerfil;
        private Button btnCadastrar;
        private Button btnCancelar;
        private TextBox tbSalario;
        private Label lSalario;
    }
}