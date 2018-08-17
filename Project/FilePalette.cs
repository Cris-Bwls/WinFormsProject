using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
	public class GroupData
	{
		public string name;
		public List<string> dataList = new List<string>();
	}

	public class FilePalette
	{
		public List<GroupData> groupList = new List<GroupData>();
		public List<string> unGroupedList = new List<string>();
	}
}
