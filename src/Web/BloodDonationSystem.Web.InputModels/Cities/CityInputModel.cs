namespace BloodDonationSystem.Web.InputModels.Cities
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;

    public class CityInputModel : IMapFrom<CityServiceModel>, IMapTo<CityServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
