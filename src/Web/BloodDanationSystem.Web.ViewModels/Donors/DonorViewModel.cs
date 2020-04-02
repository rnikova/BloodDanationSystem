namespace BloodDanationSystem.Web.ViewModels.Donors
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Cities;
    using BloodDonationSystem.Services.Models;

    public class DonorViewModel : IMapFrom<DonorServiceModel>, IMapTo<DonorServiceModel>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }

        public int CityId { get; set; }

        public string City { get; set; }
    }
}
