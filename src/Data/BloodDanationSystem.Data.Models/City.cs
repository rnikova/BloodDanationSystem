namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
            this.Hospitals = new HashSet<Hospital>();
            this.BloodCentres = new HashSet<BloodCenter>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<BloodCenter> BloodCentres { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}
