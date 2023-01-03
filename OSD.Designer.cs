namespace OSD
{
    partial class OSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSD));
            this.panel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pointTxt = new System.Windows.Forms.ColumnHeader();
            this.Xtxt = new System.Windows.Forms.ColumnHeader();
            this.Ytxt = new System.Windows.Forms.ColumnHeader();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.gridTrackBar = new System.Windows.Forms.TrackBar();
            this.darkModeButton = new System.Windows.Forms.Button();
            this.uspCheckBox = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(10, 10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1000, 1000);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.MouseEnter += new System.EventHandler(this.panel_MouseEnter);
            this.panel.MouseLeave += new System.EventHandler(this.panel_MouseLeave);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // resetButton
            // 
            this.resetButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.resetButton.BackColor = System.Drawing.Color.White;
            this.resetButton.CausesValidation = false;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetButton.Location = new System.Drawing.Point(1024, 878);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(204, 62);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(1024, 946);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 64);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pointTxt,
            this.Xtxt,
            this.Ytxt});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(1024, 10);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(204, 766);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            // 
            // pointTxt
            // 
            this.pointTxt.Text = "Point";
            this.pointTxt.Width = 67;
            // 
            // Xtxt
            // 
            this.Xtxt.Text = "X";
            this.Xtxt.Width = 67;
            // 
            // Ytxt
            // 
            this.Ytxt.Text = "Y";
            this.Ytxt.Width = 66;
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.BackColor = System.Drawing.Color.DarkGray;
            this.gridCheckBox.Location = new System.Drawing.Point(1024, 791);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(48, 19);
            this.gridCheckBox.TabIndex = 4;
            this.gridCheckBox.Text = "Grid";
            this.gridCheckBox.UseVisualStyleBackColor = false;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.gridCheckBox_CheckedChanged);
            // 
            // gridTrackBar
            // 
            this.gridTrackBar.Location = new System.Drawing.Point(1016, 816);
            this.gridTrackBar.Maximum = 20;
            this.gridTrackBar.Minimum = 3;
            this.gridTrackBar.Name = "gridTrackBar";
            this.gridTrackBar.Size = new System.Drawing.Size(104, 45);
            this.gridTrackBar.TabIndex = 5;
            this.gridTrackBar.Value = 3;
            this.gridTrackBar.Scroll += new System.EventHandler(this.gridTrackBar_Scroll);
            // 
            // darkModeButton
            // 
            this.darkModeButton.BackColor = System.Drawing.Color.White;
            this.darkModeButton.BackgroundImage = global::OSD.Properties.Resources.darkMode;
            this.darkModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.darkModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.darkModeButton.Location = new System.Drawing.Point(1198, 794);
            this.darkModeButton.Name = "darkModeButton";
            this.darkModeButton.Size = new System.Drawing.Size(30, 30);
            this.darkModeButton.TabIndex = 6;
            this.darkModeButton.UseVisualStyleBackColor = false;
            this.darkModeButton.Click += new System.EventHandler(this.darkModeButton_Click);
            // 
            // uspCheckBox
            // 
            this.uspCheckBox.AutoSize = true;
            this.uspCheckBox.Location = new System.Drawing.Point(1024, 853);
            this.uspCheckBox.Name = "uspCheckBox";
            this.uspCheckBox.Size = new System.Drawing.Size(131, 19);
            this.uspCheckBox.TabIndex = 7;
            this.uspCheckBox.Text = "Use same path back";
            this.uspCheckBox.UseVisualStyleBackColor = true;
            this.uspCheckBox.CheckedChanged += new System.EventHandler(this.uspCheckBox_CheckedChanged);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.White;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadButton.Location = new System.Drawing.Point(1131, 946);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(97, 64);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // OSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1240, 1017);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.uspCheckBox);
            this.Controls.Add(this.darkModeButton);
            this.Controls.Add(this.gridTrackBar);
            this.Controls.Add(this.gridCheckBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.panel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "OSD";
            this.Text = "OSD";
            this.Load += new System.EventHandler(this.OSD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TurboProgram_KeyDown);
            this.Resize += new System.EventHandler(this.TurboProgram_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel;
        private Button resetButton;
        private Button saveButton;
        private ListView listView1;
        private ColumnHeader pointTxt;
        private ColumnHeader Xtxt;
        private ColumnHeader Ytxt;
        private CheckBox gridCheckBox;
        private TrackBar gridTrackBar;
        private Button darkModeButton;
        private CheckBox uspCheckBox;
        private Button loadButton;
    }
}