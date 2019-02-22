using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz1;

namespace QuizTest
{
	[TestClass]
	public class SquareTest
	{
		[TestMethod]
		public void SimpleValueVerification()
		{
			IShape square = new Square(3);
			Assert.AreEqual(9, square.getSurface());
			Assert.AreEqual(12, square.getPerimeter());
		}

		[TestMethod]
		public void VerifyListOfSquares()
		{
			List<(double expectedPerimeter, 
				double expectedSurface,IShape square)> 
				testSquares = new List<(double, double, IShape)>()
				{
					(4, 1, new Square(1)),
					(8, 4, new Square(2)),
					(12, 9, new Square(3)),
					(16, 16, new Square(4)),
					(20, 25, new Square(5))
				};

			foreach(var item in testSquares)
			{
				Assert.AreEqual(item.expectedSurface, item.square.getSurface());
				Assert.AreEqual(item.expectedPerimeter, item.square.getPerimeter());
			}
		}
	}
}
