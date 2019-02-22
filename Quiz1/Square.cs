using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz1
{
	public class Square : ISquare
	{
		public double Length { get; set; }

		public Square() : this(10)
		{
		}

		public Square(double length)
		{
			this.Length = length;
		}

		public double getPerimeter()
		{
			return 4 * Length;
		}

		public double getSurface()
		{
			return Length * Length;
		}
	}
}
