using EmployeeProject.Services;
using EmployeeProject.Services.EmployeeProject;

namespace EmployeeProject
{
    /// <summary>
    /// Represents an Intern employee type
    /// </summary>
    public class Intern : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Intern instance
        /// </summary>
        public Intern() : base(SalaryRates.InternRate) { }
    }
}