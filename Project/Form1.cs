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
        private List<List<PictureBoxData>> mapArray = new List<List<PictureBoxData>>();
		private List<PictureBox> pictureBoxList = new List<PictureBox>();
		private DataGroupForm dataGroupForm = new DataGroupForm(true);
		
		private int mapHeight = 0;
		private int mapWidth = 0;

		public Form1()
        {
            InitializeComponent();
			
			dataGroupForm.Show(this);

			// Init TextBoxes
			HeightTextBox.Text = mapHeight.ToString();
			WidthTextBox.Text = mapWidth.ToString();

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
			if (int.TryParse(HeightTextBox.Text, out mapHeight))
			{
				if (int.TryParse(WidthTextBox.Text, out mapWidth))
				{
					//Change Map Size

					// Change Width
					int arrayWidth = mapArray.Count();
					if (arrayWidth > mapWidth)
					{
						int removeCount = arrayWidth - mapWidth;
						for (int i = 0; i < removeCount; ++i)
						{
							mapArray.Remove(mapArray.Last());
						}
					}
					else
					{
						int addCount = mapWidth - arrayWidth;
						for (int i = 0; i < addCount; ++i)
						{
							mapArray.Add(new List<PictureBoxData>());
						}
					}

					// Change Height
					foreach(List<PictureBoxData> list in mapArray)
					{
						int arrayHeight = list.Count();
						if (arrayHeight > mapHeight)
						{
							int removeCount = arrayHeight - mapHeight;
							for (int i = 0; i < removeCount; ++i)
							{
								list.Remove(list.Last());
							}
						}
						else
						{
							int addCount = mapHeight - arrayHeight;
							for (int i = 0; i < addCount; ++i)
							{
								list.Add(new PictureBoxData());
							}
						}
					}
				}
			}
		}
	}
}
