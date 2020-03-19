using System.ComponentModel.DataAnnotations;

namespace BloodDonationSystem.Services.Models
{
    public class BloodTypeServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string ABOGroupName { get; set; }

        [Required]
        public string RhesusFactor { get; set; }
    }
}
