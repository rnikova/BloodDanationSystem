﻿namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Informations;

    public interface IInformationsService
    {
        Task<bool> CreateContactFormAsync(ContactFormServiceModel contactFormServiceModel);

        Task<IEnumerable<ContactFormServiceModel>> AllMessages();

        Task<ContactFormServiceModel> GetByIdAsync(string id);

        Task<IEnumerable<BloodCentersServiceModel>> AllBloodCenters();
    }
}
