namespace BloodDonationSystem.Services.Models.Cities
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;
    using System.Collections.Generic;

    public class CityServiceModel : IMapFrom<City>, IMapTo<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<HospitalServiceModel> Hospitals { get; set; }
    }
}
