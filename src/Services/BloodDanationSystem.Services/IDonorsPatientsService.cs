namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;

    public interface IDonorsPatientsService
    {
        Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel);
    }
}
