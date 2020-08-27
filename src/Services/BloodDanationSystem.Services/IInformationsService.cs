namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Informations;

    public interface IInformationsService
    {
        Task<bool> CreateContactFormAsync(ContactFormServiceModel contactFormServiceModel);

        Task<IEnumerable<ContactFormServiceModel>> AllMessagesAsync();

        Task<ContactFormServiceModel> GetByIdAsync(string id);

        Task<IEnumerable<BloodCentersServiceModel>> AllBloodCentersAsync();

        Task<BloodCentersServiceModel> GetBloodCenterByIdAsync(int id);

        Task<int> EditBloodCenterAsync(BloodCentersServiceModel model);

        Task<int> DeleteBloodCenterAsync(int id);
    }
}
