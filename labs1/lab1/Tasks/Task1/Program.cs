namespace Task1
{
    class Program
    {
        public static void Run()
        {
            IUserInterface ui = new ConsoleInterface();
            Logic logic = new Logic(ui);
            logic.Run();
        }
    }
}