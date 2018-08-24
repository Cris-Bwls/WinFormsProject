using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	abstract class Inheritance
	{
		abstract public void Print();
	}

	class Child1 : Inheritance
	{
		override public void Print()
		{
			Console.WriteLine("This is Child 1");
		}
	}

	class Child2 : Inheritance
	{
		override public void Print()
		{
			Console.WriteLine("This is Child 2");
		}
	}
}
