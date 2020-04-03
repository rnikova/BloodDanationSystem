namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;

    public class DonorsPatientsService : IDonorsPatientsService
    {
        private readonly ApplicationDbContext context;

        public DonorsPatientsService(ApplicationDbContext context)
        {
            this.context = context;
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
    }
}
