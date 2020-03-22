namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Web.InputModels.Donors;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorService donorService;

        public UsersController(UserManager<ApplicationUser> userManager, IDonorService donorService)
        {
            this.userManager = userManager;
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
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            var model = new DonorServiceModel()
            {
                FullName = donorsCreateInputModel.FullName,
                Age = donorsCreateInputModel.Age,
                BloodType = donorsCreateInputModel.BloodType,
                UserId = user.Id,
            };

            await this.donorService.Create(model);

            return this.View("/");
        }

        public IActionResult BecomePatient()
        {
            return this.View();
        }
    }
}
