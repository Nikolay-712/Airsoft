namespace AirsoftApplication.Services.Data.Images
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Images;
    using AirsoftApplication.Web.ViewModels.Images;
    using Google.Apis.Auth.OAuth2;
    using Google.Cloud.Storage.V1;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly GoogleCredential googleCredential;
        private readonly StorageClient storageClient;
        private readonly string bucketName;

        public ImageService(IConfiguration configuration, IDeletableEntityRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
            this.googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("GoogleCredentialFile"));
            this.storageClient = StorageClient.Create(this.googleCredential);
            this.bucketName = configuration.GetValue<string>("GoogleCloudStorageBucket");
        }

        public async Task UploadFileAsync(string guidingId, IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var imageObject = await this.storageClient.UploadObjectAsync(this.bucketName, file.FileName, null, memoryStream);

                    var image = new Image()
                    {
                        Name = file.FileName,
                        ImageUrl = imageObject.MediaLink,
                        GuidingId = guidingId,
                    };

                    await this.imageRepository.AddAsync(image);
                    await this.imageRepository.SaveChangesAsync();

                    memoryStream.Close();
                }
            }
        }

        public async Task DeleteFileAsync(string imageId)
        {
            var image = this.imageRepository
                .AllAsNoTracking()
                .Where(x => x.Id == imageId)
                .FirstOrDefault();

            this.imageRepository.Delete(image);
            await this.imageRepository.SaveChangesAsync();

            await this.storageClient.DeleteObjectAsync(this.bucketName, image.Name);
        }

        public IEnumerable<ImageViewModel> GetAllImages(string guidingId)
        {
            var images = this.imageRepository.All()
                .Where(x => x.GuidingId == guidingId)
                .Select(x => new ImageViewModel
                {
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                }).ToList();

            return images;
        }

        public string GetProfileImageUrl(string userId)
        {
            if (userId == null)
            {
                return null;
            }

            var images = this.GetAllImages(userId);

            if (images.Count() < 1)
            {
                return null;
            }

            return images.OrderByDescending(x => x.CreatedOn).FirstOrDefault().ImageUrl;
        }
    }
}
