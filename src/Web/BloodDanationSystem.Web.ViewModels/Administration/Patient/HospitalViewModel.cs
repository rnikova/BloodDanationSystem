﻿namespace BloodDanationSystem.Web.ViewModels.Administration.Patient
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class HospitalViewModel : IMapFrom<HospitalServiceModel>
    {
        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }
    }
}
