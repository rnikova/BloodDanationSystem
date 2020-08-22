namespace BloodDonationSystem.Web.InputModels.Donors
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Web.InputModels.BloodTypees;
    using BloodDonationSystem.Web.InputModels.Cities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static BloodDanationSystem.Common.GlobalConstants;

    public class DonorsCreateInputModel : IMapTo<DonorServiceModel>, IMapFrom<DonorServiceModel>
    {
        private const string InvalidFullNameMessage = "Моля въведете трите си имена на български език";

        public string Id { get; set; }

        [Required]
        [Display(Name = "Трите имена")]
        [RegularExpression(@"[\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+", ErrorMessage = InvalidFullNameMessage)]
        public string FullName { get; set; }

        [Required]
        [Range(DonorMinAge, DonorMaxAge)]
        [Display(Name = "Години")]
        public int Age { get; set; }

        [Display(Name = "Град, в който може да дарите")]
        public int CityId { get; set; }

        public CityInputModel City { get; set; }

        public IEnumerable<CityServiceModel> Cities { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeInputModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }
    }
}
