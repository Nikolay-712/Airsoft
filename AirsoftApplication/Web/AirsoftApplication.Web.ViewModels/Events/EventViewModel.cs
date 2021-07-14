namespace AirsoftApplication.Web.ViewModels.Events
{
    using AirsoftApplication.Web.ViewModels.Images;

    public class EventViewModel
    {
        public string Id { get; set; }

        public ImageViewModel Image { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public FieldViewModel Battlefield { get; set; }
    }
}
