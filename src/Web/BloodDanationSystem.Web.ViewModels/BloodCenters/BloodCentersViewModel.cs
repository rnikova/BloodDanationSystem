namespace BloodDanationSystem.Web.ViewModels.BloodCenters
{
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Cities;
    using BloodDonationSystem.Services.Models;

    public class BloodCentersViewModel : IMapFrom<BloodCentersServiceModel>, IMapTo<BloodCentersServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        public int CityId { get; set; }

        [Display(Name = "Град")]
        public CityViewModel City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Работно време")]
        public string WorkingHours { get; set; }

        [Display(Name = "Телефон за събития")]
        public string EventPhone { get; set; }
    }
}
