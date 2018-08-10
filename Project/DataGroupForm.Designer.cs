namespace Project
{
	partial class DataGroupForm
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.NewGroupButton = new System.Windows.Forms.Button();
			this.ImportImageButton = new System.Windows.Forms.Button();
			this.HideButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 31);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AllowDrop = true;
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.AutoScrollMargin = new System.Drawing.Size(15, 15);
			this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AllowDrop = true;
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(314, 531);
			this.splitContainer1.SplitterDistance = 347;
			this.splitContainer1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ungrouped Images";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// NewGroupButton
			// 
			this.NewGroupButton.Location = new System.Drawing.Point(5, 2);
			this.NewGroupButton.Name = "NewGroupButton";
			this.NewGroupButton.Size = new System.Drawing.Size(75, 23);
			this.NewGroupButton.TabIndex = 5;
			this.NewGroupButton.Text = "New Group";
			this.NewGroupButton.UseVisualStyleBackColor = true;
			this.NewGroupButton.Click += new System.EventHandler(this.NewGroupButton_Click);
			// 
			// ImportImageButton
			// 
			this.ImportImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImportImageButton.Location = new System.Drawing.Point(102, 2);
			this.ImportImageButton.Name = "ImportImageButton";
			this.ImportImageButton.Size = new System.Drawing.Size(103, 23);
			this.ImportImageButton.TabIndex = 6;
			this.ImportImageButton.Text = "Import Image";
			this.ImportImageButton.UseVisualStyleBackColor = true;
			this.ImportImageButton.Click += new System.EventHandler(this.ImportImageButton_Click);
			// 
			// HideButton
			// 
			this.HideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.HideButton.Location = new System.Drawing.Point(239, 2);
			this.HideButton.Name = "HideButton";
			this.HideButton.Size = new System.Drawing.Size(75, 23);
			this.HideButton.TabIndex = 7;
			this.HideButton.Text = "Hide";
			this.HideButton.UseVisualStyleBackColor = true;
			this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
			// 
			// DataGroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.HideButton;
			this.ClientSize = new System.Drawing.Size(314, 562);
			this.ControlBox = false;
			this.Controls.Add(this.HideButton);
			this.Controls.Add(this.ImportImageButton);
			this.Controls.Add(this.NewGroupButton);
			this.Controls.Add(this.splitContainer1);
			this.MinimumSize = new System.Drawing.Size(330, 600);
			this.Name = "DataGroupForm";
			this.Text = "DataGroupForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.DataGroupForm_Load);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button NewGroupButton;
		private System.Windows.Forms.Button ImportImageButton;
		private System.Windows.Forms.Button HideButton;
	}
}