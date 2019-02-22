using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2
{
	public class Vector
	{
		public double magnitude { get; set; }
		public double phase { get; set; }

		/// <summary>
		/// Initializes new Vector object
		/// </summary>
		/// <param name="magnitude">Magnitude of vector</param>
		/// <param name="phase">phase, in degrees, range from 0 to 180</param>
		public Vector(double magnitude, double phase)
		{
			if(phase >= 180 || phase < 0)
			{
				throw new ArgumentOutOfRangeException("vectors range have to be in range of 0 to 180 degrees");
			}
			this.magnitude = magnitude;
			this.phase = phase;
		}
		/// <summary>
		/// Adds up 2 vectors
		/// </summary>
		/// <param name="v1">First vector</param>
		/// <param name="v2">Second vector</param>
		/// <returns></returns>
		public static Vector Add(Vector v1, Vector v2)
		{
			double phaseDifference =  180 - getPhaseDifference(v1.phase, v2.phase);

			double resultMagnitude = Math.Sqrt(v1.magnitude* v1.magnitude + v2.magnitude * v2.magnitude
				- 2* v1.magnitude* v2.magnitude * Math.Cos(degreeToRad(phaseDifference)));

			double sinCoefficient = Math.Sin(degreeToRad(phaseDifference)) / resultMagnitude;
			double resultPhase;
			if (v1.phase < v2.phase)
			{
				resultPhase = v1.phase + Math.Asin(v2.magnitude * sinCoefficient) * 180 / Math.PI;
			}
			else
			{
				resultPhase = v2.phase + Math.Asin(v1.magnitude * sinCoefficient) * 180 / Math.PI;
			}
			//double resultPhase = Math.Asin(resultPhaseSin) * 180 / Math.PI;
			return new Vector(resultMagnitude, resultPhase);
		}
		private static double degreeToRad(double degree)
		{
			return degree * Math.PI / 180;
		}

		private static double getPhaseDifference(double phase1, double phase2)
		{
			return Math.Abs(phase1 - phase2);
		}
	}
}
