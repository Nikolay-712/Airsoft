namespace AirsoftApplication.Web.ViewModels.Administration.Contacts
{
    using System.Collections.Generic;

    public class AllMessagesViewModel : PagingViewModel
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
