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
using System.Xml.Serialization;

namespace Project
{
	public partial class DataGroupForm : Form
	{
		public List<Group> groupList = new List<Group>();
		public List<PictureBox> unGroupedList = new List<PictureBox>();

		public bool internalDrag = false;
		private bool isString = false;

		private List<string> dragPathList = new List<string>();
		private List<Image> imageList = new List<Image>();
		private List<Image> newImageList = new List<Image>();
		private Thread getImageThread;
		
		private string root = Application.StartupPath;

		public DataGroupForm(bool loadLast)
		{
			InitializeComponent();			

			// Double Buffering
			typeof(SplitContainer).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
			| BindingFlags.Instance | BindingFlags.NonPublic, null,
			splitContainer1, new object[] { true });

			//Load Previous Palette
			if (loadLast)
			{
				LoadPalette("./Last.ipal");
			}
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
				temp.ImageLocation = (string)image.Tag;
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
					foreach (string fileName in popup.FileNames)
					{
						string path = fileName;
						//Check if path is in project root
						if (fileName.Contains(root))
							//path = fileName.Trim(root.ToArray());
							path ="." + fileName.Remove(0, root.Length);

						Image temp = new Bitmap(path);
						temp.Tag = path;
						newImageList.Add(temp);
					}

					// Import Images
					ImportImages();
				}
			}
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
					foreach (string fileName in data)
					{
						string path = fileName;
						//Check if path is in project root
						if (fileName.Contains(root))
							//path = fileName.Trim(root.ToArray());
							path = "." + fileName.Remove(0, root.Length);
						//else
							// Give Warning to User

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
				Image temp = new Bitmap(path);
				temp.Tag = path;
				newImageList.Add(temp);
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

		public Panel GetUnGroupedPanel()
		{
			return UngroupedPanel;
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
			SavePalette("./Last.ipal");
		}

		private void hideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void SavePalette(string path)
		{
			FilePalette data = new FilePalette();

			// Add Ungrouped Images
			foreach (PictureBox pb in unGroupedList)
			{
				data.unGroupedList.Add(pb.ImageLocation);
			}

			// Add Groups
			foreach (Group group in groupList)
			{
				GroupData temp = new GroupData();
				List<PictureBox> list;

				group.GetData(out temp.name, out list);
				foreach (PictureBox pb in list)
				{
					temp.dataList.Add(pb.ImageLocation);
				}

				data.groupList.Add(temp);
			}

			// Serialize
			XmlSerializer serializer = new XmlSerializer(typeof(FilePalette));
			using (StreamWriter writer = new StreamWriter(path))
			{
				serializer.Serialize(writer, data);
			}
		}

		private void LoadPalette(string path)
		{
			ClearData();

			// Load Blank Palette
			if (!File.Exists(path))
			{
				return;
			}

			// Deserialize
			XmlSerializer serializer = new XmlSerializer(typeof(FilePalette));
			using (StreamReader reader = new StreamReader(path))
			{
				FilePalette data = (FilePalette)serializer.Deserialize(reader);

				foreach(string imageLoc in data.unGroupedList)
				{
					// Check image exists at location
					if (!File.Exists(imageLoc))
					{
						// File does not exist
						continue;
					}

					// Get Image from Save
					Image image = new Bitmap(imageLoc);
					image.Tag = imageLoc;

					// Add Image to imageList
					imageList.Add(image);

					// Create PictureBox
					PictureBox pictureBox = new PictureBox();
					pictureBox.Image = image;
					pictureBox.ImageLocation = (string)image.Tag;
					pictureBox.Parent = UngroupedPanel;
					pictureBox.Size = new Size(Group.m_nImageSize, Group.m_nImageSize);
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox.MouseDown += PictureBox_MouseDown;
					pictureBox.QueryContinueDrag += PictureBox_QueryContinueDrag;

					// Add PictureBox to unGroupedList
					unGroupedList.Add(pictureBox);					
				}
				ResizeUngrouped();

				foreach (GroupData groupData in data.groupList)
				{
					Group temp = new Group(groupList, splitContainer1.Panel1);
					groupList.Add(temp);

					// Set Name
					temp.SetName(groupData.name);

					// Get Data
					foreach (string imageLoc in groupData.dataList)
					{
						// Get Image from Save
						try
						{
							Image image;
							image = new Bitmap(imageLoc);

							// Add Image to imageList
							imageList.Add(image);
							image.Tag = imageLoc;

							// Create PictureBox
							PictureBox pictureBox = new PictureBox();
							pictureBox.Image = image;
							pictureBox.ImageLocation = (string)image.Tag;
							pictureBox.Parent = temp.GetDataPanel();
							pictureBox.Size = new Size(Group.m_nImageSize, Group.m_nImageSize);
							pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
							pictureBox.MouseDown += PictureBox_MouseDown;
							pictureBox.QueryContinueDrag += PictureBox_QueryContinueDrag;

							// Add PictureBox to unGroupedList
							temp.GetDataList().Add(pictureBox);
						}
						catch (Exception e)
						{
							// TODO
							// Create new Form saying image not found
							Console.WriteLine(e.Message);
						}
					}
					temp.ResizeData();
				}
			}

		}

		private void ResetPalette()
		{
			ClearData();
			//LoadPalette(null);
		}

		private void ClearData()
		{
			// Remove Groups from controls
			foreach (Group group in groupList)
			{
				group.RemoveControls();
			}
			// Clear Group List
			groupList.Clear();

			// Remove Ungrouped PictureBoxes from control
			UngroupedPanel.Controls.Clear();

			// Clear Ungrouped List
			unGroupedList.Clear();

			// Clear Image List
			imageList.Clear();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetPalette();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog popup = new SaveFileDialog())
			{
				popup.Title = "Save Palette";
				popup.Filter = "Image Palette File|*.ipal";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					SavePalette(popup.FileName);
				}
			}
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog popup = new OpenFileDialog())
			{
				popup.Title = "Load Palette";
				popup.Filter = "Image Palette File|*.ipal";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					LoadPalette(popup.FileName);
				}
			}
		}
	}
}
