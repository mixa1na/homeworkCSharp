namespace Task1
{
    public class Logic
    {
        private readonly IUserInterface _ui;

        public Logic(IUserInterface ui) => _ui = ui;

        public void Run()
        {
            int sizeA = _ui.GetStrictlyPositiveInteger("Enter size for array A:");
            double[] arrayA = _ui.GetDoubleArray($"Enter {sizeA} space-separated numbers for array A:", sizeA);

            int sizeB = _ui.GetStrictlyPositiveInteger("Enter size for array B:");
            double[] arrayB = _ui.GetDoubleArray($"Enter {sizeB} space-separated numbers for array B:", sizeB);

            const int variant = 6;
            int a = variant;
            int b = variant * 2;
            int c = variant / 2;
            double result = MathOperations.CalculateFunction(a, b, c);
            _ui.ShowMessage($"Function result: {result}");

            double[] arrayC = ArrayOperations.GenerateArrayC(arrayA, arrayB, variant / 2);
            _ui.ShowArray("Resulting array C", arrayC);
        }
    }
}