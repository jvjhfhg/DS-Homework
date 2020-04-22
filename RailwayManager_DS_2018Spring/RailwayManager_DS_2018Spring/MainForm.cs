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

            CatalogBox.CharacterCasing = CharacterCasing.Upper;
            CatalogBox2.CharacterCasing = CharacterCasing.Upper;
            TrainCatalogBox.CharacterCasing = CharacterCasing.Upper;
        }

        User currentUser;
        DataTable ticketData, orderData, trainData, ticketKindData;

        private void LoginPage(int preUser = -1) {
            LoginForm loginForm = new LoginForm(preUser);
            loginForm.ShowDialog();
            if (loginForm.loginUser == -1) {
                Environment.Exit(0);
            }

            currentUser = Database.QueryProfile(loginForm.loginUser);
            currentUser.password = loginForm.pswd;
            WelcomeLabel.Text = "欢迎您，" + ((UserPrivilege)currentUser.priv == UserPrivilege.Admin ? "管理员" : "用户") + currentUser.name;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoginPage();

            PrivilegeBox2.ReadOnly = true;
            OrderDataInitation();
            TicketDataInitation();
            UserDataInitation();
            TicketKindInitation();
            TrainDataInitation();
        }

        private void TicketKindInitation() {
            ticketKindData = new DataTable();
            for (int i = 1; i <= 5; ++i)
                ticketKindData.Columns.Add(new DataColumn("票种" + i.ToString()));
            var row = ticketKindData.NewRow();
            for (int i = 1; i <= 5; ++i)
                row["票种" + i.ToString()] = "票种" + i.ToString();
            ticketKindData.Rows.Add(row);

            TicketKindGrid.DataSource = ticketKindData;
            TicketKindGrid.MultiSelect = false;
            TicketKindGrid.AllowUserToAddRows = false;
            TicketKindGrid.AllowUserToDeleteRows = false;
        }

        private void TrainDataInitation() {
            trainData = new DataTable();
            trainData.Columns.Add(new DataColumn("车站名"));
            trainData.Columns.Add(new DataColumn("到达时间"));
            trainData.Columns.Add(new DataColumn("发车时间"));
            trainData.Columns.Add(new DataColumn("经停时间"));
            for (int i = 1; i <= 5; ++i)
                trainData.Columns.Add(new DataColumn($"价格(票种{i.ToString()})"));
            
            TrainDataGrid.DataSource = trainData;
            TrainDataGrid.MultiSelect = false;
        }

        private void UserDataInitation() {
            IDBox.Text = currentUser.id.ToString();
            IDBox.ReadOnly = true;
            UsernameBox.Text = currentUser.name;
            PasswordBox.Text = currentUser.password;
            PasswordBox.PasswordChar = '*';
            EmailBox.Text = currentUser.email;
            PhoneBox.Text = currentUser.phone;
            PrivilegeBox.Text = (UserPrivilege)currentUser.priv == UserPrivilege.Admin ? "管理员" : "用户";
            PrivilegeBox.ReadOnly = true;
            ModifyConfirmButton.Enabled = false;
        }

        private void OrderDataInitation() {
            orderData = new DataTable();
            orderData.Columns.Add(new DataColumn("车次编号"));
            orderData.Columns.Add(new DataColumn("发车日期"));
            orderData.Columns.Add(new DataColumn("出发站"));
            orderData.Columns.Add(new DataColumn("出发时间"));
            orderData.Columns.Add(new DataColumn("到达站"));
            orderData.Columns.Add(new DataColumn("到达时间"));
            for (int i = 1; i <= 5; ++i) {
                orderData.Columns.Add(new DataColumn("票种" + i.ToString()));
                orderData.Columns.Add(new DataColumn("余票" + i.ToString()));
                orderData.Columns.Add(new DataColumn("价格" + i.ToString()));
            }

            OrderGrid.DataSource = orderData;
            OrderGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OrderGrid.MultiSelect = false;
            for (int i = 0; i < OrderGrid.ColumnCount; ++i) {
                OrderGrid.Columns[i].ReadOnly = true;
            }
        }

        private void TicketDataInitation() {
            ticketData = new DataTable();
            ticketData.Columns.Add(new DataColumn("车次编号"));
            ticketData.Columns.Add(new DataColumn("发车日期"));
            ticketData.Columns.Add(new DataColumn("出发站"));
            ticketData.Columns.Add(new DataColumn("出发时间"));
            ticketData.Columns.Add(new DataColumn("到达站"));
            ticketData.Columns.Add(new DataColumn("到达时间"));
            for (int i = 1; i <= 5; ++i) {
                ticketData.Columns.Add(new DataColumn("票种" + i.ToString()));
                ticketData.Columns.Add(new DataColumn("余票" + i.ToString()));
                ticketData.Columns.Add(new DataColumn("价格" + i.ToString()));
            }

            TicketGrid.DataSource = ticketData;
            TicketGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TicketGrid.MultiSelect = false;
            for (int i = 0; i < TicketGrid.ColumnCount; ++i) {
                TicketGrid.Columns[i].ReadOnly = true;
            }
        }

        private void DataGridRefresh() {
            if (Loc1Box.Text.Length == 0 || Loc2Box.Text.Length == 0 || CatalogBox.Text.Length == 0) {
                MessageBox.Show("信息不足！", "铁卢12306");
                ticketData.Rows.Clear();
                return;
            }

            List<List<string>> tmp = null;

            Task t = new Task(() => {
                if (TransferChecker.Checked)
                    tmp = Database.QueryTransfer(Loc1Box.Text, Loc2Box.Text, DateBox.Text, CatalogBox.Text);
                else
                    tmp = Database.QueryTicket(Loc1Box.Text, Loc2Box.Text, DateBox.Text, CatalogBox.Text);
            });
            t.Start();
            t.Wait();

            ticketData.Rows.Clear();
            if (tmp.Count == 0) {
                MessageBox.Show("找不到符合要求的车次！", "铁卢12306");
                Loc1Box.Text = "";
                Loc2Box.Text = "";
                CatalogBox.Text = "";
                return;
            }
            for (int i = 0; i < tmp.Count; ++i) {
                DataRow row = ticketData.NewRow();
                row["车次编号"] = tmp[i][0];
                row["发车日期"] = DateBox.Text;
                row["出发站"] = tmp[i][1]; // Loc1Box.Text;
                row["出发时间"] = tmp[i][3];
                row["到达站"] = tmp[i][4]; // Loc2Box.Text;
                row["到达时间"] = tmp[i][6];
                for (int j = 1; j <= 5; ++j) {
                    if (7 + j * 3 <= tmp[i].Count) {
                        row["票种" + j.ToString()] = tmp[i][6 + j * 3 - 2];
                        row["余票" + j.ToString()] = tmp[i][6 + j * 3 - 1];
                        row["价格" + j.ToString()] = tmp[i][6 + j * 3];
                    }
                }
                ticketData.Rows.Add(row);
            }
        }

        private void OrderGridRefresh() {
            if (CatalogBox2.Text.Length == 0) {
                MessageBox.Show("信息不足！", "铁卢12306");
                orderData.Rows.Clear();
                return;
            }

            List<List<string>> tmp = null;

            Task t = new Task(() => tmp = Database.QueryOrder(currentUser.id, DateBox2.Text, CatalogBox2.Text));
            t.Start();
            t.Wait();

            orderData.Rows.Clear();
            if (tmp.Count == 0) {
                MessageBox.Show("找不到符合要求的订单！", "铁卢12306");
                CatalogBox2.Text = "";
                return;
            }
            for (int i = 0; i < tmp.Count; ++i) {
                DataRow row = orderData.NewRow();
                row["车次编号"] = tmp[i][0];
                row["发车日期"] = DateBox2.Text;
                row["出发站"] = tmp[i][1];
                row["出发时间"] = tmp[i][3];
                row["到达站"] = tmp[i][4];
                row["到达时间"] = tmp[i][6];
                for (int j = 1; j <= 5; ++j) {
                    if (7 + j * 3 <= tmp[i].Count) {
                        row["票种" + j.ToString()] = tmp[i][6 + j * 3 - 2];
                        row["余票" + j.ToString()] = tmp[i][6 + j * 3 - 1];
                        row["价格" + j.ToString()] = tmp[i][6 + j * 3];
                    }
                }
                orderData.Rows.Add(row);
            }
        }

        private void BuyButton_Click(object sender, EventArgs e) {
            if (TicketGrid.SelectedRows.Count == 0) return;
            var row = TicketGrid.SelectedRows[0];
            if (row.Index == TicketGrid.RowCount - 1) return;
            if (TicketKindBox.Text.Length != 1 || !(TicketKindBox.Text[0] >= '1' && TicketKindBox.Text[0] <= '0' + (row.Cells.Count - 6) / 3)) {
                MessageBox.Show("请输入合法的车票种类！", "铁卢12306");
                return;
            }
            foreach (char ch in TicketCntBox.Text) {
                if (!char.IsDigit(ch)) {
                    MessageBox.Show("请输入合法的购票张数！", "铁卢12306");
                    return;
                }
            }
            if (Database.BuyTicket(currentUser.id, int.Parse(TicketCntBox.Text), row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(), DateBox.Text, row.Cells[3 + 3 * int.Parse(TicketKindBox.Text)].Value.ToString())) {
                MessageBox.Show("购票成功！", "铁卢12306");
                DataGridRefresh();
            } else {
                MessageBox.Show("非法的购票请求！\n请检查您的购票张数是否超过剩余票数。", "铁卢12306");
            }
        }

        private void RefundButton_Click(object sender, EventArgs e) {
            if (OrderGrid.SelectedRows.Count == 0) return;
            var row = OrderGrid.SelectedRows[0];
            if (row.Index == OrderGrid.RowCount - 1) return;
            if (TicketKindBox2.Text.Length != 1 || !(TicketKindBox2.Text[0] >= '1' && TicketKindBox2.Text[0] <= '0' + (row.Cells.Count - 6) / 3)) {
                MessageBox.Show("请输入合法的车票种类！", "铁卢12306");
                return;
            }
            foreach (char ch in TicketCntBox2.Text) {
                if (!char.IsDigit(ch)) {
                    MessageBox.Show("请输入合法的退票张数！", "铁卢12306");
                    return;
                }
            }
            if (Database.RefundTicket(currentUser.id, int.Parse(TicketCntBox2.Text), row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(), DateBox2.Text, row.Cells[3 + 3 * int.Parse(TicketKindBox2.Text)].Value.ToString())) {
                MessageBox.Show("退票成功！", "铁卢12306");
                OrderGridRefresh();
            } else {
                MessageBox.Show("非法的退票请求！\n请检查您的退票张数是否超过订单中的购票张数。", "铁卢12306");
            }
        }

        private void QueryConfirmButton_Click(object sender, EventArgs e) {
            DataGridRefresh();
        }

        private bool CheckUserInfo() {
            if (UsernameBox.TextLength == 0 || PasswordBox.TextLength == 0 || EmailBox.TextLength == 0 || PhoneBox.TextLength == 0) {
                MessageBox.Show("用户名、密码、邮箱、电话号码不能为空！", "铁卢12306");
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
                MessageBox.Show("不合法的邮箱！", "铁卢12306");
                return false;
            }

            string phone = PhoneBox.Text;
            if (phone.First() == '+') {
                phone = phone.Substring(1);
            }
            if (phone.First() == '-' || phone.Last() == '-') {
                MessageBox.Show("不合法的手机号！", "铁卢12306");
                return false;
            }
            foreach (char ch in phone) {
                if ((ch < '0' || ch > '9') && ch != '-') {
                    MessageBox.Show("不合法的手机号！", "铁卢12306");
                    return false;
                }
            }

            return true;
        }

        private void ModifyConfirmButton_Click(object sender, EventArgs e) {
            if (!CheckUserInfo()) {
                return;
            }
            if (Database.ModifyPrifile(currentUser.id, UsernameBox.Text, PasswordBox.Text, EmailBox.Text, PhoneBox.Text)) {
                MessageBox.Show("修改成功！", "铁卢12306");
                currentUser.name = UsernameBox.Text;
                currentUser.password = PasswordBox.Text;
                currentUser.email = EmailBox.Text;
                currentUser.phone = PhoneBox.Text;
                WelcomeLabel.Text = "欢迎您，" + ((UserPrivilege)currentUser.priv == UserPrivilege.Admin ? "管理员" : "用户") + currentUser.name;
            } else {
                MessageBox.Show("修改失败！", "铁卢12306");
            }
        }

        private bool CheckModified() {
            return UsernameBox.Text != currentUser.name ||
                   PasswordBox.Text != currentUser.password ||
                   EmailBox.Text != currentUser.email ||
                   PhoneBox.Text != currentUser.phone;
        }

        private void UsernameBox_TextChanged(object sender, EventArgs e) {
            ModifyConfirmButton.Enabled = CheckModified();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e) {
            ModifyConfirmButton.Enabled = CheckModified();
        }

        private void EmailBox_TextChanged(object sender, EventArgs e) {
            ModifyConfirmButton.Enabled = CheckModified();
        }

        private void PhoneBox_TextChanged(object sender, EventArgs e) {
            ModifyConfirmButton.Enabled = CheckModified();
        }

        private void QueryConfirmButton2_Click(object sender, EventArgs e) {
            OrderGridRefresh();
        }

        private void TrainOption_Click(object sender, EventArgs e) {
            if ((UserPrivilege)currentUser.priv != UserPrivilege.Admin) {
                MessageBox.Show("对不起，您没有权限进行这项操作！", "铁卢12306");
                Options.SelectTab(0);
            }
        }

        private void QueryTrainButton_Click(object sender, EventArgs e) {
            var vec = Database.QueryTrain(TrainIDBox.Text);
            if (vec[0].Count == 1) {
                MessageBox.Show("找不到指定的列车！", "铁卢12306");
                trainData.Rows.Clear();
                for (int i = 0; i < 5; ++i)
                    TicketKindGrid.Rows[0].Cells[i].Value = "票种" + (i + 1).ToString();
                TrainNameBox.Text = "";
                TrainCatalogBox.Text = "";
                TicketKindCnt.Value = 1;
            } else {
                trainData.Rows.Clear();
                
                TrainNameBox.Text = vec[0][1];
                TrainCatalogBox.Text = vec[0][2];
                for (int i = 0; i < 5; ++i) {
                    TicketKindGrid.Rows[0].Cells[i].Value = "票种" + (i + 1).ToString();
                }
                for (int i = 5; i < vec[0].Count; ++i) {
                    TicketKindGrid.Rows[0].Cells[i - 5].Value = vec[0][i];
                }
                TicketKindCnt.Value = int.Parse(vec[0][4]);
                for (int i = 1; i < vec.Count; ++i) {
                    var row = trainData.NewRow();
                    row["车站名"] = vec[i][0];
                    row["到达时间"] = vec[i][1];
                    row["发车时间"] = vec[i][2];
                    row["经停时间"] = vec[i][3];
                    for (int j = 4; j < vec[i].Count; ++j) {
                        row[$"价格(票种{(j - 3).ToString()})"] = vec[i][j];
                    }
                    trainData.Rows.Add(row);
                }
            }
        }

        private void DeleteTrainButton_Click(object sender, EventArgs e) {
            if (Database.DeleteTrain(TrainIDBox.Text)) {
                MessageBox.Show("删除成功！", "铁卢12306");
                trainData.Rows.Clear();
                for (int i = 1; i <= 5; ++i)
                    TrainDataGrid.Columns[i + 3].HeaderCell.Value = "价格" + i.ToString();
            } else {
                MessageBox.Show("删除失败！", "铁卢12306");
            }
        }

        private void ModifyTrainButton_Click(object sender, EventArgs e) {
            List<string> cmds = new List<string> {
                TrainIDBox.Text,
                TrainNameBox.Text,
                TrainCatalogBox.Text,
                (TrainDataGrid.RowCount - 1).ToString(),
                TicketKindCnt.Value.ToString()
            };
            for (int i = 0; i < TicketKindCnt.Value; ++i)
                cmds.Add(TicketKindGrid.Rows[0].Cells[i].Value.ToString());
            for (int i = 0; i < TrainDataGrid.RowCount - 1; ++i) {
                for (int j = 0; j < 4 + TicketKindCnt.Value; ++j)
                    cmds.Add(TrainDataGrid.Rows[i].Cells[j].Value.ToString());
            }
            if (Database.ModifyTrain(cmds)) {
                MessageBox.Show("修改成功！", "铁卢12306");
                trainData.Rows.Clear();
                for (int i = 1; i <= 5; ++i)
                    TrainDataGrid.Columns[i + 3].HeaderCell.Value = "价格" + i.ToString();
            } else {
                MessageBox.Show("修改失败！", "铁卢12306");
            }
        }

        private void AddTrainButton_Click(object sender, EventArgs e) {
            List<string> cmds = new List<string> {
                TrainIDBox.Text,
                TrainNameBox.Text,
                TrainCatalogBox.Text,
                (TrainDataGrid.RowCount - 1).ToString(),
                TicketKindCnt.Value.ToString()
            };
            for (int i = 0; i < TicketKindCnt.Value; ++i)
                cmds.Add(TicketKindGrid.Rows[0].Cells[i].Value.ToString());
            for (int i = 0; i < TrainDataGrid.RowCount - 1; ++i) {
                for (int j = 0; j < 4 + TicketKindCnt.Value; ++j)
                    cmds.Add(TrainDataGrid.Rows[i].Cells[j].Value.ToString());
            }
            if (Database.AddTrain(cmds)) {
                MessageBox.Show("添加成功！", "铁卢12306");
            } else {
                MessageBox.Show("添加失败！", "铁卢12306");
            }
        }

        private void QueryPrivilegeButton_Click(object sender, EventArgs e) {
            foreach (char ch in UserIDBox.Text) {
                if (!char.IsDigit(ch)) {
                    MessageBox.Show("不是合法的用户ID！", "铁卢12306");
                    UserIDBox.Text = "";
                    PrivilegeBox2.Text = "";
                    return;
                }
            }
            var user = Database.QueryProfile(int.Parse(UserIDBox.Text));
            if (user.id == -1) {
                MessageBox.Show("该用户不存在！", "铁卢12306");
                UserIDBox.Text = "";
                PrivilegeBox2.Text = "";
                return;
            }
            PrivilegeBox2.Text = (UserPrivilege)user.priv == UserPrivilege.Admin ? "管理员" : "用户";
        }

        private void TicketKindGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            /*for (int i = 0; i < 5; ++i)
                TrainDataGrid.Columns[i + 4].HeaderCell.Value = ticketKindData.Rows[0][i];*/
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void 清空数据ToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((UserPrivilege)currentUser.priv == UserPrivilege.Admin) {
                Database.Clean();
                MessageBox.Show("清除成功！", "铁卢12306");
                LogoutToolStripMenuItem_Click(sender, e);
            } else {
                MessageBox.Show("？\n小伙子，你在玩火。", "铁卢12306");
            }
        }

        private void SaleTrainButton_Click(object sender, EventArgs e) {
            if (Database.SaleTrain(TrainIDBox.Text)) {
                MessageBox.Show("发售成功！", "铁卢12306");
            } else {
                MessageBox.Show("发售失败！", "铁卢12306");
            }
        }

        private void ModifyPrivilegeButton_Click(object sender, EventArgs e) {
            foreach (char ch in UserIDBox.Text) {
                if (!char.IsDigit(ch)) {
                    MessageBox.Show("不是合法的用户ID！", "铁卢12306");
                    UserIDBox.Text = "";
                    PrivilegeBox2.Text = "";
                    return;
                }
            }
            if (MessageBox.Show("您确定要提升该用户的权限吗？", "铁卢12306", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                if (Database.ModifyPrivilege(currentUser.id, int.Parse(UserIDBox.Text), 2)) {
                    MessageBox.Show("操作成功！", "铁卢12306");
                    PrivilegeBox2.Text = "管理员";
                } else {
                    MessageBox.Show("操作失败！", "铁卢12306");
                }
            }
        }

        private void Options_SelectedIndexChanged(object sender, EventArgs e) {
            if (Options.SelectedIndex >= 3 && (UserPrivilege)currentUser.priv != UserPrivilege.Admin) {
                MessageBox.Show("对不起，您没有权限进行这项操作！", "铁卢12306");
                Options.SelectTab(0);
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e) {
            Hide();
            LoginPage(currentUser.id);
            Show();

            ticketData.Rows.Clear();
            orderData.Rows.Clear();
            UserDataInitation();
            trainData.Rows.Clear();
            for (int i = 0; i < 5; ++i)
                TicketKindGrid.Rows[0].Cells[i].Value = "票种" + (i + 1).ToString();
            UserIDBox.Text = "";
            PrivilegeBox2.Text = "";
            Options.SelectTab(0);
        }
    }
}
