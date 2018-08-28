using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
	public partial class ErrorForm : Form
	{
		//--------------------------------------------------------
		//	ErrorForm
		//		Overloaded constructor
		//
		//	@param
		//		string text - text describing error
		//--------------------------------------------------------
		public ErrorForm(string text)
		{
			InitializeComponent();
			ErrorLabel.Text = text;
		}

		//--------------------------------------------------------
		//	CloseButton_Click
		//		On click closes form
		//--------------------------------------------------------
		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
