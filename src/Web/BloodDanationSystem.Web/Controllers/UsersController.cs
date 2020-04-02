namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels;
    using BloodDanationSystem.Web.ViewModels.Donors;
    using BloodDanationSystem.Web.ViewModels.Patients;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.Donors;
    using BloodDonationSystem.Web.InputModels.Hospitals;
    using BloodDonationSystem.Web.InputModels.Patients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

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
            var cities = this.donorService.AllCities();
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
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new DonorServiceModel()
            {
                Id = donorsCreateInputModel.Id,
                FullName = donorsCreateInputModel.FullName,
                Age = donorsCreateInputModel.Age,
                BloodType = new BloodTypeServiceModel
                {
                    ABOGroupName = donorsCreateInputModel.BloodType.ABOGroupName,
                    RhesusFactor = donorsCreateInputModel.BloodType.RhesusFactor,
                },
                UserId = user.Id,
                City = new CityServiceModel
                {
                    Name = donorsCreateInputModel.City.Name,
                },
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
                Hospitals = hospitals,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePatient(PatientsCreateInputModel patientCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var hospitals = this.patientService.AllHospitals();
                var inputModel = new PatientsCreateInputModel
                {
                    Hospitals = hospitals,
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
            };

            await this.patientService.CreateAsync(model);

            return this.Redirect("/");
        }

        public async Task<IActionResult> FindPatient()
        {
            var patients = await this.patientService.All().To<PatientViewModel>().ToListAsync();

            return this.View(patients);
        }

        public async Task<IActionResult> FindDonor()
        {
            var donors = await this.donorService.All().To<DonorViewModel>().ToListAsync();

            return this.View(donors);
        }
    }
}
