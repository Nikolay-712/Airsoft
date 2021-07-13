namespace AirsoftApplication.Data.Models.Contacts
{
    using System;

    using AirsoftApplication.Data.Common.Models;

    public class Message : BaseDeletableModel<string>
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public bool HasBeenRead { get; set; }
    }
}
