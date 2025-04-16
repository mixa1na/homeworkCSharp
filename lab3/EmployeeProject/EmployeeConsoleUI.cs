namespace EmployeeProject
{
    /// <summary>
    /// All console UI interactions for the application
    /// </summary>
    public class EmployeeConsoleUI
    {
        private readonly SalaryCalculator _calculator;

        /// <summary>
        /// Initializes a new instance of the EmployeeConsoleUI class
        /// </summary>

        public EmployeeConsoleUI(SalaryCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Run()
        {
            ShowWelcomeMessage();

            while (true)
            {
                try
                {
                    var employee = GetEmployeeSelection();
                    if (ShouldExit(employee)) break;

                    employee.HoursWorked = GetValidHoursWorked();
                    ShowCalculatedSalary(employee);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }

            ExitApplication();
        }

        /// <summary>
        /// Displays the employee type selection menu
        /// </summary>
        private void ShowWelcomeMessage()
        {
            Console.WriteLine("Employee Salary Calculator");
        }

        /// <summary>
        /// Gets employee type selection from user
        /// </summary>
        private Employee? GetEmployeeSelection()
        {
            while (true)
            {
                try
                {
                    ShowSelectionMenu();
                    var input = GetUserInput();
                    return ParseEmployeeSelection(input);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displays the employee type selection menu
        /// </summary>
        private void ShowSelectionMenu()
        {
            Console.WriteLine("\nSelect employee type:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Developer");
            Console.WriteLine("3. Intern");
            Console.WriteLine("4. Exit");
            Console.Write("Your choice: ");
        }

        /// <summary>
        /// Gets input from the console
        /// </summary>
        private string? GetUserInput() => Console.ReadLine();

        /// <summary>
        /// Parses user input into Employee instance
        /// </summary>
        private Employee? ParseEmployeeSelection(string? input)
        {
            return input switch
            {
                "1" => new Manager(),
                "2" => new Developer(),
                "3" => new Intern(),
                "4" => null,
                _ => throw new ArgumentException("Please enter 1-4")
            };
        }

        /// <summary>
        /// Determines if application should exit
        /// </summary>
        private bool ShouldExit(Employee? employee) => employee == null;

        /// <summary>
        /// Gets valid hours worked input from user
        /// </summary>
        private int GetValidHoursWorked()
        {
            while (true)
            {
                try
                {
                    return GetAndValidateHoursWorked();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Prompts for and validates hours worked input
        /// </summary>
        private int GetAndValidateHoursWorked()
        {
            Console.Write("\nEnter hours worked (1-160): ");
            var input = GetUserInput();

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be empty");

            if (!int.TryParse(input, out var hours))
                throw new ArgumentException("Please enter a valid number");

            if (hours < 1 || hours > 160)
                throw new ArgumentException("Hours must be between 1 and 160");

            return hours;
        }

        /// <summary>
        /// Displays calculated salary for employee
        /// </summary>
        private void ShowCalculatedSalary(Employee employee)
        {
            Console.WriteLine($"\nCalculated salary: {_calculator.Calculate(employee)}");
        }

        /// <summary>
        /// Displays error message to user
        /// </summary>
        private void ShowError(Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        /// <summary>
        /// Handles application exit procedure
        /// </summary>
        private void ExitApplication()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}