namespace BloodDonationSystem.Web.InputModels.Informations
{

    using System.ComponentModel.DataAnnotations;

    public class AddBloodCenterInputModel
    {
        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Град")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Работно време")]
        public string WorkingHours { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Телефон за събития")]
        public string EventPhone { get; set; }
    }
}
