namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Constants;

    public class Donor
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FullName { get; set; }

        [Range(UserMinAge, UserMaxAge)]
        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodType BloodType { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
