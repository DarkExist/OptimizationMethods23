using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2.methods
{
	public class GradientDecentConstStep
	{
		public static int AmountOfOperations = 0;
		public static Tuple<double[], double> FindMin(double[] x0, Func<double[], double> Operation, double epsilon = 0.001, double epsilon1 = 0.001, double epsilon2 = 0.001, int limit = 150, double stepSize = 0.5)
		{
			AmountOfOperations = 0;
			double result = 0;
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

				

				step7:
				AmountOfOperations++;
				if (k >= limit)
				{
					return Tuple.Create(tempx, Operation(tempx));
				}
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
								tempDiff[i] = xHistory[k][i] - xHistory[k-1][i];
							}

							if ((GradientCompute.ComputeNorm(tempDiff) < epsilon2)
								&& (Operation(xHistory[k]) - Operation(xHistory[k-1]) < epsilon2))
							{
								return Tuple.Create(tempx, Operation(tempx));
							}


						}
						
					}
					k += 1;

				}
				else
				{
					tempx = xHistory[k];
					xHistory.Remove(xHistory[k]);
					stepSize /= 2;
					goto step7;
					
				}

			}
		}
	}
}
