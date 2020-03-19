namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using Microsoft.AspNetCore.Mvc;

    public class DonorController : AdministrationController
    {
        private readonly DonorService donorService;

        public DonorController(DonorService donorService)
        {
            this.donorService = donorService;
        }

        public async Task<IActionResult> All()
        {
            var allDonors = this.donorService.All();

            return this.View(allDonors);
        }
    }
}