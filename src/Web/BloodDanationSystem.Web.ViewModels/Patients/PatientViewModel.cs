namespace BloodDanationSystem.Web.ViewModels.Patients
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Administration.BloodTypes;
    using BloodDanationSystem.Web.ViewModels.Hospitals;
    using BloodDonationSystem.Services.Models.Patients;

    public class PatientViewModel : IMapFrom<PatientServiceModel>, IMapTo<PatientServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeViewModel BloodType { get; set; }

        public string UserId { get; set; }

        public int HospitalId { get; set; }

        public HospitalViewModel Hospital { get; set; }

        public string Ward { get; set; }
    }
}
