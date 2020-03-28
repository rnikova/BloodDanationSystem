namespace BloodDanationSystem.Web.ViewModels.Administration.Patient
{
    using BloodDanationSystem.Web.ViewModels.Administration.BloodTypes;

    public class BecomePatientViewModel
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeViewModel BloodType { get; set; }

        public int HospitalId { get; set; }
    }
}
