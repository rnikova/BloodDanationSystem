namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using CloudinaryDotNet.Actions;

    public interface IDonorsPatientsService
    {
        Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorsUserIdAsync(string donorId);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByPatientsUserIdAsync(string patientId);

        Task<bool> AddImageAsync(DonorsPatientsServiceModel donorsPatientsServiceModel, string imageUrl);

        Task<bool> DeleteDonorsPatient(DonorsPatientsServiceModel donorsPatientsServiceModel);
    }
}
