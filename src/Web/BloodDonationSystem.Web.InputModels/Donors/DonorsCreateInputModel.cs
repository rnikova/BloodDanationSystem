namespace BloodDonationSystem.Web.InputModels.Donors
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Web.InputModels.BloodTypees;
    using BloodDonationSystem.Web.InputModels.Cities;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using static BloodDanationSystem.Common.GlobalConstants;

    public class DonorsCreateInputModel : IMapTo<DonorServiceModel>, IMapFrom<DonorServiceModel>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Трите имена")]
        public string FullName { get; set; }

        [Required]
        [Range(DonorMinAge, DonorMaxAge)]
        [Display(Name = "Години")]
        public int Age { get; set; }

        public CityInputModel City { get; set; }

        public IQueryable<CityServiceModel> Cities { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeInputModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }
    }
}
