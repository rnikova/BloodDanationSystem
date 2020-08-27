namespace BloodDanationSystem.Web.ViewModels.Administration.Information
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Cities;

    public class EditBloodCenterViewModel : IMapFrom<BloodCenter>, IMapTo<BloodCenter>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public CityViewModel City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string WorkingHours { get; set; }

        public string Email { get; set; }

        public string EventPhone { get; set; }
    }
}
