namespace HospitalPatientManagement.Models
{
    /// <summary>
    /// Represents a hospital patient with personal and medical data.
    /// </summary>
    public class Patient
    {
        private const int DaysInYear = 365;

        private readonly string _surname;
        private readonly int _age;
        private readonly DateTime _admissionDate;
        private DateTime _dischargeDate;
        private readonly string _diagnosis;
        private readonly string _department;

        /// <summary>
        /// Gets the patient's surname.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
        }

        /// <summary>
        /// Gets the diagnosis of the patient.
        /// </summary>
        public string Diagnosis
        {
            get { return _diagnosis; }
        }

        /// <summary>
        /// Gets the age of the patient.
        /// </summary>
        public int Age
        {
            get { return _age; }
        }

        /// <summary>
        /// Calculates the number of days the patient stayed in hospital.
        /// </summary>
        public int StayLength
        {
            get
            {
                TimeSpan stay = _dischargeDate - _admissionDate;
                return (int)stay.TotalDays;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        /// <param name="surname">Patient's surname.</param>
        /// <param name="age">Patient's age in years.</param>
        /// <param name="admissionDate">Date when patient was admitted to hospital.</param>
        /// <param name="dischargeDate">Date when patient was discharged from hospital.</param>
        /// <param name="diagnosis">Medical diagnosis of the patient.</param>
        /// <param name="department">Hospital department where patient was treated.</param>
        public Patient(
            string surname,
            int age,
            DateTime admissionDate,
            DateTime dischargeDate,
            string diagnosis,
            string department)
        {
            _surname = surname;
            _age = age;
            _admissionDate = admissionDate;
            _dischargeDate = dischargeDate;
            _diagnosis = diagnosis;
            _department = department;
        }

        /// <summary>
        /// Halves the patient's hospital stay length by adjusting the discharge date.
        /// </summary>
        public void HalveStay()
        {
            double halfDays = StayLength / 2.0;
            _dischargeDate = _admissionDate.AddDays(halfDays);
        }

        /// <summary>
        /// Increases the patient's hospital stay length by 1.5 times by adjusting the discharge date.
        /// </summary>
        public void IncreaseStay()
        {
            double increasedDays = StayLength * 1.5;
            _dischargeDate = _admissionDate.AddDays(increasedDays);
        }

        /// <summary>
        /// Returns a formatted string with patient info for display.
        /// </summary>
        /// <returns>Formatted string containing surname, diagnosis, stay length, and age.</returns>
        public string GetFormattedInfo()
        {
            return string.Format("{0,-10} {1,-12} {2,5} {3,5}", _surname, _diagnosis, StayLength, _age);
        }
    }
}
