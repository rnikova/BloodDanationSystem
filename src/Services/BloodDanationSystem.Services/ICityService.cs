namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDonationSystem.Services.Models.Cities;

    public interface ICityService
    {
        IQueryable<CityServiceModel> AllCities();
    }
}
