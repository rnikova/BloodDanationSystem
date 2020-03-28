using BloodDanationSystem.Data.Models;
using BloodDanationSystem.Services.Mapping;
using BloodDonationSystem.Services.Models.Users;

namespace BloodDonationSystem.Services.Models.Patients
{
    public class PatientServiceModel : IMapFrom<Patient>, IMapTo<Patient>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string UserId { get; set; }

        public UserServiceModel User { get; set; }

        public int HospitalId { get; set; }

        public HospitalServiceModel Hospital { get; set; }
    }
}
