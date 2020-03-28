namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDonationSystem.Services.Models.Patients;

    public interface IPatientService
    {
        Task<bool> CreateAsync(PatientServiceModel patientServiceModel);

        IQueryable<PatientServiceModel> All();

        IEnumerable<Hospital> AllHospitals();
    }
}
