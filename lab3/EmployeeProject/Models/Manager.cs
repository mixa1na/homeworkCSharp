using EmployeeProject.Services.EmployeeProject;
using EmployeeProject.Services;

namespace EmployeeProject
{
    /// <summary>
    /// Represents a Manager employee type
    /// </summary>
    public class Manager : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Manager instance
        /// </summary>
        public Manager() : base(SalaryRates.ManagerRate) { }
    }
}