namespace AirsoftApplication.Data.Models.Comments
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Users;

    public class SubComment : BaseDeletableModel<string>
    {
        public SubComment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string CommentId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
