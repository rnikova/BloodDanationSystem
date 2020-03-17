namespace BloodDanationSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    public class BloodCenter : BaseDeletableModel<int>
    {
        public BloodCenter()
        {
        }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WorkingHours { get; set; }

        [Required]
        public string EventPhone { get; set; }
    }
}
