using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationMethods2.methods._3
{
	public class Newton
	{
		public static int AmountOfOperations = 0;
		public static Tuple<double[], double> FindMin(double[] x0, SymbolicExpression expression,
			double epsilon1 = 0.001, double epsilon2 = 0.001, int M = 50)
		{
			SymbolicExpression x = SymbolicExpression.Variable("x");
			SymbolicExpression y = SymbolicExpression.Variable("y");
			var variables = new List<SymbolicExpression> { x, y };

			var hessian = FunctionsForThird.ComputeHessian(expression, variables);
			var gradient = FunctionsForThird.ComputeGradient(expression, variables);

			List<List<double[]>> xHistory = new();

			int k = 0;

			var substitutions = new Dictionary<string, FloatingPoint>
			{
				{ "x", x0[0] },
				{ "y", x0[1] },
			};

			var gradientInDot = FunctionsForThird.ComputeValueOfGradient(gradient, substitutions);

			if (FunctionsForThird.NormalizeVector(gradientInDot) <= epsilon1)
			{
				return Tuple.Create(x0, expression.Evaluate(substitutions).RealValue);
			}

			if (k >= M)
			{
				return Tuple.Create(x0, expression.Evaluate(substitutions).RealValue);
			}

			var hessianInDot = FunctionsForThird.ComputeValueOfHessian(hessian, substitutions);

			var reverseHessianInDot = FunctionsForThird.ComputeReverseHessian(hessianInDot);

			if (FunctionsForThird.ComputeDeterminantOfListFloatingMatrix(reverseHessianInDot) > 0)
			{

			}
			else
			{

			}

		}
	}
}

/*
 // Подстановка значений

*/