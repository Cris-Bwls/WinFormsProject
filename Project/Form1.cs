using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Project
{
	public partial class Form1 : Form
	{
		private List<List<MapData>> mapArray = new List<List<MapData>>();
		private List<List<PictureBox>> pictureBoxArray = new List<List<PictureBox>>();
		private DataGroupForm dataGroupForm = new DataGroupForm(true);

		private uint mapHeight = 0;
		private uint mapWidth = 0;

		private const uint pictureBoxMaxCol = 25;
		private const uint pictureBoxMaxRow = 25;

		private uint mapOffsetX = 0;
		private uint mapOffsetY = 0;

		private int imageSize = 50;
		private const int imagePadding = 2;

		public object currentObject;

		//--------------------------------------------------------
		//	Form1
		//		Constructor
		//--------------------------------------------------------
		public Form1()
		{
			InitializeComponent();

			dataGroupForm.Show(this);

			// Inheritance & Polymorphism
			Inheritance inherit;
			inherit = new Child1();
			inherit.Print();
			inherit = new Child2();
			inherit.Print();

			// Init TextBoxes
			InitTextBoxes();

			// Double Buffering
			typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
			| BindingFlags.Instance | BindingFlags.NonPublic, null,
			WorkPanel, new object[] { true });
		}

		//--------------------------------------------------------
		//	Form1_Load
		//--------------------------------------------------------
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		//--------------------------------------------------------
		//	Reset
		//		Resets the map to default
		//--------------------------------------------------------
		private void Reset()
		{
			mapHeight = 0;
			mapWidth = 0;
			imageSize = 50;
			mapOffsetX = 0;
			mapOffsetY = 0;
			currentObject = null;

			mapArray.Clear();
			ResizePictureBoxArray();
			InitTextBoxes();

			
		}

		//--------------------------------------------------------
		//	InitTextBoxes
		//		Initializes the Input text boxes
		//--------------------------------------------------------
		private void InitTextBoxes()
		{
			HeightTextBox.Text = mapHeight.ToString();
			WidthTextBox.Text = mapWidth.ToString();

			XPosTextBox.Text = mapOffsetX.ToString();
			YPosTextBox.Text = mapOffsetY.ToString();

			ImageSizeTextBox.Text = imageSize.ToString();
		}

		//--------------------------------------------------------
		//	newToolStripMenuItem_Click
		//		Resets the current map to default
		//--------------------------------------------------------
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Reset();
		}

		//--------------------------------------------------------
		//	saveToolStripMenuItem_Click
		//		Saves the map to file
		//--------------------------------------------------------
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog popup = new SaveFileDialog())
			{
				popup.Title = "Save Map";
				popup.Filter = "Map File|*.map";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					SaveMap(popup.FileName);
				}
			}
		}

		//--------------------------------------------------------
		//	loadToolStripMenuItem_Click
		//		Loads a Map from file
		//--------------------------------------------------------
		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog popup = new OpenFileDialog())
			{
				popup.Title = "Load Map";
				popup.Filter = "Map File|*.map";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					LoadMap(popup.FileName);
				}
			}
		}

		//--------------------------------------------------------
		//	closeToolStripMenuItem_Click
		//		Closes the window
		//--------------------------------------------------------
		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//--------------------------------------------------------
		//	imagePalletteToolStripMenuItem_Click
		//		On Click changes visibility of ImagePalette window
		//		If it doesnt exist it creates it
		//--------------------------------------------------------
		private void imagePalletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGroupForm.IsDisposed)
				dataGroupForm = new DataGroupForm(true);

			dataGroupForm.Visible = !dataGroupForm.Visible;
		}

		//--------------------------------------------------------
		//	ResizeMapButton_Click
		//		On click changes map size based on user input
		//		if valid
		//--------------------------------------------------------
		private void ResizeMapButton_Click(object sender, EventArgs e)
		{
			bool widthInvalid = false;
			bool heightInvalid = false;

			if (uint.TryParse(HeightTextBox.Text, out mapHeight))
			{
				if (uint.TryParse(WidthTextBox.Text, out mapWidth))
				{
					//Change Map Size

					// Change Width
					int arrayWidth = mapArray.Count();
					// Shrink
					if (arrayWidth > mapWidth)
					{
						// Shrink Map Array
						int removeCount = arrayWidth - (int)mapWidth;
						for (int i = 0; i < removeCount; ++i)
						{
							mapArray.Remove(mapArray.Last());
						}
					}
					// Grow
					else
					{
						int addCount = (int)mapWidth - arrayWidth;
						for (int i = 0; i < addCount; ++i)
						{
							mapArray.Add(new List<MapData>());
						}
					}

					// Change Height
					foreach (List<MapData> list in mapArray)
					{
						int arrayHeight = list.Count();
						// Shrink
						if (arrayHeight > mapHeight)
						{
							int removeCount = arrayHeight - (int)mapHeight;
							for (int i = 0; i < removeCount; ++i)
							{
								list.Remove(list.Last());
							}
						}
						// Grow
						else
						{
							int addCount = (int)mapHeight - arrayHeight;
							for (int i = 0; i < addCount; ++i)
							{
								list.Add(new MapData());
							}
						}
					}

					// Resize PictureBox Array
					ResizePictureBoxArray();
				}
				// ELSE Width try parse failed
				else
					widthInvalid = true;
			}
			// ELSE Height try parse failed
			else
				heightInvalid = true;

			// If failure
			if (widthInvalid || heightInvalid)
			{
				// Get Error Text
				string errorText;
				if (widthInvalid)
					errorText = "Width is Invalid";
				else
					errorText = "Height is Invalid";

				// Show Error Dialog
				ErrorForm errorForm = new ErrorForm(errorText);
				errorForm.ShowDialog();
				errorForm.Location = MousePosition;
			}
		}

		//--------------------------------------------------------
		//	OffsetChangedButton_Click
		//		On Click changes offset based on user input if valid
		//--------------------------------------------------------
		private void OffsetChangedButton_Click(object sender, EventArgs e)
		{
			bool XOffsetInvalid = false;
			bool YOffsetInvalid = false;

			if (uint.TryParse(XPosTextBox.Text, out mapOffsetX))
				if (uint.TryParse(YPosTextBox.Text, out mapOffsetY))
				{
					ShiftMap();
				}
				else
					YOffsetInvalid = true;
			else
				XOffsetInvalid = true;

			// If failure
			if (XOffsetInvalid || YOffsetInvalid)
			{
				// Get Error Text
				string errorText;
				if (XOffsetInvalid)
					errorText = "X offset is Invalid";
				else
					errorText = "Y offset is Invalid";

				// Show Error Dialog
				ErrorForm errorForm = new ErrorForm(errorText);
				errorForm.ShowDialog();
				errorForm.DesktopLocation = MousePosition;
			}
		}

		//--------------------------------------------------------
		//	SizeChangedButton_Click
		//		On Click Changes the imagesize variable based upon
		//		text input if valid
		//--------------------------------------------------------
		private void SizeChangedButton_Click(object sender, EventArgs e)
		{
			bool error = false;
			int temp;

			if (int.TryParse(ImageSizeTextBox.Text, out temp))
			{
				if (temp < 0)
					error = true;
				else
				{
					imageSize = temp;
					ResizePictureBoxes();
				}
			}
			// ELSE try parse fails
			else
				error = true;

			// IF error occured
			if (error)
			{
				// Error Text
				string text = "Size inputed is invalid";

				// Show error window
				ErrorForm errorForm = new ErrorForm(text);
				errorForm.ShowDialog();
			}
		}

		//--------------------------------------------------------
		//	ResizePictureBoxArray
		//		Resizes the array based on map width and height
		//--------------------------------------------------------
		private void ResizePictureBoxArray()
		{
			// Change Width
			int arrayWidth = pictureBoxArray.Count();
			// Shrink
			if (arrayWidth > mapWidth)
			{
				// Shrink Map Array
				int removeCount = arrayWidth - (int)mapWidth;
				for (int i = 0; i < removeCount; ++i)
				{
					foreach (PictureBox temp in pictureBoxArray.Last())
					{
						temp.Parent = null;
					}
					pictureBoxArray.Remove(pictureBoxArray.Last());
				}
			}
			// Grow
			else
			{
				uint temp = mapWidth;
				if (temp > pictureBoxMaxRow)
					temp = pictureBoxMaxRow;

				int addCount = (int)temp - arrayWidth;
				for (int i = 0; i < addCount; ++i)
				{
					pictureBoxArray.Add(new List<PictureBox>());
				}
			}

			// Change Height
			foreach (List<PictureBox> list in pictureBoxArray)
			{
				int arrayHeight = list.Count();
				// Shrink
				if (arrayHeight > mapHeight)
				{
					int removeCount = arrayHeight - (int)mapHeight;
					for (int i = 0; i < removeCount; ++i)
					{
						list.Last().Parent = null;
						list.Remove(list.Last());
					}
				}
				// Grow
				else
				{
					uint temp = mapHeight;
					if (temp > pictureBoxMaxCol)
						temp = pictureBoxMaxCol;

					int addCount = (int)temp - arrayHeight;
					for (int i = 0; i < addCount; ++i)
					{
						Point pos = new Point(pictureBoxArray.IndexOf(list), list.Count());
						list.Add(NewPictureBox(pos));
					}
				}
			}
		}

		//--------------------------------------------------------
		//	NewPictureBox
		//		Creates and initializes a new picture box
		//
		//	@param
		//		Point pos - Index of Picturebox
		//--------------------------------------------------------
		private PictureBox NewPictureBox(Point pos)
		{
			var index = pos;
			// Change Pos
			pos.X *= (imageSize + imagePadding);
			pos.X += imagePadding;
			pos.Y *= (imageSize + imagePadding);
			pos.Y += imagePadding;

			// Create Picture Box
			PictureBox pictureBox = new PictureBox();
			pictureBox.Size = new Size(imageSize, imageSize);
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox.Location = pos;
			pictureBox.Parent = mapPanel;
			pictureBox.BackColor = Color.LightSlateGray;
			pictureBox.MouseMove += PictureBox_Capture;
			pictureBox.Tag = index;

			// Add Tooltip
			toolTip1.SetToolTip(pictureBox, "TEST");

			// Return Initialised PictureBox
			return pictureBox;
		}

		//--------------------------------------------------------
		//	PictureBox_Capture
		//		Sets mapPanels mouse capture to true when over the
		//		picture box
		//--------------------------------------------------------
		private void PictureBox_Capture(object sender, MouseEventArgs e)
		{
			mapPanel.Capture = true;
		}

		//--------------------------------------------------------
		//	PictureBox_MouseOver
		//		Sets the map image for that picture box to current
		//		selected if able
		//
		//	@param
		//		PictureBox picture - picture box that mouse is over
		//--------------------------------------------------------
		private void PictureBox_MouseOver(PictureBox picture)
		{
			// Check CurrentObject exists
			if (currentObject == null)
				return;

			// Get Index with offset
			Point index = (Point)(picture).Tag;
			index.X += (int)mapOffsetX;
			index.Y += (int)mapOffsetY;

			if (index.X > mapWidth || index.Y > mapHeight)
				return;

			// Store Map Data
			var temp = mapArray[index.X][index.Y];
			temp.m_Image = ((PictureBox)currentObject).Image;
			temp.m_Data.m_imageLoc = ((PictureBox)currentObject).ImageLocation;
			temp.m_Data.m_Pos = index;

			// Set PictureBox Image
			picture.Image = temp.m_Image;
		}

		//--------------------------------------------------------
		//	mapPanel_MouseMove
		//		On Mouse Move Checks if the mouse has entered a
		//		map picture box with mousebutton down
		//--------------------------------------------------------
		private void mapPanel_MouseMove(object sender, MouseEventArgs e)
		{
			// If left mouse button is NOT down
			if (e.Button != MouseButtons.Left)
				return;

			for (int x = 0; x < pictureBoxArray.Count(); ++x)
			{
				var first = pictureBoxArray[x][0];

				// IF above the current row
				if (e.X < first.Left)
					return;

				// Check if over picture box in X axis
				if (e.X > first.Left && e.X < first.Right)
				{
					for (int y = 0; y < pictureBoxArray[x].Count(); ++y)
					{
						var current = pictureBoxArray[x][y];

						// If left of current column
						if (e.Y < current.Top)
							return;

						// Check if over picture box in Y axis
						if (e.Y > current.Top && e.Y < current.Bottom)
						{
							PictureBox_MouseOver(current);
							return;
						}
					}
				}
			}
		}

		//--------------------------------------------------------
		// ShiftMap
		//		Shifts the map images according to offsets
		//--------------------------------------------------------
		private void ShiftMap()
		{
			for (int x = 0; x < pictureBoxArray.Count(); ++x)
			{
				for (int y = 0; y < pictureBoxArray[x].Count(); ++y)
				{
					pictureBoxArray[x][y].Show();

					int mapX = x + (int)mapOffsetX;
					int mapY = y + (int)mapOffsetY;

					// Set pictureBox image to map image with offset
					if (mapX < mapWidth && mapY < mapHeight)
						pictureBoxArray[x][y].Image = mapArray[mapX][mapY].m_Image;
					else
						pictureBoxArray[x][y].Hide();
				}
			}
		}

		//--------------------------------------------------------
		//	ResizePictureBoxes
		//		Resizes Picture boxes in map panel
		//--------------------------------------------------------
		private void ResizePictureBoxes()
		{
			foreach (List<PictureBox> list in pictureBoxArray)
			{
				foreach (PictureBox picture in list)
				{
					var pos = (Point)picture.Tag;

					pos.X *= imageSize + imagePadding;
					pos.X += imagePadding;

					pos.Y *= imageSize + imagePadding;
					pos.Y += imagePadding;

					picture.Size = new Size(imageSize, imageSize);
					picture.Location = pos;
				}
			}
		}

		//--------------------------------------------------------
		//	XPosAdd_Click
		//		On Left Click increments from mapoffsetX if able
		//		then calls ShiftMap
		//--------------------------------------------------------
		private void XposAdd_Click(object sender, EventArgs e)
		{
			if (mapOffsetX < mapWidth - 1)
				++mapOffsetX;


			XPosTextBox.Text = mapOffsetX.ToString();
			ShiftMap();
		}

		//--------------------------------------------------------
		//	XPosSub_Click
		//		On Left Click decrements from mapoffsetX if able
		//		then calls ShiftMap
		//--------------------------------------------------------
		private void XPosSub_Click(object sender, EventArgs e)
		{
			if (mapOffsetX > 0)
				--mapOffsetX;

			XPosTextBox.Text = mapOffsetX.ToString();
			ShiftMap();
		}

		//--------------------------------------------------------
		//	YPosAdd_Click
		//		On Left Click increments from mapoffsetY if able
		//		then calls ShiftMap
		//--------------------------------------------------------
		private void YPosAdd_Click(object sender, EventArgs e)
		{
			if (mapOffsetY < mapHeight - 1)
				++mapOffsetY;

			YPosTextBox.Text = mapOffsetY.ToString();
			ShiftMap();
		}

		//--------------------------------------------------------
		// YPosSub_Click
		//		On Left Click decrements from mapoffsetY if able
		//		then calls ShiftMap
		//--------------------------------------------------------
		private void YPosSub_Click(object sender, EventArgs e)
		{
			if (mapOffsetY > 0)
				--mapOffsetY;

			YPosTextBox.Text = mapOffsetY.ToString();
			ShiftMap();
		}

		//--------------------------------------------------------
		//	SaveMap
		//		Saves a map to given path
		//
		//	@param
		//	 string path - path to Save map to
		//--------------------------------------------------------
		private void SaveMap(string path)
		{
			SaveData data = new SaveData();

			// Store MapSaveData
			foreach (List<MapData> list in mapArray)
			{
				var tempList = new List<MapSaveData>();

				foreach (MapData mapData in list)
				{
					tempList.Add(mapData.m_Data);
				}

				data.mapArray.Add(tempList);
			}

			// Store Variables
			data.imageSize = imageSize;

			data.mapHeight = mapHeight;
			data.mapWidth = mapWidth;

			data.mapOffsetX = mapOffsetX;
			data.mapOffsetY = mapOffsetY;


			// Serialize
			XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
			using (StreamWriter writer = new StreamWriter(path))
			{
				serializer.Serialize(writer, data);
			}
		}

		//--------------------------------------------------------
		//	LoadMap
		//		Loads a map from given path
		//
		//	@param
		//	 string path - path to load map from
		//--------------------------------------------------------
		private void LoadMap(string path)
		{
			bool error = false;
			string errorText = null;
			Reset();

			// Load Blank Palette
			if (!File.Exists(path))
			{
				return;
			}

			// Deserialize
			XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
			using (StreamReader reader = new StreamReader(path))
			{
				SaveData data = (SaveData)serializer.Deserialize(reader);

				foreach (List<MapSaveData> list in data.mapArray)
				{
					List<MapData> newList = new List<MapData>();
					mapArray.Add(newList);

					foreach (MapSaveData saveData in list)
					{
						MapData mapData = new MapData();

						// Get image Location from saveData
						var imageLoc = saveData.m_imageLoc;

						// Add MapData to list
						newList.Add(mapData);

						// Add SaveData to MapData
						mapData.m_Data = saveData;

						// Check path is not null
						if (imageLoc != null)
						{
							// Check image exists
							if (!File.Exists(imageLoc))
							{
								error = true;
								errorText += (imageLoc + "\n");
								continue;
							}

							// Get Image from Save
							Image image = new Bitmap(imageLoc);
							image.Tag = imageLoc;

							// Add Image to mapData
							mapData.m_Image = image;
						}
					}
				}

				// Get other var
				imageSize = data.imageSize;

				mapHeight = data.mapHeight;
				mapWidth = data.mapWidth;

				mapOffsetX = data.mapOffsetX;
				mapOffsetY = data.mapOffsetY;

				// Init text boxes
				InitTextBoxes();

				// Resize PictureBoxArray
				ResizePictureBoxArray();
				ShiftMap();
			}

			// If Image failed to load
			if (error)
			{
				ErrorForm errorForm = new ErrorForm("The following Images failed to load: \n" + errorText);
				errorForm.ShowDialog();
				errorForm.Location = MousePosition;
			}
		}

		//--------------------------------------------------------
		//	mapPanel_MouseUp
		//		Upon Mouse Up sets mapPanel capture to false
		//--------------------------------------------------------
		private void mapPanel_MouseUp(object sender, MouseEventArgs e)
		{
			mapPanel.Capture = false;
		}
	}
}
