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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imagePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imagePalletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolbarPanel = new System.Windows.Forms.Panel();
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
			this.menuStrip1.SuspendLayout();
			this.ToolbarPanel.SuspendLayout();
			this.SizePanel.SuspendLayout();
			this.HeightPanel.SuspendLayout();
			this.WidthPanel.SuspendLayout();
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
            this.importToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagePaletteToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.importToolStripMenuItem.Text = "&Import";
			// 
			// imagePaletteToolStripMenuItem
			// 
			this.imagePaletteToolStripMenuItem.Name = "imagePaletteToolStripMenuItem";
			this.imagePaletteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.imagePaletteToolStripMenuItem.Text = "Image Palette";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.loadToolStripMenuItem.Text = "&Load";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagePalletteToolStripMenuItem});
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.windowToolStripMenuItem.Text = "&Window";
			this.windowToolStripMenuItem.Click += new System.EventHandler(this.windowToolStripMenuItem_Click);
			// 
			// imagePalletteToolStripMenuItem
			// 
			this.imagePalletteToolStripMenuItem.Name = "imagePalletteToolStripMenuItem";
			this.imagePalletteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.imagePalletteToolStripMenuItem.Text = "Image Palette";
			this.imagePalletteToolStripMenuItem.Click += new System.EventHandler(this.imagePalletteToolStripMenuItem_Click);
			// 
			// ToolbarPanel
			// 
			this.ToolbarPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ToolbarPanel.Controls.Add(this.SizePanel);
			this.ToolbarPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.ToolbarPanel.Location = new System.Drawing.Point(947, 24);
			this.ToolbarPanel.Name = "ToolbarPanel";
			this.ToolbarPanel.Size = new System.Drawing.Size(270, 630);
			this.ToolbarPanel.TabIndex = 2;
			// 
			// SizePanel
			// 
			this.SizePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.SizePanel.Controls.Add(this.ResizeMapButton);
			this.SizePanel.Controls.Add(this.SizeLabel);
			this.SizePanel.Controls.Add(this.HeightPanel);
			this.SizePanel.Controls.Add(this.WidthPanel);
			this.SizePanel.Location = new System.Drawing.Point(18, 13);
			this.SizePanel.Name = "SizePanel";
			this.SizePanel.Size = new System.Drawing.Size(240, 86);
			this.SizePanel.TabIndex = 2;
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
			this.SizeLabel.Location = new System.Drawing.Point(94, 0);
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
			this.HeightPanel.Location = new System.Drawing.Point(129, 14);
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
			this.WidthPanel.Location = new System.Drawing.Point(11, 14);
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
			this.WorkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WorkPanel.Location = new System.Drawing.Point(0, 24);
			this.WorkPanel.Name = "WorkPanel";
			this.WorkPanel.Size = new System.Drawing.Size(947, 630);
			this.WorkPanel.TabIndex = 3;
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
			this.SizePanel.ResumeLayout(false);
			this.SizePanel.PerformLayout();
			this.HeightPanel.ResumeLayout(false);
			this.HeightPanel.PerformLayout();
			this.WidthPanel.ResumeLayout(false);
			this.WidthPanel.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imagePaletteToolStripMenuItem;
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
	}
}

