namespace Task1
{
    interface IUserInterface
    {
        int GetIntegerInput(string message);
        double[] GetDoubleArray(string message, int expectedSize);
        void ShowMessage(string message);
        void ShowArray(string name, double[] array);
    }
}