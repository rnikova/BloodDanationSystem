namespace BloodDanationSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BloodDanationSystem.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Hospitals = new HashSet<Hospital>();
            this.BloodCentres = new HashSet<BloodCenter>();
            this.Donors = new HashSet<Donor>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<BloodCenter> BloodCentres { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
    }
}
