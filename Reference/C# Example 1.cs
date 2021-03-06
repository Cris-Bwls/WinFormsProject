﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private PictureBox[,] m_Grid = new PictureBox[3, 3];
		private string m_ImagePath = "";

		public Form1()
		{
			InitializeComponent();

			CreateGrid();
		}

		private void CreateGrid()
		{
			for(int row = 0; row < 3; ++row)
			{
				for(int col = 0; col < 3; ++col)
				{
					m_Grid[row, col] = new PictureBox();
					m_Grid[row, col].Margin = new Padding(1, 1, 1, 1);
					m_Grid[row, col].Dock = DockStyle.None;
					m_Grid[row, col].BackColor = Color.White;
					m_Grid[row, col].Size = new Size(60, 60);
					m_Grid[row, col].BorderStyle = BorderStyle.FixedSingle;
					m_Grid[row, col].Location = new Point(col * 61, row * 61);
					
					panel2.Controls.Add(m_Grid[row, col]);
				}
			}
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			MyText.Text = "Hello World";
			PlayButton.BackColor = Color.Red;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ImageButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog popup = new OpenFileDialog())
			{
				popup.Title = "Load Image";
				popup.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					string filename = popup.FileName;
					m_ImagePath = filename;
					ImageBox.Image = new Bitmap(filename);
				}
			}
		}

		private void SaveImage_Click(object sender, EventArgs e)
		{
			if(ImageBox.Image != null)
			{
				using (SaveFileDialog popup = new SaveFileDialog())
				{
					popup.Title = "Save Image";
					popup.Filter = "jpg|*.jpg";

					if(popup.ShowDialog() == DialogResult.OK)
					{
						ImageBox.Image.Save(popup.FileName);
					}
				}
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog popup = new SaveFileDialog())
			{
				popup.Title = "Save Project";
				popup.Filter = "Save File|*.sav";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					SaveData data = new SaveData();
					data.m_Text = MyText.Text;
					int.TryParse(textBox1.Text, out data.m_Value);
					data.m_Filename = m_ImagePath;

					XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
					using (StreamWriter writer = new StreamWriter(popup.FileName))
					{
						serializer.Serialize(writer, data);
					}
				}
			}
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog popup = new OpenFileDialog())
			{
				popup.Title = "Load Project";
				popup.Filter = "Save File|*.sav";

				if (popup.ShowDialog() == DialogResult.OK)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
					using (StreamReader reader = new StreamReader(popup.FileName))
					{
						SaveData data = (SaveData)serializer.Deserialize(reader);

						MyText.Text = data.m_Text;
					}
				}
			}
		}
	}
}