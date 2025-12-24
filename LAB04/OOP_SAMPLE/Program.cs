namespace OOP_SAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticEquation eq1 = new QuadraticEquation(2, 4, -3);
           foreach (double root in eq1.GetRoots())
            {
                Console.WriteLine(root);
            }
        }
    }
}

