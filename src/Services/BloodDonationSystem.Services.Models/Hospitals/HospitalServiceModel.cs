namespace BloodDonationSystem.Services.Models.Hospitals
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class HospitalServiceModel : IMapFrom<Hospital>, IMapTo<Hospital>
    {
        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }
    }
}
