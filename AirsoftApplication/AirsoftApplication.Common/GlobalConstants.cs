namespace AirsoftApplication.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "AirsoftApplication";

        public const string EventsCacheKey = nameof(EventsCacheKey);
        public const string FieldCachKey = nameof(FieldCachKey);

        public const string AdministrationCacheKey = nameof(AdministrationCacheKey);

        public const string UsersCacheKey = nameof(UsersCacheKey);
        public const string MessageCachKey = nameof(MessageCachKey);

        public const int ManufactureMinLenght = 3;
        public const int ManufactureMaxLenght = 100;

        public const int NameMinLenght = 5;
        public const int NameMaxLenght = 50;
        public const int ContentTextMinLenght = 10;
        public const int ContentTextMaxLenght = 300;

        public const int MessageContentMinLenght = 50;
        public const int MessageContentMaxLenght = 500;

        public class ApplicationRole
        {
            public const string AdministratorRoleName = "Administrator";
            public const string SoldierRoleName = "Soldier";
            public const string CaptainRoleName = "Captain";
        }

        public class DateTimeFormat
        {
            public const string DateFormat = "dd.MM.yyyy";
            public const string TimeFormat = "HH.mm";
        }

        public class Team
        {
            public const string Email = "graoforce@abv.bg";
            public const string Name = "Graoforce Team";
        }

        public class Files
        {
            public const int MaxSize = 5;
        }
    }
}
