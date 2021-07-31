namespace AirsoftApplication.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Services.Data.Statistics;
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

        public IActionResult AllMessages()
        {
            var messages = this.contactService.AllMessages();
            return this.View(messages);
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
