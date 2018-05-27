using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayManager_DS_2018Spring {
    public partial class LoginForm: Form {
        public int loginUser;

        public LoginForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            loginUser = -1;
            PasswordBox.PasswordChar = '*';
            VerificationCode.CodeCount = 4;
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            if (VerificationBox.Text.ToUpper() != VerificationCode.CodeStr) {
                HintLabel.Text = "错误的验证码";
                // UseridBox.Text = "";
                PasswordBox.Text = "";
                VerificationBox.Text = "";
                VerificationCode.NewCode();
            } else {
                bool charValid = true;
                foreach (char ch in UseridBox.Text)
                    if (!char.IsDigit(ch)) {
                        charValid = false; break;
                    }
                if (!charValid) {
                    HintLabel.Text = "非法的用户ID";
                    UseridBox.Text = "";
                    PasswordBox.Text = "";
                    VerificationBox.Text = "";
                    VerificationCode.NewCode();
                    return;
                }
                if (!Database.Login(int.Parse(UseridBox.Text), PasswordBox.Text)) {
                    HintLabel.Text = "错误的用户ID或密码";
                    PasswordBox.Text = "";
                    VerificationBox.Text = "";
                    VerificationCode.NewCode();
                } else {
                    loginUser = int.Parse(UseridBox.Text);
                    Close();
                }
            }
        }

        private void HelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("这都要点帮助，我怀疑你这里有问题。", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void VerificationBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LoginButton_Click(sender, e);
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LoginButton_Click(sender, e);
            }
        }

        private void UsernameBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LoginButton_Click(sender, e);
            }
        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            RegisterForm registerForm = new RegisterForm();
            Hide();
            registerForm.ShowDialog();
            Show();
        }
    }
}
