namespace Task2
{
    interface IUserInterface
    {
        int GetIntegerInput(string message);
        double GetDoubleInput(string message);
        string GetStringInput(string message);
        double[] GetDoubleArray(string message);
        void ShowMessage(string message);
    }
}
