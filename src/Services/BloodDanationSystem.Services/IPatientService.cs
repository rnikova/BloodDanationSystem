namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDonationSystem.Services.Models.Patients;

    public interface IPatientService
    {
        Task<bool> CreateAsync(PatientServiceModel patientServiceModel);

        Task<IEnumerable<PatientServiceModel>> All();

        Task<IEnumerable<PatientServiceModel>> AllActive();

        Task<PatientServiceModel> GetByUserIdAsync(string userId);

        Task<PatientServiceModel> GetByPatientIdAsync(string patientId);

        Task<byte[]> DownloadPhotoAsync(string image);
    }
}
