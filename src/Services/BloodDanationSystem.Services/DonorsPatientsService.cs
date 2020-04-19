namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using Microsoft.EntityFrameworkCore;

    public class DonorsPatientsService : IDonorsPatientsService
    {
        private readonly ApplicationDbContext context;
        private readonly IPatientService patientService;

        public DonorsPatientsService(ApplicationDbContext context, IPatientService patientService)
        {
            this.context = context;
            this.patientService = patientService;
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

        public async Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorsUserIdAsync(string donorId)
        {
            var donorPatient = await this.context.DonorsPatients.Where(x => x.Donor.UserId == donorId && x.IsDeleted == false).Include(x => x.Patient).SingleOrDefaultAsync();
            var patient = await this.patientService.GetByPatientIdAsync(donorPatient.PatientId);
            var model = new DonorsPatientsServiceModel
            {
                PatientId = donorPatient.PatientId,
                Patient = patient,
                DonorId = donorPatient.DonorId,
                Image = donorPatient.Image,
            };

            return model;
        }

        public async Task<DonorsPatientsServiceModel> GetDonorsPatientsByPatientsUserIdAsync(string patientId)
        {
            var donorPatient = await this.context.DonorsPatients.Where(x => x.Patient.UserId == patientId && x.IsDeleted == false).SingleOrDefaultAsync();
            var model = new DonorsPatientsServiceModel
            {
                PatientId = donorPatient.PatientId,
                DonorId = donorPatient.DonorId,
                Image = donorPatient.Image,
            };

            return model;
        }
    }
}
