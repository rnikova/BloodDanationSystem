﻿namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.Patients;

    public interface IPatientService
    {
        Task<bool> CreateAsync(PatientServiceModel patientServiceModel);

        IQueryable<PatientServiceModel> All();

        Task<PatientServiceModel> FindByUserIdAsync(string id);
    }
}
