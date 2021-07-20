namespace AirsoftApplication.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Web.ViewModels.Images;

    public class EventViewModel
    {
        public string Id { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public ImageViewModel CoverImage => this.Images.OrderBy(x => x.CreatedOn).FirstOrDefault();

        public string Date { get; set; }

        public string Time { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public FieldViewModel Battlefield { get; set; }
    }
}
