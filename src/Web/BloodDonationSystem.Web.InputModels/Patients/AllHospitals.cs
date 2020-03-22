namespace BloodDonationSystem.Web.InputModels.Patients
{
    using BloodDanationSystem.Data.Models;
    using System.Collections.Generic;

    public class AllHospitals
    {
        IEnumerable<Hospital> Hospitals { get; set; }
    }
}
