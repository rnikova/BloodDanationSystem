namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    using static BloodDanationSystem.Common.GlobalConstants;

    public class Donor : BaseDeletableModel<string>
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FullName { get; set; }

        [Range(DonorMinAge, DonorMaxAge)]
        public int Age { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public int BloodTypeId { get; set; }

        public virtual BloodType BloodType { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
