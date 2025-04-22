using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Services
{
    namespace EmployeeProject
    {
        /// <summary>
        /// Contains all constant values used in the application
        /// </summary>
        public static class SalaryRates
        {
            /// <summary>
            /// Hourly rate for Manager position
            /// </summary>
            public const decimal ManagerRate = 50m;

            /// <summary>
            /// Hourly rate for Developer position
            /// </summary>
            public const decimal DeveloperRate = 40m;

            /// <summary>
            /// Hourly rate for Intern position
            /// </summary>
            public const decimal InternRate = 20m;

            /// <summary>
            /// Maximum allowed working hours per month
            /// </summary>
            public const int MaxHours = 160;
        }
    }
}
