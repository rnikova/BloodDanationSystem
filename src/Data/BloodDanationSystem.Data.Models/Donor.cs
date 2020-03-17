﻿namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    using static BloodDanationSystem.Data.Models.Constants;

    public class Donor : BaseDeletableModel<string>
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FullName { get; set; }

        [Range(UserMinAge, UserMaxAge)]
        public int Age { get; set; }

        [Required]
        public string BloodTypeId { get; set; }

        public virtual BloodType BloodType { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
