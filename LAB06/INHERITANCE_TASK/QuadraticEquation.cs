using System;

namespace InheritanceTask
{
    public class QuadraticEquation : Equation
    {
        public double Discriminant { get; private set; }

        public QuadraticEquation(double a, double b, double c) : base(new double[] { a, b, c })
        {
            EquationType = "Quadratic Equation";
            CalculateDiscriminant();
        }

        private void CalculateDiscriminant()
        {
            double a = Coefficients[0];
            double b = Coefficients[1];
            double c = Coefficients[2];
            Discriminant = b * b - 4 * a * c;
            HasRealRoots = Discriminant >= 0;
        }

        public override double[] Solve()
        {
            if (!HasRealRoots) return new double[] { };

            double a = Coefficients[0];
            double b = Coefficients[1];

            if (Math.Abs(Discriminant) < 1e-9)
            {
                return new double[] { -b / (2 * a) };
            }
            else
            {
                double x1 = (-b + Math.Sqrt(Discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
                return new double[] { x1, x2 };
            }
        }

        public override string ToString()
        {
            return $"Quadratic: {Coefficients[0]}x^2 + {Coefficients[1]}x + {Coefficients[2]} = 0 (D={Discriminant:F2})";
        }
    }
}