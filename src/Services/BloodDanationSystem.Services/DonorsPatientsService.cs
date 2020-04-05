namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Services.Models.Patients;
    using Microsoft.EntityFrameworkCore;

    public class DonorsPatientsService : IDonorsPatientsService
    {
        private readonly ApplicationDbContext context;

        public DonorsPatientsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddImageAsync(DonorsPatientsServiceModel donorsPatientsServiceModel, string imageUrl)
        {
            var donorPatient = await this.context.DonorsPatients.Where(x => x.DonorId == donorsPatientsServiceModel.DonorId && x.PatientId == donorsPatientsServiceModel.PatientId && x.IsDeleted == false).SingleOrDefaultAsync();

            donorPatient.Image = imageUrl;

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel)
        {
            var donorPatient = new DonorsPatients
            {
                PatientId = donorsPatientsServiceModel.PatientId,
                DonorId = donorsPatientsServiceModel.DonorId,
            };

            await this.context.DonorsPatients.AddAsync(donorPatient);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorIdAsync(string donorId)
        {
            var donorPatient = await this.context.DonorsPatients.Where(x => x.Donor.UserId == donorId && x.IsDeleted == false).SingleOrDefaultAsync();
            var model = new DonorsPatientsServiceModel
            {
                PatientId = donorPatient.PatientId,
                Patient = donorPatient.Patient.To<PatientServiceModel>(),
                DonorId = donorPatient.DonorId,
                Donor = donorPatient.Donor.To<DonorServiceModel>(),
            };

            return model;
        }
    }
}
