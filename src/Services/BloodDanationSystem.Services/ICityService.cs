namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.Cities;

    public interface ICityService
    {
        Task<IEnumerable<CityServiceModel>> AllCities();
    }
}
