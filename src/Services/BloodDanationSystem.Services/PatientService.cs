namespace BloodDanationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using Microsoft.AspNetCore.Identity;

    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext context;

        public PatientService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(PatientServiceModel patientServiceModel)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == patientServiceModel.UserId);
            var role = this.context.Roles.FirstOrDefault(x => x.Name == "Patient");
            var aboGroup = Enum.Parse<ABOGroup>(patientServiceModel.BloodType.ABOGroupName);
            var rhesusFactor = Enum.Parse<RhesusFactor>(patientServiceModel.BloodType.RhesusFactor);

            var bloodType = this.context.BloodTypes.SingleOrDefault(x => x.ABOGroupName == aboGroup && x.RhesusFactor == rhesusFactor);

            var patient = new Patient()
            {
                FullName = patientServiceModel.FullName,
                Age = patientServiceModel.Age,
                BloodType = bloodType,
                BloodTypeId = bloodType.Id,
                User = user,
                UserId = user.Id,
                HospitalId = patientServiceModel.HospitalId,
            };

            user.Roles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = user.Id });

            this.context.Patients.Add(patient);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<PatientServiceModel> All()
        {
            return this.context.Patients.To<PatientServiceModel>();
        }

        public IEnumerable<Hospital> AllHospitals()
        {
            return this.context.Hospitals.ToList();
        }
    }
}
