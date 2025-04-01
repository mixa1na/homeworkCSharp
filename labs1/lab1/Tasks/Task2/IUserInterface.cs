namespace Task2
{
    public interface IUserInterface
    {
        int GetStrictlyPositiveInteger(string message);
        double GetDouble(string message);
        string GetNonEmptyString(string message);
        double[] GetDoubleArray(string message);
        void ShowMessage(string message);
    }
}