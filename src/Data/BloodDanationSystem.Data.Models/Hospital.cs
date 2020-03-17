namespace BloodDanationSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    public class Hospital : BaseDeletableModel<int>
    {
        public Hospital()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ward { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
