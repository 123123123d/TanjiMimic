namespace TanjiMimic
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainTabCtrl = new System.Windows.Forms.TabControl();
            this.HomeTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TMLink = new System.Windows.Forms.LinkLabel();
            this.ArachisGitHubLnkLbl = new System.Windows.Forms.LinkLabel();
            this.DarkBoxLnkLbl = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.NovoMimicLbl = new System.Windows.Forms.Label();
            this.ToolboxTab = new System.Windows.Forms.TabPage();
            this.ToolsOptionsGrpbx = new System.Windows.Forms.GroupBox();
            this.MGesturesChckbx = new System.Windows.Forms.CheckBox();
            this.MClothesChckbx = new System.Windows.Forms.CheckBox();
            this.MDancingChckbx = new System.Windows.Forms.CheckBox();
            this.MSignChckbx = new System.Windows.Forms.CheckBox();
            this.MMottoChckbx = new System.Windows.Forms.CheckBox();
            this.MWalkingChckbx = new System.Windows.Forms.CheckBox();
            this.MStanceChckbx = new System.Windows.Forms.CheckBox();
            this.MSpeechChckbx = new System.Windows.Forms.CheckBox();
            this.AutoCopyCMChckbx = new System.Windows.Forms.CheckBox();
            this.SettingsGrpbx = new System.Windows.Forms.GroupBox();
            this.AutoLoadChckbx = new System.Windows.Forms.CheckBox();
            this.AClearOnExit = new System.Windows.Forms.CheckBox();
            this.PlayerInformationGrpbx = new System.Windows.Forms.GroupBox();
            this.PlayerInformationPnl = new System.Windows.Forms.Panel();
            this.PDataGrid = new System.Windows.Forms.DataGridView();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerImg = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SelectPlayerGrpbx = new System.Windows.Forms.GroupBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.PlayerListCmbbx = new System.Windows.Forms.ComboBox();
            this.MainTabCtrl.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ToolboxTab.SuspendLayout();
            this.ToolsOptionsGrpbx.SuspendLayout();
            this.SettingsGrpbx.SuspendLayout();
            this.PlayerInformationGrpbx.SuspendLayout();
            this.PlayerInformationPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerImg)).BeginInit();
            this.SelectPlayerGrpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabCtrl
            // 
            this.MainTabCtrl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.MainTabCtrl.Controls.Add(this.HomeTab);
            this.MainTabCtrl.Controls.Add(this.ToolboxTab);
            this.MainTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.MainTabCtrl.Name = "MainTabCtrl";
            this.MainTabCtrl.SelectedIndex = 0;
            this.MainTabCtrl.Size = new System.Drawing.Size(433, 360);
            this.MainTabCtrl.TabIndex = 2;
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.groupBox1);
            this.HomeTab.Controls.Add(this.NovoMimicLbl);
            this.HomeTab.Location = new System.Drawing.Point(4, 4);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTab.Size = new System.Drawing.Size(425, 334);
            this.HomeTab.TabIndex = 0;
            this.HomeTab.Text = "Home";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TMLink);
            this.groupBox1.Controls.Add(this.ArachisGitHubLnkLbl);
            this.groupBox1.Controls.Add(this.DarkBoxLnkLbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 246);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // TMLink
            // 
            this.TMLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TMLink.AutoSize = true;
            this.TMLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TMLink.Location = new System.Drawing.Point(104, 72);
            this.TMLink.Name = "TMLink";
            this.TMLink.Size = new System.Drawing.Size(213, 13);
            this.TMLink.TabIndex = 5;
            this.TMLink.TabStop = true;
            this.TMLink.Text = "https://GitHub.com/JustDevInc/TanjiMimic";
            this.TMLink.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.TMLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TMLink_LinkClicked);
            // 
            // ArachisGitHubLnkLbl
            // 
            this.ArachisGitHubLnkLbl.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ArachisGitHubLnkLbl.AutoSize = true;
            this.ArachisGitHubLnkLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArachisGitHubLnkLbl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ArachisGitHubLnkLbl.Location = new System.Drawing.Point(175, 142);
            this.ArachisGitHubLnkLbl.Name = "ArachisGitHubLnkLbl";
            this.ArachisGitHubLnkLbl.Size = new System.Drawing.Size(229, 30);
            this.ArachisGitHubLnkLbl.TabIndex = 4;
            this.ArachisGitHubLnkLbl.TabStop = true;
            this.ArachisGitHubLnkLbl.Text = "GitHub.com/ArachisH";
            this.ArachisGitHubLnkLbl.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.ArachisGitHubLnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ArachisGithubLnkLbl_LinkClicked);
            // 
            // DarkBoxLnkLbl
            // 
            this.DarkBoxLnkLbl.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.DarkBoxLnkLbl.AutoSize = true;
            this.DarkBoxLnkLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkBoxLnkLbl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.DarkBoxLnkLbl.Location = new System.Drawing.Point(26, 142);
            this.DarkBoxLnkLbl.Name = "DarkBoxLnkLbl";
            this.DarkBoxLnkLbl.Size = new System.Drawing.Size(122, 30);
            this.DarkBoxLnkLbl.TabIndex = 3;
            this.DarkBoxLnkLbl.TabStop = true;
            this.DarkBoxLnkLbl.Text = "Darkbox.nl";
            this.DarkBoxLnkLbl.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.DarkBoxLnkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DarkBoxLnkLbl_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 227);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NovoMimicLbl
            // 
            this.NovoMimicLbl.AutoSize = true;
            this.NovoMimicLbl.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.NovoMimicLbl.Location = new System.Drawing.Point(91, 3);
            this.NovoMimicLbl.Name = "NovoMimicLbl";
            this.NovoMimicLbl.Size = new System.Drawing.Size(241, 54);
            this.NovoMimicLbl.TabIndex = 4;
            this.NovoMimicLbl.Text = "Tanji Mimic";
            // 
            // ToolboxTab
            // 
            this.ToolboxTab.Controls.Add(this.ToolsOptionsGrpbx);
            this.ToolboxTab.Controls.Add(this.AutoCopyCMChckbx);
            this.ToolboxTab.Controls.Add(this.SettingsGrpbx);
            this.ToolboxTab.Controls.Add(this.PlayerInformationGrpbx);
            this.ToolboxTab.Controls.Add(this.SelectPlayerGrpbx);
            this.ToolboxTab.Location = new System.Drawing.Point(4, 4);
            this.ToolboxTab.Name = "ToolboxTab";
            this.ToolboxTab.Padding = new System.Windows.Forms.Padding(3);
            this.ToolboxTab.Size = new System.Drawing.Size(425, 334);
            this.ToolboxTab.TabIndex = 2;
            this.ToolboxTab.Text = "Toolbox";
            // 
            // ToolsOptionsGrpbx
            // 
            this.ToolsOptionsGrpbx.Controls.Add(this.MGesturesChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MClothesChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MDancingChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MSignChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MMottoChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MWalkingChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MStanceChckbx);
            this.ToolsOptionsGrpbx.Controls.Add(this.MSpeechChckbx);
            this.ToolsOptionsGrpbx.Location = new System.Drawing.Point(4, 260);
            this.ToolsOptionsGrpbx.Name = "ToolsOptionsGrpbx";
            this.ToolsOptionsGrpbx.Size = new System.Drawing.Size(414, 59);
            this.ToolsOptionsGrpbx.TabIndex = 7;
            this.ToolsOptionsGrpbx.TabStop = false;
            this.ToolsOptionsGrpbx.Text = "Tools/Options";
            // 
            // MGesturesChckbx
            // 
            this.MGesturesChckbx.AutoSize = true;
            this.MGesturesChckbx.Location = new System.Drawing.Point(308, 33);
            this.MGesturesChckbx.Name = "MGesturesChckbx";
            this.MGesturesChckbx.Size = new System.Drawing.Size(98, 17);
            this.MGesturesChckbx.TabIndex = 10;
            this.MGesturesChckbx.Text = "Mimic Gestures";
            this.MGesturesChckbx.UseVisualStyleBackColor = true;
            // 
            // MClothesChckbx
            // 
            this.MClothesChckbx.AutoSize = true;
            this.MClothesChckbx.Location = new System.Drawing.Point(115, 33);
            this.MClothesChckbx.Name = "MClothesChckbx";
            this.MClothesChckbx.Size = new System.Drawing.Size(91, 17);
            this.MClothesChckbx.TabIndex = 7;
            this.MClothesChckbx.Text = "Mimic Clothes";
            this.MClothesChckbx.UseVisualStyleBackColor = true;
            // 
            // MDancingChckbx
            // 
            this.MDancingChckbx.AutoSize = true;
            this.MDancingChckbx.Location = new System.Drawing.Point(308, 17);
            this.MDancingChckbx.Name = "MDancingChckbx";
            this.MDancingChckbx.Size = new System.Drawing.Size(96, 17);
            this.MDancingChckbx.TabIndex = 9;
            this.MDancingChckbx.Text = "Mimic Dancing";
            this.MDancingChckbx.UseVisualStyleBackColor = true;
            // 
            // MSignChckbx
            // 
            this.MSignChckbx.AutoSize = true;
            this.MSignChckbx.Location = new System.Drawing.Point(212, 17);
            this.MSignChckbx.Name = "MSignChckbx";
            this.MSignChckbx.Size = new System.Drawing.Size(77, 17);
            this.MSignChckbx.TabIndex = 4;
            this.MSignChckbx.Text = "Mimic Sign";
            this.MSignChckbx.UseVisualStyleBackColor = true;
            // 
            // MMottoChckbx
            // 
            this.MMottoChckbx.AutoSize = true;
            this.MMottoChckbx.Location = new System.Drawing.Point(115, 17);
            this.MMottoChckbx.Name = "MMottoChckbx";
            this.MMottoChckbx.Size = new System.Drawing.Size(83, 17);
            this.MMottoChckbx.TabIndex = 6;
            this.MMottoChckbx.Text = "Mimic Motto";
            this.MMottoChckbx.UseVisualStyleBackColor = true;
            // 
            // MWalkingChckbx
            // 
            this.MWalkingChckbx.AutoSize = true;
            this.MWalkingChckbx.Location = new System.Drawing.Point(14, 17);
            this.MWalkingChckbx.Name = "MWalkingChckbx";
            this.MWalkingChckbx.Size = new System.Drawing.Size(95, 17);
            this.MWalkingChckbx.TabIndex = 3;
            this.MWalkingChckbx.Text = "Mimic Walking";
            this.MWalkingChckbx.UseVisualStyleBackColor = true;
            // 
            // MStanceChckbx
            // 
            this.MStanceChckbx.AutoSize = true;
            this.MStanceChckbx.Location = new System.Drawing.Point(212, 33);
            this.MStanceChckbx.Name = "MStanceChckbx";
            this.MStanceChckbx.Size = new System.Drawing.Size(90, 17);
            this.MStanceChckbx.TabIndex = 8;
            this.MStanceChckbx.Text = "Mimic Stance";
            this.MStanceChckbx.UseVisualStyleBackColor = true;
            // 
            // MSpeechChckbx
            // 
            this.MSpeechChckbx.AutoSize = true;
            this.MSpeechChckbx.Location = new System.Drawing.Point(14, 33);
            this.MSpeechChckbx.Name = "MSpeechChckbx";
            this.MSpeechChckbx.Size = new System.Drawing.Size(93, 17);
            this.MSpeechChckbx.TabIndex = 5;
            this.MSpeechChckbx.Text = "Mimic Speech";
            this.MSpeechChckbx.UseVisualStyleBackColor = true;
            // 
            // AutoCopyCMChckbx
            // 
            this.AutoCopyCMChckbx.AutoSize = true;
            this.AutoCopyCMChckbx.Location = new System.Drawing.Point(231, 32);
            this.AutoCopyCMChckbx.Name = "AutoCopyCMChckbx";
            this.AutoCopyCMChckbx.Size = new System.Drawing.Size(185, 17);
            this.AutoCopyCMChckbx.TabIndex = 8;
            this.AutoCopyCMChckbx.Text = "Automatically Copy Clothes\\Motto";
            this.AutoCopyCMChckbx.UseVisualStyleBackColor = true;
            // 
            // SettingsGrpbx
            // 
            this.SettingsGrpbx.Controls.Add(this.AutoLoadChckbx);
            this.SettingsGrpbx.Controls.Add(this.AClearOnExit);
            this.SettingsGrpbx.Location = new System.Drawing.Point(225, 4);
            this.SettingsGrpbx.Name = "SettingsGrpbx";
            this.SettingsGrpbx.Size = new System.Drawing.Size(193, 68);
            this.SettingsGrpbx.TabIndex = 10;
            this.SettingsGrpbx.TabStop = false;
            this.SettingsGrpbx.Text = "Settings";
            // 
            // AutoLoadChckbx
            // 
            this.AutoLoadChckbx.AutoSize = true;
            this.AutoLoadChckbx.Checked = true;
            this.AutoLoadChckbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoLoadChckbx.Location = new System.Drawing.Point(6, 14);
            this.AutoLoadChckbx.Name = "AutoLoadChckbx";
            this.AutoLoadChckbx.Size = new System.Drawing.Size(170, 17);
            this.AutoLoadChckbx.TabIndex = 1;
            this.AutoLoadChckbx.Text = "Automatically Load Information";
            this.AutoLoadChckbx.UseVisualStyleBackColor = true;
            // 
            // AClearOnExit
            // 
            this.AClearOnExit.AutoSize = true;
            this.AClearOnExit.Location = new System.Drawing.Point(6, 45);
            this.AClearOnExit.Name = "AClearOnExit";
            this.AClearOnExit.Size = new System.Drawing.Size(183, 17);
            this.AClearOnExit.TabIndex = 8;
            this.AClearOnExit.Text = "Automatically Clear On Room Exit";
            this.AClearOnExit.UseVisualStyleBackColor = true;
            // 
            // PlayerInformationGrpbx
            // 
            this.PlayerInformationGrpbx.Controls.Add(this.PlayerInformationPnl);
            this.PlayerInformationGrpbx.Controls.Add(this.checkBox2);
            this.PlayerInformationGrpbx.Location = new System.Drawing.Point(4, 70);
            this.PlayerInformationGrpbx.Name = "PlayerInformationGrpbx";
            this.PlayerInformationGrpbx.Size = new System.Drawing.Size(414, 184);
            this.PlayerInformationGrpbx.TabIndex = 9;
            this.PlayerInformationGrpbx.TabStop = false;
            this.PlayerInformationGrpbx.Text = "Player Information";
            // 
            // PlayerInformationPnl
            // 
            this.PlayerInformationPnl.AutoScroll = true;
            this.PlayerInformationPnl.Controls.Add(this.PDataGrid);
            this.PlayerInformationPnl.Controls.Add(this.PlayerImg);
            this.PlayerInformationPnl.Location = new System.Drawing.Point(6, 19);
            this.PlayerInformationPnl.Name = "PlayerInformationPnl";
            this.PlayerInformationPnl.Size = new System.Drawing.Size(402, 159);
            this.PlayerInformationPnl.TabIndex = 1;
            // 
            // PDataGrid
            // 
            this.PDataGrid.AllowUserToAddRows = false;
            this.PDataGrid.AllowUserToDeleteRows = false;
            this.PDataGrid.AllowUserToResizeColumns = false;
            this.PDataGrid.AllowUserToResizeRows = false;
            this.PDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.PDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataType,
            this.DataValue});
            this.PDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PDataGrid.Location = new System.Drawing.Point(64, 0);
            this.PDataGrid.MultiSelect = false;
            this.PDataGrid.Name = "PDataGrid";
            this.PDataGrid.ReadOnly = true;
            this.PDataGrid.RowHeadersVisible = false;
            this.PDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PDataGrid.ShowCellErrors = false;
            this.PDataGrid.ShowCellToolTips = false;
            this.PDataGrid.ShowEditingIcon = false;
            this.PDataGrid.ShowRowErrors = false;
            this.PDataGrid.Size = new System.Drawing.Size(338, 159);
            this.PDataGrid.TabIndex = 1;
            // 
            // DataType
            // 
            this.DataType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataType.FillWeight = 30F;
            this.DataType.HeaderText = "Type";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            this.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataValue
            // 
            this.DataValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataValue.HeaderText = "Value";
            this.DataValue.Name = "DataValue";
            this.DataValue.ReadOnly = true;
            this.DataValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlayerImg
            // 
            this.PlayerImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlayerImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlayerImg.ErrorImage = null;
            this.PlayerImg.InitialImage = null;
            this.PlayerImg.Location = new System.Drawing.Point(0, 0);
            this.PlayerImg.Name = "PlayerImg";
            this.PlayerImg.Size = new System.Drawing.Size(64, 159);
            this.PlayerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PlayerImg.TabIndex = 0;
            this.PlayerImg.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(223, -15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(185, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Automatically Copy Clothes\\Motto";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // SelectPlayerGrpbx
            // 
            this.SelectPlayerGrpbx.Controls.Add(this.ClearBtn);
            this.SelectPlayerGrpbx.Controls.Add(this.PlayerListCmbbx);
            this.SelectPlayerGrpbx.Location = new System.Drawing.Point(4, 4);
            this.SelectPlayerGrpbx.Name = "SelectPlayerGrpbx";
            this.SelectPlayerGrpbx.Size = new System.Drawing.Size(215, 49);
            this.SelectPlayerGrpbx.TabIndex = 6;
            this.SelectPlayerGrpbx.TabStop = false;
            this.SelectPlayerGrpbx.Text = "Select Player - Total: 0";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(169, 16);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(40, 23);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // PlayerListCmbbx
            // 
            this.PlayerListCmbbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerListCmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerListCmbbx.Enabled = false;
            this.PlayerListCmbbx.FormattingEnabled = true;
            this.PlayerListCmbbx.Location = new System.Drawing.Point(6, 18);
            this.PlayerListCmbbx.Name = "PlayerListCmbbx";
            this.PlayerListCmbbx.Size = new System.Drawing.Size(157, 21);
            this.PlayerListCmbbx.TabIndex = 2;
            this.PlayerListCmbbx.SelectedIndexChanged += new System.EventHandler(this.PlayerListCmbbx_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 360);
            this.Controls.Add(this.MainTabCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Tanji Mimic - Main";
            this.MainTabCtrl.ResumeLayout(false);
            this.HomeTab.ResumeLayout(false);
            this.HomeTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolboxTab.ResumeLayout(false);
            this.ToolboxTab.PerformLayout();
            this.ToolsOptionsGrpbx.ResumeLayout(false);
            this.ToolsOptionsGrpbx.PerformLayout();
            this.SettingsGrpbx.ResumeLayout(false);
            this.SettingsGrpbx.PerformLayout();
            this.PlayerInformationGrpbx.ResumeLayout(false);
            this.PlayerInformationGrpbx.PerformLayout();
            this.PlayerInformationPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerImg)).EndInit();
            this.SelectPlayerGrpbx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabCtrl;
        private System.Windows.Forms.TabPage HomeTab;
        private System.Windows.Forms.Label NovoMimicLbl;
        private System.Windows.Forms.TabPage ToolboxTab;
        private System.Windows.Forms.GroupBox ToolsOptionsGrpbx;
        private System.Windows.Forms.CheckBox MGesturesChckbx;
        private System.Windows.Forms.CheckBox MClothesChckbx;
        private System.Windows.Forms.CheckBox MDancingChckbx;
        private System.Windows.Forms.CheckBox MSignChckbx;
        private System.Windows.Forms.CheckBox MMottoChckbx;
        private System.Windows.Forms.CheckBox MWalkingChckbx;
        private System.Windows.Forms.CheckBox MStanceChckbx;
        private System.Windows.Forms.CheckBox MSpeechChckbx;
        private System.Windows.Forms.CheckBox AutoCopyCMChckbx;
        private System.Windows.Forms.GroupBox SettingsGrpbx;
        private System.Windows.Forms.CheckBox AutoLoadChckbx;
        private System.Windows.Forms.GroupBox PlayerInformationGrpbx;
        private System.Windows.Forms.Panel PlayerInformationPnl;
        private System.Windows.Forms.DataGridView PDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataValue;
        private System.Windows.Forms.PictureBox PlayerImg;
        private System.Windows.Forms.GroupBox SelectPlayerGrpbx;
        private System.Windows.Forms.ComboBox PlayerListCmbbx;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel TMLink;
        private System.Windows.Forms.LinkLabel ArachisGitHubLnkLbl;
        private System.Windows.Forms.LinkLabel DarkBoxLnkLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox AClearOnExit;
        private System.Windows.Forms.CheckBox checkBox2;

    }
}