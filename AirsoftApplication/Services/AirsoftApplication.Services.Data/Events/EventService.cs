namespace AirsoftApplication.Services.Data.Events
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Web.ViewModels.Administration.Events;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Battlefield> fieldRepository;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IImageService imageService;

        public EventService(
            IDeletableEntityRepository<Battlefield> fieldRepository,
            IDeletableEntityRepository<Event> eventRepository,
            IImageService imageService)
        {
            this.fieldRepository = fieldRepository;
            this.eventRepository = eventRepository;
            this.imageService = imageService;
        }

        public IEnumerable<FieldViewModel> GetTeamFields()
        {
            var teamFields = this.fieldRepository.All()
                  .Select(x => new FieldViewModel
                  {
                      FieldId = x.Id,
                      Name = x.Name,
                      Description = x.Description,
                      CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy"),
                      Location = x.Location,
                  }).ToList();

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
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            return gameEvent;
        }

        public IEnumerable<EventViewModel> AllEvents()
        {
            var events = this.eventRepository.All().Select(x => new EventViewModel
            {
                Id = x.Id,
                Images = this.imageService.GetAllImages(x.Id),
                Date = x.Date.ToString("dd.MM.yyyy"),
                Time = x.Time.ToString("HH.mm"),
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

            return events;
        }

        public async Task AddImagesAsync(InputEventImagesViewModel input)
        {
            await this.imageService.UploadFileAsync(input.EventId, input.Images);
        }

        public IEnumerable<ImageViewModel> EventImages(string eventId)
        {
            var images = this.AllEvents().FirstOrDefault(x => x.Id == eventId).Images;
            return images;
        }
    }
}
