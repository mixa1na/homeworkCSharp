using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Services
{
    /// <summary>
    /// Base class for employees with fixed hourly rate
    /// </summary>
    public abstract class EmployeeWithFixedRate : Employee
    {
        /// <summary>
        /// Fixed hourly rate for this employee type
        /// </summary>
        private readonly decimal _hourlyRate;

        /// <summary>
        /// Initializes a new instance with specified hourly rate
        /// </summary>
        protected EmployeeWithFixedRate(decimal hourlyRate)
        {
            _hourlyRate = hourlyRate;
        }

        /// <inheritdoc/>
        protected override decimal HourlyRate => _hourlyRate;
    }
}
