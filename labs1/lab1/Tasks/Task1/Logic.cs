namespace Task1
{
    class Logic
    {
        private IUserInterface _ui;
        public Logic(IUserInterface ui) { _ui = ui; }

        public void Run()
        {
            int sizeA = _ui.GetIntegerInput("Enter size of array A:");
            double[] arrayA = _ui.GetDoubleArray("Enter elements of array A:", sizeA);

            int sizeB = _ui.GetIntegerInput("Enter size of array B:");
            double[] arrayB = _ui.GetDoubleArray("Enter elements of array B:", sizeB);

            int variant = 6;
            int a = variant;
            int b = variant * 2;
            int c = variant / 2;

            double result = MathOperations.CalculateFunction(a, b, c);
            _ui.ShowMessage($"Function result: {result}");

            double[] arrayC = ArrayOperations.GenerateArrayC(arrayA, arrayB, c);
            _ui.ShowArray("Array C", arrayC);
        }
    }
}