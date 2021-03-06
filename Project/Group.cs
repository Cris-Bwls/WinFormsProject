﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class Group
    {
		public const int m_nImageSize = 75;
		public const int m_nImagePadding = 5;

        private const int m_nHeaderPanelHeight = 25;
		private const int m_nDataPanelHeight = 100;
		
		private string m_Name = "Group";

		private Panel m_parentPanel = null;
		private List<Group> m_container = null;


		private Panel m_headerPanel = new Panel();
		private Panel m_dataPanel = new Panel();

		private Button m_collapseGroup = new Button();
		private Button m_renameGroup = new Button();
		private Button m_deleteGroup = new Button();

		private List<PictureBox> m_dataList = new List<PictureBox>();

		private TextBox m_TextBox = new TextBox();

		//--------------------------------------------------------
		//	Group
		//		Overloaded constructor
		//
		//	@param
		//		List<Group> container
		//			- container of the groups
		//		Panel parentPanel
		//			- parent panel of group
		//--------------------------------------------------------
		public Group(List<Group> container, Panel parentPanel)
        {
            // Set Container
            m_container = container;

			// New Tooltip
			ToolTip toolTip = new ToolTip();

            // Setup Parent Panel
            m_parentPanel = parentPanel;
            parentPanel.Controls.Add(m_dataPanel);
            parentPanel.Controls.Add(m_headerPanel);

            // Setup Header Panel
            m_headerPanel.Size = new System.Drawing.Size(parentPanel.Size.Width, m_nHeaderPanelHeight);
            m_headerPanel.Dock = DockStyle.Top;

            m_headerPanel.Controls.Add(m_collapseGroup);
            m_headerPanel.Controls.Add(m_renameGroup);
            m_headerPanel.Controls.Add(m_deleteGroup);
            m_headerPanel.Controls.Add(m_TextBox);

            // Collapse Button
            m_collapseGroup.Text = m_Name;
            m_collapseGroup.SetBounds(0, 0, (m_headerPanel.Size.Width / 2), m_headerPanel.Height);
            m_collapseGroup.Click += new System.EventHandler(CollapseGroup_Click);

			toolTip.SetToolTip(m_collapseGroup, "click to collapse group");

            // Rename Button
            m_renameGroup.Text = "...";
            m_renameGroup.SetBounds((m_headerPanel.Size.Width / 2) + 5, 0, 40, m_headerPanel.Height);
            m_renameGroup.Click += new System.EventHandler(RenameGroup_Click);

			toolTip.SetToolTip(m_renameGroup, "Click to enable renaming of group");

			// Delete Button
			m_deleteGroup.Text = "X";
            m_deleteGroup.SetBounds((m_headerPanel.Size.Width - 25), 0, 20, m_headerPanel.Height);
            m_deleteGroup.Click += new System.EventHandler(DeleteGroup_Click);
            m_deleteGroup.ForeColor = Color.Red;

			toolTip.SetToolTip(m_deleteGroup, "Click to delete group");

			// Setup Data Panel
			m_dataPanel.Size = new System.Drawing.Size(parentPanel.Size.Width, m_nDataPanelHeight);
            m_dataPanel.Dock = DockStyle.Top;

			m_dataPanel.BackColor = Color.DimGray;
			m_dataPanel.AllowDrop = true;
			m_dataPanel.AutoScroll = true;
			m_dataPanel.Resize += DataPanel_Resize;
			m_dataPanel.DragEnter += DataPanel_DragEnter;
			m_dataPanel.DragDrop += DataPanel_DragDrop;

            // Setup TextBox
            m_TextBox.Visible = false;
            m_TextBox.Text = m_Name;
            m_TextBox.TextChanged += new System.EventHandler(TextBox_ChangedText);
            m_TextBox.Size = new System.Drawing.Size(100, 20);
            m_TextBox.TabIndex = 3;

			toolTip.SetToolTip(m_TextBox, "Input new Group name here");
		}

		//--------------------------------------------------------
		//	UngroupImages
		//		Moves Images back to Ungrouped
		//--------------------------------------------------------
		private void UngroupImages()
		{
			DataGroupForm form = (DataGroupForm)m_parentPanel.FindForm();
			foreach (PictureBox picture in m_dataList)
			{
				picture.Parent = form.GetUnGroupedPanel();
				form.unGroupedList.Add(picture);
			}
			form.ResizeUngrouped();
		}

		//--------------------------------------------------------
		//	GetDataList
		//		
		//	@ return
		//		List<PictureBox> returns the list of picture boxes
		//--------------------------------------------------------
		public List<PictureBox> GetDataList()
		{
			return m_dataList;
		}

		//--------------------------------------------------------
		//	CollapseGroup_Click
		//		On click switches data panel visibility
		//--------------------------------------------------------
		private void CollapseGroup_Click(object sender, EventArgs e)
        {
            m_dataPanel.Visible = !m_dataPanel.Visible;
        }

		//--------------------------------------------------------
		//	RenameGroup_Click
		//		On click brings up rename text box
		//--------------------------------------------------------
		private void RenameGroup_Click(object sender, EventArgs e)
        {
            m_TextBox.Visible = !m_TextBox.Visible;

            if (m_TextBox.Visible)
            {
                var point = m_renameGroup.Location;
                point.X += m_renameGroup.Size.Width;
                m_TextBox.Location = point;
            }

        }

		//--------------------------------------------------------
		//	DeleteGroup_Click
		//		On click deletes group
		//--------------------------------------------------------
		private void DeleteGroup_Click(object sender, EventArgs e)
        {
            m_parentPanel.Controls.Remove(m_dataPanel);
            m_parentPanel.Controls.Remove(m_headerPanel);
			UngroupImages();
            m_container.Remove(this);
        }

		//--------------------------------------------------------
		//	TextBox_ChangedText
		//		On text change, changes name of group
		//--------------------------------------------------------
		private void TextBox_ChangedText(object sender, EventArgs e)
        {
            m_Name = m_TextBox.Text;
            m_collapseGroup.Text = m_Name;
        }

		//--------------------------------------------------------
		//	ResizeData
		//		Resizes the picture box locations 
		//		according to panel size
		//--------------------------------------------------------
		public void ResizeData()
		{
			int nImageSizeWPadding = (Group.m_nImageSize + Group.m_nImagePadding);
			int nColumnNum = m_dataPanel.Width / nImageSizeWPadding;

			for (int i = 0; i < m_dataList.Count; ++i)
			{
				int row = i / nColumnNum;
				int col = i % nColumnNum;

				int y = row * nImageSizeWPadding;
				int x = col * nImageSizeWPadding + 10;

				m_dataList[i].Location = new Point(x, y);
			}
		}

		//--------------------------------------------------------
		//	DataPanel_Resize
		//		On panel resize changes the positions of 
		//		picture boxes in the panel
		//--------------------------------------------------------
		private void DataPanel_Resize(object sender, EventArgs e)
		{
			ResizeData();
		}

		//--------------------------------------------------------
		//	DataPanel_DragEnter
		//		On enter checks drag contents and changes cursor
		//--------------------------------------------------------
		private void DataPanel_DragEnter(object sender, DragEventArgs e)
		{
			// Check that the data is a picturebox
			if (e.Data.GetDataPresent(typeof(PictureBox)))
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
		}

		//--------------------------------------------------------
		//	DataPanel_DragDrop
		//		On Drop moves picture box from origin to destination
		//		if able
		//--------------------------------------------------------
		private void DataPanel_DragDrop(object sender, DragEventArgs e)
		{

			// Check that the sender is a picturebox
			PictureBox temp = e.Data.GetData(typeof(PictureBox)) as PictureBox;
			if (temp == null)
			{
				e.Effect = DragDropEffects.None;
				return;
			}

			// Check that it came from DataGroupForm
			DataGroupForm f = temp.FindForm() as DataGroupForm;
			if (f == null)
			{
				e.Effect = DragDropEffects.None;
				return;
			}

			// Check if PictureBox is in Ungrouped List
			if (f.unGroupedList.Contains(temp))
			{
				f.unGroupedList.Remove(temp);
				f.ResizeUngrouped();

				temp.Parent = m_dataPanel;

				this.m_dataList.Add(temp);
				this.ResizeData();

				return;
			}
			
			// Check if PictureBox is in a Group
			foreach (Group g in f.groupList)
			{
				if (g.m_dataList.Contains(temp))
				{
					g.m_dataList.Remove(temp);
					g.ResizeData();

					temp.Parent = m_dataPanel;

					this.m_dataList.Add(temp);
					this.ResizeData();

					return;
				}
			}
		}

		//--------------------------------------------------------
		//	GetData
		//		Gets the name and data list
		//
		//	@param
		//		out string name
		//			- returns the name of the group
		//		out List<PictureBox> dataList 
		//			- returns the list of pictureBoxes
		//--------------------------------------------------------
		public void GetData(out string name, out List<PictureBox> dataList)
		{
			name = m_Name;
			dataList = m_dataList;
		}

		//--------------------------------------------------------
		//	SetName
		//		Sets name of group according to string
		//
		//	@param
		//		string name - new name of group
		//--------------------------------------------------------
		public void SetName(string name)
		{
			m_TextBox.Text = name;
			m_Name = name;
		}

		//--------------------------------------------------------
		//	GetDataPanel
		//		
		//	@return
		//		panel - returns panel containing all the data
		//--------------------------------------------------------
		public Panel GetDataPanel()
		{
			return m_dataPanel;
		}

		//--------------------------------------------------------
		//	RemoveControls
		//		Removes the groups panels from its parents control
		//--------------------------------------------------------
		public void RemoveControls()
		{
			m_parentPanel.Controls.Remove(m_headerPanel);
			m_parentPanel.Controls.Remove(m_dataPanel);
		}
	}
}
