namespace MyCourseWork
{
    partial class loginForm
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
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lablel1 = new System.Windows.Forms.Label();
            this.loginLoginTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginLoginButton = new System.Windows.Forms.Button();
            this.loginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.label2);
            this.loginGroupBox.Controls.Add(this.lablel1);
            this.loginGroupBox.Controls.Add(this.loginLoginTextBox);
            this.loginGroupBox.Controls.Add(this.loginPasswordTextBox);
            this.loginGroupBox.Controls.Add(this.loginLoginButton);
            this.loginGroupBox.Location = new System.Drawing.Point(12, 12);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(377, 137);
            this.loginGroupBox.TabIndex = 0;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Введите логин и пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль:";
            // 
            // lablel1
            // 
            this.lablel1.AutoSize = true;
            this.lablel1.Location = new System.Drawing.Point(24, 24);
            this.lablel1.Name = "lablel1";
            this.lablel1.Size = new System.Drawing.Size(51, 17);
            this.lablel1.TabIndex = 3;
            this.lablel1.Text = "Логин:";
            // 
            // loginLoginTextBox
            // 
            this.loginLoginTextBox.Location = new System.Drawing.Point(117, 21);
            this.loginLoginTextBox.Name = "loginLoginTextBox";
            this.loginLoginTextBox.Size = new System.Drawing.Size(254, 22);
            this.loginLoginTextBox.TabIndex = 0;
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Location = new System.Drawing.Point(117, 49);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.PasswordChar = '•';
            this.loginPasswordTextBox.Size = new System.Drawing.Size(254, 22);
            this.loginPasswordTextBox.TabIndex = 1;
            // 
            // loginLoginButton
            // 
            this.loginLoginButton.Location = new System.Drawing.Point(6, 77);
            this.loginLoginButton.Name = "loginLoginButton";
            this.loginLoginButton.Size = new System.Drawing.Size(365, 54);
            this.loginLoginButton.TabIndex = 2;
            this.loginLoginButton.Text = "Войти";
            this.loginLoginButton.UseVisualStyleBackColor = true;
            this.loginLoginButton.Click += new System.EventHandler(this.loginLoginButton_Click);
            this.loginLoginButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginLoginButton_KeyPress);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 161);
            this.Controls.Add(this.loginGroupBox);
            this.Name = "loginForm";
            this.Text = "Form1";
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lablel1;
        private System.Windows.Forms.TextBox loginLoginTextBox;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Button loginLoginButton;
    }
}

