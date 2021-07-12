namespace AirsoftApplication.Web.ViewModels.Events
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Images;

    public class FieldViewModel
    {
        public string FieldId { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
