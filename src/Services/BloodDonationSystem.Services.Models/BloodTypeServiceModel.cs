using BloodDanationSystem.Data.Models;
using BloodDanationSystem.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationSystem.Services.Models
{
    public class BloodTypeServiceModel : IMapFrom<BloodType>, IMapTo<BloodType>
    {
        public int Id { get; set; }

        public string ABOGroupName { get; set; }

        public string RhesusFactor { get; set; }
    }
}
