namespace BloodDanationSystem.Web.ViewModels.BloodCenters
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Cities;
    using BloodDonationSystem.Services.Models;

    public class BloodCentersViewModel : IMapFrom<BloodCentersServiceModel>, IMapTo<BloodCentersServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public CityViewModel City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string WorkingHours { get; set; }

        public string EventPhone { get; set; }
    }
}
