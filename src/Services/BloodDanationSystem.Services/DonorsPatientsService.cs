namespace BloodDanationSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Services.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DonorsPatientsService : IDonorsPatientsService
    {
        private readonly ApplicationDbContext context;
        private readonly IPatientService patientService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly EfDeletableEntityRepository<DonorsPatients> donorsPatientsRepository;

        public DonorsPatientsService(
            ApplicationDbContext context,
            IPatientService patientService,
            UserManager<ApplicationUser> userManager,
            EfDeletableEntityRepository<DonorsPatients> donorsPatientsRepository)
        {
            this.context = context;
            this.patientService = patientService;
            this.userManager = userManager;
            this.donorsPatientsRepository = donorsPatientsRepository;
        }

        public async Task<bool> AddImageAsync(DonorsPatientsServiceModel donorsPatientsServiceModel, string imageUrl)
        {
            var donorPatient = await this.donorsPatientsRepository
                .GetByIdWithDeletedAsync(donorsPatientsServiceModel.DonorId, donorsPatientsServiceModel.PatientId);

            // var donorPatient = await this.context.DonorsPatients.Where(x => x.DonorId == donorsPatientsServiceModel.DonorId && x.PatientId == donorsPatientsServiceModel.PatientId && x.IsDeleted == false).SingleOrDefaultAsync();
            donorPatient.Image = imageUrl;

            var result = await this.donorsPatientsRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateAsync(DonorsPatientsServiceModel donorsPatientsServiceModel)
        {
            var donorPatient = new DonorsPatients
            {
                PatientId = donorsPatientsServiceModel.PatientId,
                DonorId = donorsPatientsServiceModel.DonorId,
            };

            var isContains = await this.donorsPatientsRepository.GetByIdWithDeletedAsync(donorPatient.DonorId, donorPatient.PatientId);
            if (isContains == null)
            {
                await this.donorsPatientsRepository.AddAsync(donorPatient);
            }

            // if (!await this.context.DonorsPatients.ContainsAsync(donorPatient))
            // {
            //    await this.context.DonorsPatients.AddAsync(donorPatient);
            // }
            donorPatient.IsDeleted = false;
            var result = await this.donorsPatientsRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteDonorsPatientAsync(DonorsPatientsServiceModel donorsPatientsServiceModel)
        {
            var donorsPatients = await this.donorsPatientsRepository.GetByIdWithDeletedAsync(donorsPatientsServiceModel.DonorId, donorsPatientsServiceModel.PatientId);

            // var donorsPatients = await this.context.DonorsPatients.Include(x => x.Donor.User).SingleOrDefaultAsync(x => x.PatientId == donorsPatientsServiceModel.PatientId && x.DonorId == donorsPatientsServiceModel.DonorId);
            this.donorsPatientsRepository.Delete(donorsPatients);
            donorsPatients.ImageId = string.Empty;
            donorsPatients.Image = string.Empty;
            var patient = donorsPatients.Patient;
            var donor = donorsPatients.Donor;

            await this.userManager.RemoveFromRoleAsync(donor.User, GlobalConstants.DonorRoleName);
            await this.userManager.RemoveFromRoleAsync(patient.User, GlobalConstants.PatientRoleName);

            var result = await this.donorsPatientsRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<DonorsPatientsServiceModel> GetDonorsPatientsByDonorsUserIdAsync(string donorId)
        {
           // var donorPatient = await this.donorsPatientsRepository.GetByIdWithDeletedAsync(donorId);
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
            var donorPatient = await this.context.DonorsPatients.Include(x => x.Patient.User).Where(x => x.Patient.UserId == patientId && x.IsDeleted == false).SingleOrDefaultAsync();

            if (donorPatient == null)
            {
                return null;
            }

            var model = new DonorsPatientsServiceModel
            {
                PatientId = donorPatient.PatientId,
                Patient = new PatientServiceModel
                {
                    User = new UserServiceModel
                    {
                        Email = donorPatient.Patient.User.Email,
                    },
                    NeededBloodBanks = donorPatient.Patient.NeededBloodBanks,
                },
                DonorId = donorPatient.DonorId,
                Image = donorPatient.Image,
                ImageId = donorPatient.ImageId,
            };

            return model;
        }
    }
}
