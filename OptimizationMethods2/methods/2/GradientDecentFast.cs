using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2.methods
{
	public class GradientDecentFast
	{
		public static int AmountOfOperations = 0;
		public static Tuple<double[], double> FindMin(double[] x0, Func<double[], double> Operation, double epsilon = 0.001, double epsilon1 = 0.001, double epsilon2 = 0.001, int limit = 150)
		{
			AmountOfOperations = 0;
			double result = 0;
			double stepSize;
			double[] tempx = new double[x0.Length];
			Array.Copy(x0, tempx, x0.Length);
			int k = 0;
			List<double[]> xHistory = new();


			while (true)
			{
				double[] gradientInPoint = GradientCompute.ComputeGradient(Operation, tempx);


				if (GradientCompute.ComputeNorm(gradientInPoint) < epsilon1)
				{
					return Tuple.Create(tempx, Operation(tempx));
				}



				step6:
				AmountOfOperations++;
				if (AmountOfOperations > limit)
				{
					return Tuple.Create(tempx, Operation(tempx));
				}
				stepSize = FindMinStep(Operation, (double[])tempx.Clone());
				xHistory.Add((double[])tempx.Clone());


				gradientInPoint = GradientCompute.ComputeGradient(Operation, tempx);
				for (int i = 0; i < gradientInPoint.Length; i++)
				{
					tempx[i] = tempx[i] - stepSize * gradientInPoint[i];
				}

				if (Operation(tempx) - Operation(xHistory[k]) < 0)
				{
					double[] tempDiff = new double[tempx.Length];
					for (int i = 0; i < tempx.Length; i++)
					{
						tempDiff[i] = tempx[i] - xHistory[k][i];
					}

					if ((GradientCompute.ComputeNorm(tempDiff) < epsilon2)
						&& (Operation(tempx) - Operation(xHistory[k]) < epsilon2))
					{
						if (xHistory.Count >= 2 && k >= 1)
						{
							tempDiff = new double[xHistory[k].Length];
							for (int i = 0; i < tempDiff.Length; i++)
							{
								tempDiff[i] = xHistory[k][i] - xHistory[k - 1][i];
							}

							if ((GradientCompute.ComputeNorm(tempDiff) < epsilon2)
								&& (Operation(xHistory[k]) - Operation(xHistory[k - 1]) < epsilon2))
							{
								return Tuple.Create(tempx, Operation(tempx));
							}


						}
						k += 1;
					}

				}
				else
				{
					tempx = xHistory[k];
					xHistory.Remove(xHistory[k]);
					stepSize /= 2;
					goto step6;

				}

			}
		}

		private static double FindMinStep(Func<double[], double> Operation, double[] point)
		{
			double[] gradient = GradientCompute.ComputeGradient(Operation, point);

			double left = 1e-5f, right = 20, t = 1, epsilon = 1e-3f;

			while (right - left > epsilon)
			{
				double mid = (left + right) / 2;

				double[] pointMinusT1 = CalculatePoint(point, gradient, mid - epsilon);
				double[] pointPlusT1 = CalculatePoint(point, gradient, mid + epsilon);

				double value1 = Operation(pointMinusT1);
				double value2 = Operation(pointPlusT1);

				if (value1 < value2)
					right = mid;
				else
					left = mid;
			}
			return (left + right) / 2;
		}

		private static double[] CalculatePoint(double[] point, double[] gradient, double t)
		{
			double[] newPoint = new double[point.Length];
			for (int i = 0; i < point.Length; i++)
			{
				newPoint[i] = point[i] - t * gradient[i];
			}
			return newPoint;
		}












	}



}
