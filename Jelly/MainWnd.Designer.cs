
namespace KakaoMSG
{
    partial class MainWnd
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.btnFindFriend = new System.Windows.Forms.Button();
            this.btnSyncDB = new System.Windows.Forms.Button();
            this.friendList = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gfl_fill = new System.Windows.Forms.Panel();
            this.GFList = new System.Windows.Forms.CheckedListBox();
            this.gfl_tool = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGFminus = new System.Windows.Forms.Button();
            this.chkGFLall = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnGFadd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gl_fill = new System.Windows.Forms.Panel();
            this.GList = new System.Windows.Forms.CheckedListBox();
            this.gl_tool = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGLdel = new System.Windows.Forms.Button();
            this.btnGLadd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fl_fill = new System.Windows.Forms.Panel();
            this.fl_tool = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFLremove = new System.Windows.Forms.Button();
            this.btnFLadd = new System.Windows.Forms.Button();
            this.chkFLall = new System.Windows.Forms.CheckBox();
            this.btnFLsave = new System.Windows.Forms.Button();
            this.txtMsgbox = new System.Windows.Forms.TextBox();
            this.btnKakaoMe = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImgUp = new System.Windows.Forms.Button();
            this.btnImgDown = new System.Windows.Forms.Button();
            this.lstImageView = new System.Windows.Forms.ListView();
            this.img = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.rbImgFirst = new System.Windows.Forms.RadioButton();
            this.rbMsgFirst = new System.Windows.Forms.RadioButton();
            this.btnImgRemove = new System.Windows.Forms.Button();
            this.btnImgAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKakaoAll = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SendList = new System.Windows.Forms.ListBox();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.setupTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gfl_fill.SuspendLayout();
            this.gfl_tool.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gl_fill.SuspendLayout();
            this.gl_tool.SuspendLayout();
            this.panel3.SuspendLayout();
            this.fl_fill.SuspendLayout();
            this.fl_tool.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindFriend
            // 
            this.btnFindFriend.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFindFriend.Location = new System.Drawing.Point(0, 0);
            this.btnFindFriend.Name = "btnFindFriend";
            this.btnFindFriend.Size = new System.Drawing.Size(140, 28);
            this.btnFindFriend.TabIndex = 0;
            this.btnFindFriend.Text = "친구목록 불러오기";
            this.btnFindFriend.UseVisualStyleBackColor = true;
            this.btnFindFriend.Click += new System.EventHandler(this.btnFindFriend_Click);
            // 
            // btnSyncDB
            // 
            this.btnSyncDB.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSyncDB.Location = new System.Drawing.Point(781, 0);
            this.btnSyncDB.Name = "btnSyncDB";
            this.btnSyncDB.Size = new System.Drawing.Size(99, 28);
            this.btnSyncDB.TabIndex = 2;
            this.btnSyncDB.Text = "DB 다시읽기";
            this.btnSyncDB.UseVisualStyleBackColor = true;
            this.btnSyncDB.Click += new System.EventHandler(this.button2_Click);
            // 
            // friendList
            // 
            this.friendList.CheckOnClick = true;
            this.friendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendList.FormattingEnabled = true;
            this.friendList.Items.AddRange(new object[] {
            "집사람",
            "송종근"});
            this.friendList.Location = new System.Drawing.Point(0, 0);
            this.friendList.Margin = new System.Windows.Forms.Padding(0);
            this.friendList.Name = "friendList";
            this.friendList.Size = new System.Drawing.Size(168, 562);
            this.friendList.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnFindFriend);
            this.panel1.Controls.Add(this.btnSyncDB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 30);
            this.panel1.TabIndex = 4;
            // 
            // btnConfig
            // 
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfig.Location = new System.Drawing.Point(729, 0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(52, 28);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.Text = "설정";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 624);
            this.panel2.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(170, 0);
            this.panel5.MinimumSize = new System.Drawing.Size(150, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 622);
            this.panel5.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.gfl_fill);
            this.panel7.Controls.Add(this.gfl_tool);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(60, 0);
            this.panel7.MinimumSize = new System.Drawing.Size(100, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(171, 620);
            this.panel7.TabIndex = 2;
            // 
            // gfl_fill
            // 
            this.gfl_fill.Controls.Add(this.GFList);
            this.gfl_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gfl_fill.Location = new System.Drawing.Point(0, 58);
            this.gfl_fill.Name = "gfl_fill";
            this.gfl_fill.Size = new System.Drawing.Size(171, 562);
            this.gfl_fill.TabIndex = 2;
            // 
            // GFList
            // 
            this.GFList.CheckOnClick = true;
            this.GFList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GFList.FormattingEnabled = true;
            this.GFList.Location = new System.Drawing.Point(0, 0);
            this.GFList.Name = "GFList";
            this.GFList.Size = new System.Drawing.Size(171, 562);
            this.GFList.TabIndex = 0;
            // 
            // gfl_tool
            // 
            this.gfl_tool.Controls.Add(this.label3);
            this.gfl_tool.Controls.Add(this.btnGFminus);
            this.gfl_tool.Controls.Add(this.chkGFLall);
            this.gfl_tool.Dock = System.Windows.Forms.DockStyle.Top;
            this.gfl_tool.Location = new System.Drawing.Point(0, 0);
            this.gfl_tool.Name = "gfl_tool";
            this.gfl_tool.Size = new System.Drawing.Size(171, 58);
            this.gfl_tool.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "수신자 목록";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGFminus
            // 
            this.btnGFminus.Location = new System.Drawing.Point(141, 25);
            this.btnGFminus.Name = "btnGFminus";
            this.btnGFminus.Size = new System.Drawing.Size(25, 25);
            this.btnGFminus.TabIndex = 1;
            this.btnGFminus.Text = "-";
            this.btnGFminus.UseVisualStyleBackColor = true;
            this.btnGFminus.Click += new System.EventHandler(this.btnGFminus_Click);
            // 
            // chkGFLall
            // 
            this.chkGFLall.AutoSize = true;
            this.chkGFLall.Location = new System.Drawing.Point(3, 28);
            this.chkGFLall.Name = "chkGFLall";
            this.chkGFLall.Size = new System.Drawing.Size(40, 19);
            this.chkGFLall.TabIndex = 3;
            this.chkGFLall.Text = "All";
            this.chkGFLall.UseVisualStyleBackColor = true;
            this.chkGFLall.CheckedChanged += new System.EventHandler(this.chkGFLall_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnGFadd);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(60, 620);
            this.panel6.TabIndex = 1;
            // 
            // btnGFadd
            // 
            this.btnGFadd.Location = new System.Drawing.Point(10, 262);
            this.btnGFadd.Name = "btnGFadd";
            this.btnGFadd.Size = new System.Drawing.Size(40, 43);
            this.btnGFadd.TabIndex = 0;
            this.btnGFadd.Text = ">";
            this.btnGFadd.UseVisualStyleBackColor = true;
            this.btnGFadd.Click += new System.EventHandler(this.btnGFadd_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.gl_fill);
            this.panel4.Controls.Add(this.gl_tool);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(403, 0);
            this.panel4.MinimumSize = new System.Drawing.Size(100, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 622);
            this.panel4.TabIndex = 6;
            // 
            // gl_fill
            // 
            this.gl_fill.Controls.Add(this.GList);
            this.gl_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gl_fill.Location = new System.Drawing.Point(0, 58);
            this.gl_fill.Name = "gl_fill";
            this.gl_fill.Size = new System.Drawing.Size(168, 562);
            this.gl_fill.TabIndex = 2;
            // 
            // GList
            // 
            this.GList.CheckOnClick = true;
            this.GList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GList.FormattingEnabled = true;
            this.GList.Items.AddRange(new object[] {
            "그룹A",
            "그룹B"});
            this.GList.Location = new System.Drawing.Point(0, 0);
            this.GList.Name = "GList";
            this.GList.Size = new System.Drawing.Size(168, 562);
            this.GList.TabIndex = 0;
            this.GList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.GList_ItemCheck);
            this.GList.SelectedValueChanged += new System.EventHandler(this.GList_SelectedValueChanged);
            // 
            // gl_tool
            // 
            this.gl_tool.Controls.Add(this.label4);
            this.gl_tool.Controls.Add(this.btnGLdel);
            this.gl_tool.Controls.Add(this.btnGLadd);
            this.gl_tool.Dock = System.Windows.Forms.DockStyle.Top;
            this.gl_tool.Location = new System.Drawing.Point(0, 0);
            this.gl_tool.Name = "gl_tool";
            this.gl_tool.Size = new System.Drawing.Size(168, 58);
            this.gl_tool.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "그룹";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGLdel
            // 
            this.btnGLdel.Location = new System.Drawing.Point(139, 25);
            this.btnGLdel.Name = "btnGLdel";
            this.btnGLdel.Size = new System.Drawing.Size(25, 25);
            this.btnGLdel.TabIndex = 3;
            this.btnGLdel.Text = "-";
            this.btnGLdel.UseVisualStyleBackColor = true;
            this.btnGLdel.Click += new System.EventHandler(this.btnGLdel_Click);
            // 
            // btnGLadd
            // 
            this.btnGLadd.Location = new System.Drawing.Point(110, 25);
            this.btnGLadd.Name = "btnGLadd";
            this.btnGLadd.Size = new System.Drawing.Size(25, 25);
            this.btnGLadd.TabIndex = 2;
            this.btnGLadd.Text = "+";
            this.btnGLadd.UseVisualStyleBackColor = true;
            this.btnGLadd.Click += new System.EventHandler(this.btnGLadd_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.fl_fill);
            this.panel3.Controls.Add(this.fl_tool);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.MinimumSize = new System.Drawing.Size(100, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 622);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // fl_fill
            // 
            this.fl_fill.Controls.Add(this.friendList);
            this.fl_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_fill.Location = new System.Drawing.Point(0, 58);
            this.fl_fill.Name = "fl_fill";
            this.fl_fill.Size = new System.Drawing.Size(168, 562);
            this.fl_fill.TabIndex = 5;
            // 
            // fl_tool
            // 
            this.fl_tool.Controls.Add(this.label5);
            this.fl_tool.Controls.Add(this.btnFLremove);
            this.fl_tool.Controls.Add(this.btnFLadd);
            this.fl_tool.Controls.Add(this.chkFLall);
            this.fl_tool.Controls.Add(this.btnFLsave);
            this.fl_tool.Dock = System.Windows.Forms.DockStyle.Top;
            this.fl_tool.Location = new System.Drawing.Point(0, 0);
            this.fl_tool.Name = "fl_tool";
            this.fl_tool.Size = new System.Drawing.Size(168, 58);
            this.fl_tool.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "카카오 친구목록";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFLremove
            // 
            this.btnFLremove.Location = new System.Drawing.Point(86, 25);
            this.btnFLremove.Name = "btnFLremove";
            this.btnFLremove.Size = new System.Drawing.Size(25, 25);
            this.btnFLremove.TabIndex = 5;
            this.btnFLremove.Text = "-";
            this.btnFLremove.UseVisualStyleBackColor = true;
            this.btnFLremove.Click += new System.EventHandler(this.btnFLremove_Click);
            // 
            // btnFLadd
            // 
            this.btnFLadd.Location = new System.Drawing.Point(57, 25);
            this.btnFLadd.Name = "btnFLadd";
            this.btnFLadd.Size = new System.Drawing.Size(25, 25);
            this.btnFLadd.TabIndex = 4;
            this.btnFLadd.Text = "+";
            this.btnFLadd.UseVisualStyleBackColor = true;
            this.btnFLadd.Click += new System.EventHandler(this.btnFLadd_Click);
            // 
            // chkFLall
            // 
            this.chkFLall.AutoSize = true;
            this.chkFLall.Location = new System.Drawing.Point(3, 28);
            this.chkFLall.Name = "chkFLall";
            this.chkFLall.Size = new System.Drawing.Size(40, 19);
            this.chkFLall.TabIndex = 2;
            this.chkFLall.Text = "All";
            this.chkFLall.UseVisualStyleBackColor = true;
            this.chkFLall.CheckedChanged += new System.EventHandler(this.chkFLall_CheckedChanged);
            // 
            // btnFLsave
            // 
            this.btnFLsave.Font = new System.Drawing.Font("맑은 고딕", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFLsave.Location = new System.Drawing.Point(128, 25);
            this.btnFLsave.Name = "btnFLsave";
            this.btnFLsave.Size = new System.Drawing.Size(35, 25);
            this.btnFLsave.TabIndex = 1;
            this.btnFLsave.Text = "저장";
            this.btnFLsave.UseVisualStyleBackColor = true;
            this.btnFLsave.Click += new System.EventHandler(this.btnFLsave_Click);
            // 
            // txtMsgbox
            // 
            this.txtMsgbox.Location = new System.Drawing.Point(6, 74);
            this.txtMsgbox.Multiline = true;
            this.txtMsgbox.Name = "txtMsgbox";
            this.txtMsgbox.Size = new System.Drawing.Size(285, 249);
            this.txtMsgbox.TabIndex = 7;
            this.txtMsgbox.TextChanged += new System.EventHandler(this.txtMsgbox_TextChanged);
            // 
            // btnKakaoMe
            // 
            this.btnKakaoMe.BackColor = System.Drawing.Color.Gold;
            this.btnKakaoMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKakaoMe.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnKakaoMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKakaoMe.Location = new System.Drawing.Point(6, 8);
            this.btnKakaoMe.Name = "btnKakaoMe";
            this.btnKakaoMe.Size = new System.Drawing.Size(132, 34);
            this.btnKakaoMe.TabIndex = 8;
            this.btnKakaoMe.Text = "나에게 보내기";
            this.btnKakaoMe.UseVisualStyleBackColor = false;
            this.btnKakaoMe.Click += new System.EventHandler(this.btnKakaoMe_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(575, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(307, 624);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.btnImgUp);
            this.tabPage1.Controls.Add(this.btnImgDown);
            this.tabPage1.Controls.Add(this.lstImageView);
            this.tabPage1.Controls.Add(this.rbImgFirst);
            this.tabPage1.Controls.Add(this.rbMsgFirst);
            this.tabPage1.Controls.Add(this.btnImgRemove);
            this.tabPage1.Controls.Add(this.btnImgAdd);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnKakaoAll);
            this.tabPage1.Controls.Add(this.txtMsgbox);
            this.tabPage1.Controls.Add(this.btnKakaoMe);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(299, 596);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "단일 메시지";
            // 
            // btnImgUp
            // 
            this.btnImgUp.Location = new System.Drawing.Point(217, 338);
            this.btnImgUp.Name = "btnImgUp";
            this.btnImgUp.Size = new System.Drawing.Size(25, 25);
            this.btnImgUp.TabIndex = 20;
            this.btnImgUp.Text = "^";
            this.btnImgUp.UseVisualStyleBackColor = true;
            this.btnImgUp.Click += new System.EventHandler(this.btnImgUp_Click);
            // 
            // btnImgDown
            // 
            this.btnImgDown.Location = new System.Drawing.Point(242, 338);
            this.btnImgDown.Name = "btnImgDown";
            this.btnImgDown.Size = new System.Drawing.Size(25, 25);
            this.btnImgDown.TabIndex = 19;
            this.btnImgDown.Text = "v";
            this.btnImgDown.UseVisualStyleBackColor = true;
            this.btnImgDown.Click += new System.EventHandler(this.btnImgDown_Click);
            // 
            // lstImageView
            // 
            this.lstImageView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.img,
            this.columnHeader1});
            this.lstImageView.Font = new System.Drawing.Font("맑은 고딕", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstImageView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstImageView.HideSelection = false;
            this.lstImageView.Location = new System.Drawing.Point(6, 366);
            this.lstImageView.Name = "lstImageView";
            this.lstImageView.Size = new System.Drawing.Size(287, 224);
            this.lstImageView.TabIndex = 18;
            this.lstImageView.UseCompatibleStateImageBehavior = false;
            // 
            // img
            // 
            this.img.Text = "이미지";
            this.img.Width = 287;
            // 
            // rbImgFirst
            // 
            this.rbImgFirst.AutoSize = true;
            this.rbImgFirst.Location = new System.Drawing.Point(132, 341);
            this.rbImgFirst.Name = "rbImgFirst";
            this.rbImgFirst.Size = new System.Drawing.Size(49, 19);
            this.rbImgFirst.TabIndex = 16;
            this.rbImgFirst.Text = "우선";
            this.rbImgFirst.UseVisualStyleBackColor = true;
            // 
            // rbMsgFirst
            // 
            this.rbMsgFirst.AutoSize = true;
            this.rbMsgFirst.Checked = true;
            this.rbMsgFirst.Location = new System.Drawing.Point(132, 53);
            this.rbMsgFirst.Name = "rbMsgFirst";
            this.rbMsgFirst.Size = new System.Drawing.Size(49, 19);
            this.rbMsgFirst.TabIndex = 15;
            this.rbMsgFirst.TabStop = true;
            this.rbMsgFirst.Text = "우선";
            this.rbMsgFirst.UseVisualStyleBackColor = true;
            // 
            // btnImgRemove
            // 
            this.btnImgRemove.Location = new System.Drawing.Point(268, 338);
            this.btnImgRemove.Name = "btnImgRemove";
            this.btnImgRemove.Size = new System.Drawing.Size(25, 25);
            this.btnImgRemove.TabIndex = 14;
            this.btnImgRemove.Text = "-";
            this.btnImgRemove.UseVisualStyleBackColor = true;
            this.btnImgRemove.Click += new System.EventHandler(this.btnImgRemove_Click);
            // 
            // btnImgAdd
            // 
            this.btnImgAdd.Location = new System.Drawing.Point(191, 338);
            this.btnImgAdd.Name = "btnImgAdd";
            this.btnImgAdd.Size = new System.Drawing.Size(25, 25);
            this.btnImgAdd.TabIndex = 13;
            this.btnImgAdd.Text = "+";
            this.btnImgAdd.UseVisualStyleBackColor = true;
            this.btnImgAdd.Click += new System.EventHandler(this.btnImgAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "이미지 첨부(선택)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "메시지 작성 하기";
            // 
            // btnKakaoAll
            // 
            this.btnKakaoAll.Location = new System.Drawing.Point(151, 8);
            this.btnKakaoAll.Name = "btnKakaoAll";
            this.btnKakaoAll.Size = new System.Drawing.Size(142, 34);
            this.btnKakaoAll.TabIndex = 9;
            this.btnKakaoAll.Text = "선택 그룹 보내기";
            this.btnKakaoAll.UseVisualStyleBackColor = true;
            this.btnKakaoAll.Click += new System.EventHandler(this.btnKakaoAll_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SendList);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(299, 596);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "전송결과";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SendList
            // 
            this.SendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendList.FormattingEnabled = true;
            this.SendList.ItemHeight = 15;
            this.SendList.Location = new System.Drawing.Point(3, 3);
            this.SendList.Name = "SendList";
            this.SendList.Size = new System.Drawing.Size(293, 590);
            this.SendList.TabIndex = 7;
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "1610323837628_1_091429.jpg");
            // 
            // setupTimer
            // 
            this.setupTimer.Interval = 5000;
            this.setupTimer.Tick += new System.EventHandler(this.setupTimer_Tick);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 654);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWnd";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jelly";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWnd_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWnd_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.gfl_fill.ResumeLayout(false);
            this.gfl_tool.ResumeLayout(false);
            this.gfl_tool.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gl_fill.ResumeLayout(false);
            this.gl_tool.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.fl_fill.ResumeLayout(false);
            this.fl_tool.ResumeLayout(false);
            this.fl_tool.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindFriend;
        private System.Windows.Forms.Button btnSyncDB;
        private System.Windows.Forms.CheckedListBox friendList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox GFList;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnGFminus;
        private System.Windows.Forms.Button btnGFadd;
        private System.Windows.Forms.Panel gfl_fill;
        private System.Windows.Forms.Panel gfl_tool;
        private System.Windows.Forms.Panel gl_fill;
        private System.Windows.Forms.Panel gl_tool;
        private System.Windows.Forms.Panel fl_fill;
        private System.Windows.Forms.Panel fl_tool;
        private System.Windows.Forms.Button btnGLdel;
        private System.Windows.Forms.Button btnGLadd;
        private System.Windows.Forms.CheckedListBox GList;
        private System.Windows.Forms.Button btnFLsave;
        private System.Windows.Forms.CheckBox chkFLall;
        private System.Windows.Forms.CheckBox chkGFLall;
        private System.Windows.Forms.Button btnFLremove;
        private System.Windows.Forms.Button btnFLadd;
        private System.Windows.Forms.TextBox txtMsgbox;
        private System.Windows.Forms.Button btnKakaoMe;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKakaoAll;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox SendList;
        private System.Windows.Forms.Button btnImgRemove;
        private System.Windows.Forms.Button btnImgAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbImgFirst;
        private System.Windows.Forms.RadioButton rbMsgFirst;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ListView lstImageView;
        private System.Windows.Forms.ColumnHeader img;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnImgUp;
        private System.Windows.Forms.Button btnImgDown;
        private System.Windows.Forms.Timer setupTimer;
    }
}

