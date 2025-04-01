using System;

namespace Task1
{
    public static class MathOperations
    {
        public static double CalculateFunction(int a, int b, int c)
        {
            return (2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
        }
    }
}