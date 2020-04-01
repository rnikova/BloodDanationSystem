namespace BloodDonationSystem.Services.Models
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;

    public class BloodCentersServiceModel : IMapFrom<BloodCenter>, IMapTo<BloodCenter>
    {
        public string Name { get; set; }

        public int CityId { get; set; }

        public CityServiceModel City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string WorkingHours { get; set; }

        public string EventPhone { get; set; }
    }
}
