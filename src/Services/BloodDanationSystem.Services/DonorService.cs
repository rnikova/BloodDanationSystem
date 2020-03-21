namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using Microsoft.AspNetCore.Identity;

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

        public async Task<bool> Create(DonorServiceModel donorServiceModel)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == donorServiceModel.UserId);
            var role = this.context.Roles.FirstOrDefault(x => x.Name == "Donor");

            var donor = donorServiceModel.To<Donor>();
            user.Roles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = user.Id });

            this.context.Donors.Add(donor);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
