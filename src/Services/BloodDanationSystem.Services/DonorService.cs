namespace BloodDanationSystem.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DonorService : IDonorService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public DonorService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> CreateAsync(DonorServiceModel donorServiceModel)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Id == donorServiceModel.UserId);
            var aboGroup = Enum.Parse<ABOGroup>(donorServiceModel.BloodType.ABOGroupName);
            var rhesusFactor = Enum.Parse<RhesusFactor>(donorServiceModel.BloodType.RhesusFactor);

            var bloodType = await this.context.BloodTypes.SingleOrDefaultAsync(x => x.ABOGroupName == aboGroup && x.RhesusFactor == rhesusFactor);

            var donor = new Donor()
            {
                FullName = donorServiceModel.FullName,
                Age = donorServiceModel.Age,
                BloodType = bloodType,
                BloodTypeId = bloodType.Id,
                User = user,
                UserId = user.Id,
                CityId = donorServiceModel.CityId,
            };

            await this.userManager.AddToRoleAsync(user, GlobalConstants.DonorRoleName);

            await this.context.Donors.AddAsync(donor);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<DonorServiceModel> All()
        {
            return this.context.Donors.To<DonorServiceModel>();
        }

        public async Task<DonorServiceModel> GetByUserIdAsync(string userId)
        {
            var donor = await this.context.Donors.SingleOrDefaultAsync(x => x.UserId == userId);
            var model = new DonorServiceModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                Age = donor.Age,
                BloodTypeId = donor.BloodTypeId,
                CityId = donor.CityId,
                UserId = donor.UserId,
            };

            return model;
        }
    }
}
