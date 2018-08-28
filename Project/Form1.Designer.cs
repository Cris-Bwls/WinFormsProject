namespace Project
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imagePalletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolbarPanel = new System.Windows.Forms.Panel();
			this.MapOffsetPanel = new System.Windows.Forms.Panel();
			this.OffsetChangedButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.YPosAdd = new System.Windows.Forms.Button();
			this.YPosSub = new System.Windows.Forms.Button();
			this.YPosTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.XPosSub = new System.Windows.Forms.Button();
			this.XposAdd = new System.Windows.Forms.Button();
			this.XPosTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.DisplaySizePanel = new System.Windows.Forms.Panel();
			this.ImageSizeTextBox = new System.Windows.Forms.TextBox();
			this.SizeChangedButton = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.SizePanel = new System.Windows.Forms.Panel();
			this.ResizeMapButton = new System.Windows.Forms.Button();
			this.SizeLabel = new System.Windows.Forms.Label();
			this.HeightPanel = new System.Windows.Forms.Panel();
			this.HeightTextBox = new System.Windows.Forms.TextBox();
			this.HeightLabel = new System.Windows.Forms.Label();
			this.WidthPanel = new System.Windows.Forms.Panel();
			this.WidthTextBox = new System.Windows.Forms.TextBox();
			this.WidthLabel = new System.Windows.Forms.Label();
			this.WorkPanel = new System.Windows.Forms.Panel();
			this.mapPanel = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1.SuspendLayout();
			this.ToolbarPanel.SuspendLayout();
			this.MapOffsetPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.DisplaySizePanel.SuspendLayout();
			this.SizePanel.SuspendLayout();
			this.HeightPanel.SuspendLayout();
			this.WidthPanel.SuspendLayout();
			this.WorkPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1217, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.loadToolStripMenuItem.Text = "&Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagePalletteToolStripMenuItem});
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.windowToolStripMenuItem.Text = "&Window";
			// 
			// imagePalletteToolStripMenuItem
			// 
			this.imagePalletteToolStripMenuItem.Name = "imagePalletteToolStripMenuItem";
			this.imagePalletteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.imagePalletteToolStripMenuItem.Text = "Image Palette";
			this.imagePalletteToolStripMenuItem.ToolTipText = "Click to Show or Hide Palette Window";
			this.imagePalletteToolStripMenuItem.Click += new System.EventHandler(this.imagePalletteToolStripMenuItem_Click);
			// 
			// ToolbarPanel
			// 
			this.ToolbarPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ToolbarPanel.Controls.Add(this.MapOffsetPanel);
			this.ToolbarPanel.Controls.Add(this.DisplaySizePanel);
			this.ToolbarPanel.Controls.Add(this.SizePanel);
			this.ToolbarPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.ToolbarPanel.Location = new System.Drawing.Point(947, 24);
			this.ToolbarPanel.Name = "ToolbarPanel";
			this.ToolbarPanel.Size = new System.Drawing.Size(270, 630);
			this.ToolbarPanel.TabIndex = 2;
			// 
			// MapOffsetPanel
			// 
			this.MapOffsetPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.MapOffsetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapOffsetPanel.Controls.Add(this.OffsetChangedButton);
			this.MapOffsetPanel.Controls.Add(this.label2);
			this.MapOffsetPanel.Controls.Add(this.panel2);
			this.MapOffsetPanel.Controls.Add(this.panel3);
			this.MapOffsetPanel.Location = new System.Drawing.Point(18, 211);
			this.MapOffsetPanel.Name = "MapOffsetPanel";
			this.MapOffsetPanel.Size = new System.Drawing.Size(240, 86);
			this.MapOffsetPanel.TabIndex = 4;
			// 
			// OffsetChangedButton
			// 
			this.OffsetChangedButton.Location = new System.Drawing.Point(78, 60);
			this.OffsetChangedButton.Name = "OffsetChangedButton";
			this.OffsetChangedButton.Size = new System.Drawing.Size(84, 23);
			this.OffsetChangedButton.TabIndex = 3;
			this.OffsetChangedButton.Text = "Change Offset";
			this.OffsetChangedButton.UseVisualStyleBackColor = true;
			this.OffsetChangedButton.Click += new System.EventHandler(this.OffsetChangedButton_Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(93, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Map Offset";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel2
			// 
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel2.Controls.Add(this.YPosAdd);
			this.panel2.Controls.Add(this.YPosSub);
			this.panel2.Controls.Add(this.YPosTextBox);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(128, 14);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(100, 40);
			this.panel2.TabIndex = 1;
			// 
			// YPosAdd
			// 
			this.YPosAdd.Location = new System.Drawing.Point(77, 20);
			this.YPosAdd.Name = "YPosAdd";
			this.YPosAdd.Size = new System.Drawing.Size(23, 20);
			this.YPosAdd.TabIndex = 6;
			this.YPosAdd.Text = "+";
			this.toolTip1.SetToolTip(this.YPosAdd, "Increment Y positon");
			this.YPosAdd.UseVisualStyleBackColor = true;
			this.YPosAdd.Click += new System.EventHandler(this.YPosAdd_Click);
			// 
			// YPosSub
			// 
			this.YPosSub.Location = new System.Drawing.Point(0, 20);
			this.YPosSub.Name = "YPosSub";
			this.YPosSub.Size = new System.Drawing.Size(23, 20);
			this.YPosSub.TabIndex = 6;
			this.YPosSub.Text = "-";
			this.toolTip1.SetToolTip(this.YPosSub, "Decrement Y positon");
			this.YPosSub.UseVisualStyleBackColor = true;
			this.YPosSub.Click += new System.EventHandler(this.YPosSub_Click);
			// 
			// YPosTextBox
			// 
			this.YPosTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.YPosTextBox.Location = new System.Drawing.Point(25, 20);
			this.YPosTextBox.Name = "YPosTextBox";
			this.YPosTextBox.Size = new System.Drawing.Size(50, 20);
			this.YPosTextBox.TabIndex = 2;
			this.toolTip1.SetToolTip(this.YPosTextBox, "Change the Y Position ");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Y Pos";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel3
			// 
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel3.Controls.Add(this.XPosSub);
			this.panel3.Controls.Add(this.XposAdd);
			this.panel3.Controls.Add(this.XPosTextBox);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new System.Drawing.Point(10, 14);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(100, 40);
			this.panel3.TabIndex = 0;
			// 
			// XPosSub
			// 
			this.XPosSub.Location = new System.Drawing.Point(0, 20);
			this.XPosSub.Name = "XPosSub";
			this.XPosSub.Size = new System.Drawing.Size(23, 20);
			this.XPosSub.TabIndex = 6;
			this.XPosSub.Text = "-";
			this.toolTip1.SetToolTip(this.XPosSub, "Decrement X positon");
			this.XPosSub.UseVisualStyleBackColor = true;
			this.XPosSub.Click += new System.EventHandler(this.XPosSub_Click);
			// 
			// XposAdd
			// 
			this.XposAdd.Location = new System.Drawing.Point(77, 20);
			this.XposAdd.Name = "XposAdd";
			this.XposAdd.Size = new System.Drawing.Size(23, 20);
			this.XposAdd.TabIndex = 2;
			this.XposAdd.Text = "+";
			this.toolTip1.SetToolTip(this.XposAdd, "Increment X positon");
			this.XposAdd.UseVisualStyleBackColor = true;
			this.XposAdd.Click += new System.EventHandler(this.XposAdd_Click);
			// 
			// XPosTextBox
			// 
			this.XPosTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.XPosTextBox.Location = new System.Drawing.Point(25, 20);
			this.XPosTextBox.Name = "XPosTextBox";
			this.XPosTextBox.Size = new System.Drawing.Size(50, 20);
			this.XPosTextBox.TabIndex = 1;
			this.toolTip1.SetToolTip(this.XPosTextBox, "Change the X Position \r\nrelative to the top left tile");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 0);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "X Pos";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// DisplaySizePanel
			// 
			this.DisplaySizePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.DisplaySizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DisplaySizePanel.Controls.Add(this.ImageSizeTextBox);
			this.DisplaySizePanel.Controls.Add(this.SizeChangedButton);
			this.DisplaySizePanel.Controls.Add(this.Label1);
			this.DisplaySizePanel.Location = new System.Drawing.Point(18, 314);
			this.DisplaySizePanel.Name = "DisplaySizePanel";
			this.DisplaySizePanel.Size = new System.Drawing.Size(240, 51);
			this.DisplaySizePanel.TabIndex = 3;
			this.toolTip1.SetToolTip(this.DisplaySizePanel, "Change the viewing size of \r\nthe images on the map");
			// 
			// ImageSizeTextBox
			// 
			this.ImageSizeTextBox.Location = new System.Drawing.Point(10, 16);
			this.ImageSizeTextBox.Name = "ImageSizeTextBox";
			this.ImageSizeTextBox.Size = new System.Drawing.Size(100, 20);
			this.ImageSizeTextBox.TabIndex = 4;
			// 
			// SizeChangedButton
			// 
			this.SizeChangedButton.Location = new System.Drawing.Point(146, 13);
			this.SizeChangedButton.Name = "SizeChangedButton";
			this.SizeChangedButton.Size = new System.Drawing.Size(82, 23);
			this.SizeChangedButton.TabIndex = 3;
			this.SizeChangedButton.Text = "Change Size";
			this.SizeChangedButton.UseVisualStyleBackColor = true;
			this.SizeChangedButton.Click += new System.EventHandler(this.SizeChangedButton_Click);
			// 
			// Label1
			// 
			this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(84, -1);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(69, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Image Size";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SizePanel
			// 
			this.SizePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.SizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SizePanel.Controls.Add(this.ResizeMapButton);
			this.SizePanel.Controls.Add(this.SizeLabel);
			this.SizePanel.Controls.Add(this.HeightPanel);
			this.SizePanel.Controls.Add(this.WidthPanel);
			this.SizePanel.Location = new System.Drawing.Point(18, 15);
			this.SizePanel.Name = "SizePanel";
			this.SizePanel.Size = new System.Drawing.Size(240, 86);
			this.SizePanel.TabIndex = 2;
			this.toolTip1.SetToolTip(this.SizePanel, "Change size of map");
			// 
			// ResizeMapButton
			// 
			this.ResizeMapButton.Location = new System.Drawing.Point(78, 60);
			this.ResizeMapButton.Name = "ResizeMapButton";
			this.ResizeMapButton.Size = new System.Drawing.Size(75, 23);
			this.ResizeMapButton.TabIndex = 3;
			this.ResizeMapButton.Text = "Resize Map";
			this.ResizeMapButton.UseVisualStyleBackColor = true;
			this.ResizeMapButton.Click += new System.EventHandler(this.ResizeMapButton_Click);
			// 
			// SizeLabel
			// 
			this.SizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.SizeLabel.AutoSize = true;
			this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeLabel.Location = new System.Drawing.Point(93, 0);
			this.SizeLabel.Name = "SizeLabel";
			this.SizeLabel.Size = new System.Drawing.Size(59, 13);
			this.SizeLabel.TabIndex = 2;
			this.SizeLabel.Text = "Map Size";
			this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// HeightPanel
			// 
			this.HeightPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.HeightPanel.Controls.Add(this.HeightTextBox);
			this.HeightPanel.Controls.Add(this.HeightLabel);
			this.HeightPanel.Location = new System.Drawing.Point(128, 14);
			this.HeightPanel.Name = "HeightPanel";
			this.HeightPanel.Size = new System.Drawing.Size(100, 40);
			this.HeightPanel.TabIndex = 1;
			// 
			// HeightTextBox
			// 
			this.HeightTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.HeightTextBox.Location = new System.Drawing.Point(0, 20);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
			this.HeightTextBox.TabIndex = 2;
			// 
			// HeightLabel
			// 
			this.HeightLabel.AutoSize = true;
			this.HeightLabel.Location = new System.Drawing.Point(32, 0);
			this.HeightLabel.Name = "HeightLabel";
			this.HeightLabel.Size = new System.Drawing.Size(38, 13);
			this.HeightLabel.TabIndex = 1;
			this.HeightLabel.Text = "Height";
			this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// WidthPanel
			// 
			this.WidthPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.WidthPanel.Controls.Add(this.WidthTextBox);
			this.WidthPanel.Controls.Add(this.WidthLabel);
			this.WidthPanel.Location = new System.Drawing.Point(10, 14);
			this.WidthPanel.Name = "WidthPanel";
			this.WidthPanel.Size = new System.Drawing.Size(100, 40);
			this.WidthPanel.TabIndex = 0;
			// 
			// WidthTextBox
			// 
			this.WidthTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.WidthTextBox.Location = new System.Drawing.Point(0, 20);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
			this.WidthTextBox.TabIndex = 1;
			// 
			// WidthLabel
			// 
			this.WidthLabel.AutoSize = true;
			this.WidthLabel.Location = new System.Drawing.Point(34, 0);
			this.WidthLabel.Name = "WidthLabel";
			this.WidthLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.WidthLabel.Size = new System.Drawing.Size(35, 13);
			this.WidthLabel.TabIndex = 0;
			this.WidthLabel.Text = "Width";
			this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// WorkPanel
			// 
			this.WorkPanel.AutoScroll = true;
			this.WorkPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.WorkPanel.Controls.Add(this.mapPanel);
			this.WorkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WorkPanel.Location = new System.Drawing.Point(0, 24);
			this.WorkPanel.Name = "WorkPanel";
			this.WorkPanel.Size = new System.Drawing.Size(947, 630);
			this.WorkPanel.TabIndex = 3;
			// 
			// mapPanel
			// 
			this.mapPanel.AllowDrop = true;
			this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapPanel.AutoScroll = true;
			this.mapPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mapPanel.Location = new System.Drawing.Point(20, 15);
			this.mapPanel.Name = "mapPanel";
			this.mapPanel.Size = new System.Drawing.Size(900, 600);
			this.mapPanel.TabIndex = 0;
			this.toolTip1.SetToolTip(this.mapPanel, "Select an image on the palette,\r\nLeft Click on or drag over map tiles\r\nto place i" +
        "mage on the map");
			this.mapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
			this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
			this.mapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1217, 654);
			this.Controls.Add(this.WorkPanel);
			this.Controls.Add(this.ToolbarPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ToolbarPanel.ResumeLayout(false);
			this.MapOffsetPanel.ResumeLayout(false);
			this.MapOffsetPanel.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.DisplaySizePanel.ResumeLayout(false);
			this.DisplaySizePanel.PerformLayout();
			this.SizePanel.ResumeLayout(false);
			this.SizePanel.PerformLayout();
			this.HeightPanel.ResumeLayout(false);
			this.HeightPanel.PerformLayout();
			this.WidthPanel.ResumeLayout(false);
			this.WidthPanel.PerformLayout();
			this.WorkPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imagePalletteToolStripMenuItem;
		private System.Windows.Forms.Panel ToolbarPanel;
		private System.Windows.Forms.Panel WorkPanel;
		private System.Windows.Forms.Panel HeightPanel;
		private System.Windows.Forms.Label HeightLabel;
		private System.Windows.Forms.Panel WidthPanel;
		private System.Windows.Forms.Label WidthLabel;
		private System.Windows.Forms.TextBox HeightTextBox;
		private System.Windows.Forms.TextBox WidthTextBox;
		private System.Windows.Forms.Panel SizePanel;
		private System.Windows.Forms.Label SizeLabel;
		private System.Windows.Forms.Button ResizeMapButton;
		private System.Windows.Forms.Panel mapPanel;
		private System.Windows.Forms.Panel DisplaySizePanel;
		private System.Windows.Forms.Button SizeChangedButton;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox ImageSizeTextBox;
		private System.Windows.Forms.Panel MapOffsetPanel;
		private System.Windows.Forms.Button OffsetChangedButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox YPosTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox XPosTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button YPosAdd;
		private System.Windows.Forms.Button YPosSub;
		private System.Windows.Forms.Button XPosSub;
		private System.Windows.Forms.Button XposAdd;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}

