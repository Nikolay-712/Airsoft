namespace AirsoftApplication.Web.ViewModels.Comments
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public class CommentViewModel
    {
        public string Id { get; set; }

        public string Date { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string PlayerName { get; set; }

        public string ProfileImageUrl => this.GetProfileImage();

        public IEnumerable<ImageViewModel> Images { get; set; }

        private string GetProfileImage()
        {
            if (this.UserId != null)
            {
                var imageUrl = this.Images.OrderByDescending(x => x.CreatedOn).FirstOrDefault().ImageUrl;
                return imageUrl;
            }

            return null;
        }
    }
}
