using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz2;

namespace QuizTest
{
	[TestClass]
	public class VectorTest
	{
		[TestMethod]
		public void SimpleAdditionValidation()
		{
			Vector v1 = new Vector(12, 0);
			Vector v2 = new Vector(21, 70);

			Vector res = Vector.Add(v1, v2);
			Assert.AreEqual(27.5, Math.Round(res.magnitude,1));
			Assert.AreEqual(45.8, Math.Round(res.phase,1));
		}

		[TestMethod]
		public void ListOfVectorsValidation()
		{
			List<(double expectedMagn, 
				double expectedPhase, 
				Vector v1, 
				Vector v2)> testVectors
				= new List<(double, double, Vector, Vector)>()
				{
					(10,   0,    new Vector(5, 0),   new Vector(5, 0)),
					(10,   50,   new Vector(5, 50),  new Vector(5, 50)),
					(27.5, 55.8, new Vector(12, 10), new Vector(21, 80)),
					(27.5, 34.2, new Vector(21, 10), new Vector(12, 80))
				};

			foreach(var item in testVectors)
			{
				Vector resultVector = Vector.Add(item.v1, item.v2);
				Assert.AreEqual(item.expectedMagn, Math.Round(resultVector.magnitude, 1));
				Assert.AreEqual(item.expectedPhase, Math.Round(resultVector.phase, 1));
			}
		}
	}
}
