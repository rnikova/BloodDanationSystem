namespace BloodDanationSystem.Data.Models
{
    using System;

    public class Hospital
    {
        public Hospital()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Ward { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }
    }
}
