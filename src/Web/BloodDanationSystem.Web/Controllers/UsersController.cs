namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Web.InputModels.Donors;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IDonorService donorService;

        public UsersController(IDonorService donorService)
        {
            this.donorService = donorService;
        }

        [HttpGet]
        public IActionResult BecomeDonor()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> BecomeDonor(DonorsCreateInputModel donorsCreateInputModel)
        {
            var model = donorsCreateInputModel.To<DonorServiceModel>();

            await this.donorService.Create(model);

            return this.View();
        }

        public IActionResult BecomePatient()
        {
            return this.View();
        }
    }
}
