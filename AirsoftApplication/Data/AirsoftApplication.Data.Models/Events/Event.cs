namespace AirsoftApplication.Data.Models.Events
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Images;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string ImageId { get; set; }

        public Image EventImage { get; set; }

        public string FieldId { get; set; }

        public Battlefield Field { get; set; }
    }
}
