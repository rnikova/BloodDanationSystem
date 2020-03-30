namespace BloodDonationSystem.Web.InputModels.Informations
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Informations;
    using System.ComponentModel.DataAnnotations;

    public class ContactFormInputModel : IMapTo<ContactFormServiceModel>, IMapFrom<ContactFormServiceModel>
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
