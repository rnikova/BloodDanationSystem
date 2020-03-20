namespace BloodDanationSystem.Web.ViewModels.Administration.Donor
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class PatientAllViewModel : IMapFrom<PatientServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string BloodType { get; set; }

        public string User { get; set; }
    }
}