namespace AirsoftApplication.Data.Models.Comments
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
