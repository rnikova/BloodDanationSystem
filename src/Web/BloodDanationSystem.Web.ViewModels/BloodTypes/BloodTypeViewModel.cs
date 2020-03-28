namespace BloodDanationSystem.Web.ViewModels.Administration.BloodTypes
{
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;

    public class BloodTypeViewModel : IMapFrom<BloodTypeServiceModel>, IMapTo<BloodTypeServiceModel>
    {
        public int Id { get; set; }

        public string ABOGroupName { get; set; }

        public string RhesusFactor { get; set; }
    }
}
