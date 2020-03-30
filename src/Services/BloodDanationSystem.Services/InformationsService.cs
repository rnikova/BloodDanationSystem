namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Informations;

    public class InformationsService : IInformationsService
    {
        private readonly ApplicationDbContext context;

        public InformationsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateContactFormAsync(ContactFormServiceModel contactFormServiceModel)
        {
            var model = new ContactForm
            {
                Name = contactFormServiceModel.Name,
                Subject = contactFormServiceModel.Subject,
                Message = contactFormServiceModel.Message,
                Email = contactFormServiceModel.Email,
            };

            await this.context.ContactForms.AddAsync(model);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ContactFormServiceModel> AllMessages()
        {
            return this.context.ContactForms.To<ContactFormServiceModel>();
        }

        public async Task<ContactFormServiceModel> GetByIdAsync(string id)
        {
            var email = await this.context.ContactForms.FindAsync(id);
            var model = new ContactFormServiceModel
            {
                Id = email.Id,
                Name = email.Name,
                Email = email.Email,
                Subject = email.Subject,
                Message = email.Message,
            };

            return model;
        }
    }
}
