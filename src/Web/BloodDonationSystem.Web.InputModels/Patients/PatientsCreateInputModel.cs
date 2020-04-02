namespace BloodDonationSystem.Web.InputModels.Patients
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Hospitals;
    using BloodDonationSystem.Services.Models.Patients;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PatientsCreateInputModel : IMapTo<PatientServiceModel>, IMapFrom<PatientServiceModel>
    {
        [Required]
        [Display(Name = "Трите имена")]
        public string FullName { get; set; }

        [Required]
        [Display(Name ="Възраст")]
        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }

        [Display(Name ="Лечебно заведение")]
        public int HospitalId { get; set; }

        [Display(Name = "Отделение")]
        public string Ward { get; set; }

        public IQueryable<HospitalServiceModel> Hospitals { get; set; }
    }
}
