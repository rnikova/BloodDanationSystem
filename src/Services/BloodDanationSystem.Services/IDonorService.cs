namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;

    public interface IDonorService
    {
        Task<bool> CreateAsync(DonorServiceModel donorServiceModel);

        Task<IEnumerable<DonorServiceModel>> All();

        Task<DonorServiceModel> GetByUserIdAsync(string userId);

        Task<DonorServiceModel> GetByIdAsync(string donorId);
    }
}
