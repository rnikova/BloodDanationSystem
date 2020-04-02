namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    public class Patient : BaseDeletableModel<string>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FullName { get; set; }

        public int Age { get; set; }

        [Required]
        public int BloodTypeId { get; set; }

        public virtual BloodType BloodType { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Ward { get; set; }
    }
}
