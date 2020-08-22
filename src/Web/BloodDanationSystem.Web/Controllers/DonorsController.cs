namespace BloodDanationSystem.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Web.InputModels.DonorsPatients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = GlobalConstants.DonorRoleName)]
    public class DonorsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorsPatientsService donorsPatientsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPatientService patientService;
        private readonly IDonorService donorService;

        public DonorsController(
            UserManager<ApplicationUser> userManager,
            IDonorsPatientsService donorsPatientsService,
            ICloudinaryService cloudinaryService,
            IPatientService patientService,
            IDonorService donorService)
        {
            this.userManager = userManager;
            this.donorsPatientsService = donorsPatientsService;
            this.cloudinaryService = cloudinaryService;
            this.patientService = patientService;
            this.donorService = donorService;
        }

        [HttpGet]
        public IActionResult MyPatients()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> MyPatients(ImageInputModel photo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var photoName = Guid.NewGuid().ToString();
            var photoUrl = await this.cloudinaryService.UploadImageAsync(photo.Image, photoName);

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var donorPatient = await this.donorsPatientsService.GetDonorsPatientsByDonorsUserIdAsync(user.Id);
            donorPatient.Patient.NeededBloodBanks--;
            donorPatient.ImageId = photoUrl.PublicId;

            await this.donorsPatientsService.AddImageAsync(donorPatient, photoUrl?.SecureUri.AbsoluteUri);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> FindPatient()
        {
            var patients = await this.patientService.AllActive();

            return this.View(patients);
        }

        [HttpPost]
        public async Task<IActionResult> DonorAddPatient(string patientId)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var donor = await this.donorService.GetByUserIdAsync(user.Id);

            var donorPatient = new DonorsPatientsServiceModel
            {
                PatientId = patientId,
                DonorId = donor.Id,
            };

            await this.donorsPatientsService.CreateAsync(donorPatient);

            return this.Redirect("/");
        }
    }
}
