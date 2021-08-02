namespace AirsoftApplication.Web.ViewModels.Events
{
    using AirsoftApplication.Web.ViewModels.Vote;

    public class MostRatedEventViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Location { get; set; }

        public VoteViewModel Vote { get; set; }
    }
}
