namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.Administration.Information;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    public class InformationController : AdministrationController
    {
        private readonly IInformationsService informationsService;

        public InformationController(IInformationsService informationsService)
        {
            this.informationsService = informationsService;
        }

        public async Task<IActionResult> Emails()
        {
            var emails = await this.informationsService.AllMessages().To<EmailsAllViewModel>().ToListAsync();

            return this.View(emails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var email = await this.informationsService.GetByIdAsync(id);
            var model = new DetailsViewModel
            {
                Id = email.Id,
                Name = email.Name,
                Email = email.Email,
                Subject = email.Subject,
                Message = email.Message,
            };

            return this.View(model);
        }
    }
}
