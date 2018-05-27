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
    public partial class RegisterForm: Form {
        public RegisterForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void RegisterForm_Load(object sender, EventArgs e) {
            PasswordBox.PasswordChar = '*';
        }

        private bool CheckUserInfo() {
            if (UsernameBox.TextLength == 0 || PasswordBox.TextLength == 0 || EmailBox.TextLength == 0 || PhoneBox.TextLength == 0) {
                HintLabel.Text = "用户名、密码、邮箱、电话号码不能为空";
                return false;
            }

            int findAt = 0;
            foreach (char ch in EmailBox.Text) {
                if (ch == '@') {
                    if (findAt == 0) findAt = 1;
                    else findAt = 2;
                }
            }
            if (findAt != 1 || EmailBox.Text.First() == '@' || EmailBox.Text.Last() == '@') {
                HintLabel.Text = "不合法的邮箱";
                return false;
            }

            string phone = PhoneBox.Text;
            if (phone.First() == '+') {
                phone = phone.Substring(1);
            }
            if (phone.First() == '-' || phone.Last() == '-') {
                HintLabel.Text = "不合法的手机号";
                return false;
            }
            foreach (char ch in phone) {
                if ((ch < '0' || ch > '9') && ch != '-') {
                    HintLabel.Text = "不合法的手机号";
                    return false;
                }
            }
            
            return true;
        }

        private void EnterButton_Click(object sender, EventArgs e) {
            if (!CheckUserInfo()) {
                return;
            }
            int newUser = Database.Register(UsernameBox.Text, PasswordBox.Text, EmailBox.Text, PasswordBox.Text);
            if (newUser == -1) {
                HintLabel.Text = "用户已存在";
                return;
            }
            HintLabel.Text = "";
            MessageBox.Show($"注册成功！\n您的ID是{newUser}，这是您的登录凭证，请务必保存好。", "铁卢12306");
            Close();
        }

        private void CancelRegButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void UsernameBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterButton_Click(sender, e);
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterButton_Click(sender, e);
            }
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterButton_Click(sender, e);
            }
        }

        private void PhoneBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                EnterButton_Click(sender, e);
            }
        }
    }
}
