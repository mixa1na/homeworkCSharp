namespace EmployeeProject
{
    /// <summary>
    /// Class representing an employee
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Maximum allowed working hours per month
        /// </summary>
        public const int MaxHours = 160;
        private int _hoursWorked;

        /// <summary>
        /// Number of hours worked by the employee
        /// </summary>
        public int HoursWorked
        {
            get => _hoursWorked;
            set => _hoursWorked = value;
        }

        /// <summary>
        /// Hourly rate for employee type
        /// </summary>
        protected abstract decimal HourlyRate { get; }

        /// <summary>
        /// Calculates monthly salary based on hours worked and hourly rate
        /// </summary>
        public virtual decimal CalculateSalary() => HoursWorked * HourlyRate;
    }
}