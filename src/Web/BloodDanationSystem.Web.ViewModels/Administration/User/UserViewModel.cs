namespace BloodDanationSystem.Web.ViewModels.Administration.User
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Users;

    public class UserViewModel : IMapFrom<UserServiceModel>, IMapTo<UserServiceModel>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }
    }
}
