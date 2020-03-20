using BloodDanationSystem.Data.Models;
using BloodDanationSystem.Services.Mapping;

namespace BloodDonationSystem.Services.Models
{
    public class PatientServiceModel : IMapFrom<Patient>, IMapTo<Patient>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public int HospitalId { get; set; }

        public string Hospital { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
    }
}
