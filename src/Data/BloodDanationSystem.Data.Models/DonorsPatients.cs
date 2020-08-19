namespace BloodDanationSystem.Data.Models
{
    using BloodDanationSystem.Data.Common.Models;

    public class DonorsPatients : BaseDeletableModel<string>
    {
        public string DonorId { get; set; }

        public virtual Donor Donor { get; set; }

        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string Image { get; set; }

        public string ImageId { get; set; }
    }
}
