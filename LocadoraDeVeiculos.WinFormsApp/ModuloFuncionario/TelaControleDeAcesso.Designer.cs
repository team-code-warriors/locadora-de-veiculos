namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    partial class TelaControleDeAcesso
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
            this.lLogin = new System.Windows.Forms.Label();
            this.lSenha = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.btnAcessar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(12, 19);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(49, 20);
            this.lLogin.TabIndex = 0;
            this.lLogin.Text = "Login:";
            // 
            // lSenha
            // 
            this.lSenha.AutoSize = true;
            this.lSenha.Location = new System.Drawing.Point(9, 70);
            this.lSenha.Name = "lSenha";
            this.lSenha.Size = new System.Drawing.Size(52, 20);
            this.lSenha.TabIndex = 1;
            this.lSenha.Text = "Senha:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(67, 16);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(262, 27);
            this.tbLogin.TabIndex = 2;
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(67, 67);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(262, 27);
            this.tbSenha.TabIndex = 3;
            // 
            // btnAcessar
            // 
            this.btnAcessar.Location = new System.Drawing.Point(114, 133);
            this.btnAcessar.Name = "btnAcessar";
            this.btnAcessar.Size = new System.Drawing.Size(105, 46);
            this.btnAcessar.TabIndex = 4;
            this.btnAcessar.Text = "Acessar";
            this.btnAcessar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(224, 133);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 46);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaControleDeAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 190);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAcessar);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lSenha);
            this.Controls.Add(this.lLogin);
            this.Name = "TelaControleDeAcesso";
            this.Text = "Controle de Acesso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lLogin;
        private Label lSenha;
        private TextBox tbLogin;
        private TextBox tbSenha;
        private Button btnAcessar;
        private Button btnCancelar;
    }
}