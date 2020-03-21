namespace BloodDonationSystem.Services.Models
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class BloodTypeServiceModel : IMapFrom<BloodType>, IMapTo<BloodType>
    {
        public int Id { get; set; }

        public string ABOGroupName { get; set; }

        public string RhesusFactor { get; set; }
    }
}
