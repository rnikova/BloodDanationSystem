namespace BloodDonationSystem.Web.InputModels.Donors
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using System.ComponentModel.DataAnnotations;

    using static BloodDanationSystem.Common.GlobalConstants;

    public class DonorsCreateInputModel : IMapTo<DonorServiceModel>, IMapFrom<DonorServiceModel>
    {
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [Range(DonorMinAge, DonorMaxAge)]
        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeServiceModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }
    }
}
