using BloodDonationSystem.Services.Models;
using System.Linq;

namespace BloodDanationSystem.Services
{
    public interface IPatentService
    {
        IQueryable<PatientServiceModel> All();
    }
}
