using EmployeeProject.Services;

namespace EmployeeProject
{
    /// <summary>
    /// Represents a Manager employee type
    /// </summary>
    public class Manager : EmployeeWithFixedRate
    {
        /// <summary>
        /// Initializes a new Manager
        /// </summary>
        public Manager() : base(50m) { }
    }
}