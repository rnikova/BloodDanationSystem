﻿namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;

    public interface IDonorsPatientsService
    {
        Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorIdAsync(string donorId);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByPatientIdAsync(string patientId);

        Task<bool> AddImageAsync(DonorsPatientsServiceModel donorsPatientsServiceModel, string imageUrl);
    }
}
