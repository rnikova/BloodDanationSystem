namespace BloodDonationSystem.Web.InputModels.Patients
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.Hospitals;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PatientsCreateInputModel : IMapTo<PatientServiceModel>, IMapFrom<PatientServiceModel>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }

        [Display(Name ="Hospital")]
        public int HospitalId { get; set; }

        public IQueryable<HospitalInputModel> Hospitals { get; set; }
    }
}
