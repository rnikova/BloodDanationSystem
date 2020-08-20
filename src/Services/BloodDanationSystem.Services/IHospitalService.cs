namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using BloodDonationSystem.Services.Models.Hospitals;

    public interface IHospitalService
    {
        IQueryable<HospitalServiceModel> AllHospitals();

        IEnumerable<HospitalServiceModel> HospitalsInCity(int id);
    }
}
