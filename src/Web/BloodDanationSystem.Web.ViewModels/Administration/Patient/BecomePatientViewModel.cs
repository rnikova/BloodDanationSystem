namespace BloodDanationSystem.Web.ViewModels.Administration.Patient
{
    using BloodDanationSystem.Web.ViewModels.Administration.BloodTypes;
    using Microsoft.AspNetCore.Mvc;

    public class BecomePatientViewModel
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public int BloodTypeId { get; set; }

        public BloodTypeViewModel BloodType { get; set; }

        [BindProperty]
        public HospitalViewModel HospitalId { get; set; }
        public void OnPost()
        {

        }
    }
}
