namespace BloodDonationSystem.Services.Models
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class DonorServiceModel : IMapFrom<Donor>, IMapTo<Donor>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }
    }
}
