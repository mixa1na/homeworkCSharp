using EmployeeProject.Services;
using EmployeeProject.Services.EmployeeProject;

namespace EmployeeProject
{
    /// <summary>
    /// Represents a Developer employee type
    /// </summary>
    public class Developer : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Developer instance
        /// </summary>
        public Developer() : base(SalaryRates.DeveloperRate) { }
    }
}