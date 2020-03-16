namespace BloodDanationSystem.Data.Models
{
    using System;

    public class BloodCenter
    {
        public BloodCenter()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }

        public string Address { get; set; }
    }
}
