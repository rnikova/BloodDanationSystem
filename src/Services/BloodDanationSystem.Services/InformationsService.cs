namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Informations;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ContactFormServiceModel>> AllMessagesAsync()
        {
            return await this.context
                .ContactForms
                .AsNoTracking()
                .To<ContactFormServiceModel>()
                .ToListAsync();
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

        public async Task<IEnumerable<BloodCentersServiceModel>> AllBloodCentersAsync()
        {
            return await this.context
                .BloodCenters
                .AsNoTracking()
                .OrderBy(x => x.City.Name)
                .To<BloodCentersServiceModel>()
                .ToListAsync();
        }

        public async Task<BloodCentersServiceModel> GetBloodCenterByIdAsync(int id)
        {
            var bloodCenter = await this.context
                .BloodCenters
                .SingleOrDefaultAsync(x => x.Id == id);
            var model = new BloodCentersServiceModel
            {
                Id = bloodCenter.Id,
                Address = bloodCenter.Address,
                Phone = bloodCenter.Phone,
                EventPhone = bloodCenter.EventPhone,
                Email = bloodCenter.Email,
                WorkingHours = bloodCenter.WorkingHours,
                Name = bloodCenter.Name,
            };

            return model;
        }

        public async Task<int> AddBloodCenterAsync(BloodCentersServiceModel bloodCenter)
        {
            var newBloodCenter = new BloodCenter
            {
                Name = bloodCenter.Name,
                Email = bloodCenter.Email,
                Phone = bloodCenter.Phone,
                EventPhone = bloodCenter.EventPhone,
                Address = bloodCenter.Address,
                City = bloodCenter.City.To<City>(),
                WorkingHours = bloodCenter.WorkingHours,
            };

            await this.context.BloodCenters.AddAsync(newBloodCenter);
            var result = await this.context.SaveChangesAsync();

            return result;
        }

        public async Task<int> EditBloodCenterAsync(BloodCentersServiceModel model)
        {
            var bloodCenter = await this.context
                .BloodCenters
                .SingleOrDefaultAsync(x => x.Id == model.Id);

            bloodCenter = model.To<BloodCenter>();

            var result = await this.context.SaveChangesAsync();

            return result;
        }

        public async Task<int> DeleteBloodCenterAsync(int id)
        {
            var bloodCenter = await this.context
                .BloodCenters
                .SingleOrDefaultAsync(x => x.Id == id);
            bloodCenter.IsDeleted = true;

            var result = await this.context.SaveChangesAsync();

            return result;
        }
    }
}
