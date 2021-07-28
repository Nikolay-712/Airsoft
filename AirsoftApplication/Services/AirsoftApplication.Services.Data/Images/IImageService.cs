namespace AirsoftApplication.Services.Data.Images
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        Task UploadFileAsync(string guidingId, IEnumerable<IFormFile> files);

        Task DeleteFileAsync(string imageId);

        IEnumerable<ImageViewModel> GetAllImages(string guidingId);

        string GetProfileImageUrl(string userId);
    }
}
