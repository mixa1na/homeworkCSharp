namespace HospitalPatientManagement.Models
{
    /// <summary>
    /// Represents a patient in the hospital management system.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Gets the last name of the patient.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets the age of the patient.
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// Gets the admission date of the patient.
        /// </summary>
        public DateTime AdmissionDate { get; }

        /// <summary>
        /// Gets or sets the discharge date of the patient.
        /// </summary>
        public DateTime DischargeDate { get; set; }

        /// <summary>
        /// Gets the diagnosis assigned to the patient.
        /// </summary>
        public string Diagnosis { get; }

        /// <summary>
        /// Gets the department where the patient is being treated.
        /// </summary>
        public string Department { get; }

        /// <summary>
        /// Gets the duration of the patient's stay in days.
        /// </summary>
        public int StayDuration => (DischargeDate - AdmissionDate).Days;

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        public Patient(string lastName, int age, DateTime admissionDate, DateTime dischargeDate, string diagnosis, string department)
        {
            LastName = lastName;
            Age = age;
            AdmissionDate = admissionDate;
            DischargeDate = dischargeDate;
            Diagnosis = diagnosis;
            Department = department;
        }

        /// <summary>
        /// Handles logic for halving the treatment duration.
        /// </summary>
        public void HandleHomeKey()
        {
            double duration = (DischargeDate - AdmissionDate).TotalDays / 2;
            DischargeDate = AdmissionDate.AddDays(duration);
        }

        /// <summary>
        /// Handles logic for increasing the treatment duration by 50%.
        /// </summary>
        public void HandleEndKey()
        {
            double duration = (DischargeDate - AdmissionDate).TotalDays * 1.5;
            DischargeDate = AdmissionDate.AddDays(duration);
        }
    }
}
