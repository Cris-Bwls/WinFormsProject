using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	public class SaveData
	{
		public List<List<MapSaveData>> mapArray = new List<List<MapSaveData>>();

		public uint mapHeight = 0;
		public uint mapWidth = 0;

		public uint mapOffsetX = 0;
		public uint mapOffsetY = 0;

		public int imageSize = 50;
	}
}
