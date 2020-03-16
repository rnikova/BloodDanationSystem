namespace BloodDanationSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<BloodCenter> BloodCentres { get; set; }

        public ICollection<Hospital> Hospitals { get; set; }
    }
}
