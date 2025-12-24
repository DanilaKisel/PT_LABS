using System;

namespace InheritanceTask
{
    public abstract class Equation
    {
        public double[] Coefficients { get; set; }
        public string EquationType { get; protected set; }
        public bool HasRealRoots { get; protected set; }

        public Equation(double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public abstract double[] Solve();

        public bool HasRootsInInterval(double min, double max)
        {
            double[] roots = Solve();
            foreach (var root in roots)
            {
                if (root >= min && root <= max)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{EquationType}: {string.Join(" ", Coefficients)}";
        }
    }
}