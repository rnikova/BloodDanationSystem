namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    public class Patient : BaseDeletableModel<string>
    {
        private const int MinValueNeededBloodBanks = 1;
        private const int MaxValueNeededBloodBanks = 10;

        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [RegularExpression(@"[\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+ [\u0410-\u042F\u0430-\u044F]+")]
        public string FullName { get; set; }

        [Required]
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

        [Required]
        [Range(MinValueNeededBloodBanks, MaxValueNeededBloodBanks)]
        public int NeededBloodBanks { get; set; }
    }
}
