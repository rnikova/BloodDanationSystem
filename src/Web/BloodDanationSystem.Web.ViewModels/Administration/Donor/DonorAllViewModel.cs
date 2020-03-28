namespace BloodDanationSystem.Web.ViewModels.Administration.Donor
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Administration.BloodTypes;
    using BloodDanationSystem.Web.ViewModels.Administration.User;
    using BloodDonationSystem.Services.Models;

    public class DonorAllViewModel : IMapFrom<DonorServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeViewModel BloodType { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}
