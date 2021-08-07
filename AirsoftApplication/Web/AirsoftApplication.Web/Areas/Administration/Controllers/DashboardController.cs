namespace AirsoftApplication.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IContactService contactService;
        private readonly IAdministrationServive administrationServive;

        public DashboardController(
            IContactService contactService,
            IAdministrationServive administrationServive)
        {
            this.contactService = contactService;
            this.administrationServive = administrationServive;
        }

        public IActionResult Index()
        {
            var statistic = this.administrationServive.GetStatistic();
            return this.View(statistic);
        }

        public IActionResult AllMessages(int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var messages = this.contactService.AllMessages();
            var itemsPerpage = 5;

            var allMessages = new AllMessagesViewModel
            {
                PageNumber = page,
                ItemsPerPage = itemsPerpage,
                ItemsCount = messages.Count(),
                Messages = messages
                .Skip((page - 1) * itemsPerpage).Take(itemsPerpage),
            };

            if (page > allMessages.PagesCount)
            {
                return this.NotFound();
            }

            return this.View(allMessages);
        }

        public IActionResult MessageById(string messageId)
        {
            if (messageId == null)
            {
                return this.Redirect("AllMessages");
            }

            var message = this.contactService.MessageById(messageId);

            return this.View(message);
        }
    }
}
