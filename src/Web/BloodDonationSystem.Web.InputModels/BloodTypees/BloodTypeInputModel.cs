namespace BloodDonationSystem.Web.InputModels.BloodTypees
{
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class BloodTypeInputModel : IMapFrom<BloodTypeServiceModel>, IMapTo<BloodTypeServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Кръвна група")]
        public string ABOGroupName { get; set; }

        [Display(Name = "Резус фактор")]
        public string RhesusFactor { get; set; }
    }
}
