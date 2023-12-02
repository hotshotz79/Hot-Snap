namespace Hot_Snap
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dialog_snapLoc = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSnapLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettingsBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.dgv_cards = new System.Windows.Forms.DataGridView();
            this.flow_variants = new System.Windows.Forms.FlowLayoutPanel();
            this.diag_fileUpload = new System.Windows.Forms.OpenFileDialog();
            this.pic_upload = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnBrowseScreenshot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBundleLoc = new System.Windows.Forms.TextBox();
            this.btnBrowseBundle = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVariantName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPatch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chk_showNsfw = new System.Windows.Forms.CheckBox();
            this.chkUploadNsfw = new System.Windows.Forms.CheckBox();
            this.dgv_decks = new System.Windows.Forms.DataGridView();
            this.flow_deck = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGuide = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblNoVariants = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.chk_skipCaptureMsg = new System.Windows.Forms.CheckBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.lblInstalled = new System.Windows.Forms.Label();
            this.lblDblClick = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lnk_uabe = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCardSelected = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_upload)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_decks)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 681);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.lblDblClick);
            this.tabPage1.Controls.Add(this.lblInstalled);
            this.tabPage1.Controls.Add(this.lblNoVariants);
            this.tabPage1.Controls.Add(this.btnPull);
            this.tabPage1.Controls.Add(this.dgv_cards);
            this.tabPage1.Controls.Add(this.flow_variants);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Card Variants";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flow_deck);
            this.tabPage2.Controls.Add(this.dgv_decks);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnReset);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnUpload);
            this.tabPage3.Controls.Add(this.btnBrowseScreenshot);
            this.tabPage3.Controls.Add(this.btnCapture);
            this.tabPage3.Controls.Add(this.pic_upload);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(976, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Upload";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.btnSettingsSave);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(976, 648);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            // 
            // txtSnapLocation
            // 
            this.txtSnapLocation.Location = new System.Drawing.Point(110, 26);
            this.txtSnapLocation.Name = "txtSnapLocation";
            this.txtSnapLocation.Size = new System.Drawing.Size(262, 22);
            this.txtSnapLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Snap Location:";
            // 
            // btnSettingsBrowse
            // 
            this.btnSettingsBrowse.BackColor = System.Drawing.Color.DimGray;
            this.btnSettingsBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSettingsBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingsBrowse.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSettingsBrowse.Location = new System.Drawing.Point(378, 24);
            this.btnSettingsBrowse.Name = "btnSettingsBrowse";
            this.btnSettingsBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsBrowse.TabIndex = 2;
            this.btnSettingsBrowse.Text = "Browse";
            this.btnSettingsBrowse.UseVisualStyleBackColor = false;
            this.btnSettingsBrowse.Click += new System.EventHandler(this.btnSettingsBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "GitHub Token:";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(110, 56);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(262, 22);
            this.txtToken.TabIndex = 4;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSettingsSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSettingsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingsSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSettingsSave.Location = new System.Drawing.Point(767, 320);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsSave.TabIndex = 6;
            this.btnSettingsSave.Text = "Save";
            this.btnSettingsSave.UseVisualStyleBackColor = false;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // dgv_cards
            // 
            this.dgv_cards.AllowUserToAddRows = false;
            this.dgv_cards.AllowUserToDeleteRows = false;
            this.dgv_cards.AllowUserToResizeColumns = false;
            this.dgv_cards.AllowUserToResizeRows = false;
            this.dgv_cards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_cards.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_cards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cards.ColumnHeadersVisible = false;
            this.dgv_cards.Location = new System.Drawing.Point(0, 0);
            this.dgv_cards.MultiSelect = false;
            this.dgv_cards.Name = "dgv_cards";
            this.dgv_cards.ReadOnly = true;
            this.dgv_cards.RowHeadersVisible = false;
            this.dgv_cards.Size = new System.Drawing.Size(155, 622);
            this.dgv_cards.TabIndex = 0;
            this.dgv_cards.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cards_CellClick);
            this.dgv_cards.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cards_CellContentDoubleClick);
            // 
            // flow_variants
            // 
            this.flow_variants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_variants.AutoScroll = true;
            this.flow_variants.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flow_variants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flow_variants.Location = new System.Drawing.Point(154, 0);
            this.flow_variants.Name = "flow_variants";
            this.flow_variants.Size = new System.Drawing.Size(822, 622);
            this.flow_variants.TabIndex = 1;
            // 
            // diag_fileUpload
            // 
            this.diag_fileUpload.DefaultExt = "bundle";
            this.diag_fileUpload.Filter = "Cards|cards_assets*.bundle";
            // 
            // pic_upload
            // 
            this.pic_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_upload.Location = new System.Drawing.Point(40, 156);
            this.pic_upload.Name = "pic_upload";
            this.pic_upload.Size = new System.Drawing.Size(245, 290);
            this.pic_upload.TabIndex = 0;
            this.pic_upload.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DimGray;
            this.btnCapture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCapture.Location = new System.Drawing.Point(55, 454);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(82, 25);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnBrowseScreenshot
            // 
            this.btnBrowseScreenshot.BackColor = System.Drawing.Color.DimGray;
            this.btnBrowseScreenshot.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBrowseScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseScreenshot.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseScreenshot.Location = new System.Drawing.Point(187, 454);
            this.btnBrowseScreenshot.Name = "btnBrowseScreenshot";
            this.btnBrowseScreenshot.Size = new System.Drawing.Size(82, 25);
            this.btnBrowseScreenshot.TabIndex = 2;
            this.btnBrowseScreenshot.Text = "Browse";
            this.btnBrowseScreenshot.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "or";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "1. Preview Screenshot of Variant";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "2. Variant .bundle File";
            // 
            // txtBundleLoc
            // 
            this.txtBundleLoc.Location = new System.Drawing.Point(10, 30);
            this.txtBundleLoc.Name = "txtBundleLoc";
            this.txtBundleLoc.Size = new System.Drawing.Size(352, 22);
            this.txtBundleLoc.TabIndex = 7;
            // 
            // btnBrowseBundle
            // 
            this.btnBrowseBundle.BackColor = System.Drawing.Color.DimGray;
            this.btnBrowseBundle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBrowseBundle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBundle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseBundle.Location = new System.Drawing.Point(287, 56);
            this.btnBrowseBundle.Name = "btnBrowseBundle";
            this.btnBrowseBundle.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseBundle.TabIndex = 8;
            this.btnBrowseBundle.Text = "Browse";
            this.btnBrowseBundle.UseVisualStyleBackColor = false;
            this.btnBrowseBundle.Click += new System.EventHandler(this.btnBrowseBundle_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.ForestGreen;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpload.Location = new System.Drawing.Point(618, 454);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 25);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NOTE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(511, 70);
            this.label7.TabIndex = 0;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // txtVariantName
            // 
            this.txtVariantName.Location = new System.Drawing.Point(10, 173);
            this.txtVariantName.MaxLength = 20;
            this.txtVariantName.Name = "txtVariantName";
            this.txtVariantName.Size = new System.Drawing.Size(292, 22);
            this.txtVariantName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "4. Variant Name (File Name)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "(A-Z 0-9  only; no special characters or spaces)";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(976, 648);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(382, 279);
            this.label9.TabIndex = 0;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "3.Verify Card Selected:";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(976, 648);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Guide";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DimGray;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(537, 454);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtSnapLocation);
            this.groupBox3.Controls.Add(this.btnGuide);
            this.groupBox3.Controls.Add(this.btnSettingsBrowse);
            this.groupBox3.Controls.Add(this.txtToken);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(8, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 136);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Requirements";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnPatch);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(8, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(464, 157);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Modding";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(399, 84);
            this.label12.TabIndex = 0;
            this.label12.Text = "REQUIRED to allow modding of the game\r\n\r\nThis will launch a custom batch file to " +
    "patch the \'Catalog\' JSON\r\nusing Addressables Tools\r\n\r\nOnce patched, the file wil" +
    "l be copied to your APPDATA folder";
            // 
            // btnPatch
            // 
            this.btnPatch.BackColor = System.Drawing.Color.DimGray;
            this.btnPatch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPatch.Location = new System.Drawing.Point(356, 122);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(97, 23);
            this.btnPatch.TabIndex = 1;
            this.btnPatch.Text = "Patch JSON";
            this.btnPatch.UseVisualStyleBackColor = false;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(9, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(308, 14);
            this.label13.TabIndex = 2;
            this.label13.Text = "NOTE: this could take a while (5-10 minutes)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 254);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 14);
            this.label15.TabIndex = 19;
            this.label15.Text = "5. Tag NSFW (18+)?";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chk_skipCaptureMsg);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.chk_showNsfw);
            this.groupBox5.Controls.Add(this.txtUsername);
            this.groupBox5.Location = new System.Drawing.Point(478, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(364, 299);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generic";
            // 
            // chk_showNsfw
            // 
            this.chk_showNsfw.AutoSize = true;
            this.chk_showNsfw.Location = new System.Drawing.Point(6, 27);
            this.chk_showNsfw.Name = "chk_showNsfw";
            this.chk_showNsfw.Size = new System.Drawing.Size(167, 18);
            this.chk_showNsfw.TabIndex = 0;
            this.chk_showNsfw.Text = "Display NSFW variants";
            this.chk_showNsfw.UseVisualStyleBackColor = true;
            // 
            // chkUploadNsfw
            // 
            this.chkUploadNsfw.AutoSize = true;
            this.chkUploadNsfw.Location = new System.Drawing.Point(204, 254);
            this.chkUploadNsfw.Name = "chkUploadNsfw";
            this.chkUploadNsfw.Size = new System.Drawing.Size(15, 14);
            this.chkUploadNsfw.TabIndex = 20;
            this.chkUploadNsfw.UseVisualStyleBackColor = true;
            // 
            // dgv_decks
            // 
            this.dgv_decks.AllowUserToAddRows = false;
            this.dgv_decks.AllowUserToDeleteRows = false;
            this.dgv_decks.AllowUserToResizeColumns = false;
            this.dgv_decks.AllowUserToResizeRows = false;
            this.dgv_decks.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_decks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_decks.ColumnHeadersVisible = false;
            this.dgv_decks.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_decks.Location = new System.Drawing.Point(3, 3);
            this.dgv_decks.MultiSelect = false;
            this.dgv_decks.Name = "dgv_decks";
            this.dgv_decks.ReadOnly = true;
            this.dgv_decks.RowHeadersVisible = false;
            this.dgv_decks.Size = new System.Drawing.Size(155, 642);
            this.dgv_decks.TabIndex = 0;
            // 
            // flow_deck
            // 
            this.flow_deck.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flow_deck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_deck.Location = new System.Drawing.Point(158, 3);
            this.flow_deck.Name = "flow_deck";
            this.flow_deck.Size = new System.Drawing.Size(815, 642);
            this.flow_deck.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(113, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(122, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(347, 34);
            this.label11.TabIndex = 1;
            this.label11.Text = "(Optional field to add username to uploaded files)";
            // 
            // btnGuide
            // 
            this.btnGuide.BackColor = System.Drawing.Color.DimGray;
            this.btnGuide.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuide.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuide.Location = new System.Drawing.Point(378, 56);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(75, 23);
            this.btnGuide.TabIndex = 5;
            this.btnGuide.Text = "Guide";
            this.btnGuide.UseVisualStyleBackColor = false;
            this.btnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(482, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(486, 229);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "GitHub Token";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(470, 182);
            this.label14.TabIndex = 1;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // lblNoVariants
            // 
            this.lblNoVariants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoVariants.BackColor = System.Drawing.Color.Firebrick;
            this.lblNoVariants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoVariants.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNoVariants.Location = new System.Drawing.Point(154, 623);
            this.lblNoVariants.Name = "lblNoVariants";
            this.lblNoVariants.Size = new System.Drawing.Size(822, 25);
            this.lblNoVariants.TabIndex = 0;
            this.lblNoVariants.Text = "No custom variants found";
            this.lblNoVariants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoVariants.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(789, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 51);
            this.button1.TabIndex = 16;
            this.button1.Text = "Flip to Deck";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 14);
            this.label16.TabIndex = 2;
            this.label16.Text = "Username tag:";
            // 
            // chk_skipCaptureMsg
            // 
            this.chk_skipCaptureMsg.AutoSize = true;
            this.chk_skipCaptureMsg.Location = new System.Drawing.Point(6, 108);
            this.chk_skipCaptureMsg.Name = "chk_skipCaptureMsg";
            this.chk_skipCaptureMsg.Size = new System.Drawing.Size(347, 18);
            this.chk_skipCaptureMsg.TabIndex = 3;
            this.chk_skipCaptureMsg.Text = "Skip pop-up message when \'Capturing\' screenshot";
            this.chk_skipCaptureMsg.UseVisualStyleBackColor = true;
            // 
            // btnPull
            // 
            this.btnPull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPull.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPull.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPull.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPull.Location = new System.Drawing.Point(77, 623);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(78, 25);
            this.btnPull.TabIndex = 2;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = false;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // lblInstalled
            // 
            this.lblInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstalled.BackColor = System.Drawing.Color.ForestGreen;
            this.lblInstalled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInstalled.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInstalled.Location = new System.Drawing.Point(154, 623);
            this.lblInstalled.Name = "lblInstalled";
            this.lblInstalled.Size = new System.Drawing.Size(822, 25);
            this.lblInstalled.TabIndex = 3;
            this.lblInstalled.Text = "Variant Installed!";
            this.lblInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInstalled.Visible = false;
            // 
            // lblDblClick
            // 
            this.lblDblClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDblClick.BackColor = System.Drawing.Color.LightBlue;
            this.lblDblClick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDblClick.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDblClick.Location = new System.Drawing.Point(154, 623);
            this.lblDblClick.Name = "lblDblClick";
            this.lblDblClick.Size = new System.Drawing.Size(822, 25);
            this.lblDblClick.TabIndex = 4;
            this.lblDblClick.Text = "Variants found, double click to install";
            this.lblDblClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDblClick.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 623);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Restore";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox6.Controls.Add(this.lnk_uabe);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(8, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(960, 632);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Texture Editing";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(7, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(443, 207);
            this.label18.TabIndex = 0;
            this.label18.Text = resources.GetString("label18.Text");
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(7, 218);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(512, 390);
            this.label19.TabIndex = 1;
            this.label19.Text = resources.GetString("label19.Text");
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(525, 268);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(429, 358);
            this.label20.TabIndex = 2;
            this.label20.Text = resources.GetString("label20.Text");
            // 
            // lnk_uabe
            // 
            this.lnk_uabe.AutoSize = true;
            this.lnk_uabe.Location = new System.Drawing.Point(268, 22);
            this.lnk_uabe.Name = "lnk_uabe";
            this.lnk_uabe.Size = new System.Drawing.Size(32, 14);
            this.lnk_uabe.TabIndex = 3;
            this.lnk_uabe.TabStop = true;
            this.lnk_uabe.Text = "Link";
            this.lnk_uabe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_uabe_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCardSelected);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtBundleLoc);
            this.panel1.Controls.Add(this.chkUploadNsfw);
            this.panel1.Controls.Add(this.btnBrowseBundle);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtVariantName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(318, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 290);
            this.panel1.TabIndex = 17;
            // 
            // lblCardSelected
            // 
            this.lblCardSelected.AutoSize = true;
            this.lblCardSelected.BackColor = System.Drawing.SystemColors.Control;
            this.lblCardSelected.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardSelected.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCardSelected.Location = new System.Drawing.Point(19, 117);
            this.lblCardSelected.Name = "lblCardSelected";
            this.lblCardSelected.Size = new System.Drawing.Size(0, 14);
            this.lblCardSelected.TabIndex = 23;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 681);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Hot SNAP! (v0.1)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_upload)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_decks)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FolderBrowserDialog dialog_snapLoc;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSettingsBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSnapLocation;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.FlowLayoutPanel flow_variants;
        private System.Windows.Forms.DataGridView dgv_cards;
        private System.Windows.Forms.OpenFileDialog diag_fileUpload;
        private System.Windows.Forms.PictureBox pic_upload;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseScreenshot;
        private System.Windows.Forms.TextBox txtBundleLoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowseBundle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVariantName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkUploadNsfw;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chk_showNsfw;
        private System.Windows.Forms.FlowLayoutPanel flow_deck;
        private System.Windows.Forms.DataGridView dgv_decks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblNoVariants;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chk_skipCaptureMsg;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Label lblInstalled;
        private System.Windows.Forms.Label lblDblClick;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel lnk_uabe;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCardSelected;
    }
}