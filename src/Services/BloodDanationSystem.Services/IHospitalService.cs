namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.Hospitals;

    public interface IHospitalService
    {
        Task<IEnumerable<HospitalServiceModel>> AllHospitals();

        Task<IEnumerable<HospitalServiceModel>> HospitalsInCity(int id);
    }
}
