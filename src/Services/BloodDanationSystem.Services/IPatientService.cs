namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDonationSystem.Services.Models;

    public interface IPatientService
    {
        IQueryable<PatientServiceModel> All();
    }
}
