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
	//--------------------------------------------------------
	//	ErrorState
	//		Enumerator for possible error states
	//--------------------------------------------------------
	enum ErrorState
	{
		Default,

		NotRoot,
		DoesNotExist

	}


	public partial class DataGroupForm : Form
	{
		public List<Group> groupList = new List<Group>();
		public List<PictureBox> unGroupedList = new List<PictureBox>();

		private ErrorState errorState = ErrorState.Default;
		private string errorText;

		public bool isDrag = false;
		private bool isString = false;

		private List<string> dragPathList = new List<string>();
		private List<Image> imageList = new List<Image>();
		private List<Image> newImageList = new List<Image>();
		private Thread getImageThread;
		private System.Windows.Forms.Timer dragTimer = new System.Windows.Forms.Timer();

		private const int delay = 100; //Minimum of 100

		private string root = Application.StartupPath;

		//--------------------------------------------------------
		//	DataGroupForm
		//		Constructor
		//--------------------------------------------------------
		public DataGroupForm(bool loadLast)
		{
			InitializeComponent();

			// Timer Init
			dragTimer.Interval = delay;
			dragTimer.Tick += Timer_Tick;

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

		//--------------------------------------------------------
		//	DataGroupForm_Load
		//--------------------------------------------------------
		private void DataGroupForm_Load(object sender, EventArgs e)
		{

		}

		//--------------------------------------------------------
		//	NewGroupButton_Click
		//		On click adds a new group
		//--------------------------------------------------------
		private void NewGroupButton_Click(object sender, EventArgs e)
		{

			groupList.Add(new Group(groupList, splitContainer1.Panel1));
		}

		//--------------------------------------------------------
		//	ImportImages
		//		Initialize picture boxes from images in
		//		newImageList
		//--------------------------------------------------------
		private void ImportImages()
		{
			// Load Images into ungrouped picture boxes
			foreach(Image image in newImageList)
			{
				// Init Picture Box
				var temp = new PictureBox();
				temp.Image = image;
				temp.ImageLocation = (string)image.Tag;
				temp.Parent = UngroupedPanel;
				temp.Size = new Size(Group.m_nImageSize, Group.m_nImageSize);
				temp.SizeMode = PictureBoxSizeMode.Zoom;
				temp.MouseDown += PictureBox_MouseDown;
				temp.QueryContinueDrag += PictureBox_QueryContinueDrag;

				// Add Tooltip
				toolTip1.SetToolTip(temp, "Left Click Picture Box to select it for map painting");

				// Add PictureBox to list
				unGroupedList.Add(temp);
			}
			newImageList.Clear();
			ResizeUngrouped();
		}

		//--------------------------------------------------------
		//	ImportImageButton_Click
		//		On click Load image/s using load dialog
		//--------------------------------------------------------
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
							path = fileName.TrimStart(root.ToArray());
						else
							errorState = ErrorState.NotRoot;

						Image temp = new Bitmap(path);
						temp.Tag = path;
						newImageList.Add(temp);
					}

					// Import Images
					ImportImages();
				}
			}
		}

		//--------------------------------------------------------
		//	SplitPanel2_DragEnter
		//		On drag enter check if valid and change cursor
		//		accordingly
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	SplitPanel2_DragDrop
		//		Drop dragged images into ungrouped panel 
		//		from file explorer
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	GetIsValidFileType
		//		Check drag contents are valid for drop
		//--------------------------------------------------------
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
							path = fileName.TrimStart(root.ToArray());
						else
							errorState = ErrorState.NotRoot;

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

		//--------------------------------------------------------
		//	LoadImage
		//		Load Images from new image list
		//--------------------------------------------------------
		protected void LoadImage()
		{
			newImageList.Clear();
			foreach (string path in dragPathList)
			{
				Image temp = new Bitmap(path);
				temp.Tag = path;
				newImageList.Add(temp);
			}
			if (errorState == ErrorState.NotRoot)
			{
				// Give Warning to User
				string text = "Image is not in root directory, only share palettes that have images in root directory";
				ErrorForm errorForm = new ErrorForm(text);
				errorForm.ShowDialog();
				errorState = ErrorState.Default;
			}
		}

		//--------------------------------------------------------
		//	ResizeUngrouped
		//		Resizes the ungrouped picture boxes
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	GetUnGroupedPanel
		//	
		//	@return
		//		Panel - returns ungrouped panel
		//--------------------------------------------------------
		public Panel GetUnGroupedPanel()
		{
			return UngroupedPanel;
		}

		//--------------------------------------------------------
		//	UngroupedPanel_Resize
		//		On Panel resize resizes the Ungrouped pictures
		//--------------------------------------------------------
		private void UngroupedPanel_Resize(object sender, EventArgs e)
		{
			ResizeUngrouped();
		}

		//--------------------------------------------------------
		//	PictureBox_MouseDown
		//		On mouse down makes picture box current 
		//		and starts the drag timer
		//--------------------------------------------------------
		private void PictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			dragTimer.Stop();
			dragTimer.Start();

			// Reset previous selected picture boxes border
			PictureBox prev = (PictureBox)((Form1)this.Owner).currentObject;

			if (prev != null)
				prev.BorderStyle = BorderStyle.None;

			// Set current selected picture boxes border
			PictureBox current = (PictureBox)sender;
			current.BorderStyle = BorderStyle.Fixed3D;

			// Set current object to sender
			((Form1)this.Owner).currentObject = sender;
		}

		//--------------------------------------------------------
		//	PictureBox_QueryContinueDrag
		//		Checks if drag should continue
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	DataGroupForm_FormClosed
		//		On form close Saves the palette
		//--------------------------------------------------------
		private void DataGroupForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Save current as LastUsed.ipal
			SavePalette("./Last.ipal");
		}

		//--------------------------------------------------------
		//	hideToolStripMenuItem_Click
		//		Hides the window
		//--------------------------------------------------------
		private void hideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		//--------------------------------------------------------
		//	SavePalette
		//		Saves a palette to file using given path
		//
		//	@param
		//	string path - path to Save file to
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	LoadPalette
		//		Loads a palette from file using given path
		//
		//	@param
		//	string path - path to load file from
		//--------------------------------------------------------
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
					// Check image exists
					if (!File.Exists(imageLoc))
					{
						errorState = ErrorState.DoesNotExist;
						errorText += (imageLoc + "\n");
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

					// Add Tooltip
					toolTip1.SetToolTip(pictureBox, "Left Click Picture Box to select it for map painting");

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
						// Check image exists
						if (!File.Exists(imageLoc))
						{
							errorState = ErrorState.DoesNotExist;
							errorText += (imageLoc + "\n");
							continue;
						}
						// Get Image from Save
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

						// Add Tooltip
						toolTip1.SetToolTip(pictureBox, "Left Click Picture Box to select it for map painting");

						// Add PictureBox to unGroupedList
						temp.GetDataList().Add(pictureBox);
					}
					
					temp.ResizeData();
				}

				// If Image failed to load
				if (errorState == ErrorState.DoesNotExist)
				{
					errorState = ErrorState.Default;
					ErrorForm errorForm = new ErrorForm("The following Images failed to load: \n" + errorText);
					errorForm.ShowDialog();
				}
			}

		}

		//--------------------------------------------------------
		//	ResetPalette
		//		Resets Palette by calling ClearData
		//--------------------------------------------------------
		private void ResetPalette()
		{
			ClearData();
			//LoadPalette(null);
		}

		//--------------------------------------------------------
		//	ClearData
		//		Clears Data
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	newToolStripMenuItem_Click
		//		Resets palette
		//--------------------------------------------------------
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetPalette();
		}

		//--------------------------------------------------------
		//	saveToolStripMenuItem_Click
		//		Saves a palette to file
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	loadToolStripMenuItem_Click
		//		Loads a palette from file
		//--------------------------------------------------------
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

		//--------------------------------------------------------
		//	Timer_Tick
		//		On Tick if left mouse button down activates 
		//		drag&drop
		//--------------------------------------------------------
		private void Timer_Tick(object sender, EventArgs e)
		{
			if (MouseButtons == MouseButtons.Left)
			{
				var temp = ((Form1)Owner).currentObject;
				((PictureBox)temp).DoDragDrop((temp), DragDropEffects.Move);
			}
			dragTimer.Stop();
		}
	}
}
