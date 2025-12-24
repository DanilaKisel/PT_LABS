using System;
using System.Linq;

namespace InheritanceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Equation[] equations = new Equation[10];
            Random rnd = new Random();

            for (int i = 0; i < equations.Length; i++)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    double a = rnd.Next(-10, 11);
                    if (a == 0) a = 1;
                    double b = rnd.Next(-10, 11);
                    equations[i] = new LinearEquation(a, b);
                }
                else
                {
                    double a = rnd.Next(-10, 11);
                    if (a == 0) a = 1;
                    double b = rnd.Next(-10, 11);
                    double c = rnd.Next(-10, 11);
                    equations[i] = new QuadraticEquation(a, b, c);
                }
            }

            foreach (var eq in equations)
            {
                double[] roots = eq.Solve();
                string rootsStr = roots.Length > 0 ? string.Join(", ", roots.Select(r => r.ToString("F2"))) : "no roots";
                Console.WriteLine($"{eq} | Roots: [{rootsStr}]");
            }

            Equation maxRootsEq = equations[0];
            int maxRootsCount = -1;

            foreach (var eq in equations)
            {
                int count = eq.Solve().Length;
                if (count > maxRootsCount)
                {
                    maxRootsCount = count;
                    maxRootsEq = eq;
                }
            }
            Console.WriteLine($"Max roots: {maxRootsEq}");

            double minDiscriminant = double.MaxValue;
            QuadraticEquation minDiscEq = null;

            foreach (var eq in equations)
            {
                if (eq is QuadraticEquation quadEq)
                {
                    if (quadEq.Discriminant < minDiscriminant)
                    {
                        minDiscriminant = quadEq.Discriminant;
                        minDiscEq = quadEq;
                    }
                }
            }

            if (minDiscEq != null)
            {
                Console.WriteLine($"Min discriminant ({minDiscriminant:F2}): {minDiscEq}");
            }
            
            Console.ReadKey();
        }
    }
}