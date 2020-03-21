using BloodDanationSystem.Services.Mapping;
using BloodDonationSystem.Services.Models;

namespace BloodDonationSystem.Web.InputModels.Donors
{
    public class DonorsCreateInputModel : IMapTo<DonorServiceModel>, IMapFrom<DonorServiceModel>
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public string RhesusFactor { get; set; }

        public string UserId { get; set; }
    }
}
