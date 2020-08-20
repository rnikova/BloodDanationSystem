namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.Donors;
    using BloodDonationSystem.Web.InputModels.Patients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorService donorService;
        private readonly IPatientService patientService;
        private readonly ICityService cityService;
        private readonly IHospitalService hospitalService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IDonorService donorService,
            IPatientService patientService,
            ICityService cityService,
            IHospitalService hospitalService)
        {
            this.userManager = userManager;
            this.donorService = donorService;
            this.patientService = patientService;
            this.cityService = cityService;
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public IActionResult BecomeDonor()
        {
            var cities = this.cityService.AllCities().Result;
            var inputModel = new DonorsCreateInputModel
            {
                Cities = cities,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> BecomeDonor(DonorsCreateInputModel donorsCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var cities = this.cityService.AllCities().Result;
                var inputModel = new DonorsCreateInputModel
                {
                    Cities = cities,
                };

                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new DonorServiceModel()
            {
                FullName = donorsCreateInputModel.FullName,
                Age = donorsCreateInputModel.Age,
                BloodType = new BloodTypeServiceModel
                {
                    ABOGroupName = donorsCreateInputModel.BloodType.ABOGroupName,
                    RhesusFactor = donorsCreateInputModel.BloodType.RhesusFactor,
                },
                UserId = user.Id,
                CityId = donorsCreateInputModel.CityId,
            };

            await this.donorService.CreateAsync(model);
            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult BecomePatient()
        {
            var cities = this.cityService.AllCities().Result;
            var inputModel = new PatientsCreateInputModel
            {
                Cities = cities,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePatient(PatientsCreateInputModel patientCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var cities = this.cityService.AllCities().Result;
                var inputModel = new PatientsCreateInputModel
                {
                    Cities = cities,
                };

                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new PatientServiceModel()
            {
                FullName = patientCreateInputModel.FullName,
                Age = patientCreateInputModel.Age,
                HospitalId = patientCreateInputModel.HospitalId,
                BloodType = new BloodTypeServiceModel
                {
                    ABOGroupName = patientCreateInputModel.BloodType.ABOGroupName,
                    RhesusFactor = patientCreateInputModel.BloodType.RhesusFactor,
                },
                UserId = user.Id,
                Ward = patientCreateInputModel.Ward,
                NeededBloodBanks = patientCreateInputModel.NeededBloodBanks,
            };

            await this.patientService.CreateAsync(model);

            return this.Redirect("/");
        }

        public async Task<JsonResult> GetHospitals(int cityId)
        {
            var hospitals = await this.hospitalService.HospitalsInCity(cityId);

            return this.Json(new SelectList(hospitals, "Id", "Name"));
        }
    }
}
