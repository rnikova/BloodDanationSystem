namespace BloodDanationSystem.Web.Controllers
{
    using System.Net;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Donors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = GlobalConstants.PatientRoleName)]
    public class PatientsController : Controller
    {
        private readonly IDonorService donorService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorsPatientsService donorsPatientsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPatientService patientService;

        public PatientsController(
            IDonorService donorService,
            UserManager<ApplicationUser> userManager,
            IDonorsPatientsService donorsPatientsService,
            ICloudinaryService cloudinaryService,
            IPatientService patientService)
        {
            this.donorService = donorService;
            this.userManager = userManager;
            this.donorsPatientsService = donorsPatientsService;
            this.cloudinaryService = cloudinaryService;
            this.patientService = patientService;
        }

        public async Task<IActionResult> FindDonor()
        {
            var donors = await this.donorService.All().To<DonorViewModel>().ToListAsync();

            return this.View(donors);
        }

        public async Task<IActionResult> MyDonors()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var donorPatient = await this.donorsPatientsService.GetDonorsPatientsByPatientsUserIdAsync(user.Id);

            if (donorPatient != null || !string.IsNullOrEmpty(donorPatient.Image))
            {
                this.ViewData["Photo"] = donorPatient.Image;
                var image = await this.patientService.SendEmailWithPhotoAsync(donorPatient);
            }

            if (donorPatient.Patient.NeededBloodBanks == 0)
            {
                await this.donorsPatientsService.DeleteDonorsPatient(donorPatient);
                await this.cloudinaryService.DeleteImageAsync(donorPatient.ImageId);
            }

            return this.View();
        }
    }
}
