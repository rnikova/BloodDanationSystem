namespace BloodDanationSystem.Web.ViewModels.Cities
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;

    public class CityViewModel : IMapFrom<CityServiceModel>, IMapTo<CityServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
