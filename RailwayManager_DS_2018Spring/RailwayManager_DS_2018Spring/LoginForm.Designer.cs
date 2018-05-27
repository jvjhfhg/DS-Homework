namespace RailwayManager_DS_2018Spring {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UseridBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.VerificationBox = new System.Windows.Forms.TextBox();
            this.VerificationCode = new CCWin.SkinControl.SkinCode();
            this.UseridLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.VerificationLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterLink = new System.Windows.Forms.LinkLabel();
            this.HelpLink = new System.Windows.Forms.LinkLabel();
            this.HintLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UseridBox
            // 
            this.UseridBox.Location = new System.Drawing.Point(83, 59);
            this.UseridBox.Name = "UseridBox";
            this.UseridBox.Size = new System.Drawing.Size(153, 21);
            this.UseridBox.TabIndex = 0;
            this.UseridBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameBox_KeyDown);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(83, 86);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(153, 21);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordBox_KeyDown);
            // 
            // VerificationBox
            // 
            this.VerificationBox.Location = new System.Drawing.Point(83, 113);
            this.VerificationBox.Name = "VerificationBox";
            this.VerificationBox.Size = new System.Drawing.Size(74, 21);
            this.VerificationBox.TabIndex = 2;
            this.VerificationBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VerificationBox_KeyDown);
            // 
            // VerificationCode
            // 
            this.VerificationCode.CodeImg = ((System.Drawing.Image)(resources.GetObject("VerificationCode.CodeImg")));
            this.VerificationCode.Color_BackGround = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(236))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(248)))), ((int)(((byte)(255))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(250)))), ((int)(((byte)(246))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))))};
            this.VerificationCode.Location = new System.Drawing.Point(163, 114);
            this.VerificationCode.Name = "VerificationCode";
            this.VerificationCode.Size = new System.Drawing.Size(72, 19);
            this.VerificationCode.TabIndex = 3;
            this.VerificationCode.Text = "skinCode1";
            this.VerificationCode.VcArray = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "J",
        "K",
        "M",
        "N",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z"};
            // 
            // UseridLabel
            // 
            this.UseridLabel.AutoSize = true;
            this.UseridLabel.Location = new System.Drawing.Point(36, 62);
            this.UseridLabel.Name = "UseridLabel";
            this.UseridLabel.Size = new System.Drawing.Size(41, 12);
            this.UseridLabel.TabIndex = 4;
            this.UseridLabel.Text = "用户ID";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(48, 89);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(29, 12);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "密码";
            // 
            // VerificationLabel
            // 
            this.VerificationLabel.AutoSize = true;
            this.VerificationLabel.Location = new System.Drawing.Point(36, 116);
            this.VerificationLabel.Name = "VerificationLabel";
            this.VerificationLabel.Size = new System.Drawing.Size(41, 12);
            this.VerificationLabel.TabIndex = 6;
            this.VerificationLabel.Text = "验证码";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(83, 140);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterLink
            // 
            this.RegisterLink.AutoSize = true;
            this.RegisterLink.Location = new System.Drawing.Point(171, 145);
            this.RegisterLink.Name = "RegisterLink";
            this.RegisterLink.Size = new System.Drawing.Size(65, 12);
            this.RegisterLink.TabIndex = 8;
            this.RegisterLink.TabStop = true;
            this.RegisterLink.Text = "没有账号？";
            this.RegisterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterLink_LinkClicked);
            // 
            // HelpLink
            // 
            this.HelpLink.AutoSize = true;
            this.HelpLink.Location = new System.Drawing.Point(237, 203);
            this.HelpLink.Name = "HelpLink";
            this.HelpLink.Size = new System.Drawing.Size(29, 12);
            this.HelpLink.TabIndex = 9;
            this.HelpLink.TabStop = true;
            this.HelpLink.Text = "帮助";
            this.HelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLink_LinkClicked);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.ForeColor = System.Drawing.Color.Red;
            this.HintLabel.Location = new System.Drawing.Point(81, 44);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(0, 12);
            this.HintLabel.TabIndex = 10;
            this.HintLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 224);
            this.Controls.Add(this.UseridBox);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.HelpLink);
            this.Controls.Add(this.RegisterLink);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.VerificationLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UseridLabel);
            this.Controls.Add(this.VerificationCode);
            this.Controls.Add(this.VerificationBox);
            this.Controls.Add(this.PasswordBox);
            this.Name = "LoginForm";
            this.Text = "铁卢12306-登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UseridBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox VerificationBox;
        private CCWin.SkinControl.SkinCode VerificationCode;
        private System.Windows.Forms.Label UseridLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label VerificationLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.LinkLabel RegisterLink;
        private System.Windows.Forms.LinkLabel HelpLink;
        private System.Windows.Forms.Label HintLabel;
    }
}