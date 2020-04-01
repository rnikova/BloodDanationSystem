namespace BloodDanationSystem.Web.ViewModels.Hospitals
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;

    public class HospitalViewModel : IMapFrom<HospitalServiceModel>, IMapTo<HospitalServiceModel>
    {
        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }
    }
}
