namespace AirsoftApplication.Services.Data.Contacts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using AirsoftApplication.Web.ViewModels.Contacts;

    public interface IContactService
    {
        Task SendMessageAsync(InputMessageViewModel input);

        IEnumerable<MessageViewModel> AllMessages();

        MessageViewModel MessageById(string messageId);

        Task ReturnAnswerAsync(MessageViewModel model);
    }
}
