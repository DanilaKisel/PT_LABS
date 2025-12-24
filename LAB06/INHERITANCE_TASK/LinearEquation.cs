using System;

namespace InheritanceTask
{
    public class LinearEquation : Equation
    {
        public LinearEquation(double a, double b) : base(new double[] { a, b })
        {
            EquationType = "Linear Equation";
            HasRealRoots = Math.Abs(a) > 1e-9 || Math.Abs(b) < 1e-9;
        }

        public override double[] Solve()
        {
            double a = Coefficients[0];
            double b = Coefficients[1];

            if (Math.Abs(a) < 1e-9)
            {
                return new double[] { };
            }

            return new double[] { -b / a };
        }

        public override string ToString()
        {
            return $"Linear: {Coefficients[0]}x + {Coefficients[1]} = 0";
        }
    }
}