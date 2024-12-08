using MathNet.Numerics.LinearAlgebra;
using MathNet.Symbolics;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2
{
	public static class FunctionsForThird
	{
		public static List<List<SymbolicExpression>> ComputeHessian(SymbolicExpression func,
			List<SymbolicExpression> variables)
		{
			var hessian = new List<List<SymbolicExpression>>();

			foreach (var v1 in variables)
			{
				var row = new List<SymbolicExpression>();
				foreach (var v2 in variables)
				{
					// Вычисление второй производной
					var secondDerivative = func.Differentiate(v1).Differentiate(v2);
					row.Add(secondDerivative);
				}
				hessian.Add(row);
			}

			return hessian;
		}

		public static List<SymbolicExpression> ComputeGradient(SymbolicExpression func,
			List<SymbolicExpression> variables)
		{
			var gradient = new List<SymbolicExpression>();
			foreach (var variable in variables)
			{
				// Первая производная по переменной
				var partialDerivative = func.Differentiate(variable);
				gradient.Add(partialDerivative);
			}
			return gradient;
		}

		public static List<FloatingPoint> ComputeValueOfGradient(List<SymbolicExpression> gradient, 
			Dictionary<string, FloatingPoint> substitutions)
		{
			List<FloatingPoint> evaluatedList = new List<FloatingPoint>();

			// Вывод численного градиента
			Console.WriteLine("Численный градиент:");
			foreach (var partialDerivative in gradient)
			{
				// Подставляем значения и выводим результат
				var evaluated = partialDerivative.Evaluate(substitutions);
				evaluatedList.Add(evaluated);

			}
			return evaluatedList;
		}

		public static List<List<FloatingPoint>> ComputeValueOfHessian(List<List<SymbolicExpression>> hessian,
			Dictionary<string, FloatingPoint> substitutions)
		{
			List<List<FloatingPoint>> evaluatedList = new();

			foreach (var row in hessian)
			{
				List<FloatingPoint> rowList = new List<FloatingPoint>();
				foreach (var element in row)
				{
					var evaluated = element.Evaluate(substitutions);
					rowList.Add(evaluated);
				}
				evaluatedList.Add(rowList);
			}

			return evaluatedList;
		}

		public static double NormalizeVector(List<FloatingPoint> vector)
		{
			double sum = 0;

			foreach (var element in vector)
			{
				sum += element.RealValue * element.RealValue;
			}

			return Math.Sqrt(sum);

		}

		public static List<List<FloatingPoint>> ComputeReverseHessian(List<List<FloatingPoint>> hessian)
		{
			var matrix = ConvertToMathNetMatrix(hessian);
			if (Math.Abs(matrix.Determinant()) < 1e-10)
			{
				throw new InvalidOperationException("Матрица необратима (определитель равен нулю).");
			}

			var inverseMatrix = matrix.Inverse();

			var result = new List<List<FloatingPoint>>();
			for (int i = 0; i < inverseMatrix.RowCount; i++)
			{
				var row = new List<FloatingPoint>();
				for (int j = 0; j < inverseMatrix.ColumnCount; j++)
				{
					row.Add(inverseMatrix[i, j]);
				}
				result.Add(row);
			}

			return result;

		}



		public static double ComputeDeterminantOfListFloatingMatrix(List<List<FloatingPoint>> inputMatrix)
		{
			var matrix = ConvertToMathNetMatrix(inputMatrix);
			return matrix.Determinant();

		}

		private static Matrix<double> ConvertToMathNetMatrix(List<List<FloatingPoint>> inputMatrix)
		{
			int rows = inputMatrix.Count;
			int cols = inputMatrix[0].Count;
			var array = new double[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					array[i, j] = inputMatrix[i][j].RealValue;
				}
			}

			return Matrix<double>.Build.DenseOfArray(array);
		}
	}
}
