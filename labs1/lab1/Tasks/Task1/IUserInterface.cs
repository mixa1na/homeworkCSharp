namespace Task1
{
    public interface IUserInterface
    {
        int GetStrictlyPositiveInteger(string message);
        double[] GetDoubleArray(string message, int requiredSize);
        void ShowMessage(string message);
        void ShowArray(string name, double[] array);
    }
}