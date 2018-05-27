namespace RailwayManager_DS_2018Spring {
    partial class RegisterForm {
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.HintLabel = new System.Windows.Forms.Label();
            this.CancelRegButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(48, 41);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(41, 12);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "用户名";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(60, 68);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(29, 12);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "密码";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(95, 38);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(140, 21);
            this.UsernameBox.TabIndex = 2;
            this.UsernameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameBox_KeyDown);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(95, 65);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(140, 21);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordBox_KeyDown);
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(95, 92);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(140, 21);
            this.EmailBox.TabIndex = 4;
            this.EmailBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmailBox_KeyDown);
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(95, 119);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(140, 21);
            this.PhoneBox.TabIndex = 5;
            this.PhoneBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneBox_KeyDown);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(36, 95);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(53, 12);
            this.EmailLabel.TabIndex = 6;
            this.EmailLabel.Text = "电子邮箱";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(36, 122);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(53, 12);
            this.PhoneLabel.TabIndex = 7;
            this.PhoneLabel.Text = "电话号码";
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(38, 155);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 8;
            this.EnterButton.Text = "注册";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.ForeColor = System.Drawing.Color.Red;
            this.HintLabel.Location = new System.Drawing.Point(48, 192);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(0, 12);
            this.HintLabel.TabIndex = 9;
            // 
            // CancelRegButton
            // 
            this.CancelRegButton.Location = new System.Drawing.Point(119, 155);
            this.CancelRegButton.Name = "CancelRegButton";
            this.CancelRegButton.Size = new System.Drawing.Size(124, 23);
            this.CancelRegButton.TabIndex = 10;
            this.CancelRegButton.Text = "我不注册了，JOJO";
            this.CancelRegButton.UseVisualStyleBackColor = true;
            this.CancelRegButton.Click += new System.EventHandler(this.CancelRegButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 224);
            this.Controls.Add(this.CancelRegButton);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Name = "RegisterForm";
            this.Text = "铁卢12306-注册新用户";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Button CancelRegButton;
    }
}