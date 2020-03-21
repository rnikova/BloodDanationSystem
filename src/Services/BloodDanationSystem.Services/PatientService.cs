namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext context;

        public PatientService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PatientServiceModel> All()
        {
            return this.context.Patients.To<PatientServiceModel>();
        }
    }
}
