namespace BloodDonationSystem.Web.InputModels.Donors
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class DonorsCreateInputModel : IMapTo<DonorServiceModel>, IMapFrom<DonorServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodTypeCreateInputModel BloodType { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }
    }
}
