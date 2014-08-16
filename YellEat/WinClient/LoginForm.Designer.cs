namespace WinClient
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.用户名 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(173, 127);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(104, 29);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(144, 21);
            this.tbxUserName.TabIndex = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(104, 81);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(144, 21);
            this.tbxPassword.TabIndex = 2;
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Location = new System.Drawing.Point(31, 38);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(41, 12);
            this.用户名.TabIndex = 3;
            this.用户名.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密 码";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.用户名);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.Text = "管理员登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.Label label2;
    }
}

