namespace BloodDonationSystem.Web.InputModels.Hospitals
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;
    using BloodDonationSystem.Web.InputModels.Cities;

    public class HospitalInputModel : IMapFrom<HospitalServiceModel>, IMapTo<HospitalServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }

        public CityInputModel City { get; set; }
    }
}
