using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Web.InputModels.DonorsPatients
{
    public class ImageInputModel
    {
        [BindProperty]
        public IFormFile Image { get; set; }
    }
}
