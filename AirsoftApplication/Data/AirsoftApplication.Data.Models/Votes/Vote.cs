namespace AirsoftApplication.Data.Models.Votes
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Users;

    public class Vote : BaseDeletableModel<string>
    {
        public Vote()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string GuidingId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
