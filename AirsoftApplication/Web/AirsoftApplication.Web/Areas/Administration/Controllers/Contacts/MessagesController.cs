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

        [HttpPost]
        public async Task<IActionResult> ReturnAnswer(MessageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("MessageById", "Dashboard", new { messageId = model.Id });
            }

            await this.contactService.ReturnAnswerAsync(model);
            return this.RedirectToAction("AllMessages", "Dashboard");
        }
    }
}
