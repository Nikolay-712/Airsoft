namespace AirsoftApplication.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Services.Data.Roles;
    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IContactService contactService;
        private readonly IRoleService roleService;
        private readonly IAdministrationServive administrationServive;

        public DashboardController(
            IContactService contactService,
            IRoleService roleService,
            IAdministrationServive administrationServive)
        {
            this.contactService = contactService;
            this.roleService = roleService;
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
            var message = this.contactService.MessageById(messageId);

            return this.View(message);
        }

        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(InputRoleViewModel input)
        {
            await this.roleService.CreateRoleAsync(input.Name);

            return this.RedirectToAction("Index");
        }
    }
}
