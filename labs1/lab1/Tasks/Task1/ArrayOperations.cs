namespace Task1
{
    class ArrayOperations
    {
        public static double[] GenerateArrayC(double[] arrayA, double[] arrayB, int index)
        {
            List<double> newArray = new List<double>();
            int minIndexB = Array.IndexOf(arrayB, arrayB.Min());
            int minIndexA = Array.LastIndexOf(arrayA, arrayA.Min());

            newArray.AddRange(arrayB.Skip(minIndexB + 1));
            newArray.AddRange(arrayA.Skip(minIndexA + 1).Take(index));

            return newArray.ToArray();
        }
    }
}