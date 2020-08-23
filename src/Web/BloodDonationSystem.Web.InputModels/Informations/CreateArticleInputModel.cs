namespace BloodDonationSystem.Web.InputModels.Informations
{
    using Microsoft.AspNetCore.Http;

    public class CreateArticleInputModel
    {
        public string Title { get; set; }


        public IFormFile Content { get; set; }
    }
}
