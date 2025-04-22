namespace EmployeeProject
{
    /// <summary>
    /// Base class for all company employees
    /// </summary>
    public abstract class Employee
    {
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