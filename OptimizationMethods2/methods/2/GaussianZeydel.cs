using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2.methods
{
	public class GaussianZeydel
	{
		public static int AmountOfOperations = 0;
		public static Tuple<double[], double> FindMin(double[] x00, int M, Func<double[], double> Operation,
			double epsilon = 0.001, double epsilon1 = 0.001, double epsilon2 = 0.001)
		{
			AmountOfOperations = 0;
			int j = 0, n = x00.Length;
			double[] tempx = new double[x00.Length];
			Array.Copy(x00, tempx, tempx.Length);
			List<List<double[]>> xHistory = new();
			xHistory.Add(new());

		step3:
			AmountOfOperations++;
			if (j >= M)
			{
				return Tuple.Create(tempx, Operation(tempx));
			}

			int k = 0;
		step5:
			if (k == n)
			{
				xHistory[j].Add((double[])tempx.Clone());
				j++;
				xHistory.Add(new());
				goto step3;
			}

			double[] gradient = GradientCompute.ComputeGradient(Operation, (double[])tempx.Clone());

			if (GradientCompute.ComputeNorm(gradient) < epsilon1)
				return Tuple.Create(tempx, Operation(tempx));

			double t = FindMinStep(Operation, (double[])tempx.Clone(), k);
			xHistory[j].Add((double[])tempx.Clone());

			int counter = 0;
		step9:
			tempx[k] = tempx[k] - t * GradientCompute.ComputeGradient(Operation, (double[])xHistory[j][k].Clone())[k];

			if (!(Operation(tempx) - Operation(xHistory[j][k]) < 0) && counter < 100)
			{
				t /= 2;
				tempx = (double[])xHistory[j][k].Clone();
				counter++;
				goto step9;
			}

			double[] tempXDiff = new double[tempx.Length];
			for (int i = 0; i < tempx.Length; i++)
				tempXDiff[i] = tempx[i] - xHistory[j][k][i];

			if ((GradientCompute.ComputeNorm(tempXDiff) < epsilon2)
				&& Math.Abs(Operation(tempx) - Operation(xHistory[j][k])) < epsilon2)
			{

				if (k >= 1 && xHistory[j].Count >= 2)
				{
					for (int i = 0; i < tempx.Length; i++)
						tempXDiff[i] = xHistory[j][k][i] - xHistory[j][k - 1][i];

					if ((GradientCompute.ComputeNorm(tempXDiff) < epsilon2)
					&& Math.Abs(Operation(xHistory[j][k]) - Operation(xHistory[j][k - 1])) < epsilon2)
					{
						return Tuple.Create(tempx, Operation(tempx));
					}

				}
			}
			k++;
			goto step5;


		}


		private static double FindMinStep(Func<double[], double> Operation, double[] point, int k)
		{
			double[] gradient = GradientCompute.ComputeGradient(Operation, point);

			double left = 1e-5f, right = 20, t = 1, epsilon = 1e-3f;

			while (right - left > epsilon)
			{
				double mid = (left + right) / 2;

				double[] pointMinusT1 = CalculatePoint(point, gradient, mid - epsilon, k);
				double[] pointPlusT1 = CalculatePoint(point, gradient, mid + epsilon, k);

				double value1 = Operation(pointMinusT1);
				double value2 = Operation(pointPlusT1);

				if (value1 < value2)
					right = mid;
				else
					left = mid;
			}
			return (left + right) / 2;
		}

		private static double[] CalculatePoint(double[] point, double[] gradient, double t, int k)
		{
			double[] newPoint = new double[point.Length];
			Array.Copy(point, newPoint, point.Length);

			newPoint[k] = point[k] - t * gradient[k];
			return newPoint;
		}
	}



	
}
