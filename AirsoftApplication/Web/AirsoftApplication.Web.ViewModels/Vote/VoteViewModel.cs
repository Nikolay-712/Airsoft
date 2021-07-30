namespace AirsoftApplication.Web.ViewModels.Vote
{
    using System.Collections.Generic;

    public class VoteViewModel
    {
        public IEnumerable<string> VotedUsers { get; set; }

        public int PositiveVotes { get; set; }

        public int NegativeVotes { get; set; }
    }
}
