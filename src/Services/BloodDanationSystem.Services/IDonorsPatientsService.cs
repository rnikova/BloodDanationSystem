namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;

    public interface IDonorsPatientsService
    {
        Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorsUserIdAsync(string donorId);

        Task<DonorsPatientsServiceModel> GetDonorsPatientsByPatientsUserIdAsync(string patientId);

        Task<bool> AddImageAsync(DonorsPatientsServiceModel donorsPatientsServiceModel, string imageUrl);

        Task<bool> DeleteDonorsPatientAsync(DonorsPatientsServiceModel donorsPatientsServiceModel);
    }
}
