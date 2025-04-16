namespace EmployeeProject
{
    class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        static void Main()
        {
            InitializeAndRunApplication();
        }

        /// <summary>
        /// Initializes application components and starts main loop
        /// </summary>
        private static void InitializeAndRunApplication()
        {
            var calculator = new SalaryCalculator();
            var ui = new EmployeeConsoleUI(calculator);
            ui.Run();
        }
    }
}