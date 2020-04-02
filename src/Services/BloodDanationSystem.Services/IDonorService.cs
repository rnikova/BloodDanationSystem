namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Cities;

    public interface IDonorService
    {
        Task<bool> CreateAsync(DonorServiceModel donorServiceModel);

        IQueryable<DonorServiceModel> All();

        IQueryable<CityServiceModel> AllCities();
    }
}
