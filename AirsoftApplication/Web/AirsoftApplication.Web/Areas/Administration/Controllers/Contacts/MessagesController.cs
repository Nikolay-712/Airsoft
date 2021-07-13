namespace AirsoftApplication.Web.Areas.Administration.Controllers.Contacts
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : AdministrationController
    {
        private readonly IContactService contactService;

        public MessagesController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public async Task<IActionResult> ReturnAnswer(MessageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.contactService.ReturnAnswerAsync(model);
            return this.View(); ////Redirect.........
        }
    }
}
