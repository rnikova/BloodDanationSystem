namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class DonorService : IDonorService
    {
        private readonly ApplicationDbContext context;

        public DonorService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<DonorServiceModel>> All()
        {
            return await this.context.Donors.To<DonorServiceModel>().ToListAsync();
        }
    }
}
