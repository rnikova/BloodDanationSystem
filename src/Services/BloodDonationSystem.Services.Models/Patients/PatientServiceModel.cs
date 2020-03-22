namespace BloodDonationSystem.Services.Models.Patients
{
    public class PatientServiceModel
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }

        public string HospitalId { get; set; }
    }
}
