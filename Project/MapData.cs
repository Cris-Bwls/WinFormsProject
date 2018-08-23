using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
	public class MapSaveData
	{
		public string m_imageLoc = null;
		public Point m_Pos = new Point(0, 0);
	}

	public class MapData
	{
		public Image m_Image = null;
		public MapSaveData m_Data = new MapSaveData();
	}
}
