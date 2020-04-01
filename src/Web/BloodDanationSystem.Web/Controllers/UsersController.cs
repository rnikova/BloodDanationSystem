namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.Donors;
    using BloodDonationSystem.Web.InputModels.Hospitals;
    using BloodDonationSystem.Web.InputModels.Patients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorService donorService;
        private readonly IPatientService patientService;

        public UsersController(UserManager<ApplicationUser> userManager, IDonorService donorService, IPatientService patientService)
        {
            this.userManager = userManager;
            this.donorService = donorService;
            this.patientService = patientService;
        }

        [HttpGet]
        public IActionResult BecomeDonor()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomeDonor(DonorsCreateInputModel donorsCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new DonorServiceModel()
            {
                Id = donorsCreateInputModel.Id,
                FullName = donorsCreateInputModel.FullName,
                Age = donorsCreateInputModel.Age,
                BloodType = donorsCreateInputModel.BloodType,
                UserId = user.Id,
            };

            await this.donorService.CreateAsync(model);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult BecomePatient()
        {
            var hospitals = this.patientService.AllHospitals();
            var inputModel = new PatientsCreateInputModel
            {
                Hospitals = hospitals.To<HospitalInputModel>(),
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePatient(PatientsCreateInputModel patientCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new PatientServiceModel()
            {
                FullName = patientCreateInputModel.FullName,
                Age = patientCreateInputModel.Age,
                BloodType = patientCreateInputModel.BloodType,
                HospitalId = patientCreateInputModel.HospitalId,
                UserId = user.Id,
            };

            await this.patientService.CreateAsync(model);

            return this.Redirect("/");
        }
    }
}
