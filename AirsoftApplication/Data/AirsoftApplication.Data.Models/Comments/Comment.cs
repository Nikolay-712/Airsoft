namespace AirsoftApplication.Data.Models.Comments
{
    using System;
    using System.Collections.Generic;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Data.Models.Votes;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SubComments = new HashSet<SubComment>();
            this.Vote = new HashSet<Vote>();
        }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<SubComment> SubComments { get; set; }

        public ICollection<Vote> Vote { get; set; }
    }
}
