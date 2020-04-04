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
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Web.InputModels.Donors;
    using BloodDonationSystem.Web.InputModels.Hospitals;
    using BloodDonationSystem.Web.InputModels.Patients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorService donorService;
        private readonly IPatientService patientService;
        private readonly ICityService cityService;
        private readonly IHospitalService hospitalService;
        private readonly IDonorsPatientsService donorsPatientsService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IDonorService donorService,
            IPatientService patientService,
            ICityService cityService,
            IHospitalService hospitalService,
            IDonorsPatientsService donorsPatientsService)
        {
            this.userManager = userManager;
            this.donorService = donorService;
            this.patientService = patientService;
            this.cityService = cityService;
            this.hospitalService = hospitalService;
            this.donorsPatientsService = donorsPatientsService;
        }

        [HttpGet]
        public IActionResult BecomeDonor()
        {
            var cities = this.cityService.AllCities();
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
                var cities = this.cityService.AllCities();
                var inputModel = new DonorsCreateInputModel
                {
                    Cities = cities,
                };

                return this.View(inputModel);
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
                CityId = donorsCreateInputModel.CityId,
            };

            await this.donorService.CreateAsync(model);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult BecomePatient()
        {
            var hospitals = this.hospitalService.AllHospitals();
            var cities = this.cityService.AllCities();
            var inputModel = new PatientsCreateInputModel
            {
                Hospitals = hospitals,
                Cities = cities,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> BecomePatient(PatientsCreateInputModel patientCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var hospitals = this.cityService.AllCities();
                var inputModel = new PatientsCreateInputModel
                {
                    Cities = hospitals,
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

        [HttpGet]
        public IActionResult MyPatients()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult MyPatients(byte[] photo)
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> FindPatient()
        {
            var patients = await this.patientService.All().To<PatientViewModel>().ToListAsync();

            return this.View(patients);
        }

        [HttpPost]
        public async Task<IActionResult> DonorAddPatient(string patientId)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var donor = await this.donorService.GetByUserId(user.Id);

            var donorPatient = new DonorsPatientsServiceModel
            {
                PatientId = patientId,
                DonorId = donor.Id,
            };

            await this.donorsPatientsService.CreateAsync(donorPatient);

            return this.RedirectToAction("MyPatients");
        }

        public async Task<IActionResult> FindDonor()
        {
            var donors = await this.donorService.All().To<DonorViewModel>().ToListAsync();

            return this.View(donors);
        }
    }
}
