namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.Informations;

    public interface IInformationsService
    {
        Task<bool> CreateContactFormAsync(ContactFormServiceModel contactFormServiceModel);

        IQueryable<ContactFormServiceModel> AllMessages();

        Task<ContactFormServiceModel> GetByIdAsync(string id);
    }
}
