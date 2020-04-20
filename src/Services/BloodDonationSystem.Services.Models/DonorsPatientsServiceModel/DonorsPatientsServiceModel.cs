namespace BloodDonationSystem.Services.Models.DonorsPatientsServiceModel
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Patients;

    public class DonorsPatientsServiceModel : IMapFrom<DonorsPatients>, IMapTo<DonorsPatients>, IMapFrom<Patient>, IMapTo<Patient>
    {
        public string DonorId { get; set; }

        public DonorServiceModel Donor { get; set; }

        public string PatientId { get; set; }

        public PatientServiceModel Patient { get; set; }

        public string Image { get; set; }

        public string ImageId { get; set; }
    }
}
