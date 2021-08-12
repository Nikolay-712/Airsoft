namespace AirsoftApplication.Services.Data.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Services.Data.Comments;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Services.Data.Votes;
    using AirsoftApplication.Web.ViewModels.Administration.Events;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;
    using Microsoft.Extensions.Caching.Memory;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Battlefield> fieldRepository;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IImageService imageService;
        private readonly ICommentService commentService;
        private readonly IVoteService voteService;
        private readonly IMemoryCache memoryCache;

        public EventService(
            IDeletableEntityRepository<Battlefield> fieldRepository,
            IDeletableEntityRepository<Event> eventRepository,
            IImageService imageService,
            ICommentService commentService,
            IVoteService voteService,
            IMemoryCache memoryCache)
        {
            this.fieldRepository = fieldRepository;
            this.eventRepository = eventRepository;
            this.imageService = imageService;
            this.commentService = commentService;
            this.voteService = voteService;
            this.memoryCache = memoryCache;
        }

        public IEnumerable<FieldViewModel> GetTeamFields()
        {
            var teamFields = this.memoryCache.Get<IEnumerable<FieldViewModel>>(GlobalConstants.FieldCachKey);

            if (teamFields == null)
            {
                teamFields = this.fieldRepository.All()
                .Select(x => new FieldViewModel
                {
                    FieldId = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                    Location = x.Location,
                }).ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                this.memoryCache.Set(GlobalConstants.FieldCachKey, teamFields, cacheOptions);
            }

            return teamFields;
        }

        public async Task CreateBattlefieldAsync(InputFieldViewModel input)
        {
            var battlefield = new Battlefield
            {
                Name = input.Name,
                Description = input.Description,
                Location = input.LocationUrl,
            };

            await this.fieldRepository.AddAsync(battlefield);
            await this.fieldRepository.SaveChangesAsync();

            await this.imageService.UploadFileAsync(battlefield.Id, input.Images);
        }

        public async Task CreateEventAsync(InputEventViewModel input)
        {
            var gameEvent = new Event
            {
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                Time = input.Time,
                FieldId = input.FieldId,
            };

            await this.eventRepository.AddAsync(gameEvent);
            await this.eventRepository.SaveChangesAsync();

            await this.imageService.UploadFileAsync(gameEvent.Id, input.Images);
        }

        public EventViewModel UpcomingEvent()
        {
            var gameEvent = this.AllEvents()
                .OrderBy(x => x.Date)
                .FirstOrDefault(x => DateTime
                .ParseExact(x.Date, GlobalConstants.DateTimeFormat.DateFormat, CultureInfo.InvariantCulture) > DateTime.UtcNow);

            return gameEvent;
        }

        public IEnumerable<EventViewModel> AllEvents()
        {
            var events = this.memoryCache.Get<IEnumerable<EventViewModel>>(GlobalConstants.EventsCacheKey);

            if (events == null)
            {
                events = this.eventRepository.All().Select(x => new EventViewModel
                {
                    Id = x.Id,
                    Images = this.imageService.GetAllImages(x.Id),
                    Date = x.Date.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                    Time = x.Time.ToString(GlobalConstants.DateTimeFormat.TimeFormat),
                    Name = x.Name,
                    Description = x.Description,
                    Battlefield = new FieldViewModel
                    {
                        Name = x.Field.Name,
                        Description = x.Field.Description,
                        Location = x.Field.Location,
                        Images = this.imageService.GetAllImages(x.FieldId),
                    },
                }).ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                       .SetAbsoluteExpiration(TimeSpan.FromDays(5));

                this.memoryCache.Set(GlobalConstants.EventsCacheKey, events, cacheOptions);
            }

            return events;
        }

        public EventDeteilsViewModel EventDetails(string eventId)
        {
            var gameEvent = this.eventRepository.All()
                .Where(x => x.Id == eventId)
                .Select(x => new EventDeteilsViewModel
                {
                    Id = x.Id,
                    Images = this.imageService.GetAllImages(x.Id),
                    Date = x.Date.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                    Name = x.Name,
                    Description = x.Description,
                    Comments = this.commentService.AllCommentsByEvent(x.Id),
                    Vote = this.voteService.GetVotes(x.Id),
                }).FirstOrDefault();

            return gameEvent;
        }

        public async Task AddImagesAsync(InputEventImagesViewModel input)
        {
            await this.imageService.UploadFileAsync(input.EventId, input.Images);
        }

        public IEnumerable<ImageViewModel> EventImages(string eventId)
        {
            var gameEvent = this.AllEvents().Where(x => x.Id == eventId).FirstOrDefault();
            if (gameEvent == null)
            {
                return null;
            }

            var images = gameEvent.Images;

            return images;
        }
    }
}
