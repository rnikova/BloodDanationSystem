namespace BloodDanationSystem.Data.Models
{
    public class DonorsPatients
    {
        public string DonorId { get; set; }

        public virtual Donor Donor { get; set; }

        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
