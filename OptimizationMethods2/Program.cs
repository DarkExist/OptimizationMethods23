using OptimizationMethods2.methods;
using MathNet.Symbolics;
using System.Linq.Expressions;

namespace OptimizationMethods2
{
	internal class Program
	{


		static void Main(string[] args)
		{
			Third(args);
		}

		public static void Third(string[] args)
		{
			// x^2 + 4x - y + 18y^2

			SymbolicExpression x = SymbolicExpression.Variable("x");
			SymbolicExpression y = SymbolicExpression.Variable("y");

			SymbolicExpression goalExpression = x * x + 4 * x - y + 18 * y * y;



		}

		public static void Second(string[] args)
		{
			/*//double BigFunction(double[] x) => 1 - Math.Exp(-Math.Sqrt(x[0] * x[0] + x[1] * x[1]));
			//double BigFunctionRealResult = 1;

			//double BigFunction(double[] x) => 4 * Math.Pow((x[0] + 4), 2) + Math.Pow((x[1] - 14), 2) + 3;
			//double BigFunctionRealResult = 3;

			double BigFunction(double[] x) => Math.Pow(Math.Abs(x[0] - 3), Math.E) + Math.Pow((x[1]), 2);
			double BigFunctionRealResult = 0;

			// First method
			Console.WriteLine("FIRST:");
			double FirstFunction(double[] x) => 2 * x[0] * x[0] + x[0] * x[1] + 2 * x[1] * x[1];
			double[] start = [31, -24];

			var asd = GradientDecentConstStep.FindMin(start, BigFunction);
			Console.WriteLine($"result: {asd.Item2}");

			//foreach (var x2 in asd.Item1)
			//{
			//	Console.WriteLine($"{x2}");
			//}
			Console.WriteLine($"Amount of operations {GradientDecentConstStep.AmountOfOperations}");
			Console.WriteLine($"Error: {BigFunctionRealResult - asd.Item2}");

			//-------------

			// Second method
			Console.WriteLine("SECOND:");

			double SecondFunction(double[] x) => 2 * x[0] * x[0] + x[0] * x[1] + 2 * x[1] * x[1];
			double[] x = [600.5, 102];

			var asde = GradientDecentFast.FindMin(start, BigFunction);
			Console.WriteLine($"result: {asde.Item2}");

			//foreach (var x2 in asde.Item1)
			//{
			//	Console.WriteLine($"{x2}");
			//}
			Console.WriteLine($"Amount of operations {GradientDecentFast.AmountOfOperations}");
			Console.WriteLine($"Error: {BigFunctionRealResult - asde.Item2}");

			//--------------

			// Third method
			Console.WriteLine("THIRD:");
			double ThirdFunction(double[] x) => 2 * x[0] * x[0] + x[0] * x[1] + 2 * x[1] * x[1];
			double[] x3 = [600.5, 102];

			var asdf = CoordinateDecent.FindMin(start, 150, BigFunction);
			Console.WriteLine($"result: {asdf.Item2}");

			//foreach (var x2 in asdf.Item1)
			//{
			//	Console.WriteLine($"{x2}");
			//}
			Console.WriteLine($"Amount of operations {CoordinateDecent.AmountOfOperations}");
			Console.WriteLine($"Error: {BigFunctionRealResult - asdf.Item2}");
			//--------------

			// Fourth method
			Console.WriteLine("FOURTH:");
			double FourthFunction(double[] x) => 2 * x[0] * x[0] + x[0] * x[1] + 2 * x[1] * x[1];
			double[] x4 = [600.5, 102];

			var asdg = GaussianZeydel.FindMin(start, 250, BigFunction);
			Console.WriteLine($"result: {asdg.Item2}");

			//foreach (var x2 in asdg.Item1)
			//{
			//	Console.WriteLine($"{x2}");
			//}
			Console.WriteLine($"Amount of operations {GaussianZeydel.AmountOfOperations}");
			Console.WriteLine($"Error: {BigFunctionRealResult - asdg.Item2}");
			//--------------

			//double TestFunction(double[] x) => 2 * x[0] * x[0] + x[0] * x[1] + 2 * x[1] * x[1];
			//PlotMaker.TestGradientConst(TestFunction);
			//PlotMaker.TestGradientFast(TestFunction);
			//PlotMaker.TestCoordinateDecent(TestFunction);
			//PlotMaker.TestGaussianZeydel(TestFunction);*/
		}


	}
}