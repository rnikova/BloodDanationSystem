namespace BloodDonationSystem.Services.Models
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Services.Models.Users;

    public class DonorServiceModel : IMapFrom<Donor>, IMapTo<Donor>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }

        public UserServiceModel User { get; set; }

        public int CityId{ get; set; }

        public CityServiceModel City { get; set; }
    }
}
