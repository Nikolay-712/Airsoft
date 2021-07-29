namespace AirsoftApplication.Data.Models.Comments
{
    using System;
    using System.Collections.Generic;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Data.Models.Votes;

    public class SubComment : BaseDeletableModel<string>
    {
        public SubComment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Vote = new HashSet<Vote>();
        }

        public string CommentId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Vote> Vote { get; set; }
    }
}
