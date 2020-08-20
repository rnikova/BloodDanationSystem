namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;
    using Microsoft.EntityFrameworkCore;

    public class HospitalService : IHospitalService
    {
        private readonly EfDeletableEntityRepository<Hospital> hospitalsRepository;
        private readonly ApplicationDbContext context;

        public HospitalService(EfDeletableEntityRepository<Hospital> hospitalsRepository, ApplicationDbContext context)
        {
            this.hospitalsRepository = hospitalsRepository;
            this.context = context;
        }

        public async Task<IEnumerable<HospitalServiceModel>> AllHospitals()
        {
            return await this.hospitalsRepository
                .AllAsNoTracking()
                .To<HospitalServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<HospitalServiceModel>> HospitalsInCity(int cityId)
        {
            return await this.hospitalsRepository
               .AllAsNoTracking()
               .Where(x => x.CityId == cityId)
               .To<HospitalServiceModel>()
               .ToListAsync();
        }
    }
}
