namespace AirsoftApplication.Data.Models.Events
{
    using System;
    using System.Collections.Generic;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Images;

    public class Battlefield : BaseDeletableModel<string>
    {
        public Battlefield()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}
