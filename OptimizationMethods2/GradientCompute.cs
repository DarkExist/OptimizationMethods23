using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2
{
	public class GradientCompute
	{
		public static double[] ComputeGradient(Func<double[], double> function, double[] point, double epsilon = 1e-5f)
		{
			int dimensions = point.Length;
			double[] gradient = new double[dimensions];
			double[] pointCopy = new double[dimensions];

			for (int i = 0; i < dimensions; i++)
			{
				Array.Copy(point, pointCopy, dimensions);

				pointCopy[i] += epsilon;
				double fPlus = function(pointCopy);

				// get i - e
				pointCopy[i] -= 2 * epsilon;
				double fMinus = function(pointCopy);

				gradient[i] = (fPlus - fMinus) / (2 * epsilon);
			}

			return gradient;
		}

		public static double ComputeNorm(double[] gradient)
		{
			double sum = 0;
			foreach (var elem in gradient)
				sum += elem * elem;
			return Math.Sqrt(sum);
		}

	}
}
