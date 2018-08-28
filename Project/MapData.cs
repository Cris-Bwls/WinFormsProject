using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
	//--------------------------------------------------------
	//	MapSaveData
	//		Container of map save data for individual point
	//--------------------------------------------------------
	public class MapSaveData
	{
		public string m_imageLoc = null;
		public Point m_Pos = new Point(0, 0);
	}

	//--------------------------------------------------------
	//	MapData
	//		Container of map data for individual point
	//--------------------------------------------------------
	public class MapData
	{
		public Image m_Image = null;
		public MapSaveData m_Data = new MapSaveData();
	}
}
