namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class DonorService : IDonorService
    {
        private readonly ApplicationDbContext context;

        public DonorService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<DonorServiceModel> All()
        {
            return this.context.Donors.To<DonorServiceModel>();
        }
    }
}
