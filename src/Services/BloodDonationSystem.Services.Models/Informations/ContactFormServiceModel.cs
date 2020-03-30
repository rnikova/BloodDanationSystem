namespace BloodDonationSystem.Services.Models.Informations
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;

    public class ContactFormServiceModel : IMapFrom<ContactForm>, IMapTo<ContactForm>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
