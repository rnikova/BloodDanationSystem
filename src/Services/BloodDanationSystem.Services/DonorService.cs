namespace BloodDanationSystem.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;
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
            var aboGroup = Enum.Parse<ABOGroup>(donorServiceModel.BloodType.ABOGroupName);
            var rhesusFactor = Enum.Parse<RhesusFactor>(donorServiceModel.BloodType.RhesusFactor);

            var bloodType = this.context.BloodTypes.SingleOrDefault(x => x.ABOGroupName == aboGroup && x.RhesusFactor == rhesusFactor);

            var donor = new Donor()
            {
                FullName = donorServiceModel.FullName,
                Age = donorServiceModel.Age,
                BloodType = bloodType,
                BloodTypeId = bloodType.Id,
                User = user,
                UserId = user.Id,
            };

            user.Roles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = user.Id });

            this.context.Donors.Add(donor);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
