namespace EmployeeProject
{
    /// <summary>
    /// Provides salary calculation services for employees
    /// </summary>
    public class SalaryCalculator
    {
        /// <summary>
        /// Calculates salary for the given employee
        /// </summary>
        public decimal Calculate(Employee employee) => employee.CalculateSalary();
    }
}