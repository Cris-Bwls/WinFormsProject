using System;
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

		private Button m_addData = new Button();

		private List<PictureBox> m_dataList = new List<PictureBox>();

		private TextBox m_TextBox = new TextBox();

        public Group(List<Group> container, Panel parentPanel)
        {
            // Set Container
            m_container = container;

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

            // Rename Button
            m_renameGroup.Text = "...";
            m_renameGroup.SetBounds((m_headerPanel.Size.Width / 2) + 5, 0, 40, m_headerPanel.Height);
            m_renameGroup.Click += new System.EventHandler(RenameGroup_Click);

            // Delete Button
            m_deleteGroup.Text = "X";
            m_deleteGroup.SetBounds((m_headerPanel.Size.Width - 25), 0, 20, m_headerPanel.Height);
            m_deleteGroup.Click += new System.EventHandler(DeleteGroup_Click);
            m_deleteGroup.ForeColor = Color.Red;

            // Setup Data Panel
            m_dataPanel.Size = new System.Drawing.Size(parentPanel.Size.Width, m_nDataPanelHeight);
            m_dataPanel.Dock = DockStyle.Top;

            m_dataPanel.Controls.Add(m_addData);

            // Add Data Button
            m_addData.Dock = DockStyle.Top;
            m_addData.Click += new System.EventHandler(CollapseGroup_Click);

            // Setup TextBox
            m_TextBox.Visible = false;
            m_TextBox.Text = m_Name;
            m_TextBox.TextChanged += new System.EventHandler(TextBox_ChangedText);
            m_TextBox.Size = new System.Drawing.Size(100, 20);
            m_TextBox.TabIndex = 3;
        }

		public List<PictureBox> GetDataList()
		{
			return m_dataList;
		}

		private void CollapseGroup_Click(object sender, EventArgs e)
        {
            m_dataPanel.Visible = !m_dataPanel.Visible;
        }

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

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            m_parentPanel.Controls.Remove(m_dataPanel);
            m_parentPanel.Controls.Remove(m_headerPanel);
            m_container.Remove(this);
        }

        private void TextBox_ChangedText(object sender, EventArgs e)
        {
            m_Name = m_TextBox.Text;
            m_collapseGroup.Text = m_Name;
        }
    }
}
