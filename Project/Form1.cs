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

		public Form1()
        {
            InitializeComponent();
			
			dataGroupForm.Show(this);

			// Init TextBoxes
			HeightTextBox.Text = mapHeight.ToString();
			WidthTextBox.Text = mapWidth.ToString();

			XPosTextBox.Text = mapOffsetX.ToString();
			YPosTextBox.Text = mapOffsetY.ToString();

			ImageSizeTextBox.Text = imageSize.ToString();

			// Double Buffering
			typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
			| BindingFlags.Instance | BindingFlags.NonPublic, null,
			WorkPanel, new object[] { true });
		}

		private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void windowToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void imagePalletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGroupForm.IsDisposed)
				dataGroupForm = new DataGroupForm(true);

			dataGroupForm.Visible = !dataGroupForm.Visible;
		}

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
				if(widthInvalid)
					errorText = "Width is Invalid";
				else
					errorText = "Height is Invalid";

				// Show Error Dialog
				ErrorForm errorForm = new ErrorForm(errorText);
				errorForm.ShowDialog();
			}
		}

		private void OffsetChangedButton_Click(object sender, EventArgs e)
		{
			bool XOffsetInvalid = false;
			bool YOffsetInvalid = false;

			if (uint.TryParse(XPosTextBox.Text, out mapOffsetX))
				YOffsetInvalid = !(uint.TryParse(YPosTextBox.Text, out mapOffsetY));
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
			}
		}

		private void SizeChangedButton_Click(object sender, EventArgs e)
		{
			bool error = false;
			int temp;

			if (int.TryParse(ImageSizeTextBox.Text, out temp))
			{
				if (temp < 0)
					error = true;
				else
					imageSize = temp;
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
			pictureBox.MouseEnter += PictureBox_MouseOver;
			pictureBox.Tag = index;

			// Return Initialised PictureBox
			return pictureBox;
		}

		private void PictureBox_MouseOver(object sender, EventArgs e)
		{
			if (MouseButtons == MouseButtons.Left)
			{
				// Check CurrentObject exists
				if (currentObject == null)
					return;

				// Get Index with offset
				Point index = (Point)((PictureBox)sender).Tag;
				index.X += (int)mapOffsetX;
				index.Y += (int)mapOffsetY;

				// Store Map Data
				var temp = mapArray[index.X][index.Y];
				temp.m_Image = ((PictureBox)currentObject).Image;
				temp.m_Data.m_imageLoc = (string)temp.m_Image.Tag;
				temp.m_Data.m_Pos = index;

				// Set PictureBox Image
				((PictureBox)sender).Image = temp.m_Image;
			}
		}
	}
}
