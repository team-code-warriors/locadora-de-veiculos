namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    partial class TelaCadastroGrupoDeVeiculos
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
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(106, 115);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(101, 44);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(213, 115);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 43);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(84, 53);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(230, 27);
            this.textBoxNome.TabIndex = 3;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Enabled = false;
            this.textBoxNumero.Location = new System.Drawing.Point(84, 10);
            this.textBoxNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(74, 27);
            this.textBoxNumero.TabIndex = 5;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(12, 13);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(66, 20);
            this.labelNumero.TabIndex = 4;
            this.labelNumero.Text = "Número:";
            // 
            // TelaCadastroGrupoDeVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 170);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroGrupoDeVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Grupo de Veículos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCadastrar;
        private Button btnCancelar;
        private Label label1;
        private TextBox textBoxNome;
        private TextBox textBoxNumero;
        private Label labelNumero;
    }
}