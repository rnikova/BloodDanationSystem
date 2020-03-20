namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Administration.Donor;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PatientController : Controller
    {
        private readonly IPatentService patientService;

        public PatientController(IPatentService patientService)
        {
            this.patientService = patientService;
        }

        public async Task<IActionResult> All()
        {
            var allDonors = await this.patientService.All().To<PatientAllViewModel>().ToListAsync();

            return this.View(allDonors);
        }
    }
}