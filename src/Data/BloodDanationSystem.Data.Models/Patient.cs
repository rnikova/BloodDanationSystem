namespace BloodDanationSystem.Data.Models
{
    using System;

    public class Patient
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string BloodTypeId { get; set; }

        public BloodType BloodType { get; set; }

        public string HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
