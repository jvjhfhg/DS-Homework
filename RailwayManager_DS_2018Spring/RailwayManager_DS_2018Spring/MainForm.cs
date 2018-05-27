using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayManager_DS_2018Spring {
    public partial class MainForm: Form {
        public MainForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        User currentUser;

        private void TrainDataInitation() {
            DataTable trainData = new DataTable();
            trainData.Columns.Add(new DataColumn("车次"));
            trainData.Columns.Add(new DataColumn("始发站"));
            trainData.Columns.Add(new DataColumn("终点站"));

            DataRow row1 = trainData.NewRow();
            row1["车次"] = "K282"; ;
            row1["始发站"] = "上海";
            row1["终点站"] = "绵阳";

            trainData.Rows.Add(row1);

            TicketGrid.DataSource = trainData;
            TicketGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TicketGrid.MultiSelect = false;
            for (int i = 0; i < 3; ++i) {
                TicketGrid.Columns[i].ReadOnly = true;
                TicketGrid.Columns[i].Width = 185;
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            /*LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.loginUser == -1) {
                Environment.Exit(0);
            }

            currentUser = Database.QueryProfile(loginForm.loginUser);*/

            currentUser = Database.QueryProfile(2018);

            TrainDataInitation();
        }
    }
}
