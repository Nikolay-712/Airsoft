namespace AirsoftApplication.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Services.Data.Team;
    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IContactService contactService;
        private readonly ITeamService teamService;
        private readonly IAdministrationServive administrationServive;

        public DashboardController(
            IContactService contactService,
            ITeamService teamService,
            IAdministrationServive administrationServive)
        {
            this.contactService = contactService;
            this.teamService = teamService;
            this.administrationServive = administrationServive;
        }

        public IActionResult Index(int page = 1)
        {
            var statistic = this.administrationServive.GetStatistic();

            var teamList = this.teamService.TeamList();
            var itemsPerpage = 5;

            statistic.ItemsPerPage = itemsPerpage;
            statistic.PageNumber = page;
            statistic.ItemsCount = teamList.Count();

            statistic.TeamPlayers = teamList
                .Skip((page - 1) * itemsPerpage)
                    .Take(itemsPerpage);

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            this.ViewData["Actionname"] = actionName;

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
                    .Skip((page - 1) * itemsPerpage)
                    .Take(itemsPerpage),
            };

            if (page > allMessages.PagesCount && allMessages.Messages.Count() > 0)
            {
                return this.NotFound();
            }

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            this.ViewData["Actionname"] = actionName;
            return this.View(allMessages);
        }

        public IActionResult MessageById(string messageId)
        {
            var message = this.contactService.MessageById(messageId);

            if (message == null)
            {
                return this.NotFound();
            }

            return this.View(message);
        }
    }
}
