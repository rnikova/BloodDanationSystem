namespace BloodDanationSystem.Services.Tests.Common
{
    using System.Reflection;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Services.Models.Hospitals;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Services.Models.Users;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(PatientServiceModel).GetTypeInfo().Assembly,
                typeof(Patient).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(DonorsPatientsServiceModel).GetTypeInfo().Assembly,
                typeof(DonorsPatients).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(DonorServiceModel).GetTypeInfo().Assembly,
                typeof(Donor).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(HospitalServiceModel).GetTypeInfo().Assembly,
                typeof(Hospital).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(ApplicationUser).GetTypeInfo().Assembly,
                typeof(UserServiceModel).GetTypeInfo().Assembly);
        }
    }
}
