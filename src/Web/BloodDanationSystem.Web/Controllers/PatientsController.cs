namespace BloodDanationSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using BloodDanationSystem.Common;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Services.Messaging;
    using BloodDanationSystem.Web.ViewModels.Donors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = GlobalConstants.PatientRoleName)]
    public class PatientsController : Controller
    {
        private readonly IDonorService donorService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonorsPatientsService donorsPatientsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPatientService patientService;
        private readonly IEmailSender emailSender;

        public PatientsController(
            IDonorService donorService,
            UserManager<ApplicationUser> userManager,
            IDonorsPatientsService donorsPatientsService,
            ICloudinaryService cloudinaryService,
            IPatientService patientService,
            IEmailSender emailSender)
        {
            this.donorService = donorService;
            this.userManager = userManager;
            this.donorsPatientsService = donorsPatientsService;
            this.cloudinaryService = cloudinaryService;
            this.patientService = patientService;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> FindDonor()
        {
            var donors = await this.donorService.All().To<DonorViewModel>().ToListAsync();

            return this.View(donors);
        }

        public async Task<IActionResult> MyDonors()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var donorPatient = await this.donorsPatientsService.GetDonorsPatientsByPatientsUserIdAsync(user.Id);

            if (donorPatient != null || !string.IsNullOrEmpty(donorPatient.Image))
            {
                this.ViewData["Photo"] = donorPatient.Image;

                var photo = await this.patientService.DownloadPhotoAsync(donorPatient.Image);
                var body = "Изпращаме ви служебна бележка за кръводаряване";

                await this.emailSender.SendEmailAsync(donorPatient.Patient.User.Email, "Служебна бележка кръводаряване", body, photo);
            }

            if (donorPatient.Patient.NeededBloodBanks == 0)
            {
                await this.donorsPatientsService.DeleteDonorsPatientAsync(donorPatient);
                await this.cloudinaryService.DeleteImageAsync(donorPatient.ImageId);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> WantYourHelp(string donorId)
        {
            var donor = await this.donorService.GetByIdAsync(donorId);
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var patien = await this.patientService.GetByUserIdAsync(user.Id);
            var callbackUrl = this.Url.Action(
                action: "DonorAndPatient",
                controller: "Donors");
            var body = $@"Здравей, имам нужда от твоята помощ. <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'> Кликни тук,</a> за да дариш кръв.";

            await this.emailSender.SendEmailAsync(donor.User.Email, "Имам нужда от твоята помощ", body);

            return this.View();
        }
    }
}
