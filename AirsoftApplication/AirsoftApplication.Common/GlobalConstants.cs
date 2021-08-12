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
            public const string Phone = "+359 888800111";
            public const string GoogleLocation = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d624.7952277044214!2d22.966514229205224!3d42.54866088669482!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aab7876e5480d1%3A0x370af8e15d58be0d!2sAirsoft%20team%20Graoforce!5e1!3m2!1sbg!2sbg!4v1626872026098!5m2!1sbg!2sbg";
        }

        public class Files
        {
            public const int MaxSize = 5;
        }
    }
}
