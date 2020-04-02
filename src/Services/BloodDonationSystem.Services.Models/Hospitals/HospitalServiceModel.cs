namespace BloodDonationSystem.Services.Models.Hospitals
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;

    public class HospitalServiceModel : IMapFrom<Hospital>, IMapTo<Hospital>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }

        public CityServiceModel City { get; set; }
    }
}
