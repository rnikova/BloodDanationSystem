namespace BloodDanationSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Aspose.Words;
    using Aspose.Words.Saving;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Web.ViewModels.BloodCenters;
    using BloodDonationSystem.Services.Models.Informations;
    using BloodDonationSystem.Web.InputModels.Informations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
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
        public IActionResult BloodCenters()
        {
            var hospitals = this.informationsService.AllBloodCenters().To<BloodCentersViewModel>();

            return this.View(hospitals);
        }

        [HttpGet]
        public IActionResult ArticleQA()
        {
            string filepath = @"Articles/QA.docx";
            Document doc = new Document(filepath);

            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                ExportHeadersFootersMode = ExportHeadersFootersMode.None,
                ExportRelativeFontSize = true,
                CssStyleSheetType = CssStyleSheetType.External,
            };

            string allText = doc.ToString(saveOptions);
            var text = allText.Substring(406);

            this.ViewBag.WordHtml = text;
            return this.View();
        }

        [HttpGet]
        public IActionResult ArticleTests()
        {
            string filepath = @"Articles/Tests.docx";
            Document doc = new Document(filepath);

            HtmlSaveOptions saveOptions = new HtmlSaveOptions
            {
                ExportHeadersFootersMode = ExportHeadersFootersMode.None,
                ExportRelativeFontSize = true,
                CssStyleSheetType = CssStyleSheetType.External,
            };

            string allText = doc.ToString(saveOptions);
            var text = allText.Substring(406);

            this.ViewBag.WordHtml = text;
            return this.View();
        }
    }
}
