namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Aspose.Words;
    using BloodDanationSystem.Services;
    using BloodDonationSystem.Services.Models.Informations;
    using BloodDonationSystem.Web.InputModels.Informations;
    using Microsoft.AspNetCore.Mvc;

    public class InformationsController : BaseController
    {
        private readonly IInformationsService informationsService;

        public InformationsController(IInformationsService informationsService)
        {
            this.informationsService = informationsService;
        }

        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormInputModel contactFormInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var model = new ContactFormServiceModel
            {
                Name = contactFormInputModel.Name,
                Subject = contactFormInputModel.Subject,
                Email = contactFormInputModel.Email,
                Message = contactFormInputModel.Message,
            };

            await this.informationsService.CreateContactFormAsync(model);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult Article()
        {
            string filepath = @"Articles/QA.docx";
            Document doc = new Document(filepath);
            string allText = doc.ToString(SaveFormat.Html);

            var text = allText.Substring(51062);

            this.ViewBag.WordHtml = text;
            return this.View();
        }
    }
}
