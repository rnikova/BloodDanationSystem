namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDonationSystem.Services.Models;

    public interface IDonorService
    {
        IQueryable<DonorServiceModel> All();
    }
}
