namespace GerenciadorSenhas
{
    partial class frmAlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlterarSenha));
            this.pnlAlterarSenha = new System.Windows.Forms.Panel();
            this.txtSenhaAnterior = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSenhaNova = new System.Windows.Forms.Button();
            this.txtNovaSenhaConf = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlAlterarSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAlterarSenha
            // 
            this.pnlAlterarSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlAlterarSenha.Controls.Add(this.txtSenhaAnterior);
            this.pnlAlterarSenha.Controls.Add(this.label9);
            this.pnlAlterarSenha.Controls.Add(this.label8);
            this.pnlAlterarSenha.Controls.Add(this.label7);
            this.pnlAlterarSenha.Controls.Add(this.btnSenhaNova);
            this.pnlAlterarSenha.Controls.Add(this.txtNovaSenhaConf);
            this.pnlAlterarSenha.Controls.Add(this.txtNovaSenha);
            this.pnlAlterarSenha.Controls.Add(this.label6);
            this.pnlAlterarSenha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlterarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAlterarSenha.Location = new System.Drawing.Point(0, 0);
            this.pnlAlterarSenha.Name = "pnlAlterarSenha";
            this.pnlAlterarSenha.Size = new System.Drawing.Size(499, 327);
            this.pnlAlterarSenha.TabIndex = 4;
            this.pnlAlterarSenha.Visible = false;
            // 
            // txtSenhaAnterior
            // 
            this.txtSenhaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaAnterior.Location = new System.Drawing.Point(25, 103);
            this.txtSenhaAnterior.Name = "txtSenhaAnterior";
            this.txtSenhaAnterior.PasswordChar = '*';
            this.txtSenhaAnterior.Size = new System.Drawing.Size(452, 32);
            this.txtSenhaAnterior.TabIndex = 1;
            this.txtSenhaAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaAnterior.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenhaAnterior_KeyDown);
            this.txtSenhaAnterior.Validated += new System.EventHandler(this.txtSenhaAnterior_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 26);
            this.label9.TabIndex = 0;
            this.label9.Text = "Senha anterior";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Confirmar a senha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nova senha";
            // 
            // btnSenhaNova
            // 
            this.btnSenhaNova.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSenhaNova.Location = new System.Drawing.Point(25, 264);
            this.btnSenhaNova.Name = "btnSenhaNova";
            this.btnSenhaNova.Size = new System.Drawing.Size(452, 44);
            this.btnSenhaNova.TabIndex = 4;
            this.btnSenhaNova.Text = "Alterar";
            this.btnSenhaNova.UseVisualStyleBackColor = true;
            this.btnSenhaNova.Click += new System.EventHandler(this.btnSenhaNova_Click);
            // 
            // txtNovaSenhaConf
            // 
            this.txtNovaSenhaConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovaSenhaConf.Location = new System.Drawing.Point(25, 227);
            this.txtNovaSenhaConf.Name = "txtNovaSenhaConf";
            this.txtNovaSenhaConf.PasswordChar = '*';
            this.txtNovaSenhaConf.Size = new System.Drawing.Size(452, 31);
            this.txtNovaSenhaConf.TabIndex = 3;
            this.txtNovaSenhaConf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovaSenha.Location = new System.Drawing.Point(25, 166);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.PasswordChar = '*';
            this.txtNovaSenha.Size = new System.Drawing.Size(452, 31);
            this.txtNovaSenha.TabIndex = 2;
            this.txtNovaSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(488, 46);
            this.label6.TabIndex = 0;
            this.label6.Text = "Alterar senha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 327);
            this.Controls.Add(this.pnlAlterarSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlterarSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha";
            this.pnlAlterarSenha.ResumeLayout(false);
            this.pnlAlterarSenha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAlterarSenha;
        private System.Windows.Forms.TextBox txtSenhaAnterior;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSenhaNova;
        private System.Windows.Forms.TextBox txtNovaSenhaConf;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.Label label6;
    }
}