namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;

    public interface IDonorService
    {
        Task<bool> Create(DonorServiceModel donorServiceModel);

        IQueryable<DonorServiceModel> All();
    }
}
