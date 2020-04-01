namespace BloodDonationSystem.Services.Models.Cities
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class CityServiceModel : IMapFrom<City>, IMapTo<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
