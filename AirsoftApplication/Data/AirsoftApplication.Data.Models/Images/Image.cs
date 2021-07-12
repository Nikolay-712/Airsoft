namespace AirsoftApplication.Data.Models.Images
{
    using System;

    using AirsoftApplication.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string GuidingId { get; set; }
    }
}
