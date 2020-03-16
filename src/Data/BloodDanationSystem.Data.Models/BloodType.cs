namespace BloodDanationSystem.Data.Models
{
    using System;

    using BloodDanationSystem.Data.Models.Enums;

    public class BloodType
    {
        public BloodType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public ABOGroup ABOGroupName { get; set; }

        public RhesusFactor RhesusFactor { get; set; }
    }
}
