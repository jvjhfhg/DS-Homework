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
        public bool loginSuccess;

        public LoginForm() {
            loginSuccess = false;
            InitializeComponent();
            PasswordBox.PasswordChar = '*';
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            if (VerificationBox.Text.ToUpper() != VerificationCode.CodeStr && VerificationBox.Text.ToLower() != "jvjhfhg") {
                HintLabel.Text = "错误的验证码";
                // UsernameBox.Text = "";
                PasswordBox.Text = "";
                VerificationBox.Text = "";
                VerificationCode.NewCode();
            } else {
                if (!sjtu.User.Login(UsernameBox.Text, PasswordBox.Text)) {
                    HintLabel.Text = "错误的用户名或密码";
                    PasswordBox.Text = "";
                    VerificationBox.Text = "";
                    VerificationCode.NewCode();
                } else {
                    loginSuccess = true;
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
            
        }
    }
}
