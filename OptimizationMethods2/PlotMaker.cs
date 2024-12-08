using OptimizationMethods2.methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2
{
	public class PlotMaker
	{
		private static void MakePlot(string name, string changedName, string argsName, List<double> args, List<double> values)
		{
			var plt = new ScottPlot.Plot();

			var asd = plt.Add.Scatter(args, values);
			asd.Smooth = true;
			asd.SmoothTension = 1;
			asd.LegendText = changedName;
			plt.XLabel(argsName);
			plt.YLabel(changedName);

			plt.SavePng($"{name}_{DateTime.Now.ToString("dd.MM.yy HH.mm.ss")}.png", 400, 400);
		}



		public static void TestGradientConst(Func<double[], double> Operation)
		{
			Console.WriteLine("Function 2x^2+xy+2y^2 (const)");


			List<double> args = new List<double>();
			List<double> ErrorValues = new List<double>();
			List<double> AmountOfOperationValues = new List<double>();

			double[] startPoint = [-133, 546];
			double realResult = 0;

			//Limit
			for (int i = 0; i < 501; i++)
			{
				args.Add(i);
				Tuple<double[], double> result = GradientDecentConstStep.FindMin(startPoint, Operation, limit: i);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(GradientDecentConstStep.AmountOfOperations);
				Console.WriteLine($"Result: {fResult}");
			}
			MakePlot("Метод Градиентного спуска с постоянным шагом ΔЛимит(M)", "Ошибка", "Лимит(M)", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод Градиентного спуска с постоянным шагом ΔЛимит(M)", "Количество операций", "Лимит(M)", args, AmountOfOperationValues);



			/*			//StepSize
						for (double i = 0.1; i < 3; i += 0.011)
						{
							args.Add(i);
							Tuple<double[], double> result = GradientDecentConstStep.FindMin(startPoint, Operation, stepSize: i);
							double[] xResult = result.Item1;
							double fResult = result.Item2;
							ErrorValues.Add(Math.Abs(realResult - fResult));
							AmountOfOperationValues.Add(GradientDecentConstStep.AmountOfOperations);
							Console.WriteLine($"i: {i} Result: {fResult}");
						}
						MakePlot("Метод Градиентного спуска с постоянным шагом ΔШаг", "Ошибка", "Шаг", args, ErrorValues);
						Thread.Sleep(2000);
						MakePlot("Метод Градиентного спуска с постоянным шагом ΔШаг", "Количество операций", "Шаг", args, AmountOfOperationValues);
			*/


			/*//epsilon
			for (double i = 0.0001; i < 1; i += 0.0001)
			{
				args.Add(i);
				Tuple<double[], double> result = GradientDecentConstStep.FindMin(startPoint, Operation, epsilon: i);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(GradientDecentConstStep.AmountOfOperations);
				Console.WriteLine($"i: {i} Result: {fResult}");
			}
			MakePlot("Метод Градиентного спуска с постоянным шагом Δepsilon", "Ошибка", "epsilon", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод Градиентного спуска с постоянным шагом Δepsilon", "Количество операций", "Δepsilon", args, AmountOfOperationValues);
*/


		}



		public static void TestGradientFast(Func<double[], double> Operation)
		{
			Console.WriteLine("Function 2x^2+xy+2y^2 (const)");


			List<double> args = new List<double>();
			List<double> ErrorValues = new List<double>();
			List<double> AmountOfOperationValues = new List<double>();

			double[] startPoint = [600.5, 102];
			double realResult = 0;

			//Limit
			for (int i = 0; i < 501; i++)
			{
				args.Add(i);
				Tuple<double[], double> result = GradientDecentFast.FindMin(startPoint, Operation, limit: i);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(GradientDecentFast.AmountOfOperations);
				Console.WriteLine($"Result: {fResult}");
			}
			MakePlot("Метод Градиентного спуска быстрый ΔЛимит(M)1", "Ошибка", "Лимит(M)", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод Градиентного спуска быстрый ΔЛимит(M)1", "Количество операций", "Лимит(M)", args, AmountOfOperationValues);
		}


		public static void TestCoordinateDecent(Func<double[], double> Operation)
		{
			Console.WriteLine("Function 2x^2+xy+2y^2 (const)");


			List<double> args = new List<double>();
			List<double> ErrorValues = new List<double>();
			List<double> AmountOfOperationValues = new List<double>();

			double[] startPoint = [600.5, 102];
			double realResult = 0;

			/*//Limit
			for (int i = 2; i < 501; i++)
			{
				args.Add(i);
				Tuple<double[], double> result = CoordinateDecent.FindMin(startPoint, i, Operation);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(CoordinateDecent.AmountOfOperations);
				Console.WriteLine($"Result: {fResult}");
			}
			MakePlot("Метод покоординатного спуска ΔЛимит(M)", "Ошибка", "Лимит(M)", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод покоординатного спуска ΔЛимит(M)", "Количество операций", "Лимит(M)", args, AmountOfOperationValues);
*/


			//StepSize
			for (double i = 0.01; i < 3; i += 0.01)
			{
				args.Add(i);
				Tuple<double[], double> result = CoordinateDecent.FindMin(startPoint, 150, Operation, step: i);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(CoordinateDecent.AmountOfOperations);
				Console.WriteLine($"i: {i} Result: {fResult}");
			}
			MakePlot("Метод покоординатного спуска ΔШаг", "Ошибка", "Шаг", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод покоординатного спуска ΔШаг", "Количество операций", "Шаг", args, AmountOfOperationValues);

		}


		public static void TestGaussianZeydel(Func<double[], double> Operation)
		{
			Console.WriteLine("Function 2x^2+xy+2y^2 (const)");


			List<double> args = new List<double>();
			List<double> ErrorValues = new List<double>();
			List<double> AmountOfOperationValues = new List<double>();

			double[] startPoint = [600.5, 102];
			double realResult = 0;

			//Limit
			for (int i = 2; i < 501; i++)
			{
				args.Add(i);
				Tuple<double[], double> result = GaussianZeydel.FindMin(startPoint, i, Operation);
				double[] xResult = result.Item1;
				double fResult = result.Item2;
				ErrorValues.Add(Math.Abs(realResult - fResult));
				AmountOfOperationValues.Add(GaussianZeydel.AmountOfOperations);
				Console.WriteLine($"Result: {fResult}");
			}
			MakePlot("Метод Гаусса-Зейделя ΔЛимит(M)", "Ошибка", "Лимит(M)", args, ErrorValues);
			Thread.Sleep(2000);
			MakePlot("Метод Гаусса-Зейделя ΔЛимит(M)", "Количество операций", "Лимит(M)", args, AmountOfOperationValues);

		}
	}
	
}
