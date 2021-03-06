﻿namespace BloodDanationSystem.Services
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<UploadResult> UploadImageAsync(IFormFile image, string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "DonorsImages",
                    File = new FileDescription(fileName, ms),
                };

                uploadResult = this.cloudinary.Upload(uploadParams);
            }

            return uploadResult;
        }

        public async Task DeleteImageAsync(string imageId)
        {
            var deletionParams = new DeletionParams(imageId);
            var deletionResult = await this.cloudinary.DestroyAsync(deletionParams);
        }
    }
}
