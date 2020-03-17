namespace BloodDanationSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Models.Enums;

    public class BloodType
    {
        public BloodType()
        {
        }

        public int Id { get; set; }

        [Required]
        public ABOGroup ABOGroupName { get; set; }

        [Required]
        public RhesusFactor RhesusFactor { get; set; }
    }
}
