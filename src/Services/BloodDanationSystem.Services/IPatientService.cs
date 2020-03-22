namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDonationSystem.Services.Models;

    public interface IPatientService
    {
        Task<bool> Create(PatientServiceModel patientServiceModel);

        IQueryable<PatientServiceModel> All();

        IEnumerable<Hospital> AllHospitals();
    }
}
