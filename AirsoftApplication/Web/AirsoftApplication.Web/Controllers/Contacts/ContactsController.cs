namespace AirsoftApplication.Web.Controllers.Contacts
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Contacts;
    using AirsoftApplication.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputMessageViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.contactService.SendMessageAsync(input);

            return this.View();
        }
    }
}
