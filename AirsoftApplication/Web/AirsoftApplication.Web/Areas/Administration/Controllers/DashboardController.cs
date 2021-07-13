namespace AirsoftApplication.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IContactService contactService;

        public DashboardController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AllMessages()
        {
            var messages = this.contactService.AllMessages();
            return this.View(messages);
        }

        public IActionResult MessageById(string messageId)
        {
            var message = this.contactService.MessageById(messageId);

            return this.View(message);
        }
    }
}
