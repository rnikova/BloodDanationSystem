namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Services.Messaging;
    using BloodDanationSystem.Web.ViewModels.Administration.Information;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class InformationController : AdministrationController
    {
        private readonly IInformationsService informationsService;
        private readonly IEmailSender emailSender;

        public InformationController(
            IInformationsService informationsService,
            IEmailSender emailSender)
        {
            this.informationsService = informationsService;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Emails()
        {
            var emails = await this.informationsService.AllMessages();

            return this.View(emails.To<EmailsAllViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
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

        [HttpPost]
        public async Task<IActionResult> Reply(DetailsViewModel detailsViewModel)
        {
            await this.emailSender.SendEmailAsync(detailsViewModel.Email, detailsViewModel.Subject, detailsViewModel.Answer);

            return this.RedirectToAction("Emails");
        }
    }
}
