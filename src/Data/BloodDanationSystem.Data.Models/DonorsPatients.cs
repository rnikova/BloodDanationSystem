namespace BloodDanationSystem.Data.Models
{
    public class DonorsPatients
    {
        public string DonorId { get; set; }

        public Donor Donor { get; set; }

        public string PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
