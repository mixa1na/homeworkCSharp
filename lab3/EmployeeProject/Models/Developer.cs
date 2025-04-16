using EmployeeProject.Services;

namespace EmployeeProject
{
    /// <summary>
    /// Represents a Developer employee type
    /// </summary>
    public class Developer : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Developer
        /// </summary>
        public Developer() : base(40m) { }
    }
}