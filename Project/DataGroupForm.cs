using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Project
{
	public partial class DataGroupForm : Form
	{
		private List<Group> groupList = null;
		public DataGroupForm()
		{
			InitializeComponent();

			// Double Buffering
			typeof(SplitContainer).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
			| BindingFlags.Instance | BindingFlags.NonPublic, null,
			splitContainer1, new object[] { true });
		}

		public void SetList(List<Group> list)
		{
			groupList = list;
		}

		private void DataGroupForm_Load(object sender, EventArgs e)
		{

		}
		
		private void NewGroupButton_Click(object sender, EventArgs e)
		{

			groupList.Add(new Group(groupList, splitContainer1.Panel1));
		}

		private void ImportImageButton_Click(object sender, EventArgs e)
		{
			// Load image put into ungrouped
		}

		private void HideButton_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
