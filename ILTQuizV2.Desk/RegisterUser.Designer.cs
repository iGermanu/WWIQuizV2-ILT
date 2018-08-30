namespace ILTQuizV2.Desk
{
    partial class RegisterUser
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LblRegister = new System.Windows.Forms.LinkLabel();
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.PnlRegister = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.LblLogar = new System.Windows.Forms.LinkLabel();
            this.PnlLogin.SuspendLayout();
            this.PnlRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans Cond", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(59, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "IDENTIFIQUE-SE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 29);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(160, 29);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Logar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LblRegister
            // 
            this.LblRegister.AutoSize = true;
            this.LblRegister.Location = new System.Drawing.Point(12, 149);
            this.LblRegister.Name = "LblRegister";
            this.LblRegister.Size = new System.Drawing.Size(256, 22);
            this.LblRegister.TabIndex = 6;
            this.LblRegister.TabStop = true;
            this.LblRegister.Text = "Não tem uma conta? Registre-se";
            this.LblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblRegister_LinkClicked);
            // 
            // PnlLogin
            // 
            this.PnlLogin.Controls.Add(this.label1);
            this.PnlLogin.Controls.Add(this.label2);
            this.PnlLogin.Controls.Add(this.button1);
            this.PnlLogin.Controls.Add(this.textBox1);
            this.PnlLogin.Controls.Add(this.textBox2);
            this.PnlLogin.Location = new System.Drawing.Point(14, 37);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.Size = new System.Drawing.Size(254, 108);
            this.PnlLogin.TabIndex = 7;
            // 
            // PnlRegister
            // 
            this.PnlRegister.Controls.Add(this.label4);
            this.PnlRegister.Controls.Add(this.label5);
            this.PnlRegister.Controls.Add(this.button2);
            this.PnlRegister.Controls.Add(this.textBox3);
            this.PnlRegister.Controls.Add(this.textBox4);
            this.PnlRegister.Location = new System.Drawing.Point(13, 38);
            this.PnlRegister.Name = "PnlRegister";
            this.PnlRegister.Size = new System.Drawing.Size(254, 108);
            this.PnlRegister.TabIndex = 8;
            this.PnlRegister.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Senha:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Registrar-se";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(160, 29);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(85, 37);
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '*';
            this.textBox4.Size = new System.Drawing.Size(160, 29);
            this.textBox4.TabIndex = 4;
            // 
            // LblLogar
            // 
            this.LblLogar.AutoSize = true;
            this.LblLogar.Location = new System.Drawing.Point(18, 149);
            this.LblLogar.Name = "LblLogar";
            this.LblLogar.Size = new System.Drawing.Size(242, 22);
            this.LblLogar.TabIndex = 9;
            this.LblLogar.TabStop = true;
            this.LblLogar.Text = "Já possui uma conta? Logue-se";
            this.LblLogar.Visible = false;
            this.LblLogar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblLogar_LinkClicked);
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 180);
            this.Controls.Add(this.PnlLogin);
            this.Controls.Add(this.PnlRegister);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblLogar);
            this.Controls.Add(this.LblRegister);
            this.Font = new System.Drawing.Font("Noto Sans", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegisterUser";
            this.Text = "Login | Registro";
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            this.PnlRegister.ResumeLayout(false);
            this.PnlRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel LblRegister;
        private System.Windows.Forms.Panel PnlLogin;
        private System.Windows.Forms.Panel PnlRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.LinkLabel LblLogar;
    }
}

