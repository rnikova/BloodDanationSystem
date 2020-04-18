namespace BloodDanationSystem.Services.Tests.Common
{
    using System.Reflection;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Patients;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(PatientServiceModel).GetTypeInfo().Assembly,
                typeof(Patient).GetTypeInfo().Assembly);
        }
    }
}
