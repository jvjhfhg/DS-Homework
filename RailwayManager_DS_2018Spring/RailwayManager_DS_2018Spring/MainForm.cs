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
    public partial class MainForm: Form {
        public MainForm() {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (!loginForm.loginSuccess) {
                Environment.Exit(0);
            }
            InitializeComponent();
        }
    }
}
