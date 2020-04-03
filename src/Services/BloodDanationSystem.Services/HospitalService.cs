namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;

    public class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext context;

        public HospitalService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<HospitalServiceModel> AllHospitals()
        {
            return this.context.Hospitals.To<HospitalServiceModel>();
        }

        public IEnumerable<HospitalServiceModel> HospitalsInCity(int id)
        {
            return this.context.Hospitals.Where(x => x.CityId == id).To<HospitalServiceModel>();
        }
    }
}
