namespace BloodDonationSystem.Web.InputModels.Patients
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using System.Collections.Generic;

    public class PatientsCreateInputModel : IMapTo<PatientServiceModel>, IMapFrom<PatientServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }

        public int HospitalId { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }
    }
}
