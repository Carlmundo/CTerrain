namespace W2_Terrain_Loader
{
    partial class Main
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            tlpMain = new TableLayoutPanel();
            flpStatus = new FlowLayoutPanel();
            lblHeading = new Label();
            lblCurrent = new Label();
            pbLand = new PictureBox();
            treeLevels = new TreeView();
            flpButtons = new FlowLayoutPanel();
            btnLock = new Button();
            btnRefresh = new Button();
            btnSet = new Button();
            flpOptions = new FlowLayoutPanel();
            lblOptions = new Label();
            cbCavern = new CheckBox();
            cbSeed = new CheckBox();
            txtSeed = new TextBox();
            flpButtons2 = new FlowLayoutPanel();
            btnSave = new Button();
            btnFolder = new Button();
            tlpMain.SuspendLayout();
            flpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLand).BeginInit();
            flpButtons.SuspendLayout();
            flpOptions.SuspendLayout();
            flpButtons2.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(flpStatus, 0, 1);
            tlpMain.Controls.Add(pbLand, 0, 0);
            tlpMain.Controls.Add(treeLevels, 0, 4);
            tlpMain.Controls.Add(flpButtons, 0, 2);
            tlpMain.Controls.Add(flpOptions, 0, 3);
            tlpMain.Controls.Add(flpButtons2, 0, 5);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 6;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.Size = new Size(555, 653);
            tlpMain.TabIndex = 0;
            // 
            // flpStatus
            // 
            flpStatus.Anchor = AnchorStyles.Top;
            flpStatus.AutoSize = true;
            flpStatus.Controls.Add(lblHeading);
            flpStatus.Controls.Add(lblCurrent);
            flpStatus.FlowDirection = FlowDirection.TopDown;
            flpStatus.Location = new Point(203, 190);
            flpStatus.Name = "flpStatus";
            flpStatus.Size = new Size(149, 60);
            flpStatus.TabIndex = 0;
            flpStatus.Visible = false;
            // 
            // lblHeading
            // 
            lblHeading.Anchor = AnchorStyles.None;
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading.Location = new Point(3, 0);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(143, 30);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Current Map:";
            // 
            // lblCurrent
            // 
            lblCurrent.Anchor = AnchorStyles.None;
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(60, 30);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(28, 30);
            lblCurrent.TabIndex = 1;
            lblCurrent.Text = "...";
            // 
            // pbLand
            // 
            pbLand.Anchor = AnchorStyles.None;
            pbLand.BackColor = Color.Silver;
            pbLand.Location = new Point(42, 3);
            pbLand.Name = "pbLand";
            pbLand.Size = new Size(470, 181);
            pbLand.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLand.TabIndex = 0;
            pbLand.TabStop = false;
            // 
            // treeLevels
            // 
            treeLevels.Dock = DockStyle.Fill;
            treeLevels.Location = new Point(3, 355);
            treeLevels.Name = "treeLevels";
            treeLevels.Size = new Size(549, 243);
            treeLevels.TabIndex = 3;
            treeLevels.AfterSelect += treeLevels_AfterSelect;
            // 
            // flpButtons
            // 
            flpButtons.Anchor = AnchorStyles.None;
            flpButtons.AutoSize = true;
            flpButtons.Controls.Add(btnLock);
            flpButtons.Controls.Add(btnRefresh);
            flpButtons.Controls.Add(btnSet);
            flpButtons.Location = new Point(116, 256);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(322, 46);
            flpButtons.TabIndex = 1;
            // 
            // btnLock
            // 
            btnLock.AutoSize = true;
            btnLock.Location = new Point(3, 3);
            btnLock.Name = "btnLock";
            btnLock.Size = new Size(109, 40);
            btnLock.TabIndex = 0;
            btnLock.Tag = "";
            btnLock.Text = "Lock File";
            btnLock.UseVisualStyleBackColor = true;
            btnLock.Click += btnLock_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(118, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 40);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSet
            // 
            btnSet.AutoSize = true;
            btnSet.Location = new Point(223, 3);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(96, 40);
            btnSet.TabIndex = 2;
            btnSet.Text = "Set";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // flpOptions
            // 
            flpOptions.Anchor = AnchorStyles.None;
            flpOptions.AutoSize = true;
            flpOptions.Controls.Add(lblOptions);
            flpOptions.Controls.Add(cbCavern);
            flpOptions.Controls.Add(cbSeed);
            flpOptions.Controls.Add(txtSeed);
            flpOptions.Location = new Point(18, 308);
            flpOptions.Name = "flpOptions";
            flpOptions.Size = new Size(518, 41);
            flpOptions.TabIndex = 2;
            // 
            // lblOptions
            // 
            lblOptions.Anchor = AnchorStyles.None;
            lblOptions.AutoSize = true;
            lblOptions.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOptions.Location = new Point(3, 4);
            lblOptions.Margin = new Padding(3, 0, 3, 2);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(97, 30);
            lblOptions.TabIndex = 0;
            lblOptions.Text = "Options:";
            // 
            // cbCavern
            // 
            cbCavern.Anchor = AnchorStyles.None;
            cbCavern.AutoSize = true;
            cbCavern.Location = new Point(106, 3);
            cbCavern.Name = "cbCavern";
            cbCavern.Size = new Size(103, 34);
            cbCavern.TabIndex = 1;
            cbCavern.Text = "Cavern";
            cbCavern.UseVisualStyleBackColor = true;
            // 
            // cbSeed
            // 
            cbSeed.Anchor = AnchorStyles.None;
            cbSeed.AutoSize = true;
            cbSeed.Location = new Point(215, 3);
            cbSeed.Name = "cbSeed";
            cbSeed.Size = new Size(151, 34);
            cbSeed.TabIndex = 2;
            cbSeed.Text = "Spawn Seed";
            cbSeed.UseVisualStyleBackColor = true;
            cbSeed.CheckedChanged += cbSeed_CheckedChanged;
            // 
            // txtSeed
            // 
            txtSeed.Anchor = AnchorStyles.None;
            txtSeed.Location = new Point(372, 3);
            txtSeed.MaxLength = 10;
            txtSeed.Name = "txtSeed";
            txtSeed.PlaceholderText = "Random";
            txtSeed.Size = new Size(143, 35);
            txtSeed.TabIndex = 3;
            txtSeed.TextAlign = HorizontalAlignment.Center;
            txtSeed.Visible = false;
            // 
            // flpButtons2
            // 
            flpButtons2.Anchor = AnchorStyles.None;
            flpButtons2.AutoSize = true;
            flpButtons2.Controls.Add(btnSave);
            flpButtons2.Controls.Add(btnFolder);
            flpButtons2.Location = new Point(124, 604);
            flpButtons2.Name = "flpButtons2";
            flpButtons2.Size = new Size(306, 46);
            flpButtons2.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(157, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Last Map";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += cbSave_Click;
            // 
            // btnFolder
            // 
            btnFolder.AutoSize = true;
            btnFolder.Location = new Point(166, 3);
            btnFolder.Name = "btnFolder";
            btnFolder.Size = new Size(137, 40);
            btnFolder.TabIndex = 1;
            btnFolder.Text = "Open Folder";
            btnFolder.UseVisualStyleBackColor = true;
            btnFolder.Click += btnFolder_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(555, 653);
            Controls.Add(tlpMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(470, 600);
            Name = "Main";
            Text = "CTerrain";
            FormClosing += Main_Closing;
            Load += Main_Load;
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            flpStatus.ResumeLayout(false);
            flpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLand).EndInit();
            flpButtons.ResumeLayout(false);
            flpButtons.PerformLayout();
            flpOptions.ResumeLayout(false);
            flpOptions.PerformLayout();
            flpButtons2.ResumeLayout(false);
            flpButtons2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private PictureBox pbLand;
        private TreeView treeLevels;
        private FlowLayoutPanel flpButtons;
        private Button btnLock;
        private Button btnRefresh;
        private Button btnSet;
        private Label lblCurrent;
        private FlowLayoutPanel flpStatus;
        private Label lblHeading;
        private CheckBox cbCavern;
        private FlowLayoutPanel flpOptions;
        private CheckBox cbSeed;
        private Label lblOptions;
        private TextBox txtSeed;
        private Button btnSave;
        private FlowLayoutPanel flpButtons2;
        private Button btnFolder;
    }
}
