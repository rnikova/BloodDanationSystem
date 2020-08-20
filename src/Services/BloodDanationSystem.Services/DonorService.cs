namespace BloodDanationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Common.Repositories;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DonorService : IDonorService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Donor> donorsRepository;

        public DonorService(EfDeletableEntityRepository<Donor> donorsRepository, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.donorsRepository = donorsRepository;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> CreateAsync(DonorServiceModel donorServiceModel)
        {
            if (string.IsNullOrWhiteSpace(donorServiceModel.FullName)
                || string.IsNullOrWhiteSpace(donorServiceModel.UserId)
                || donorServiceModel.BloodType == null)
            {
                throw new ArgumentNullException();
            }

            var user = await this.context.Users.SingleOrDefaultAsync(x => x.Id == donorServiceModel.UserId);

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

            await this.donorsRepository.AddAsync(donor);
            var result = await this.donorsRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<DonorServiceModel>> All()
        {
            return await this.donorsRepository
                .AllAsNoTracking()
                .To<DonorServiceModel>()
                .ToListAsync();
        }

        public async Task<DonorServiceModel> GetByUserIdAsync(string userId)
        {
            var donor = await this.donorsRepository.GetByIdWithDeletedAsync(userId);

            if (donor == null)
            {
                throw new InvalidOperationException();
            }

            // var model = new DonorServiceModel
            // {
            //    Id = donor.Id,
            //    FullName = donor.FullName,
            //    Age = donor.Age,
            //    BloodTypeId = donor.BloodTypeId,
            //    CityId = donor.CityId,
            //    UserId = donor.UserId,
            // };
            return donor.To<DonorServiceModel>();
        }

        public async Task<DonorServiceModel> GetByIdAsync(string donorId)
        {
            var donor = await this.donorsRepository.GetByIdWithDeletedAsync(donorId);

            // var donor = await this.context.Donors.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == donorId);
            // var model = new DonorServiceModel
            // {
            //    Id = donor.Id,
            //    FullName = donor.FullName,
            //    Age = donor.Age,
            //    BloodTypeId = donor.BloodTypeId,
            //    CityId = donor.CityId,
            //    UserId = donor.UserId,
            //    User = new UserServiceModel
            //    {
            //        Email = donor.User.Email,
            //    },
            // };
            return donor.To<DonorServiceModel>();
        }
    }
}
