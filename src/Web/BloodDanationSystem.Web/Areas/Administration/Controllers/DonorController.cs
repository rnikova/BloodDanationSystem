namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Administration.Donor;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class DonorController : AdministrationController
    {
        private readonly IDonorService donorService;

        public DonorController(IDonorService donorService)
        {
            this.donorService = donorService;
        }

        public async Task<IActionResult> All()
        {
            var allDonors = await this.donorService.All().To<DonorAllViewModel>().ToListAsync();

            return this.View(allDonors);
        }
    }
}