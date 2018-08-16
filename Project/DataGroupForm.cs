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
		public List<Group> groupList = null;
		public List<PictureBox> unGroupedList = new List<PictureBox>();

		public bool internalDrag = false;
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
			// Load Images into ungrouped picture boxes
			foreach(Image image in newImageList)
			{
				var temp = new PictureBox();
				temp.Image = image;
				temp.Parent = UngroupedPanel;
				temp.Size = new Size(Group.m_nImageSize, Group.m_nImageSize);
				temp.SizeMode = PictureBoxSizeMode.Zoom;
				temp.MouseDown += PictureBox_MouseDown;
				temp.QueryContinueDrag += PictureBox_QueryContinueDrag;

				// Add PictureBox to list
				unGroupedList.Add(temp);
			}
			newImageList.Clear();
			ResizeUngrouped();
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
				e.Effect = DragDropEffects.Copy;
			}
			else
				e.Effect = DragDropEffects.None;
		}	

		private void SplitPanel2_DragDrop(object sender, DragEventArgs e)
		{
			if (isString)
			{
				getImageThread = new Thread(new ThreadStart(LoadImage));
				getImageThread.Start();

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

		public void ResizeUngrouped()
		{
			int nImageSizeWPadding = (Group.m_nImageSize + Group.m_nImagePadding);
			int nColumnNum = UngroupedPanel.Width / nImageSizeWPadding;

			for (int i = 0; i < unGroupedList.Count; ++i)
			{
				int row = i / nColumnNum;
				int col = i % nColumnNum;

				int y = row * nImageSizeWPadding;
				int x = col * nImageSizeWPadding + 10;

				unGroupedList[i].Location = new Point(x, y);
			}
		}

		private void UngroupedPanel_Resize(object sender, EventArgs e)
		{
			ResizeUngrouped();
		}

		private void PictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			((PictureBox)sender).DoDragDrop((sender), DragDropEffects.Move);
		}

		private void PictureBox_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			Form f = ((PictureBox)sender).FindForm();
			
			// Check Left and Right In bounds
			if (((MousePosition.X ) < f.DesktopBounds.Left) || ((MousePosition.X) > f.DesktopBounds.Right))
				// Check Up and Down In bounds
				if (((MousePosition.Y) < f.DesktopBounds.Top) ||	((MousePosition.Y) > f.DesktopBounds.Bottom))
					// Cancel Drag
					e.Action = DragAction.Cancel;
		}

		private void DataGroupForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Save current as LastUsed.ipal

			Console.WriteLine("HELP!!! Cameron murdered me!!!");
		}

	}
}
