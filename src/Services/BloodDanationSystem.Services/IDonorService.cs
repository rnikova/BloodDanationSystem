namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;

    public interface IDonorService
    {
        Task<ICollection<DonorServiceModel>> All();
    }
}
