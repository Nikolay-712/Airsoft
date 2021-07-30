namespace AirsoftApplication.Services.Data.Votes
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Votes;
    using AirsoftApplication.Web.ViewModels.Vote;

    public class VoteService : IVoteService
    {
        private readonly IDeletableEntityRepository<Vote> voteRepository;

        public VoteService(IDeletableEntityRepository<Vote> voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public async Task VoteAsync(string guidingId, string userId, bool isUpVote)
        {
            var vote = new Vote
            {
                GuidingId = guidingId,
                UserId = userId,
                Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
            };

            await this.voteRepository.AddAsync(vote);
            await this.voteRepository.SaveChangesAsync();
        }

        public VoteViewModel GetVotes(string guidingId)
        {
            var vote = new VoteViewModel
            {
                VotedUsers = this.voteRepository.All()
                .Where(x => x.GuidingId == guidingId)
                .Select(x => x.UserId)
                .ToList(),

                PositiveVotes = this.voteRepository.All()
                .Where(x => x.GuidingId == guidingId && x.Type == VoteType.UpVote)
                .Count(),

                NegativeVotes = this.voteRepository.All()
                .Where(x => x.GuidingId == guidingId && x.Type == VoteType.DownVote)
                .Count(),
            };

            return vote;
        }
    }
}
