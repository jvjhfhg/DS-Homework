namespace RailwayManager_DS_2018Spring {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Options = new System.Windows.Forms.TabControl();
            this.QueryTicketPage = new System.Windows.Forms.TabPage();
            this.TicketCntBox = new System.Windows.Forms.TextBox();
            this.CntLabel = new System.Windows.Forms.Label();
            this.TicketKindBox = new System.Windows.Forms.TextBox();
            this.KindLabel = new System.Windows.Forms.Label();
            this.BuyButton = new System.Windows.Forms.Button();
            this.TransferChecker = new System.Windows.Forms.CheckBox();
            this.CatalogBox = new System.Windows.Forms.TextBox();
            this.CatalogLabel = new System.Windows.Forms.Label();
            this.TicketGrid = new System.Windows.Forms.DataGridView();
            this.DateLabel = new System.Windows.Forms.Label();
            this.Loc2Label = new System.Windows.Forms.Label();
            this.Loc1Label = new System.Windows.Forms.Label();
            this.QueryConfirmButton = new System.Windows.Forms.Button();
            this.DateBox = new System.Windows.Forms.DateTimePicker();
            this.Loc2Box = new System.Windows.Forms.TextBox();
            this.Loc1Box = new System.Windows.Forms.TextBox();
            this.OrderUserPage = new System.Windows.Forms.TabPage();
            this.TicketCntBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TicketKindBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RefundButton = new System.Windows.Forms.Button();
            this.CatalogBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.QueryConfirmButton2 = new System.Windows.Forms.Button();
            this.DateBox2 = new System.Windows.Forms.DateTimePicker();
            this.UserOptionPage = new System.Windows.Forms.TabPage();
            this.ModifyConfirmButton = new System.Windows.Forms.Button();
            this.PrivilegeBox = new System.Windows.Forms.TextBox();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.PrivilegeLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.TrainOption = new System.Windows.Forms.TabPage();
            this.TicketKindCnt = new System.Windows.Forms.NumericUpDown();
            this.TicketKindGrid = new System.Windows.Forms.DataGridView();
            this.DeleteTrainButton = new System.Windows.Forms.Button();
            this.SaleButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ModifyTrainButton = new System.Windows.Forms.Button();
            this.TrainDataGrid = new System.Windows.Forms.DataGridView();
            this.QueryTrainButton = new System.Windows.Forms.Button();
            this.TrainCatalogBox = new System.Windows.Forms.TextBox();
            this.TrainNameBox = new System.Windows.Forms.TextBox();
            this.TrainIDBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TrainIDLabel = new System.Windows.Forms.Label();
            this.ModifyPrivilegePage = new System.Windows.Forms.TabPage();
            this.ModifyPrivilegeButton = new System.Windows.Forms.Button();
            this.QueryPrivilegeButton = new System.Windows.Forms.Button();
            this.PrivilegeBox2 = new System.Windows.Forms.TextBox();
            this.UserIDBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.MenuOfMainPage = new System.Windows.Forms.MenuStrip();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.Options.SuspendLayout();
            this.QueryTicketPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketGrid)).BeginInit();
            this.OrderUserPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).BeginInit();
            this.UserOptionPage.SuspendLayout();
            this.TrainOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketKindCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketKindGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainDataGrid)).BeginInit();
            this.ModifyPrivilegePage.SuspendLayout();
            this.MenuOfMainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.QueryTicketPage);
            this.Options.Controls.Add(this.OrderUserPage);
            this.Options.Controls.Add(this.UserOptionPage);
            this.Options.Controls.Add(this.TrainOption);
            this.Options.Controls.Add(this.ModifyPrivilegePage);
            this.Options.Location = new System.Drawing.Point(12, 91);
            this.Options.Name = "Options";
            this.Options.SelectedIndex = 0;
            this.Options.Size = new System.Drawing.Size(809, 449);
            this.Options.TabIndex = 0;
            this.Options.SelectedIndexChanged += new System.EventHandler(this.Options_SelectedIndexChanged);
            // 
            // QueryTicketPage
            // 
            this.QueryTicketPage.Controls.Add(this.TicketCntBox);
            this.QueryTicketPage.Controls.Add(this.CntLabel);
            this.QueryTicketPage.Controls.Add(this.TicketKindBox);
            this.QueryTicketPage.Controls.Add(this.KindLabel);
            this.QueryTicketPage.Controls.Add(this.BuyButton);
            this.QueryTicketPage.Controls.Add(this.TransferChecker);
            this.QueryTicketPage.Controls.Add(this.CatalogBox);
            this.QueryTicketPage.Controls.Add(this.CatalogLabel);
            this.QueryTicketPage.Controls.Add(this.TicketGrid);
            this.QueryTicketPage.Controls.Add(this.DateLabel);
            this.QueryTicketPage.Controls.Add(this.Loc2Label);
            this.QueryTicketPage.Controls.Add(this.Loc1Label);
            this.QueryTicketPage.Controls.Add(this.QueryConfirmButton);
            this.QueryTicketPage.Controls.Add(this.DateBox);
            this.QueryTicketPage.Controls.Add(this.Loc2Box);
            this.QueryTicketPage.Controls.Add(this.Loc1Box);
            this.QueryTicketPage.Location = new System.Drawing.Point(4, 22);
            this.QueryTicketPage.Name = "QueryTicketPage";
            this.QueryTicketPage.Padding = new System.Windows.Forms.Padding(3);
            this.QueryTicketPage.Size = new System.Drawing.Size(801, 423);
            this.QueryTicketPage.TabIndex = 0;
            this.QueryTicketPage.Text = "查询车次";
            this.QueryTicketPage.UseVisualStyleBackColor = true;
            // 
            // TicketCntBox
            // 
            this.TicketCntBox.Location = new System.Drawing.Point(600, 396);
            this.TicketCntBox.Name = "TicketCntBox";
            this.TicketCntBox.Size = new System.Drawing.Size(100, 21);
            this.TicketCntBox.TabIndex = 14;
            // 
            // CntLabel
            // 
            this.CntLabel.AutoSize = true;
            this.CntLabel.Location = new System.Drawing.Point(541, 401);
            this.CntLabel.Name = "CntLabel";
            this.CntLabel.Size = new System.Drawing.Size(53, 12);
            this.CntLabel.TabIndex = 13;
            this.CntLabel.Text = "购票张数";
            // 
            // TicketKindBox
            // 
            this.TicketKindBox.Location = new System.Drawing.Point(405, 396);
            this.TicketKindBox.Name = "TicketKindBox";
            this.TicketKindBox.Size = new System.Drawing.Size(100, 21);
            this.TicketKindBox.TabIndex = 14;
            // 
            // KindLabel
            // 
            this.KindLabel.AutoSize = true;
            this.KindLabel.Location = new System.Drawing.Point(238, 401);
            this.KindLabel.Name = "KindLabel";
            this.KindLabel.Size = new System.Drawing.Size(161, 12);
            this.KindLabel.TabIndex = 13;
            this.KindLabel.Text = "车票种类（表格第一行数字）";
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(720, 394);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(75, 23);
            this.BuyButton.TabIndex = 12;
            this.BuyButton.Text = "购买";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // TransferChecker
            // 
            this.TransferChecker.AutoSize = true;
            this.TransferChecker.Location = new System.Drawing.Point(6, 398);
            this.TransferChecker.Name = "TransferChecker";
            this.TransferChecker.Size = new System.Drawing.Size(72, 16);
            this.TransferChecker.TabIndex = 11;
            this.TransferChecker.Text = "允许中转";
            this.TransferChecker.UseVisualStyleBackColor = true;
            // 
            // CatalogBox
            // 
            this.CatalogBox.Location = new System.Drawing.Point(600, 8);
            this.CatalogBox.Name = "CatalogBox";
            this.CatalogBox.Size = new System.Drawing.Size(100, 21);
            this.CatalogBox.TabIndex = 9;
            // 
            // CatalogLabel
            // 
            this.CatalogLabel.AutoSize = true;
            this.CatalogLabel.Location = new System.Drawing.Point(541, 11);
            this.CatalogLabel.Name = "CatalogLabel";
            this.CatalogLabel.Size = new System.Drawing.Size(53, 12);
            this.CatalogLabel.TabIndex = 8;
            this.CatalogLabel.Text = "列车类型";
            // 
            // TicketGrid
            // 
            this.TicketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TicketGrid.Location = new System.Drawing.Point(0, 35);
            this.TicketGrid.Name = "TicketGrid";
            this.TicketGrid.RowTemplate.Height = 23;
            this.TicketGrid.Size = new System.Drawing.Size(800, 353);
            this.TicketGrid.TabIndex = 7;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(346, 11);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(53, 12);
            this.DateLabel.TabIndex = 6;
            this.DateLabel.Text = "发车日期";
            // 
            // Loc2Label
            // 
            this.Loc2Label.AutoSize = true;
            this.Loc2Label.Location = new System.Drawing.Point(178, 11);
            this.Loc2Label.Name = "Loc2Label";
            this.Loc2Label.Size = new System.Drawing.Size(41, 12);
            this.Loc2Label.TabIndex = 5;
            this.Loc2Label.Text = "到达地";
            // 
            // Loc1Label
            // 
            this.Loc1Label.AutoSize = true;
            this.Loc1Label.Location = new System.Drawing.Point(13, 11);
            this.Loc1Label.Name = "Loc1Label";
            this.Loc1Label.Size = new System.Drawing.Size(41, 12);
            this.Loc1Label.TabIndex = 4;
            this.Loc1Label.Text = "出发地";
            // 
            // QueryConfirmButton
            // 
            this.QueryConfirmButton.Location = new System.Drawing.Point(720, 6);
            this.QueryConfirmButton.Name = "QueryConfirmButton";
            this.QueryConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.QueryConfirmButton.TabIndex = 3;
            this.QueryConfirmButton.Text = "查询";
            this.QueryConfirmButton.UseVisualStyleBackColor = true;
            this.QueryConfirmButton.Click += new System.EventHandler(this.QueryConfirmButton_Click);
            // 
            // DateBox
            // 
            this.DateBox.CustomFormat = "yyyy-MM-dd";
            this.DateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateBox.Location = new System.Drawing.Point(405, 8);
            this.DateBox.Name = "DateBox";
            this.DateBox.Size = new System.Drawing.Size(115, 21);
            this.DateBox.TabIndex = 2;
            this.DateBox.Value = new System.DateTime(2018, 6, 14, 6, 20, 53, 0);
            // 
            // Loc2Box
            // 
            this.Loc2Box.Location = new System.Drawing.Point(225, 8);
            this.Loc2Box.Name = "Loc2Box";
            this.Loc2Box.Size = new System.Drawing.Size(100, 21);
            this.Loc2Box.TabIndex = 1;
            // 
            // Loc1Box
            // 
            this.Loc1Box.Location = new System.Drawing.Point(60, 8);
            this.Loc1Box.Name = "Loc1Box";
            this.Loc1Box.Size = new System.Drawing.Size(100, 21);
            this.Loc1Box.TabIndex = 0;
            // 
            // OrderUserPage
            // 
            this.OrderUserPage.Controls.Add(this.TicketCntBox2);
            this.OrderUserPage.Controls.Add(this.label1);
            this.OrderUserPage.Controls.Add(this.TicketKindBox2);
            this.OrderUserPage.Controls.Add(this.label2);
            this.OrderUserPage.Controls.Add(this.RefundButton);
            this.OrderUserPage.Controls.Add(this.CatalogBox2);
            this.OrderUserPage.Controls.Add(this.label3);
            this.OrderUserPage.Controls.Add(this.OrderGrid);
            this.OrderUserPage.Controls.Add(this.label4);
            this.OrderUserPage.Controls.Add(this.QueryConfirmButton2);
            this.OrderUserPage.Controls.Add(this.DateBox2);
            this.OrderUserPage.Location = new System.Drawing.Point(4, 22);
            this.OrderUserPage.Name = "OrderUserPage";
            this.OrderUserPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderUserPage.Size = new System.Drawing.Size(801, 423);
            this.OrderUserPage.TabIndex = 1;
            this.OrderUserPage.Text = "查询购票记录";
            this.OrderUserPage.UseVisualStyleBackColor = true;
            // 
            // TicketCntBox2
            // 
            this.TicketCntBox2.Location = new System.Drawing.Point(464, 396);
            this.TicketCntBox2.Name = "TicketCntBox2";
            this.TicketCntBox2.Size = new System.Drawing.Size(100, 21);
            this.TicketCntBox2.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "退票张数";
            // 
            // TicketKindBox2
            // 
            this.TicketKindBox2.Location = new System.Drawing.Point(230, 396);
            this.TicketKindBox2.Name = "TicketKindBox2";
            this.TicketKindBox2.Size = new System.Drawing.Size(100, 21);
            this.TicketKindBox2.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "车票种类（表格第一行数字）";
            // 
            // RefundButton
            // 
            this.RefundButton.Location = new System.Drawing.Point(653, 394);
            this.RefundButton.Name = "RefundButton";
            this.RefundButton.Size = new System.Drawing.Size(75, 23);
            this.RefundButton.TabIndex = 26;
            this.RefundButton.Text = "退票";
            this.RefundButton.UseVisualStyleBackColor = true;
            this.RefundButton.Click += new System.EventHandler(this.RefundButton_Click);
            // 
            // CatalogBox2
            // 
            this.CatalogBox2.Location = new System.Drawing.Point(464, 8);
            this.CatalogBox2.Name = "CatalogBox2";
            this.CatalogBox2.Size = new System.Drawing.Size(100, 21);
            this.CatalogBox2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "列车类型";
            // 
            // OrderGrid
            // 
            this.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderGrid.Location = new System.Drawing.Point(0, 35);
            this.OrderGrid.Name = "OrderGrid";
            this.OrderGrid.RowTemplate.Height = 23;
            this.OrderGrid.Size = new System.Drawing.Size(800, 353);
            this.OrderGrid.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "发车日期";
            // 
            // QueryConfirmButton2
            // 
            this.QueryConfirmButton2.Location = new System.Drawing.Point(653, 6);
            this.QueryConfirmButton2.Name = "QueryConfirmButton2";
            this.QueryConfirmButton2.Size = new System.Drawing.Size(75, 23);
            this.QueryConfirmButton2.TabIndex = 18;
            this.QueryConfirmButton2.Text = "查询";
            this.QueryConfirmButton2.UseVisualStyleBackColor = true;
            this.QueryConfirmButton2.Click += new System.EventHandler(this.QueryConfirmButton2_Click);
            // 
            // DateBox2
            // 
            this.DateBox2.CustomFormat = "yyyy-MM-dd";
            this.DateBox2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateBox2.Location = new System.Drawing.Point(173, 8);
            this.DateBox2.Name = "DateBox2";
            this.DateBox2.Size = new System.Drawing.Size(115, 21);
            this.DateBox2.TabIndex = 17;
            this.DateBox2.Value = new System.DateTime(2018, 6, 14, 6, 20, 53, 0);
            // 
            // UserOptionPage
            // 
            this.UserOptionPage.Controls.Add(this.ModifyConfirmButton);
            this.UserOptionPage.Controls.Add(this.PrivilegeBox);
            this.UserOptionPage.Controls.Add(this.PhoneBox);
            this.UserOptionPage.Controls.Add(this.EmailBox);
            this.UserOptionPage.Controls.Add(this.PasswordBox);
            this.UserOptionPage.Controls.Add(this.UsernameBox);
            this.UserOptionPage.Controls.Add(this.IDBox);
            this.UserOptionPage.Controls.Add(this.PrivilegeLabel);
            this.UserOptionPage.Controls.Add(this.PhoneLabel);
            this.UserOptionPage.Controls.Add(this.EmailLabel);
            this.UserOptionPage.Controls.Add(this.PasswordLabel);
            this.UserOptionPage.Controls.Add(this.IDLabel);
            this.UserOptionPage.Controls.Add(this.UsernameLabel);
            this.UserOptionPage.Location = new System.Drawing.Point(4, 22);
            this.UserOptionPage.Name = "UserOptionPage";
            this.UserOptionPage.Padding = new System.Windows.Forms.Padding(3);
            this.UserOptionPage.Size = new System.Drawing.Size(801, 423);
            this.UserOptionPage.TabIndex = 2;
            this.UserOptionPage.Text = "用户信息";
            this.UserOptionPage.UseVisualStyleBackColor = true;
            // 
            // ModifyConfirmButton
            // 
            this.ModifyConfirmButton.Location = new System.Drawing.Point(370, 317);
            this.ModifyConfirmButton.Name = "ModifyConfirmButton";
            this.ModifyConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ModifyConfirmButton.TabIndex = 3;
            this.ModifyConfirmButton.Text = "修改";
            this.ModifyConfirmButton.UseVisualStyleBackColor = true;
            this.ModifyConfirmButton.Click += new System.EventHandler(this.ModifyConfirmButton_Click);
            // 
            // PrivilegeBox
            // 
            this.PrivilegeBox.Location = new System.Drawing.Point(393, 277);
            this.PrivilegeBox.Name = "PrivilegeBox";
            this.PrivilegeBox.Size = new System.Drawing.Size(100, 21);
            this.PrivilegeBox.TabIndex = 2;
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(393, 237);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(100, 21);
            this.PhoneBox.TabIndex = 2;
            this.PhoneBox.TextChanged += new System.EventHandler(this.PhoneBox_TextChanged);
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(393, 197);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(100, 21);
            this.EmailBox.TabIndex = 2;
            this.EmailBox.TextChanged += new System.EventHandler(this.EmailBox_TextChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(393, 157);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 21);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(393, 117);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(100, 21);
            this.UsernameBox.TabIndex = 2;
            this.UsernameBox.TextChanged += new System.EventHandler(this.UsernameBox_TextChanged);
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(393, 77);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(100, 21);
            this.IDBox.TabIndex = 2;
            // 
            // PrivilegeLabel
            // 
            this.PrivilegeLabel.AutoSize = true;
            this.PrivilegeLabel.Location = new System.Drawing.Point(316, 280);
            this.PrivilegeLabel.Name = "PrivilegeLabel";
            this.PrivilegeLabel.Size = new System.Drawing.Size(29, 12);
            this.PrivilegeLabel.TabIndex = 1;
            this.PrivilegeLabel.Text = "权限";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(316, 240);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(29, 12);
            this.PhoneLabel.TabIndex = 1;
            this.PhoneLabel.Text = "电话";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(316, 200);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(53, 12);
            this.EmailLabel.TabIndex = 1;
            this.EmailLabel.Text = "电子邮箱";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(316, 160);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(29, 12);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "密码";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(316, 80);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(41, 12);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "用户ID";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(316, 120);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(41, 12);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "用户名";
            // 
            // TrainOption
            // 
            this.TrainOption.Controls.Add(this.TicketKindCnt);
            this.TrainOption.Controls.Add(this.TicketKindGrid);
            this.TrainOption.Controls.Add(this.DeleteTrainButton);
            this.TrainOption.Controls.Add(this.SaleButton);
            this.TrainOption.Controls.Add(this.AddButton);
            this.TrainOption.Controls.Add(this.ModifyTrainButton);
            this.TrainOption.Controls.Add(this.TrainDataGrid);
            this.TrainOption.Controls.Add(this.QueryTrainButton);
            this.TrainOption.Controls.Add(this.TrainCatalogBox);
            this.TrainOption.Controls.Add(this.TrainNameBox);
            this.TrainOption.Controls.Add(this.TrainIDBox);
            this.TrainOption.Controls.Add(this.label10);
            this.TrainOption.Controls.Add(this.label7);
            this.TrainOption.Controls.Add(this.label6);
            this.TrainOption.Controls.Add(this.TrainIDLabel);
            this.TrainOption.Location = new System.Drawing.Point(4, 22);
            this.TrainOption.Name = "TrainOption";
            this.TrainOption.Padding = new System.Windows.Forms.Padding(3);
            this.TrainOption.Size = new System.Drawing.Size(801, 423);
            this.TrainOption.TabIndex = 3;
            this.TrainOption.Text = "车次操作";
            this.TrainOption.UseVisualStyleBackColor = true;
            this.TrainOption.Click += new System.EventHandler(this.TrainOption_Click);
            // 
            // TicketKindCnt
            // 
            this.TicketKindCnt.Location = new System.Drawing.Point(560, 76);
            this.TicketKindCnt.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TicketKindCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TicketKindCnt.Name = "TicketKindCnt";
            this.TicketKindCnt.Size = new System.Drawing.Size(120, 21);
            this.TicketKindCnt.TabIndex = 6;
            this.TicketKindCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TicketKindGrid
            // 
            this.TicketKindGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TicketKindGrid.Location = new System.Drawing.Point(0, 104);
            this.TicketKindGrid.Name = "TicketKindGrid";
            this.TicketKindGrid.RowTemplate.Height = 23;
            this.TicketKindGrid.Size = new System.Drawing.Size(801, 71);
            this.TicketKindGrid.TabIndex = 5;
            this.TicketKindGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TicketKindGrid_CellValueChanged);
            // 
            // DeleteTrainButton
            // 
            this.DeleteTrainButton.Location = new System.Drawing.Point(475, 394);
            this.DeleteTrainButton.Name = "DeleteTrainButton";
            this.DeleteTrainButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteTrainButton.TabIndex = 4;
            this.DeleteTrainButton.Text = "删除车次";
            this.DeleteTrainButton.UseVisualStyleBackColor = true;
            this.DeleteTrainButton.Click += new System.EventHandler(this.DeleteTrainButton_Click);
            // 
            // SaleButton
            // 
            this.SaleButton.Location = new System.Drawing.Point(718, 394);
            this.SaleButton.Name = "SaleButton";
            this.SaleButton.Size = new System.Drawing.Size(75, 23);
            this.SaleButton.TabIndex = 4;
            this.SaleButton.Text = "发售车次";
            this.SaleButton.UseVisualStyleBackColor = true;
            this.SaleButton.Click += new System.EventHandler(this.SaleTrainButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(637, 394);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "添加车次";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddTrainButton_Click);
            // 
            // ModifyTrainButton
            // 
            this.ModifyTrainButton.Location = new System.Drawing.Point(556, 394);
            this.ModifyTrainButton.Name = "ModifyTrainButton";
            this.ModifyTrainButton.Size = new System.Drawing.Size(75, 23);
            this.ModifyTrainButton.TabIndex = 4;
            this.ModifyTrainButton.Text = "修改车次";
            this.ModifyTrainButton.UseVisualStyleBackColor = true;
            this.ModifyTrainButton.Click += new System.EventHandler(this.ModifyTrainButton_Click);
            // 
            // TrainDataGrid
            // 
            this.TrainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrainDataGrid.Location = new System.Drawing.Point(0, 181);
            this.TrainDataGrid.Name = "TrainDataGrid";
            this.TrainDataGrid.RowTemplate.Height = 23;
            this.TrainDataGrid.Size = new System.Drawing.Size(800, 207);
            this.TrainDataGrid.TabIndex = 3;
            // 
            // QueryTrainButton
            // 
            this.QueryTrainButton.Location = new System.Drawing.Point(445, 28);
            this.QueryTrainButton.Name = "QueryTrainButton";
            this.QueryTrainButton.Size = new System.Drawing.Size(75, 23);
            this.QueryTrainButton.TabIndex = 2;
            this.QueryTrainButton.Text = "查询";
            this.QueryTrainButton.UseVisualStyleBackColor = true;
            this.QueryTrainButton.Click += new System.EventHandler(this.QueryTrainButton_Click);
            // 
            // TrainCatalogBox
            // 
            this.TrainCatalogBox.Location = new System.Drawing.Point(395, 76);
            this.TrainCatalogBox.Name = "TrainCatalogBox";
            this.TrainCatalogBox.Size = new System.Drawing.Size(100, 21);
            this.TrainCatalogBox.TabIndex = 1;
            // 
            // TrainNameBox
            // 
            this.TrainNameBox.Location = new System.Drawing.Point(230, 76);
            this.TrainNameBox.Name = "TrainNameBox";
            this.TrainNameBox.Size = new System.Drawing.Size(100, 21);
            this.TrainNameBox.TabIndex = 1;
            // 
            // TrainIDBox
            // 
            this.TrainIDBox.Location = new System.Drawing.Point(339, 30);
            this.TrainIDBox.Name = "TrainIDBox";
            this.TrainIDBox.Size = new System.Drawing.Size(100, 21);
            this.TrainIDBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(501, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "票的种类";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "车次类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "车次名称";
            // 
            // TrainIDLabel
            // 
            this.TrainIDLabel.AutoSize = true;
            this.TrainIDLabel.Location = new System.Drawing.Point(280, 33);
            this.TrainIDLabel.Name = "TrainIDLabel";
            this.TrainIDLabel.Size = new System.Drawing.Size(53, 12);
            this.TrainIDLabel.TabIndex = 0;
            this.TrainIDLabel.Text = "车次编号";
            // 
            // ModifyPrivilegePage
            // 
            this.ModifyPrivilegePage.Controls.Add(this.ModifyPrivilegeButton);
            this.ModifyPrivilegePage.Controls.Add(this.QueryPrivilegeButton);
            this.ModifyPrivilegePage.Controls.Add(this.PrivilegeBox2);
            this.ModifyPrivilegePage.Controls.Add(this.UserIDBox);
            this.ModifyPrivilegePage.Controls.Add(this.label9);
            this.ModifyPrivilegePage.Controls.Add(this.label8);
            this.ModifyPrivilegePage.Location = new System.Drawing.Point(4, 22);
            this.ModifyPrivilegePage.Name = "ModifyPrivilegePage";
            this.ModifyPrivilegePage.Padding = new System.Windows.Forms.Padding(3);
            this.ModifyPrivilegePage.Size = new System.Drawing.Size(801, 423);
            this.ModifyPrivilegePage.TabIndex = 4;
            this.ModifyPrivilegePage.Text = "修改用户权限";
            this.ModifyPrivilegePage.UseVisualStyleBackColor = true;
            // 
            // ModifyPrivilegeButton
            // 
            this.ModifyPrivilegeButton.Location = new System.Drawing.Point(406, 234);
            this.ModifyPrivilegeButton.Name = "ModifyPrivilegeButton";
            this.ModifyPrivilegeButton.Size = new System.Drawing.Size(75, 23);
            this.ModifyPrivilegeButton.TabIndex = 2;
            this.ModifyPrivilegeButton.Text = "提升权限";
            this.ModifyPrivilegeButton.UseVisualStyleBackColor = true;
            this.ModifyPrivilegeButton.Click += new System.EventHandler(this.ModifyPrivilegeButton_Click);
            // 
            // QueryPrivilegeButton
            // 
            this.QueryPrivilegeButton.Location = new System.Drawing.Point(317, 234);
            this.QueryPrivilegeButton.Name = "QueryPrivilegeButton";
            this.QueryPrivilegeButton.Size = new System.Drawing.Size(75, 23);
            this.QueryPrivilegeButton.TabIndex = 2;
            this.QueryPrivilegeButton.Text = "查询权限";
            this.QueryPrivilegeButton.UseVisualStyleBackColor = true;
            this.QueryPrivilegeButton.Click += new System.EventHandler(this.QueryPrivilegeButton_Click);
            // 
            // PrivilegeBox2
            // 
            this.PrivilegeBox2.Location = new System.Drawing.Point(381, 176);
            this.PrivilegeBox2.Name = "PrivilegeBox2";
            this.PrivilegeBox2.Size = new System.Drawing.Size(100, 21);
            this.PrivilegeBox2.TabIndex = 1;
            // 
            // UserIDBox
            // 
            this.UserIDBox.Location = new System.Drawing.Point(381, 117);
            this.UserIDBox.Name = "UserIDBox";
            this.UserIDBox.Size = new System.Drawing.Size(100, 21);
            this.UserIDBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "权限";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "用户ID";
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WelcomeLabel.Location = new System.Drawing.Point(12, 47);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(58, 21);
            this.WelcomeLabel.TabIndex = 2;
            this.WelcomeLabel.Text = "欢迎您";
            // 
            // MenuOfMainPage
            // 
            this.MenuOfMainPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登出ToolStripMenuItem,
            this.退出系统ToolStripMenuItem,
            this.清空数据ToolStripMenuItem});
            this.MenuOfMainPage.Location = new System.Drawing.Point(0, 0);
            this.MenuOfMainPage.Name = "MenuOfMainPage";
            this.MenuOfMainPage.Size = new System.Drawing.Size(833, 25);
            this.MenuOfMainPage.TabIndex = 3;
            this.MenuOfMainPage.Text = "Menu";
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.登出ToolStripMenuItem.Text = "切换用户";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 清空数据ToolStripMenuItem
            // 
            this.清空数据ToolStripMenuItem.Name = "清空数据ToolStripMenuItem";
            this.清空数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.清空数据ToolStripMenuItem.Text = "清空数据";
            this.清空数据ToolStripMenuItem.Click += new System.EventHandler(this.清空数据ToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(629, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "列车类型：L-临时列车；K-快速列车；T-特快列车；Z-直达特快列车；D-动车组列车；G-高速动车组列车；C-城际列车";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(833, 552);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.MenuOfMainPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuOfMainPage;
            this.Name = "MainForm";
            this.Text = "铁卢12306";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Options.ResumeLayout(false);
            this.QueryTicketPage.ResumeLayout(false);
            this.QueryTicketPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketGrid)).EndInit();
            this.OrderUserPage.ResumeLayout(false);
            this.OrderUserPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).EndInit();
            this.UserOptionPage.ResumeLayout(false);
            this.UserOptionPage.PerformLayout();
            this.TrainOption.ResumeLayout(false);
            this.TrainOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketKindCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketKindGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainDataGrid)).EndInit();
            this.ModifyPrivilegePage.ResumeLayout(false);
            this.ModifyPrivilegePage.PerformLayout();
            this.MenuOfMainPage.ResumeLayout(false);
            this.MenuOfMainPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Options;
        private System.Windows.Forms.TabPage QueryTicketPage;
        private System.Windows.Forms.TabPage OrderUserPage;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button QueryConfirmButton;
        private System.Windows.Forms.DateTimePicker DateBox;
        private System.Windows.Forms.TextBox Loc2Box;
        private System.Windows.Forms.TextBox Loc1Box;
        private System.Windows.Forms.Label Loc1Label;
        private System.Windows.Forms.Label Loc2Label;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DataGridView TicketGrid;
        private System.Windows.Forms.Label CatalogLabel;
        private System.Windows.Forms.TextBox CatalogBox;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.CheckBox TransferChecker;
        private System.Windows.Forms.Label KindLabel;
        private System.Windows.Forms.TextBox TicketKindBox;
        private System.Windows.Forms.TextBox TicketCntBox;
        private System.Windows.Forms.Label CntLabel;
        private System.Windows.Forms.MenuStrip MenuOfMainPage;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
        private System.Windows.Forms.TextBox TicketCntBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TicketKindBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefundButton;
        private System.Windows.Forms.TextBox CatalogBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView OrderGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button QueryConfirmButton2;
        private System.Windows.Forms.DateTimePicker DateBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage UserOptionPage;
        private System.Windows.Forms.Label PrivilegeLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.TextBox PrivilegeBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Button ModifyConfirmButton;
        private System.Windows.Forms.TabPage TrainOption;
        private System.Windows.Forms.Label TrainIDLabel;
        private System.Windows.Forms.TextBox TrainIDBox;
        private System.Windows.Forms.Button QueryTrainButton;
        private System.Windows.Forms.TextBox TrainCatalogBox;
        private System.Windows.Forms.TextBox TrainNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView TrainDataGrid;
        private System.Windows.Forms.Button DeleteTrainButton;
        private System.Windows.Forms.Button ModifyTrainButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TabPage ModifyPrivilegePage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ModifyPrivilegeButton;
        private System.Windows.Forms.Button QueryPrivilegeButton;
        private System.Windows.Forms.TextBox PrivilegeBox2;
        private System.Windows.Forms.TextBox UserIDBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView TicketKindGrid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown TicketKindCnt;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空数据ToolStripMenuItem;
        private System.Windows.Forms.Button SaleButton;
    }
}

