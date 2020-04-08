namespace BloodDonationSystem.Web.InputModels.Patients
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Services.Models.Hospitals;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.BloodTypees;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PatientsCreateInputModel : IMapTo<PatientServiceModel>, IMapFrom<PatientServiceModel>
    {
        private const string InvalidFullNameMessage = "Моля въведете трите имена";
        private const int MinValueNeededBloodBanks = 1;
        private const int MaxValueNeededBloodBanks = 10;

        [Required]
        [Display(Name = "Трите имена")]
        [RegularExpression(@"[\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+", ErrorMessage = InvalidFullNameMessage)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Възраст")]
        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeInputModel BloodType { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Лечебно заведение")]
        public int HospitalId { get; set; }

        [Required]
        [Display(Name = "Отделение")]
        public string Ward { get; set; }

        [Display(Name = "Нужни банки кръв")]
        [Range(MinValueNeededBloodBanks, MaxValueNeededBloodBanks)]
        public int NeededBloodBanks { get; set; }

        public IQueryable<HospitalServiceModel> Hospitals { get; set; }

        [Display(Name = "Град")]
        public int CityId { get; set; }

        public IQueryable<CityServiceModel> Cities { get; set; }
    }
}
