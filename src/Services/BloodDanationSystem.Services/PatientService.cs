namespace BloodDanationSystem.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Common.Repositories;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Patients;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public PatientService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> CreateAsync(PatientServiceModel patientServiceModel)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Id == patientServiceModel.UserId);
            var aboGroup = Enum.Parse<ABOGroup>(patientServiceModel.BloodType.ABOGroupName);
            var rhesusFactor = Enum.Parse<RhesusFactor>(patientServiceModel.BloodType.RhesusFactor);

            var bloodType = await this.context.BloodTypes.SingleOrDefaultAsync(x => x.ABOGroupName == aboGroup && x.RhesusFactor == rhesusFactor);

            var patient = new Patient()
            {
                FullName = patientServiceModel.FullName,
                Age = patientServiceModel.Age,
                BloodType = bloodType,
                BloodTypeId = bloodType.Id,
                User = user,
                UserId = user.Id,
                HospitalId = patientServiceModel.HospitalId,
                Ward = patientServiceModel.Ward,
            };

            await this.userManager.AddToRoleAsync(user, GlobalConstants.PatientRoleName);

            await this.context.Patients.AddAsync(patient);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<PatientServiceModel> All()
        {
            return this.context.Patients.To<PatientServiceModel>();
        }

        public IQueryable<PatientServiceModel> AllActive()
        {
            return this.context.Patients.Where(x => x.NeededBloodBanks > 0).To<PatientServiceModel>();
        }

        public async Task<PatientServiceModel> GetByUserIdAsync(string userId)
        {
            var patient = await this.context.Patients.FirstOrDefaultAsync(x => x.UserId == userId);
            var model = new PatientServiceModel
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Age = patient.Age,
                BloodTypeId = patient.BloodTypeId,
                HospitalId = patient.HospitalId,
                Ward = patient.Ward,
                UserId = patient.UserId,
                NeededBloodBanks = patient.NeededBloodBanks,
            };

            return model;
        }

        public async Task<PatientServiceModel> GetByPatientIdAsync(string patientId)
        {
            var patient = await this.context.Patients.FirstOrDefaultAsync(x => x.Id == patientId);
            var model = new PatientServiceModel
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Age = patient.Age,
                BloodTypeId = patient.BloodTypeId,
                HospitalId = patient.HospitalId,
                Ward = patient.Ward,
                UserId = patient.UserId,
                NeededBloodBanks = patient.NeededBloodBanks,
            };

            return model;
        }
    }
}
