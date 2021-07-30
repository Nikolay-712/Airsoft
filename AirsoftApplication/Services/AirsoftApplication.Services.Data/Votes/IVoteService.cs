namespace AirsoftApplication.Services.Data.Votes
{
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Vote;

    public interface IVoteService
    {
        Task VoteAsync(string guidingId, string userId, bool isUpVote);

        VoteViewModel GetVotes(string guidingId);
    }
}
