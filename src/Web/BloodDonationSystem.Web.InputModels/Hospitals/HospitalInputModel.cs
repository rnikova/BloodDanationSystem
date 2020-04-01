namespace BloodDonationSystem.Web.InputModels.Hospitals
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class HospitalInputModel : IMapFrom<BloodCentersServiceModel>, IMapTo<BloodCentersServiceModel>
    {
        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }
    }
}
