using EmployeeProject.Services;

namespace EmployeeProject
{
    /// <summary>
    /// Represents an Intern employee type
    /// </summary>
    public class Intern : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Intern
        /// </summary>
        public Intern() : base(20m) { }
    }
}