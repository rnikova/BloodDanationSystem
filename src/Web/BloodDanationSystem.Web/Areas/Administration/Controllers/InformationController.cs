namespace BloodDanationSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Services.Messaging;
    using BloodDanationSystem.Web.ViewModels.Administration.Information;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Cities;
    using BloodDonationSystem.Web.InputModels.Informations;
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
            var emails = await this.informationsService.AllMessagesAsync();

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

        public IActionResult CreateArticle()
        {
            return this.View();
        }

        public IActionResult AddBloodCenter()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBloodCenter(AddBloodCenterInputModel bloodCenter)
        {
            var model = new BloodCentersServiceModel
            {
                Name = bloodCenter.Name,
                City = new CityServiceModel
                {
                   Name = bloodCenter.City,
                },
                Phone = bloodCenter.Phone,
                EventPhone = bloodCenter.EventPhone,
                WorkingHours = bloodCenter.WorkingHours,
                Address = bloodCenter.Address,
                Email = bloodCenter.Email,
            };

            await this.informationsService.AddBloodCenterAsync(model);

            return this.Redirect("/Informations/BloodCenters");
        }

        public async Task<IActionResult> EditBloodCenter(int id)
        {
            var bloodCenter = await this.informationsService.GetBloodCenterByIdAsync(id);
            var model = new EditBloodCenterViewModel
            {
                Id = bloodCenter.Id,
                Address = bloodCenter.Address,
                Phone = bloodCenter.Phone,
                EventPhone = bloodCenter.EventPhone,
                Email = bloodCenter.Email,
                WorkingHours = bloodCenter.WorkingHours,
                Name = bloodCenter.Name,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBLoodCenter(EditBloodCenterViewModel bloodCenter)
        {
            var model = new BloodCentersServiceModel
            {
                Id = bloodCenter.Id,
                Address = bloodCenter.Address,
                Phone = bloodCenter.Phone,
                EventPhone = bloodCenter.EventPhone,
                Email = bloodCenter.Email,
                WorkingHours = bloodCenter.WorkingHours,
                Name = bloodCenter.Name,
            };

            await this.informationsService.EditBloodCenterAsync(model);

            return this.Redirect("/Informations/BloodCenters");
        }

        public async Task<IActionResult> DeleteBloodCenter(int id)
        {
            await this.informationsService.DeleteBloodCenterAsync(id);

            return this.Redirect("/Informations/BloodCenters");
        }
    }
}
