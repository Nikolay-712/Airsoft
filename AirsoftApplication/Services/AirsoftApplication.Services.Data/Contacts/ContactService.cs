namespace AirsoftApplication.Services.Data.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Contacts;
    using AirsoftApplication.Services.Messaging;
    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using AirsoftApplication.Web.ViewModels.Contacts;
    using Microsoft.Extensions.Caching.Memory;

    public class ContactService : IContactService
    {
        private readonly IDeletableEntityRepository<Message> messageRepository;
        private readonly IEmailSender emailSender;
        private readonly IMemoryCache memoryCache;

        public ContactService(
            IDeletableEntityRepository<Message> messageRepository,
            IEmailSender emailSender,
            IMemoryCache memoryCache)
        {
            this.messageRepository = messageRepository;
            this.emailSender = emailSender;
            this.memoryCache = memoryCache;
        }

        public async Task SendMessageAsync(InputMessageViewModel input)
        {
            var message = new Message
            {
                Username = input.Username,
                Email = input.Email,
                Subject = input.Subject,
                Content = input.Content,
                HasBeenRead = false,
            };

            await this.messageRepository.AddAsync(message);
            await this.messageRepository.SaveChangesAsync();
        }

        public IEnumerable<MessageViewModel> AllMessages()
        {
            var messges = this.memoryCache.Get<IEnumerable<MessageViewModel>>(GlobalConstants.MessageCachKey);

            messges = this.messageRepository.All()
               .Select(x => new MessageViewModel
               {
                   Id = x.Id,
                   Username = x.Username,
                   Email = x.Email,
                   Subject = x.Subject,
                   Content = x.Content,
                   CreatedOn = x.CreatedOn.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                   HasBeenRead = x.HasBeenRead,
               })
               .OrderBy(x => x.HasBeenRead)
               .ToList();

            var cacheOptions = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

            this.memoryCache.Set(GlobalConstants.MessageCachKey, messges, cacheOptions);

            return messges;
        }

        public MessageViewModel MessageById(string messageId)
        {
            var message = this.messageRepository.All()
                .Select(x => new MessageViewModel
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Subject = x.Subject,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                    HasBeenRead = x.HasBeenRead,
                })
                .FirstOrDefault(x => x.Id == messageId);

            return message;
        }

        public async Task ReturnAnswerAsync(MessageViewModel model)
        {
            var fromEmail = GlobalConstants.Team.Email;
            var fromName = GlobalConstants.Team.Name;

            var toEmail = model.Email;
            var subject = model.MessageSubject;
            var content = model.MessageContent;

            await this.emailSender.SendEmailAsync(fromEmail, fromName, toEmail, subject, content);

            if (model.Id != null)
            {
                var currentMessage = this.messageRepository.All().FirstOrDefault(x => x.Id == model.Id);

                if (currentMessage.HasBeenRead != true)
                {
                    currentMessage.HasBeenRead = true;

                    this.messageRepository.Update(currentMessage);
                    await this.messageRepository.SaveChangesAsync();
                }
            }
        }
    }
}
