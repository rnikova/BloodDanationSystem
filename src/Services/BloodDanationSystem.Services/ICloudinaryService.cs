namespace BloodDanationSystem.Services
{
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<UploadResult> UploadImageAsync(IFormFile image, string fileName);

        Task<bool> DeleteImageAsync(string imageId);
    }
}
