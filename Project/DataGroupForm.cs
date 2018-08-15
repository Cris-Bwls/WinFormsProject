using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Project
{
	public partial class DataGroupForm : Form
	{
		private List<Group> groupList = null;
		private List<PictureBox> unGroupedList = new List<PictureBox>();

		private bool internalDrag = false;
		private bool isString = false;

		private List<string> dragPathList = new List<string>();
		private List<Image> imageList = new List<Image>();
		private List<Image> newImageList = new List<Image>();
		private Thread getImageThread;

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

		private void ImportImages()
		{
			foreach(Image image in newImageList)
			{
				var temp = new PictureBox();
				temp.Image = image;
				temp.Parent = splitContainer1.Panel2;
				temp.Dock = DockStyle.Top;
				// Add PictureBox to list
				unGroupedList.Add(temp);
			}
			// Load Images into ungrouped picture boxes
		}

		private void ImportImageButton_Click(object sender, EventArgs e)
		{
			// Get List of Image paths
			using (OpenFileDialog popup = new OpenFileDialog())
			{
				popup.Title = "Load Image";
				popup.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png";
				popup.Multiselect = true;

				if (popup.ShowDialog() == DialogResult.OK)
				{
					// Add Images to newImageList
					newImageList.Clear();
					foreach (string path in popup.FileNames)
					{
						newImageList.Add(new Bitmap(path));
					}

					// Import Images
					ImportImages();
				}
			}
		}

		// Hide the form
		private void HideButton_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void SplitPanel2_DragEnter(object sender, DragEventArgs e)
		{
			isString = GetIsValidFileType(e);
			if (isString)
			{
				getImageThread = new Thread(new ThreadStart(LoadImage));
				getImageThread.Start();
				e.Effect = DragDropEffects.Copy;
			}
			else
				e.Effect = DragDropEffects.None;
		}	

		private void SplitPanel2_DragDrop(object sender, DragEventArgs e)
		{
			if (isString)
			{
				while (getImageThread.IsAlive)
				{
					Application.DoEvents();
					Thread.Sleep(0);
				}
				ImportImages();
			}
		}

		private bool GetIsValidFileType(DragEventArgs e)
		{
			bool result = false;
			dragPathList.Clear();

			if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
				if (data != null)
				{
					foreach (string path in data)
					{
						string ext = Path.GetExtension(path).ToLower();
						if ((ext == ".jpg") || (ext == ".jpeg") || (ext == ".png") || (ext == ".bmp"))
						{
							dragPathList.Add(path);
							result = true;
						}
					}
				}
			}
			return result;
		}

		protected void LoadImage()
		{
			newImageList.Clear();
			foreach (string path in dragPathList)
			{
				newImageList.Add(new Bitmap(path));
			}
		}
	}
}
