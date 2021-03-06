﻿namespace BloodDanationSystem.Web.ViewModels.Administration.Information
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Informations;

    public class EmailsAllViewModel : IMapFrom<ContactFormServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
