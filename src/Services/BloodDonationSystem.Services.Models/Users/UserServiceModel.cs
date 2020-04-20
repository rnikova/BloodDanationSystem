namespace BloodDonationSystem.Services.Models.Users
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class UserServiceModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }
    }
}
