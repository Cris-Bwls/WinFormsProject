using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	//--------------------------------------------------------
	//	Inheritance
	//		Base Class
	//--------------------------------------------------------
	abstract class Inheritance
	{
		abstract public void Print();
	}

	//--------------------------------------------------------
	//	Child1
	//		First Child class of Inheritance
	//--------------------------------------------------------
	class Child1 : Inheritance
	{
		override public void Print()
		{
			Console.WriteLine("This is Child 1");
		}
	}

	//--------------------------------------------------------
	//	Child2
	//		Second Child Class of Inheritance
	//--------------------------------------------------------
	class Child2 : Inheritance
	{
		override public void Print()
		{
			Console.WriteLine("This is Child 2");
		}
	}
}
